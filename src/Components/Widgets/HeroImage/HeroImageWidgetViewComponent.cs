using CMS;
using CMS.ContentEngine;
using CMS.Core;
using CMS.MediaLibrary;
using Kentico.Content.Web.Mvc.Routing;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using RBT.Kentico.Xperience.Custom.Widgets.HeroImage;
using System;
using System.Linq;
using System.Threading.Tasks;
[assembly:
    RegisterWidget(
        identifier: HeroImageViewComponent.IDENTIFIER,
        viewComponentType: typeof(HeroImageViewComponent),
        name: "Hero Image Widget",
        propertiesType: typeof(HeroImageWidgetProperties),
        Description = "Hero Image Widget",
        IconClass = "icon-box")]
namespace RBT.Kentico.Xperience.Custom.Widgets.HeroImage
{
    public class HeroImageViewComponent
    : ViewComponent
    {
        public const string IDENTIFIER = "Kentico.Xperience.Custom.Widgets.HeroImage";

        private readonly IContentQueryExecutor _executor;
       
        private readonly IEventLogService _eventLogService;

        public HeroImageViewComponent(IEventLogService eventLogService, IContentQueryExecutor executor)
        {
            _eventLogService = eventLogService;
            _executor = executor;
        }
        public async Task<IViewComponentResult> InvokeAsync(HeroImageWidgetProperties properties)
        {
            try
            {
                if (properties.IsVisible)
                {
                    string mobileImageUrl = string.Empty;
                    string desktopImageUrl = string.Empty;
                    if (properties.MobileImage != null && properties.MobileImage.Any())
                    {
                        var mobileImage = properties.MobileImage.First();
                        string where = $"FileGuid = '{mobileImage.Identifier}'";
                        var mediaFileInfo = MediaFileInfoProvider.GetMediaFiles(where).FirstOrDefault();

                        // Check if the MediaFileInfo is found
                        if (mediaFileInfo != null)
                        {
                            mobileImageUrl = $"~/getmedia/{mediaFileInfo.FileGUID}/{mediaFileInfo.FileName}";
                        }
                    }
                    if (properties.DesktopImage != null && properties.DesktopImage.Any())
                    {
                        var desktopImage = properties.DesktopImage.First();
                        string where = $"FileGuid = '{desktopImage.Identifier}'";
                        var mediaFileInfo = MediaFileInfoProvider.GetMediaFiles(where).FirstOrDefault();

                        // Check if the MediaFileInfo is found
                        if (mediaFileInfo != null)
                        {
                            desktopImageUrl = $"~/getmedia/{mediaFileInfo.FileGUID}/{mediaFileInfo.FileName}";
                        }
                    }
                    var heroImageModel = new HeroImageWidgetViewModel
                    {
                        IsVisible = properties.IsVisible,
                        HeroImageCSSClass = properties.HeroImageCSSClass,
                        HeroImageTitleCSSClass = properties.HeroImageTitleCSSClass,
                        HeroImageTitle = properties.HeroImageTitle,
                        DesktopImage = desktopImageUrl,
                        MobileImage = mobileImageUrl,
                        ImageAltText = properties.ImageAltText,
                        EnableCTAButton = properties.EnableCTAButton,
                        CTAButtonText = properties.CTAButtonText,
                        CTAButtonUrl = properties.CTAButtonUrl,
                        CTAButtonCssClass = properties.CTAButtonCssClass,
                        CTAButtonTarget = properties.CTAButtonTarget,
                        ContentAfter = properties.ContentAfter,
                        ContentBefore = properties.ContentBefore,

                    };

                    return View("~/Components/Widgets/HeroImage/_HeroImageWidget.cshtml", heroImageModel);
                }
                else
                {
                    return await Task.FromResult<IViewComponentResult>(Content(string.Empty));
                }
            }
            catch (Exception ex)
            {
                _eventLogService.LogException(nameof(HeroImageViewComponent), nameof(InvokeAsync), ex);
                return Content(string.Empty);
            }
        }
    }
}