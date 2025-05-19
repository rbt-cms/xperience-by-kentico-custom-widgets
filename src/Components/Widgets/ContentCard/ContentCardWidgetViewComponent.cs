using CMS;
using CMS.ContentEngine;
using CMS.Core;
using CMS.MediaLibrary;

using Kentico.Content.Web.Mvc.Routing;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Custom.Widgets.Components.Widgets.ContentCard;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Linq;
using System.Threading.Tasks;

[assembly:
    RegisterWidget(
        identifier: ContentCardWidgetViewComponent.IDENTIFIER,
        viewComponentType: typeof(ContentCardWidgetViewComponent),
        name: "Content Card",
        propertiesType: typeof(ContentCardWidgetProperties),
        Description = "Display Text, Description, Image & CTA.",
        IconClass = "icon-box")]
namespace Kentico.Xperience.Custom.Widgets.Components.Widgets.ContentCard
{
    public class ContentCardWidgetViewComponent : ViewComponent
    {
        public const string IDENTIFIER = "Kentico.Xperience.Custom.Widgets.ContentCardWidget";

        private readonly IContentQueryExecutor _executor;
        private readonly IPreferredLanguageRetriever _preferredLanguageRetriever;
        private readonly IEventLogService _eventLogService;

        public ContentCardWidgetViewComponent(IEventLogService eventLogService, IPreferredLanguageRetriever preferredLanguageRetriever, IContentQueryExecutor executor)
        {
            _eventLogService = eventLogService;
            _preferredLanguageRetriever = preferredLanguageRetriever;
            _executor = executor;
        }
        public async Task<IViewComponentResult> InvokeAsync(ContentCardWidgetProperties properties)
        {
            try
            {
                if (properties.IsVisible)
                {
                    var languageName = _preferredLanguageRetriever.Get();
                    string imageUrl = string.Empty;
                    if (properties.ContentCardImage != null && properties.ContentCardImage.Any())
                    {
                        var image = properties.ContentCardImage.First();
                        string where = $"FileGuid = '{image.Identifier}'";
                        var mediaFileInfo = MediaFileInfoProvider.GetMediaFiles(where).FirstOrDefault();

                        // Check if the MediaFileInfo is found
                        if (mediaFileInfo != null)
                        {
                            imageUrl = $"~/getmedia/{mediaFileInfo.FileGUID}/{mediaFileInfo.FileName}";
                        }
                    }

                    var cardModel = new ContentCardWidgetViewModel
                    {
                        IsVisible = properties.IsVisible,
                        ContentCardTitle = properties.ContentCardTitle,
                        ContentCardDescription = properties.ContentCardDescription,
                        ContentCardImage = imageUrl,
                        ContentCardImageCssClass = properties.ContentCardImageCssClass,
                        ContentCardCssClass = properties.ContentCardCssClass,
                        ContentCardImageHeight = properties.ContentCardImageHeight,
                        ContentCardImageWidth = properties.ContentCardImageWidth,
                        ContentCardImageAltText = properties.ContentCardImageAltText,
                        ContentCardRedirectUrl = properties.ContentCardRedirectUrl,
                        ContentAfter = properties.ContentAfter,
                        ContentBefore = properties.ContentBefore,

                    };

                    return View("~/Components/Widgets/ContentCard/_ContentCard.cshtml", cardModel);
                }
                else
                {
                    return await Task.FromResult<IViewComponentResult>(Content(string.Empty));
                }
            }
            catch (Exception ex)
            {
                _eventLogService.LogException(nameof(ContentCardWidgetViewComponent), nameof(InvokeAsync), ex);
                return Content(string.Empty);
            }
        }
    }
}
