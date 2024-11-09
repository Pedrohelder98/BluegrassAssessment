using Umbraco.Cms.Core.Models;

namespace BluegrassAssessment.Models.Umbraco
{
    public class HeaderMenu
    {
        public Link HeaderLink { get; set; }
        public IEnumerable<Link> HeaderSubMenu { get; set; }
    }
}
