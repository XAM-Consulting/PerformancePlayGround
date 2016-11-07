using System;
using FormsPerformancePlayground.iOS;
using Xamarin.Forms;

[assembly: Xamarin.Forms.ExportRenderer(typeof(ContentPage), typeof(InstrumentContentPageRenderer))]

namespace FormsPerformancePlayground.iOS
{
    public class InstrumentContentPageRenderer : Xamarin.Forms.Platform.iOS.PageRenderer
    {
        public InstrumentContentPageRenderer()
        {
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            Performance.Stop("PageLoaded", "PageLoaded", "PageLoaded");
            Performance.DumpStats();
        }
    }
}


