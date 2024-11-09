using BluegrassAssessment.Models.Umbraco.Components;
using Umbraco.Cms.Core.Models;

namespace BluegrassAssessment.Models.Umbraco
{
    public class FooterSettings
    {
        public IEnumerable<Link> FooterLinks { get; set; }
        public IEnumerable<SocialMediaComponent> SocialMediaLinks { get; set; }
    }
}
