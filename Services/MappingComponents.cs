using BluegrassAssessment.Models.Umbraco;
using BluegrassAssessment.Models.Umbraco.Components;
using Org.BouncyCastle.Security;
using System.Web;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace BluegrassAssessment.Services
{
    public class MappingComponents : IMappingComponents
    {
        public MappingComponents() { }

        public Pages GetPageModel(IPublishedContent pagePublishedContent)
        {
            var pageHeader = pagePublishedContent.Value<BlockGridModel>("pageHeader")?.Select(x => x.Content);
            var mainContent = pagePublishedContent.Value<BlockGridModel>("mainContent")?.Select(x => x.Content);
            var siteNode = pagePublishedContent.AncestorsOrSelf().FirstOrDefault(x => x.ContentType.Alias == "siteSettings");

            var pages = new Pages
            {
                PageHeader = pageHeader != null && pageHeader.Any() ? MapComponents(pageHeader) : null,
                MainContent = mainContent != null && mainContent.Any() ? MapComponents(mainContent) : null,
                HeaderSettings = siteNode != null ? MapHeaderSettings(siteNode) : null,
                FooterSettings = siteNode != null ? MapFooterSettings(siteNode) : null
            };

            return pages;
        }

        #region MapComponents
        private static IEnumerable<Component> MapComponents(IEnumerable<IPublishedElement> componentsIPublishedElements)
        {
            var components = new List<Component>();
            foreach (var component in componentsIPublishedElements)
            {
                switch (component.ContentType.Alias)
                {
                    case "heroComponent":
                        var heroComponent = MapHeroComponent(component);
                        components.Add(heroComponent);
                        break;
                    case "heroCtaComponent":
                        var heroCtaComponent = MapHeroCta(component);
                        components.Add(heroCtaComponent);
                        break;
                    case "rteComponent":
                        var rteComponent = MapRteComponent(component);
                        components.Add(rteComponent);
                        break;
                }
            }
            return components;
        }

        private static HeroComponent MapHeroComponent(IPublishedElement heroPublishedElement)
        {
            var heroComponent = new HeroComponent
            {
                Alias = heroPublishedElement.ContentType.Alias,
                Title = heroPublishedElement.Value<string>("titleHero"),
                Description = heroPublishedElement.Value<string>("descriptionHero"),
                Image = heroPublishedElement.Value<MediaWithCrops>("imageHero")
            };
            return heroComponent;
        }

        private static HeroCtaComponent MapHeroCta(IPublishedElement ctaPublishedElement)
        {
            var heroCtaComponent = new HeroCtaComponent
            {
                Alias = ctaPublishedElement.ContentType.Alias,
                Title = ctaPublishedElement.Value<string>("titleCta"),
                Description = ctaPublishedElement.Value<string>("descriptionCta"),
                Image = ctaPublishedElement.Value<MediaWithCrops>("imageCta"),
                Cta = ctaPublishedElement.Value<Link>("ctaText")
            };
            return heroCtaComponent;
        }

        private static RteComponent MapRteComponent(IPublishedElement rtePublishedElement)
        {
            var rteComponent = new RteComponent
            {
                Alias = rtePublishedElement.ContentType.Alias,
                Content = rtePublishedElement.Value<IHtmlString>("rte")
            };
            return rteComponent;
        }

        private static IEnumerable<SocialMediaComponent> MapSocialMediaLinks(IEnumerable<IPublishedElement> socialMediaLinksPublishedElements)
        {
            var socialMediaLinks = new List<SocialMediaComponent>();

            foreach (var socialMediaLink in socialMediaLinksPublishedElements)
            {
                var socialMediaLinkModel = new SocialMediaComponent
                {
                    Alias = socialMediaLink.ContentType.Alias,
                    Icon = socialMediaLink.Value<string>("socialMediaIcon"),
                    Link = socialMediaLink.Value<Link>("socialMediaLink")
                };
                socialMediaLinks.Add(socialMediaLinkModel);
            }

            return socialMediaLinks;
        }

        #endregion

        #region MapSiteSettings

        private static IEnumerable<HeaderMenu> MapHeaderSettings(IPublishedContent siteSettings)
        {
            var headerMenuContent = siteSettings.Value<BlockListModel>("headerMenu")?.Select(x => x.Content);

            var headerMenuList = new List<HeaderMenu>();
            if (headerMenuContent != null && headerMenuContent.Any())
            {
                foreach (var menu in headerMenuContent)
                {
                    var headerMenu = new HeaderMenu
                    {
                        HeaderLink = menu.Value<Link>("headerLink"),
                        HeaderSubMenu = menu.Value<IEnumerable<Link>>("headerSubMenu")
                    };
                    headerMenuList.Add(headerMenu);
                }
            }
            return headerMenuList;
        }

        private static FooterSettings MapFooterSettings(IPublishedContent siteSettings)
        {
            var socialMediaPublishedElementList = siteSettings.Value<BlockListModel>("footerSocialMediaLinks")?.Select(x => x.Content);

            var footerSettings = new FooterSettings
            {
                FooterLinks = siteSettings.Value<IEnumerable<Link>>("footerLinks"),
                SocialMediaLinks = socialMediaPublishedElementList != null && socialMediaPublishedElementList.Any() ? MapSocialMediaLinks(socialMediaPublishedElementList) : null
            };
            return footerSettings;
        }
        #endregion
    }
}
