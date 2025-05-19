﻿using Kentico.Components.Web.Mvc.FormComponents;
using Kentico.Xperience.Custom.Models.Reusable.Repeater;
using Kentico.PageBuilder.Web.Mvc;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Kentico.Xperience.Custom.Models.FormComponents;
using Kentico.Forms.Web.Mvc;

namespace Kentico.Xperience.Custom.Widgets.Repeater
{
    public class RepeaterProperties : IWidgetProperties
    {
        #region ToolTips Constants

        /// <summary>
        /// visibleToolTip
        /// </summary>
        public const string visibleToolTip = "Indicates if the widget should be displayed.";

        /// <summary>
        /// pathToolTip
        /// </summary>
        public const string pathToolTip = "Specifies the path of the selected pages. If you leave the path empty, the widget either loads all child pages or selects the current page(depending on the page type and configuration of the widget other properties).";

        /// <summary>
        /// maxitemsdisplayedToolTip
        /// </summary>
        public const string maxitemsdisplayedToolTip = "Specifies the maximum of pages to be loaded. At least as many pages as in the 'visible' value of the 'initialization script' property need to be specified. If empty, all possible pages will be selected.";

        /// <summary>
        /// orderByToolTip
        /// </summary>
        public const string orderByToolTip = "Sets the value of the ORDER BY clause in the SELECT statement used to retrieve the content. You can specify only the columns common to all of the selected page types.";

        /// <summary>
        /// viewPathToolTip
        /// </summary>
        public const string viewPathToolTip = "Configure the view with the corresponding page type-related fields and with the proper design after assigning the view path to this field(View Path). View path is being considered from 'Views/Shared/' path, just input the remaining path of a partial view without the extension. E.g.: Articles/_ArticleViewList";
     

        #endregion ToolTips Constants

        #region Widget Properties

        /// <summary>
        /// Visible for the component on site
        /// </summary>
        [EditingComponent(CheckBoxComponent.IDENTIFIER, Label = "Visible", Order = 0, Tooltip = visibleToolTip)]
        public bool IsVisible { get; set; } = true;      

        /// <summary>
        /// Select Page type classname
        /// </summary>

        [EditingComponent(RepeaterPageTypeSelector.IDENTIFIER, Order = 1, Label = "Page Type Class Name*")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select Class Name.")]
        public string PageTypeClassName { get; set; }


        /// <summary>
        /// Select the page types from the path
        /// </summary>
        [EditingComponent(PathSelector.IDENTIFIER, Order = 2, Label = "Page Path*", Tooltip = pathToolTip)]
        [EditingComponentProperty(nameof(PathSelectorProperties.RootPath), "/")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select the path")]
        public IList<PathSelectorItem> Path { get; set; }

        /// <summary>
        /// Select the view name
        /// </summary>
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "View Name*", Order = 3, Tooltip = viewPathToolTip)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please specify the view name")]
        public string ViewName { get; set; }

        /// <summary>
        /// TopN
        /// </summary>
        [EditingComponent(IntInputComponent.IDENTIFIER, Label = "Max Items Displayed", Order = 4, Tooltip = maxitemsdisplayedToolTip)]
        [Range(1, 100, ErrorMessage = "Please enter valid number")]
        public int MaxItemsDisplayed { get; set; } = 10;

        /// <summary>
        /// OrderBy
        /// </summary>
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Order by", Order = 5, Tooltip = orderByToolTip)]
        public string OrderBy { get; set; }

        /// <summary>
        /// OrderDirection
        /// </summary>
        [EditingComponent(DropDownComponent.IDENTIFIER, Label = "OrderBy Direction", Order = 6)]
        [EditingComponentProperty(nameof(DropDownProperties.DataSource), "Ascending;Ascending\r\nDescending;Descending")]
        public string OrderDirection { get; set; } 

        /// <summary>
        /// ContentBefore
        /// </summary>
        [EditingComponent(TextAreaComponent.IDENTIFIER, Label = "Content Before", Order = 7)]
        public string ContentBefore { get; set; }

        /// <summary>
        /// ContentAfter
        /// </summary>
        [EditingComponent(TextAreaComponent.IDENTIFIER, Label = "Content After", Order = 8)]
        public string ContentAfter { get; set; }

        #endregion Widget Properties
    }
}