using BluegrassAssessment.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace BluegrassAssessment.Controllers
{
    public class GeneralContentPageController : RenderController
    {
        private readonly IMappingComponents _mappingComponents;
        public GeneralContentPageController(
            ILogger<RenderController> logger,
            ICompositeViewEngine compositeViewEngine,
            IUmbracoContextAccessor umbracoContextAccessor,
            IMappingComponents mappingComponents)
            : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _mappingComponents = mappingComponents;
        }

        public override IActionResult Index()
        {
            var model = _mappingComponents.GetPageModel(CurrentPage);

            return CurrentTemplate(model);
        }
    }
}
