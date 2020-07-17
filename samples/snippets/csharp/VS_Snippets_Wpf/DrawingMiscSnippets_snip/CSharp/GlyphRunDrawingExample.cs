// <SnippetGlyphRunDrawingExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.Collections.Generic;

namespace SDKSample
{
    public class GlyphRunDrawingExample : Page
    {

        public GlyphRunDrawingExample()
        {

            // <SnippetGlyphRunDrawingExampleInline>
            GlyphRun theGlyphRun = new GlyphRun(
                new GlyphTypeface(new Uri(@"C:\WINDOWS\Fonts\TIMES.TTF")),
                0,
                false,
                13.333333333333334,
                new ushort[]{43, 72, 79, 79, 82, 3, 58, 82, 85, 79, 71},
                new Point(0, 12.29),
                new double[]{
                    9.62666666666667, 7.41333333333333, 2.96,
                    2.96, 7.41333333333333, 3.70666666666667,
                    12.5866666666667, 7.41333333333333,
                    4.44, 2.96, 7.41333333333333},
                null,
                null,
                null,
                null,
                null,
                null

                );

            GlyphRunDrawing gDrawing = new GlyphRunDrawing(Brushes.Black, theGlyphRun);
            // </SnippetGlyphRunDrawingExampleInline>

            //
            // Use a DrawingImage and an Image control
            // to display the drawing.
            //
            DrawingImage theDrawingImage = new DrawingImage(gDrawing);

            // Freeze the DrawingImage for performance benefits.
            theDrawingImage.Freeze();

            Image anImage = new Image();
            anImage.Source = theDrawingImage;
            anImage.Stretch = Stretch.None;
            anImage.HorizontalAlignment = HorizontalAlignment.Left;

            //
            // Place the image inside a border and
            // add it to the page.
            //
            Border exampleBorder = new Border();
            exampleBorder.Child = anImage;
            exampleBorder.BorderBrush = Brushes.Gray;
            exampleBorder.BorderThickness = new Thickness(1);
            exampleBorder.HorizontalAlignment = HorizontalAlignment.Left;
            exampleBorder.VerticalAlignment = VerticalAlignment.Top;
            exampleBorder.Margin = new Thickness(10);

            this.Margin = new Thickness(20);
            this.Background = Brushes.White;
            this.Content = exampleBorder;
        }
    }
}
// </SnippetGlyphRunDrawingExampleWholePage>
