using CMS;
using CMS.Core;
using CMS.MediaLibrary;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Kentico.Xperience.Custom.Widgets.EditableImage;
using System;
using System.Linq;
using System.Threading.Tasks;

[assembly:
    RegisterWidget(
        identifier: EditableImageWidgetViewComponent.IDENTIFIER,
        viewComponentType: typeof(EditableImageWidgetViewComponent),
        name: "Editable image",
        propertiesType: typeof(EditableImageWidgetProperties),
        Description = "Display image.",
        IconClass = "icon-picture")]

namespace Kentico.Xperience.Custom.Widgets.EditableImage;

public class EditableImageWidgetViewComponent:ViewComponent
{
    public const string IDENTIFIER = "Kentico.Xperience.Custom.Widgets.EditableImage";

    private readonly IEventLogService _eventLogService;

    public EditableImageWidgetViewComponent(IEventLogService eventLogService)
    {
        _eventLogService = eventLogService;
    }
    public async Task<IViewComponentResult> InvokeAsync(EditableImageWidgetProperties properties)
    {
        try
        {
            if (properties.IsVisible)
            {
                string imageUrl = string.Empty;
                if (properties.Image != null && properties.Image.Any())
                {
                    var desktopImage = properties.Image.First();
                    string where = $"FileGuid = '{desktopImage.Identifier}'";
                    var mediaFileInfo = MediaFileInfoProvider.GetMediaFiles(where).FirstOrDefault();

                    // Check if the MediaFileInfo is found
                    if (mediaFileInfo != null)
                    {
                       imageUrl = $"~/getmedia/{mediaFileInfo.FileGUID}/{mediaFileInfo.FileName}";
                    }
                }
                var editableImageModel = new EditableImageWidgetViewModel
                {
                    IsVisible = properties.IsVisible,
                    Image = imageUrl,
                    ImageCssClass = properties.ImageCssClass,
                    ImageAltText = properties.ImageAltText,
                    Width = properties.Width,
                    Height = properties.Height,
                    RedirectUrl = properties.RedirectUrl,
                    ContentAfter = properties.ContentAfter,
                    ContentBefore = properties.ContentBefore,
                };

                return View("~/Components/Widgets/EditableImage/_EditableImagewidget.cshtml", editableImageModel);
            }
            else
            {
                return await Task.FromResult<IViewComponentResult>(Content(string.Empty));
            }
        }
        catch (Exception ex)
        {
            _eventLogService.LogException(nameof(EditableImageWidgetViewComponent), nameof(InvokeAsync), ex);
            return Content(string.Empty);
        }
    }
}
