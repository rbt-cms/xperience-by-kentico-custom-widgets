using CMS.Core;
using System;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Kentico.Xperience.Custom.Widgets.GoogleMap;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using CMS;

[assembly:
    RegisterWidget(
        identifier: GoogleMapWidgetViewComponent.IDENTIFIER,
        viewComponentType: typeof(GoogleMapWidgetViewComponent),
        name: "GoogleMap",
        propertiesType: typeof(GoogleMapWidgetProperties),
        Description = "Display google map based on Latitude and Longitude.",
        IconClass = "icon-map-marker")]
namespace Kentico.Xperience.Custom.Widgets.GoogleMap
{
    /// <summary>
    /// Controller for GoogleMap widget.
    /// </summary>
    public class GoogleMapWidgetViewComponent : ViewComponent
    {
        /// <summary>
        /// Widget identifier.
        /// </summary>
        public const string IDENTIFIER = "Kentico.Xperience.Custom.Widgets.GoogleMapWidget";
        private readonly IConfiguration _configuration;
        private readonly IEventLogService _eventLogService;
        public GoogleMapWidgetViewComponent(IConfiguration configuration, IEventLogService eventLogService)
        {
            _configuration = configuration;
            _eventLogService = eventLogService;
        }
        public async Task<IViewComponentResult> InvokeAsync(GoogleMapWidgetProperties properties)
        {
            try
            {
                var googleApiKey = _configuration["GoogleMapsApiKey"];

                return await Task.FromResult((IViewComponentResult)View("~/Components/Widgets/GoogleMap/_GoogleMap.cshtml", new GoogleMapWidgetViewModel
                {
                    IsVisible = properties.IsVisible,
                    Latitude = properties.Latitude,
                    Longitude = properties.Longitude,
                    ApiKey = googleApiKey
                }));
            }
            catch (Exception ex)
            {
                _eventLogService.LogException(nameof(GoogleMapWidgetViewComponent), nameof(InvokeAsync), ex);
                return await Task.FromResult<IViewComponentResult>(Content(string.Empty));
            }
        }
    }
}



