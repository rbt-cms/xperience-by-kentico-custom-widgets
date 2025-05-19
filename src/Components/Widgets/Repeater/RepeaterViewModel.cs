using Kentico.Xperience.Admin.Base.UIPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Kentico.Xperience.Custom.Widgets.Repeater
{
    public class RepeaterViewModel
    {
        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Page Types purpose
        /// </summary>
        public List<SelectListItem> AvailablePageTypes { get; set; }

        /// <summary>
        /// Page type class name
        /// </summary>
        public string PageTypeClassName { get; set; }

        /// <summary>
        /// Contains all data related to a particular page type, with dynamic fields.
        /// </summary>
        public List<Dictionary<string, object>> PageTypeData { get; set; }

        /// <summary>
        /// Specifies if the widget is visible.
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Name of the view to render.
        /// </summary>
        public string ViewName { get; set; }

        /// <summary>
        /// Filtering conditions.
        /// </summary>
        public string Where { get; set; }

        /// <summary>
        /// HTML content to render before the repeater.
        /// </summary>
        public string HtmlBefore { get; set; }

        /// <summary>
        /// HTML content to render after the repeater.
        /// </summary>
        public string HtmlAfter { get; set; }
    }
}
