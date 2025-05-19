using CMS.MediaLibrary;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Websites.FormAnnotations;

using System.Collections.Generic;

namespace Kentico.Xperience.Custom.Widgets.Components.Widgets.ContentCard
{
    public class ContentCardWidgetProperties : IWidgetProperties
    {

        /// <summary>
        /// Declaring the widget will visible or not
        /// </summary>
        [CheckBoxComponent(Order = 0, Label = "IsVisible", Tooltip = "Select IsVisible option")]
        public bool IsVisible { get; set; } = true;

        /// <summary>
        /// Declaring to enter the  Title
        /// </summary>
        [TextInputComponent(Order = 1, Label = "Title", Tooltip = "Enter the content card title")]
        [RequiredValidationRule(ErrorMessage = "Required", FieldName = nameof(ContentCardTitle))]
        public string ContentCardTitle { get; set; }

        /// <summary>
        /// Declaring to enter Description
        /// </summary>
        [TextAreaComponent(Order = 2, Label = "Description", Tooltip = "Enter the content card description")]
        [RequiredValidationRule(ErrorMessage = "Required", FieldName = nameof(ContentCardDescription))]
        public string ContentCardDescription { get; set; }

        /// <summary>
        /// Card CSS Class
        /// </summary>
        [TextInputComponent(Order = 3, Label = "CSS Class", Tooltip = "Enter the content card CSS class")]
        public string ContentCardCssClass { get; set; }

        /// <summary>
        /// Image to be displayed.
        /// Using the AssetSelector component for Page Builder.
        /// </summary>
        [AssetSelectorComponent(Order = 4, Label = "Image", AllowedExtensions = "gif;png;jpg;jpeg;webp", Tooltip = "Select the content card image", MaximumAssets = 1)]
        [RequiredValidationRule(ErrorMessage = "Required", FieldName = nameof(ContentCardImage))]
        public IEnumerable<AssetRelatedItem> ContentCardImage { get; set; } = new List<AssetRelatedItem>();

        /// <summary>
        /// Image Css Class
        /// </summary>
        [TextInputComponent(Order = 5, Label = "CSS Class for Image ", Tooltip = "Enter the css for image")]
        public string ContentCardImageCssClass { get; set; }
        /// <summary>
        /// Declaring to enter the Image Alt Text.
        /// </summary>
        [TextAreaComponent(Order = 6, Label = "Alt Text for Image ", Tooltip = "Enter the Alt text for image")]
        [RequiredValidationRule(ErrorMessage = "Required", FieldName = nameof(ContentCardImageAltText))]
        public string ContentCardImageAltText { get; set; }

        /// <summary>
        /// Enter the Height
        /// </summary>
        [TextInputComponent(Order = 7, Label = "Image height (px)", Tooltip = "Enter the image height")]
        public string ContentCardImageHeight { get; set; }

        /// <summary>
        /// Enter the Width
        /// </summary>
        [TextInputComponent(Order = 8, Label = "Image Width (px)", Tooltip = "Enter the image width")]
        public string ContentCardImageWidth { get; set; }
        /// <summary>
        /// Declaring to enter the RedirectUrl.
        /// </summary>
        [UrlSelectorComponent(Order = 9, Label = "Target URL", Tooltip = "Enter the target URL")]
        public string ContentCardRedirectUrl { get; set; }
        /// <summary>
        /// Declaring to enter the Content Before
        /// </summary>
        [TextAreaComponent(Order = 10, Label = "Content Before", Tooltip = "HTML content placed before the widget content. Can be used to display a header or add some encapsualting code such as <div>")]
        public string ContentBefore { get; set; }
        /// <summary>
        /// Declaring to enter the Button Text
        /// </summary>
        [TextAreaComponent(Order = 11, Label = "Content After", Tooltip = "HTML content placed after the widget content. Can be used to display a header or add some encapsualting code such as <div>")]
        public string ContentAfter { get; set; }
    }
}