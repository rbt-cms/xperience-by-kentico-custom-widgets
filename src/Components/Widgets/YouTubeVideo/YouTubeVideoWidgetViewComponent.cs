using CMS;
using Kentico.PageBuilder.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Kentico.Xperience.Custom.Widgets.YouTubeVideo;
using System.Text;
using System.Threading.Tasks;

[assembly:
    RegisterWidget(
        identifier: YouTubeVideoWidgetViewComponent.IDENTIFIER,
        viewComponentType: typeof(YouTubeVideoWidgetViewComponent),
        name: "YouTubeVideo",
        propertiesType: typeof(YouTubeVideoWidgetProperties),
        Description = "Display YouTube video",
        IconClass = "icon-brand-youtube")]
namespace Kentico.Xperience.Custom.Widgets.YouTubeVideo
{
    public class YouTubeVideoWidgetViewComponent : ViewComponent
    {
        public const string IDENTIFIER = "Kentico.Xperience.Custom.Widgets.YouTubeVideo";
        public async Task<IViewComponentResult> InvokeAsync(YouTubeVideoWidgetProperties properties)
        {
            return await Task.FromResult((IViewComponentResult)View("~/Components/Widgets/YouTubeVideo/_YouTubeVideoWidget.cshtml", new YouTubeVideoWidgetViewModel
            {
                IsVisible=properties.IsVisible,
                VideoTitile=properties.VideoTitle,
                VideoURL = properties.VideoURL,
                Width = properties.Width,
                Height = properties.Height,
                IsShowRelatedVideos = properties.IsShowRelatedVideos,
                IsFullScreen = properties.IsFullScreen,
                IsAutoPlay = properties.IsAutoPlay,
                ContentBefore = properties.ContentBefore,
                ContentAfter =properties.ContentAfter,                
                VideoParameters = GetYouTubeVideo(properties.IsShowRelatedVideos, properties.IsFullScreen, properties.IsAutoPlay)
            }));
        }
        private string GetYouTubeVideo(bool relVideos, bool fullScreen, bool autoPlay)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(autoPlay ? "&autoplay=1&mute=1" : string.Empty);
            stringBuilder.Append((!relVideos) ? "&rel=0" : "&rel=1");
            stringBuilder.Append("&enablejsapi=1&version=3");
            return stringBuilder.ToString();
        }
    }
}
