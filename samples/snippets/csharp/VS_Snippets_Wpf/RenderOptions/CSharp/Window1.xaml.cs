using System;
using System.Windows;
using System.Windows.Media;

namespace WindowsApplication1
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void OnClick(object sender, EventArgs e)
        {
            Stub01();
            Stub02();
            Stub03();
            Stub04();
            Stub05();
        }

        public void Stub01()
        {
            // <SnippetRenderOptionsSnippet1>
            // Get the bitmap scaling mode for the image.
            BitmapScalingMode bitmapScalingMode = RenderOptions.GetBitmapScalingMode(MyImage);
            // </SnippetRenderOptionsSnippet1>
        }


        public void Stub02()
        {
            BitmapScalingMode bitmapScalingMode = RenderOptions.GetBitmapScalingMode(MyImage);

            // <SnippetRenderOptionsSnippet2>
            // Set the bitmap scaling mode for the image to render faster.
            RenderOptions.SetBitmapScalingMode(MyImage, BitmapScalingMode.LowQuality);
            // </SnippetRenderOptionsSnippet2>

            bitmapScalingMode = RenderOptions.GetBitmapScalingMode(MyImage);
        }

        public void Stub03()
        {
            // <SnippetRenderOptionsSnippet3>
            DrawingBrush drawingBrush = new DrawingBrush();
                        
            // Set the caching hint option for the brush.
            RenderOptions.SetCachingHint(drawingBrush, CachingHint.Cache);

            // Set the minimum and maximum relative sizes for regenerating the tiled brush.
            // The tiled brush will be regenerated and re-cached when its size is
            // 0.5x or 2x of the current cached size.
            RenderOptions.SetCacheInvalidationThresholdMinimum(drawingBrush, 0.5);
            RenderOptions.SetCacheInvalidationThresholdMaximum(drawingBrush, 2.0);
            // </SnippetRenderOptionsSnippet3>
        }

        public void Stub04()
        {
            DrawingBrush drawingBrush = new DrawingBrush();
            RenderOptions.SetCacheInvalidationThresholdMinimum(drawingBrush, 0.5);
            RenderOptions.SetCacheInvalidationThresholdMaximum(drawingBrush, 2.0);
            RenderOptions.SetCachingHint(drawingBrush, CachingHint.Cache);

            // <SnippetRenderOptionsSnippet4>
            // Get the caching hint option for the brush.
            CachingHint cachingHint = RenderOptions.GetCachingHint(drawingBrush);

            if (cachingHint == CachingHint.Cache)
            {
                // Get the minimum and maximum relative sizes for regenerating the tiled brush.
                double minimum = RenderOptions.GetCacheInvalidationThresholdMinimum(drawingBrush);
                double maximum = RenderOptions.GetCacheInvalidationThresholdMaximum(drawingBrush);

                // Perform action based on cache values...
            }
            // </SnippetRenderOptionsSnippet4>
        }

        public void Stub05()
        {
            int renderCapabilityTier = 0x00020000;
            int renderingTierTest = (renderCapabilityTier >> 16);

            // <SnippetRenderCapability1>
            // The rendering tier corresponds to the high-order word of the Tier property.
            int renderingTier = (RenderCapability.Tier >> 16);
            // </SnippetRenderCapability1>
        }
    }
}