using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Websites.FormAnnotations;

namespace RBT.Kentico.Xperience.Custom.Widgets.LinkButton
{
    public class LinkButtonWidgetProperties : IWidgetProperties
    {
        [TextInputComponent(Label = "Button text", Order = 1)]
        [RequiredValidationRule(ErrorMessage ="Required")]
        public string LinkButtonText { get; set; }
        [TextInputComponent(Label = "Button css class", Order = 2)]
        public string LinkButtonColor { get; set; }
        [TextInputComponent(Label = "Text css class", Order = 3)]
        public string LinkButtonTextColor { get; set; }       

        [UrlSelectorComponent(Label = "Button URL", Order = 4)]
        public string LinkButtonPageURL { get; set; }

        [DropDownComponent(Label = "Button target", Order = 5,Tooltip = "Specifies where to open the linked document", Options = "_blank;Blank\r\n_self;Self\r\n", OptionsValueSeparator = ";")]
        public string LinkButtonTarget { get; set; }
        [TextAreaComponent(Label ="Conent before",Order =6,Tooltip = "HTML content placed before the widget content. Can be used to display a header or add some encapsualting code such as <div>")]
        public string ContentBefore { get; set; }
        [TextAreaComponent(Label = "Conent after", Order = 7, Tooltip = "HTML content placed after the widget content. Can be used to display a header or add some encapsualting code such as <div>")]
        public string ContentAfter { get; set; }

    }
}
