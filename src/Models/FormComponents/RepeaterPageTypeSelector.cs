using CMS.DataEngine;
using Kentico.Forms.Web.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Kentico.Xperience.Custom.Models.FormComponents;
using System;
using System.Collections.Generic;
using System.Data;

[assembly: RegisterFormComponent(RepeaterPageTypeSelector.IDENTIFIER, typeof(RepeaterPageTypeSelector), "Drop-down for Page Type Selector ", IconClass = "icon-menu")]

namespace Kentico.Xperience.Custom.Models.FormComponents
{
    public class RepeaterPageTypeSelector : FormComponent<RepeaterPageTypeSelectorProperties, string>
    {
        public const string IDENTIFIER = "PageTypeSelectorComponent";

        [BindableProperty]
        public string SelectedValue { get; set; }

        // Retrieves data to be displayed in the selector
        public IEnumerable<SelectListItem> GetIndexItems()
        {
            // Execute the query on CMS_Class table where ClassType is 'Content'
            var pageTypeList = new ObjectQuery("CMS.Class")
                .WhereEquals("ClassType", "Content")
                .Columns("ClassName", "ClassDisplayName")
                .Execute();

            // Loop through the result set and yield each item as a SelectListItem
            foreach (var item in pageTypeList.Tables[0].AsEnumerable().Cast<DataRow>())
            {
                yield return new SelectListItem
                {
                    Value = item["ClassName"].ToString(),
                    Text = item["ClassDisplayName"].ToString()
                };
            }
        }
        public override string GetValue()
        {
            return SelectedValue;
        }

        public override void SetValue(string value)
        {
            SelectedValue = value;
        }
    }
}