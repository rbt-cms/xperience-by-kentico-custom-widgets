using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace Kentico.Xperience.Custom.Widgets.GoogleMap
{
    /// <summary>
    /// Googlemap widget properties.
    /// </summary>
    public class GoogleMapWidgetProperties : IWidgetProperties
    {
        /// <summary>
        /// Declaring the widget will visible or not
        /// </summary>
        [EditingComponent(CheckBoxComponent.IDENTIFIER, Order = 0, Label = "IsVisible", Tooltip = "Select IsVisible option")]
        public bool IsVisible { get; set; } = true;
        /// <summary>
        /// Declaring to enter Latitude
        /// </summary>
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Latitude", Order = 1)]
        public string Latitude { get; set; }
        /// <summary>
        /// Declaring to enter Longitude
        /// </summary>
        [EditingComponent(TextInputComponent.IDENTIFIER, Label = "Longitude", Order = 2)]
        public string Longitude { get; set; }
    }
}
