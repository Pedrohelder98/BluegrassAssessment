using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Umbraco.Cms.Core.Models;

namespace BluegrassAssessment.Models.Umbraco.Components
{
    public class HeroComponent : Component
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public MediaWithCrops Image { get; set; }
    }
}
