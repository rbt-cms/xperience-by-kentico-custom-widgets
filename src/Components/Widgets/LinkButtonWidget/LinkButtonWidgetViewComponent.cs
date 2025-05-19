using CMS;
using CMS.Core;
using System;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using RBT.Kentico.Xperience.Custom.Widgets.LinkButton;
using System.Threading.Tasks;


[assembly:
    RegisterWidget(
        identifier: LinkButtonWidgetViewComponent.IDENTIFIER,
        viewComponentType: typeof(LinkButtonWidgetViewComponent),
        name: "Link button",
        propertiesType: typeof(LinkButtonWidgetProperties),
        Description = "Display Link button.",
        IconClass = "icon-chain")]

namespace RBT.Kentico.Xperience.Custom.Widgets.LinkButton
{
    public class LinkButtonWidgetViewComponent :ViewComponent
    {
        public const string IDENTIFIER = "Kentico.Xperience.Custom.Widgets.LinkButton";
        private readonly IEventLogService _eventLogService;
        public LinkButtonWidgetViewComponent(IEventLogService eventLogService) => _eventLogService = eventLogService;
        public async Task<IViewComponentResult> InvokeAsync(LinkButtonWidgetProperties properties)
        {
            try
            {
                return View("~/Components/Widgets/LinkButtonWidget/_LinkButtonWidget.cshtml", new LinkButtonWidgetViewModel
                {
                    LinkButtonText = properties.LinkButtonText,
                    LinkButtonTextColor = properties.LinkButtonTextColor,
                    LinkButtonColor = properties.LinkButtonColor,
                    LinkButtonPageURL = properties.LinkButtonPageURL,
                    LinkButtonTarget = properties.LinkButtonTarget,
                    ContentBefore=properties.ContentBefore,
                    ContentAfter=properties.ContentAfter
                });
            }
            catch (Exception ex)
            {
                _eventLogService.LogException(nameof(LinkButtonWidgetViewComponent), nameof(InvokeAsync), ex);
                return Content(string.Empty);
            }
            
        }

    }
}
