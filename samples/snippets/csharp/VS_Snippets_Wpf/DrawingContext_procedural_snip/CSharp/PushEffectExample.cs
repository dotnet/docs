// <SnippetPushEffectExampleWholePage> 
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Media.Effects;

namespace SDKSample
{


    public class PushEffectExample : Page
    {

        public PushEffectExample()
        {
            Pen shapeOutlinePen = new Pen(Brushes.Black, 2);
            shapeOutlinePen.Freeze();

            // Create a DrawingGroup
            DrawingGroup dGroup = new DrawingGroup();

            // Obtain a DrawingContext from 
            // the DrawingGroup.
            using (DrawingContext dc = dGroup.Open())
            {
                // Draw a rectangle at full opacity.
                dc.DrawRectangle(Brushes.Blue, shapeOutlinePen, new Rect(0, 0, 25, 25));

                // Push an opacity change of 0.5. 
                // The opacity of each subsequent drawing will
                // will be multiplied by 0.5.
                dc.PushOpacity(0.5);

                // This rectangle is drawn at 50% opacity.
                dc.DrawRectangle(Brushes.Blue, shapeOutlinePen, new Rect(25, 25, 25, 25));

                // Blurs subsquent drawings. 
                dc.PushEffect(new BlurBitmapEffect(), null);

                // This rectangle is blurred and drawn at 50% opacity (0.5 x 0.5). 
                dc.DrawRectangle(Brushes.Blue, shapeOutlinePen, new Rect(50, 50, 25, 25));

                // This rectangle is also blurred and drawn at 50% opacity.
                dc.DrawRectangle(Brushes.Blue, shapeOutlinePen, new Rect(75, 75, 25, 25));

                // Stop applying the blur to subsquent drawings.
                dc.Pop();

                // This rectangle is drawn at 50% opacity with no blur effect.
                dc.DrawRectangle(Brushes.Blue, shapeOutlinePen, new Rect(100, 100, 25, 25));
            }

            // Display the drawing using an image control.
            Image theImage = new Image();
            DrawingImage dImageSource = new DrawingImage(dGroup);
            theImage.Source = dImageSource;

            this.Content = theImage;

        }




    }

}
// </SnippetPushEffectExampleWholePage> 
