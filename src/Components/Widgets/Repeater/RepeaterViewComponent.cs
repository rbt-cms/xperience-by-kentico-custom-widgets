using CMS.Core;
using CMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Linq;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Custom.Widgets.Repeater;
using Kentico.Xperience.Custom.Models.Reusable.Repeater;
using Kentico.Content.Web.Mvc.Routing;
using CMS;


[assembly: 
    RegisterWidget(RepeaterViewComponent.IDENTIFIER, 
    typeof(RepeaterViewComponent), "Repeater", 
    typeof(RepeaterProperties),
    Description = "Display data in table.", 
    IconClass = "icon-box")]
namespace Kentico.Xperience.Custom.Widgets.Repeater
{
    public class RepeaterViewComponent : ViewComponent
    {
        public const string IDENTIFIER = "Kentico.Xperience.Custom.Widgets.Repeater";
        private readonly IRepeaterRepository _repeaterRepository;
        private readonly IEventLogService _eventLogService;
        private readonly IPreferredLanguageRetriever currentLanguageRetriever;

        public RepeaterViewComponent(IRepeaterRepository repeaterRepository, IEventLogService eventLogService, IPreferredLanguageRetriever currentLanguageRetriever)
        {
            _repeaterRepository = repeaterRepository ?? throw new ArgumentNullException(nameof(repeaterRepository));
            _eventLogService = eventLogService ?? throw new ArgumentNullException(nameof(eventLogService));
            this.currentLanguageRetriever = currentLanguageRetriever;
        }

        public async Task<IViewComponentResult> InvokeAsync(RepeaterProperties properties)
        {
            try
            {
                if (!string.IsNullOrEmpty(properties.PageTypeClassName))
                {
                    int topN = ValidationHelper.GetInteger(properties.MaxItemsDisplayed, 10);
                    string selectedPath = properties.Path?.FirstOrDefault()?.TreePath ?? "";
                    //Get current culture code
                    string cultureCode = currentLanguageRetriever.Get();

                    var pageTypeData = await _repeaterRepository.GetParticularPageTypeDataAsync(
                        properties.PageTypeClassName,
                        selectedPath,
                        topN,
                        properties.OrderBy,
                        cultureCode,
                        properties.OrderDirection);

                    var viewModel = new RepeaterViewModel
                    {
                        ViewName = properties.ViewName,
                        PageTypeClassName = properties.PageTypeClassName,
                        PageTypeData = pageTypeData,
                        Visible = properties.IsVisible,
                        HtmlAfter = properties.ContentAfter,
                        HtmlBefore = properties.ContentBefore
                    };

                    return View($"~/Components/Widgets/Repeater/{properties.ViewName}.cshtml", viewModel);
                }
            }
            catch (Exception ex)
            {
                _eventLogService.LogException(nameof(RepeaterViewComponent), nameof(InvokeAsync), ex);
            }

            return Content(string.Empty);
        }
    }
}
