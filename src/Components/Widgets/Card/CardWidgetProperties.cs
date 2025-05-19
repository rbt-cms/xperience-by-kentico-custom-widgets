using CMS.MediaLibrary;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Websites.FormAnnotations;

using System.Collections.Generic;

namespace Kentico.Xperience.Custom.Widgets.Card
{
    public class CardWidgetProperties :IWidgetProperties
    {

        /// <summary>
        /// Declaring the widget will visible or not
        /// </summary>
        [CheckBoxComponent(Order = 0, Label = "IsVisible", Tooltip = "Select IsVisible option")]      
        public bool IsVisible { get; set; } =true;

        /// <summary>
        /// Declaring to enter the  Title
        /// </summary>
        [TextInputComponent(Order = 1, Label = "Card title", Tooltip = "Enter the Card title")]
        [RequiredValidationRule(ErrorMessage = "Required", FieldName = nameof(CardTitle))]
        public string CardTitle { get; set; }
         
        /// <summary>
        /// Declaring to enter Description
        /// </summary>
        [TextAreaComponent(Order = 2, Label = "Card description", Tooltip = "Enter the Card description")]
        [RequiredValidationRule(ErrorMessage = "Required", FieldName = nameof(CardDescription))]
        public string CardDescription { get; set; }

        /// <summary>
        /// Card CSS Class
        /// </summary>
        [TextInputComponent(Order = 3, Label = "Card CSS Class", Tooltip = "Enter the Card CSS Class")]
        public string CardCssClass { get; set; }

        /// <summary>
        /// Image to be displayed.
        /// Using the AssetSelector component for Page Builder.
        /// </summary>
        [AssetSelectorComponent(Order = 4, Label = "Card image", AllowedExtensions = "gif;png;jpg;jpeg;webp", Tooltip = "Select the Card image",MaximumAssets =1)]
        [RequiredValidationRule(ErrorMessage = "Required", FieldName = nameof(CardImage))]
        public IEnumerable<AssetRelatedItem> CardImage { get; set; } = new List<AssetRelatedItem>();

        /// <summary>
        /// Image Css Class
        /// </summary>
        [TextInputComponent(Order = 5, Label = "Image CSS Class", Tooltip = "Enter the image css")]
        public string CardImageCssClass { get; set; }
        /// <summary>
        /// Declaring to enter the Image Alt Text.
        /// </summary>
        [TextAreaComponent(Order = 6, Label = "Image Alt Text", Tooltip = "Enter the Image Alt Text")]
        [RequiredValidationRule(ErrorMessage = "Required", FieldName = nameof(CardImageAltText))]
        public string CardImageAltText { get; set; }

        /// <summary>
        /// Enter the Height
        /// </summary>
        [TextInputComponent(Order = 7, Label = "Image height (px)", Tooltip = "Enter the Image height")]
        public string CardImageHeight { get; set; }

        /// <summary>
        /// Enter the Width
        /// </summary>
        [TextInputComponent(Order = 8, Label = "Image Width (px)", Tooltip = "Enter the Image width")]
        public string CardImageWidth { get; set; }
        /// <summary>
        /// Declaring to enter the RedirectUrl.
        /// </summary>
        [UrlSelectorComponent(Order = 9, Label = "Redirect URL", Tooltip = "Enter the Redirect URL")]
        public string CardRedirectUrl { get; set; }
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
