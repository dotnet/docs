using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input.StylusPlugIns;
using System.Windows.Media;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Windows.Ink;

namespace AdvancedInkInputSemples
{

    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public class ImageRenderer : DynamicRenderer
    {
        delegate void InitializeRenderer();

        [ThreadStatic]
        private static ImageBrush imageBrush;

        const string imageFile = @"C:\Documents and Settings\All Users\Documents\My Pictures\Sample Pictures\Sunset.jpg";
        //const string imageFile = @"C:\Documents and Settings\Carole\My Documents\My Pictures\gracelockerbig.jpg";
        BitmapImage image1;
        Dispatcher renderingDistpatcher;
        InitializeRenderer initializeMethods;

        [ThreadStatic]
        private static SolidColorBrush solidBrush;

        protected override void OnDraw(DrawingContext drawingContext, 
                                       StylusPointCollection stylusPoints, 
                                       Geometry geometry, 
                                       Brush fillBrush)
        {
            // <Snippet17>
            if (imageBrush == null)
            {
                // Create an ImageBrush.  imageFile is a string that's a path to an image file.
                image1 = new BitmapImage(new Uri(imageFile));
                imageBrush = new ImageBrush(image1);

                // Don't tile, don't stretch; align to top/left.
                imageBrush.TileMode = TileMode.None;
                imageBrush.Stretch = Stretch.None;
                imageBrush.AlignmentX = AlignmentX.Left;
                imageBrush.AlignmentY = AlignmentY.Top;

                // Map the brush to the entire bounds of the element.
                imageBrush.ViewportUnits = BrushMappingMode.Absolute;
                imageBrush.Viewport = this.ElementBounds;
                imageBrush.Freeze();

            }
            // </Snippet17>

            drawingContext.DrawGeometry(imageBrush, null, geometry);
        }
    }

    public class ImageStroke : Stroke
    {
        private static ImageBrush imageBrush;
        private static SolidColorBrush brush;
        //const string imageFile = @"C:\Documents and Settings\Carole\My Documents\My Pictures\gracelockerbig.jpg";
        const string imageFile = @"C:\Documents and Settings\All Users\Documents\My Pictures\Sample Pictures\Sunset.jpg";
        bool viewportSet = false;
        static ImageStroke()
        {
            BitmapImage image1 = new BitmapImage(new Uri(imageFile));
            imageBrush = new ImageBrush(image1);
            imageBrush.TileMode = TileMode.None;
            imageBrush.Stretch = Stretch.None;
            imageBrush.AlignmentX = AlignmentX.Left;
            imageBrush.AlignmentY = AlignmentY.Top;

            // Map the brush to the entire bounds of the element.
            imageBrush.ViewportUnits = BrushMappingMode.Absolute;
            
        }

        public ImageStroke(Stroke oldStroke, Rect controlBounds) : base(oldStroke.StylusPoints, oldStroke.DrawingAttributes)
        {
            // This seems like a hack, but I didn't know how else to set the viewport.
            if (!viewportSet)
            {
                imageBrush.Viewport = controlBounds;
                //imageBrush.Viewbox = controlBounds;
                viewportSet = true;
            }
        }

        protected override void DrawCore(DrawingContext drawingContext, DrawingAttributes drawingAttributes)
        {
            Geometry geometry = this.GetGeometry(drawingAttributes);
            drawingContext.DrawGeometry(imageBrush, null, geometry);
            
        }
    }
}