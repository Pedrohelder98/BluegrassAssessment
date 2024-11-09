using BluegrassAssessment.Services;
using Umbraco.Cms.Core.Composing;

namespace BluegrassAssessment.Composers
{
    public class UmbracoComposer : IComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Services.AddScoped<IMappingComponents, MappingComponents>();
        }
    }
}
