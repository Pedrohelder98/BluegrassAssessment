using BluegrassAssessment.Models.Umbraco.Components;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace BluegrassAssessment.Models.Umbraco
{
    public class Pages
    {
        public IEnumerable<Component> PageHeader { get; set; }
        public IEnumerable<Component> MainContent { get; set; }
        public IEnumerable<HeaderMenu> HeaderSettings { get; set; }
        public FooterSettings FooterSettings { get; set; }
    }
}
