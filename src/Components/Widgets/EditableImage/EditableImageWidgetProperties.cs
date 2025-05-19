using CMS.MediaLibrary;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;
using System.Collections.Generic;

namespace Kentico.Xperience.Custom.Widgets.EditableImage;

public class EditableImageWidgetProperties : IWidgetProperties
{
    /// <summary>
    /// Declaring the widget will visible or not
    /// </summary>
    [CheckBoxComponent(Order = 0, Label = "IsVisible", Tooltip = "Select IsVisible option")]
    public bool IsVisible { get; set; }
    /// <summary>
    /// Image to be displayed.
    /// Using the AssetSelector component for Page Builder.
    /// </summary>
    [AssetSelectorComponent(Order = 1, Label = "Image", AllowedExtensions = "gif;png;jpg;jpeg;webp")]
    [RequiredValidationRule(ErrorMessage = "Please Select the Image", FieldName = nameof(Image))]
    public IEnumerable<AssetRelatedItem> Image { get; set; } = new List<AssetRelatedItem>();
    /// <summary>
    /// Declaring to enter the Image Alt Text.
    /// </summary>
    [TextInputComponent(Order = 2, Label = "Alt text for image", Tooltip = "Enter the alt text")]
    [RequiredValidationRule(ErrorMessage = "Please Enter the Image Alt Text", FieldName = nameof(ImageAltText))]
    public string ImageAltText { get; set; }
    /// <summary>
    /// Image Section Css
    /// </summary>
    [TextInputComponent(Order = 3, Label = "Image CSS Class", Tooltip = "Enter the image css")]
    public string ImageCssClass { get; set; }
    /// <summary>
    /// Enter the Width
    /// </summary>
    [TextInputComponent(Order = 4, Label = "Width (px)", Tooltip = "Enter desired Image width")]
    public string Width { get; set; }
    /// <summary>
    /// Enter the Height
    /// </summary>
    [TextInputComponent(Order = 5, Label = "Height (px)", Tooltip = "Enter desired Image height")]
    public string Height { get; set; }
    /// <summary>
    /// Declaring to enter the Redirection URL
    /// </summary>
    [TextInputComponent(Order = 6, Label = "Redirection URL", Tooltip = "Enter the Redirection URL")]
    public string RedirectUrl { get; set; }
    /// <summary>
    /// Declaring to enter the Content Before
    /// </summary>
    [TextAreaComponent(Order = 7, Label = "Content Before", Tooltip = "HTML content placed before the widget content. Can be used to display a header or add some encapsualting code such as <div>")]
    public string ContentBefore { get; set; }
    /// <summary>
    /// Declaring to enter the Button Text
    /// </summary>
    [TextAreaComponent(Order = 8, Label = "Content After", Tooltip = "HTML content placed after the widget content. Can be used to display a header or add some encapsualting code such as <div>")]
    public string ContentAfter { get; set; }
}
