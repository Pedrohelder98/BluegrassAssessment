using BluegrassAssessment.Models.Umbraco;
using BluegrassAssessment.Models.Umbraco.Components;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace BluegrassAssessment.Services
{
    public interface IMappingComponents
    {
        public Pages GetPageModel(IPublishedContent pagePublishedContent);
    }
}
