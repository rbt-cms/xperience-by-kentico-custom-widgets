using CMS;
using CMS.ContentEngine;
using CMS.Core;
using CMS.MediaLibrary;

using Kentico.Content.Web.Mvc.Routing;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Custom.Widgets.Card;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Linq;
using System.Threading.Tasks;

 
[assembly:
    RegisterWidget(
        identifier: CardWidgetViewComponent.IDENTIFIER,
        viewComponentType: typeof(CardWidgetViewComponent),
        name: "Card Widget",
        propertiesType: typeof(CardWidgetProperties),
        Description = "Card Widget.",
        IconClass = "icon-box")]
namespace Kentico.Xperience.Custom.Widgets.Card
{
    public class CardWidgetViewComponent :ViewComponent
    {
        public const string IDENTIFIER = "Kentico.Xperience.Custom.Widgets.CardWidget";

        private readonly IContentQueryExecutor _executor;
        private readonly IPreferredLanguageRetriever _preferredLanguageRetriever;
        private readonly IEventLogService _eventLogService;

        public CardWidgetViewComponent(IEventLogService eventLogService, IPreferredLanguageRetriever preferredLanguageRetriever, IContentQueryExecutor executor)
        {
            _eventLogService = eventLogService;
            _preferredLanguageRetriever = preferredLanguageRetriever;
            _executor = executor;
        }
        public async Task<IViewComponentResult> InvokeAsync(CardWidgetProperties properties)
        {
            try
            {
                if (properties.IsVisible)
                {
                    var languageName = _preferredLanguageRetriever.Get();
                    string imageUrl = string.Empty;
                    if (properties.CardImage != null && properties.CardImage.Any())
                    {
                        var image = properties.CardImage.First();
                        string where = $"FileGuid = '{image.Identifier}'";
                        var mediaFileInfo = MediaFileInfoProvider.GetMediaFiles(where).FirstOrDefault();

                        // Check if the MediaFileInfo is found
                        if (mediaFileInfo != null)
                        {
                            imageUrl = $"~/getmedia/{mediaFileInfo.FileGUID}/{mediaFileInfo.FileName}";
                        }
                    }
                  
                    var cardModel = new CardWidgetViewModel
                    {
                        IsVisible = properties.IsVisible,
                        CardTitle = properties.CardTitle,        
                        CardDescription = properties.CardDescription,
                        CardImage = imageUrl,
                        CardImageCssClass = properties.CardImageCssClass,
                        CardCssClass = properties.CardCssClass,
                        CardImageHeight = properties.CardImageHeight,
                        CardImageWidth = properties.CardImageWidth,
                        CardImageAltText = properties.CardImageAltText,
                        CardRedirectUrl = properties.CardRedirectUrl,
                        ContentAfter = properties.ContentAfter,
                        ContentBefore = properties.ContentBefore,

                    };

                    return View("~/Components/Widgets/Card/_Card.cshtml", cardModel);
                }
                else
                {
                    return await Task.FromResult<IViewComponentResult>(Content(string.Empty));
                }
            }
            catch (Exception ex)
            {
                _eventLogService.LogException(nameof(CardWidgetViewComponent), nameof(InvokeAsync), ex);
                return Content(string.Empty);
            }
        }
    }
}
