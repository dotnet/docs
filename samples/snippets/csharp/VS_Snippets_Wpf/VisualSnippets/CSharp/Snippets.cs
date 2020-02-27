using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SDKSample
{
    class Snippets
    {
        public static void SnippetSetEdgeMode(Visual myVisual)
        {
            //<SnippetSetEdgeMode>
            // Set the edge mode to aliased for the visual and any descendant drawing primitives it has.
            RenderOptions.SetEdgeMode((DependencyObject)myVisual, EdgeMode.Aliased);
            //</SnippetSetEdgeMode>
        }

        public static void SnippetGetRenderTier()
        {
            //<SnippetRenderTierSnippet1>
            int currentRenderTier = RenderCapability.Tier;
            //</SnippetRenderTierSnippet1>
        }

        public static void SnippetRenderOrder()
        {
            DrawingVisual drawingVisual = new DrawingVisual();

            //<SnippetRenderOrderSnippet1>
            // Retrieve the DrawingContext in order to draw into the visual object.
            DrawingContext drawingContext = drawingVisual.RenderOpen();

            // Draw a rectangle into the DrawingContext.
            Rect rect = new Rect(new Point(160, 100), new Size(320, 80));
            drawingContext.DrawRectangle(Brushes.LightBlue, (Pen)null, rect);

            // Draw a formatted text string into the DrawingContext.
            drawingContext.DrawText(
               new FormattedText("Hello, world",
                  CultureInfo.GetCultureInfo("en-us"),
                  FlowDirection.LeftToRight,
                  new Typeface("Verdana"),
                  36, Brushes.Black),
                  new Point(200, 116));

            // Persist the drawing content.
            drawingContext.Close();
            //</SnippetRenderOrderSnippet1>
        }
    }
}
