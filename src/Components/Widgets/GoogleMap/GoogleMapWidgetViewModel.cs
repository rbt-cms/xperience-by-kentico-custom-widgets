namespace Kentico.Xperience.Custom.Widgets.GoogleMap
{
    /// <summary>
    /// View model for Googel Map widget.
    /// </summary>
    public class GoogleMapWidgetViewModel
    {
        /// <summary>
        /// IsVisible
        /// </summary>
        public bool IsVisible { get; set; }
        /// <summary>
        /// App Key
        /// </summary>
        public string ApiKey { get; set; }
        /// <summary>
        /// Latitude
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        /// Longitude
        /// </summary>
        public string Longitude { get; set; }       

    }
}
