using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kentico.Xperience.Custom.Widgets.Components.Widgets.ContentCard
{
    public class ContentCardWidgetViewModel
    {
        /// <summary>
        /// Visible
        /// </summary>
        public bool IsVisible { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        public string ContentCardTitle { get; set; }

        /// <summary>
        /// CardDescription
        /// </summary>
        public string ContentCardDescription { get; set; }

        /// <summary>
        /// Card Image
        /// </summary>
        public string ContentCardImage { get; set; }

        /// <summary>
        /// CardImageAltText
        /// </summary>
        public string ContentCardImageAltText { get; set; }
        /// <summary>
        /// CardCssClass
        /// </summary>
        public string ContentCardCssClass { get; set; }

        /// <summary>
        /// CardImageCssClass
        /// </summary>
        public string ContentCardImageCssClass { get; set; }
        /// <summary>
        /// CardImageWidth
        /// </summary>
        public string ContentCardImageWidth { get; set; }
        /// <summary>
        /// CardImageHeight
        /// </summary>
        public string ContentCardImageHeight { get; set; }
       
        /// <summary>
        /// CardRedirectUrl
        /// </summary>
        public string ContentCardRedirectUrl { get; set; }
        /// <summary>
        /// ContentBefore
        /// </summary>
        public string ContentBefore { get; set; }
        /// <summary>
        /// ContentAfter
        /// </summary>
        public string ContentAfter { get; set; }
    }
}