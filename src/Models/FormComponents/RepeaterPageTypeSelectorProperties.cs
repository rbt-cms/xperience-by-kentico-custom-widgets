using CMS.DataEngine;
using Kentico.Forms.Web.Mvc;
namespace Kentico.Xperience.Custom.Models.FormComponents
{
    public class RepeaterPageTypeSelectorProperties : FormComponentProperties<string>
    {
        public RepeaterPageTypeSelectorProperties()
          : base(FieldDataType.Text)
        {
        }

        [DefaultValueEditingComponent("PageTypeSelectorProperties", DefaultValue = "")]
        public override string DefaultValue { get; set; }
    }
}