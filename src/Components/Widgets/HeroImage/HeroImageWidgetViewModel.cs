namespace RBT.Kentico.Xperience.Custom.Widgets.HeroImage
{
    public class HeroImageWidgetViewModel
    {
        public bool IsVisible { get; set; }
        public string? HeroImageCSSClass { get; set; }
        public string? HeroImageTitleCSSClass { get; set; }
        public string? HeroImageTitle { get; set; }
        public string? MobileImage { get; set; }
        public string? DesktopImage { get; set; }
        public string? ImageAltText { get; set; }
        public string? ImageCSSClass { get; set; }
        public bool EnableCTAButton { get; set; }
        public string? CTAButtonText { get; set; }
        public string? CTAButtonUrl { get; set; }
        public string? CTAButtonCssClass { get; set; }
        public string? CTAButtonTarget { get; set; }
        public string? ContentBefore { get; set; }
        public string? ContentAfter { get; set; }
    }
}
