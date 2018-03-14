// <SnippetBrushTransformExampleWholePage> 
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;

namespace BrushesIntroduction
{
    public class BrushTransformExample : Page
    {
        public BrushTransformExample()
        {
            // <SnippetImageBrushNoTransform>
            // Create an ImageBrush with no transform.
            ImageBrush noTransformImageBrush = new ImageBrush();
            noTransformImageBrush.ImageSource =
                new BitmapImage(new Uri(@"sampleImages\pinkcherries.jpg", UriKind.Relative));
            
            // Use the brush to paint a rectangle.
            Rectangle noTransformImageBrushRectangle = new Rectangle();
            noTransformImageBrushRectangle.Width = 175;
            noTransformImageBrushRectangle.Height = 90;
            noTransformImageBrushRectangle.Stroke = Brushes.Black;
            noTransformImageBrushRectangle.Fill = noTransformImageBrush;
            // </SnippetImageBrushNoTransform>

            // <SnippetImageBrushRelativeTransformExample>
            //
            // Create an ImageBrush with a relative transform and
            // use it to paint a rectangle.
            //
            ImageBrush relativeTransformImageBrush = new ImageBrush();
            relativeTransformImageBrush.ImageSource =
                new BitmapImage(new Uri(@"sampleImages\pinkcherries.jpg", UriKind.Relative));

            // Create a 45 rotate transform about the brush's center
            // and apply it to the brush's RelativeTransform property.
            RotateTransform aRotateTransform = new RotateTransform();
            aRotateTransform.CenterX = 0.5; 
            aRotateTransform.CenterY = 0.5;
            aRotateTransform.Angle = 45;
            relativeTransformImageBrush.RelativeTransform = aRotateTransform;

            // Use the brush to paint a rectangle.
            Rectangle relativeTransformImageBrushRectangle = new Rectangle();
            relativeTransformImageBrushRectangle.Width = 175;
            relativeTransformImageBrushRectangle.Height = 90;
            relativeTransformImageBrushRectangle.Stroke = Brushes.Black;
            relativeTransformImageBrushRectangle.Fill = relativeTransformImageBrush;

            // </SnippetImageBrushRelativeTransformExample>

            // <SnippetImageBrushTransformExample>
            //
            // Create an ImageBrush with a transform and
            // use it to paint a rectangle.
            //
            ImageBrush transformImageBrush = new ImageBrush();
            transformImageBrush.ImageSource =
                new BitmapImage(new Uri(@"sampleImages\pinkcherries.jpg", UriKind.Relative));

            // Create a 45 rotate transform about the brush's center
            // and apply it to the brush's Transform property.
            RotateTransform anotherRotateTransform = new RotateTransform();
            anotherRotateTransform.CenterX = 87.5;
            anotherRotateTransform.CenterY = 45;
            anotherRotateTransform.Angle = 45;
            transformImageBrush.Transform = anotherRotateTransform;

            // Use the brush to paint a rectangle.
            Rectangle transformImageBrushRectangle = new Rectangle();
            transformImageBrushRectangle.Width = 175;
            transformImageBrushRectangle.Height = 90;
            transformImageBrushRectangle.Stroke = Brushes.Black;
            transformImageBrushRectangle.Fill = transformImageBrush;

            // </SnippetImageBrushTransformExample>


            StackPanel mainPanel = new StackPanel();
            mainPanel.Children.Add(noTransformImageBrushRectangle);
            mainPanel.Children.Add(relativeTransformImageBrushRectangle);
            mainPanel.Children.Add(transformImageBrushRectangle);

            Content = mainPanel;
            Title = "Transforming Brushes";
            Background = Brushes.White;
            

        }


    }
}
// </SnippetBrushTransformExampleWholePage> 


