using CMS.MediaLibrary;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Websites.FormAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace RBT.Kentico.Xperience.Custom.Widgets.HeroImage
{
    public class HeroImageWidgetProperties : IWidgetProperties
    {
        /// <summary>
        /// Declaring the widget will visible or not
        /// </summary>
        [CheckBoxComponent(Order = 0, Label = "IsVisible", Tooltip = "Select IsVisible option")]
        public bool IsVisible { get; set; }
        /// <summary>
        /// Hero Image section CSS
        /// </summary>
        [TextInputComponent(Order = 1, Label = "Hero image section css", Tooltip = "Enter the hero image section css.")]
        public string? HeroImageCSSClass { get; set; }
        /// <summary>
        /// Hero Image Title
        /// </summary>
        [TextAreaComponent(Order = 2, Label = "Hero image title", Tooltip = "Enter the hero image title.")]
        public string? HeroImageTitle { get; set; }
        /// <summary>
        /// Hero Title section CSS
        /// </summary>
        [TextInputComponent(Order = 3, Label = "Hero image title css", Tooltip = "Enter the hero image title css.")]
        public string? HeroImageTitleCSSClass { get; set; }
        /// <summary>
        /// Image to be displayed.
        /// Using the AssetSelector component for Page Builder.
        /// </summary>
        [AssetSelectorComponent(Order = 4, Label = "Image (Desktop)", AllowedExtensions = "gif;png;jpg;jpeg;webp")]
        public IEnumerable<AssetRelatedItem> DesktopImage { get; set; } = new List<AssetRelatedItem>();
        /// <summary>
        /// Image to be displayed.
        /// Using the AssetSelector component for Page Builder.
        /// </summary>
        [AssetSelectorComponent(Order = 5, Label = "Image (Mobile)", AllowedExtensions = "gif;png;jpg;jpeg;webp")]
          public IEnumerable<AssetRelatedItem> MobileImage { get; set; } = new List<AssetRelatedItem>();
        /// <summary>
        /// Declaring to enter the Image Alt Text.
        /// </summary>
        [TextInputComponent(Order = 6, Label = "Alt text for image", Tooltip = "Enter the alt text")]
        public string? ImageAltText { get; set; }        
        /// <summary>
        /// IsButton
        /// </summary>
        [CheckBoxComponent(Order = 7, Label = "Is enable CTA Button", Tooltip = "Enable the CTA Button")]
        public bool EnableCTAButton { get; set; }
        /// <summary>
        /// Declaring to enter the Button Text
        /// </summary>
        [TextInputComponent(Order = 8, Label = "CTA button text", Tooltip = "Enter the CTA button Text.")]
        [VisibleIfTrue(nameof(EnableCTAButton))]
        public string? CTAButtonText { get; set; }

        /// <summary>
        /// Declaring to enter the Button URL
        /// </summary>
        [UrlSelectorComponent(Label = "CTA button URL", Order = 9, Tooltip = "Enter the CTA Button URL.")]
        [VisibleIfTrue(nameof(EnableCTAButton))]
        public string? CTAButtonUrl { get; set; }
        /// <summary>
        /// Declaring to enter the Button URL
        /// </summary>
        [DropDownComponent(Order = 10, Label = "CTA button target", Options = "_self;Self\r\n_blank;Blank\r\n", OptionsValueSeparator = ";")]
        [VisibleIfTrue(nameof(EnableCTAButton))]
        public string? CTAButtonTarget { get; set; }

        /// <summary>
        /// Declaring to enter the Button Text
        /// </summary>
        [TextInputComponent(Order = 11, Label = "CTA button css class", Tooltip = "Enter the CTA button css class")]
        [VisibleIfTrue(nameof(EnableCTAButton))]
        public string? CTAButtonCssClass { get; set; }
        /// <summary>
        /// Declaring to enter the Content Before
        /// </summary>
        [TextAreaComponent(Order = 12, Label = "Content Before", Tooltip = "HTML content placed before the widget content. Can be used to display a header or add some encapsualting code such as <div>")]
        public string? ContentBefore { get; set; }
        /// <summary>
        /// Declaring to enter the Button Text
        /// </summary>
        [TextAreaComponent(Order = 13, Label = "Content After", Tooltip = "HTML content placed after the widget content. Can be used to display a header or add some encapsualting code such as <div>")]
        public string? ContentAfter { get; set; }

    }
}
