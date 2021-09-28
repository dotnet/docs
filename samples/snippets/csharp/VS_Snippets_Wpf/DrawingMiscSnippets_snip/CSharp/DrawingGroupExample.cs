// <SnippetDrawingGroupExampleWholePage>
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SDKSample
{
    public class DrawingGroupExample : Page
    {

        public DrawingGroupExample()
        {

            StackPanel mainPanel = new StackPanel();
            mainPanel.Margin = new Thickness(20);
            createSimpleDrawingGroupExample(mainPanel);
            createMultipleDrawingGroupExample(mainPanel);

            this.Background = Brushes.White;
            this.Margin = new Thickness(20);
            this.Content = mainPanel;
        }

        private void createSimpleDrawingGroupExample(Panel examplePanel)
        {
            // <SnippetGraphicsMMSimpleDrawingGroupExample>
            //
            // Create three drawings.
            //
            GeometryDrawing ellipseDrawing =
                new GeometryDrawing(
                    new SolidColorBrush(Color.FromArgb(102, 181, 243, 20)),
                    new Pen(Brushes.Black, 4),
                    new EllipseGeometry(new Point(50,50), 50, 50)
                );

            ImageDrawing kiwiPictureDrawing =
                new ImageDrawing(
                    new BitmapImage(new Uri(@"sampleImages\kiwi.png", UriKind.Relative)),
                    new Rect(50,50,100,100));

            GeometryDrawing ellipseDrawing2 =
                new GeometryDrawing(
                    new SolidColorBrush(Color.FromArgb(102,181,243,20)),
                    new Pen(Brushes.Black, 4),
                    new EllipseGeometry(new Point(150, 150), 50, 50)
                );

            // Create a DrawingGroup to contain the drawings.
            DrawingGroup aDrawingGroup = new DrawingGroup();
            aDrawingGroup.Children.Add(ellipseDrawing);
            aDrawingGroup.Children.Add(kiwiPictureDrawing);
            aDrawingGroup.Children.Add(ellipseDrawing2);

            // </SnippetGraphicsMMSimpleDrawingGroupExample>

            //
            // Use a DrawingImage and an Image to display the DrawingGroup.
            //
            DrawingImage drawingImageSource = new DrawingImage(aDrawingGroup);

            // Freeze the DrawingImage for performance benefits.
            drawingImageSource.Freeze();

            Image anImage = new Image();
            anImage.Source = drawingImageSource;
            anImage.Stretch = Stretch.None;
            anImage.HorizontalAlignment = HorizontalAlignment.Left;

            Border imageBorder = new Border();
            imageBorder.BorderBrush = Brushes.Gray;
            imageBorder.BorderThickness = new Thickness(1);
            imageBorder.HorizontalAlignment = HorizontalAlignment.Left;
            imageBorder.Child = anImage;

            examplePanel.Children.Add(imageBorder);
        }

        private void createMultipleDrawingGroupExample(Panel examplePanel)
        {
            // <SnippetGraphicsMMMultipleDrawingGroupsExample>

            // Create a DrawingGroup.
            DrawingGroup mainGroup = new DrawingGroup();

            //
            // Create a GeometryDrawing
            //
            GeometryDrawing ellipseDrawing =
                new GeometryDrawing(
                    new SolidColorBrush(Color.FromArgb(102, 181, 243, 20)),
                    new Pen(Brushes.Black, 4),
                    new EllipseGeometry(new Point(50, 50), 50, 50)
                );

            //
            // Use a DrawingGroup to apply a blur
            // bitmap effect to the drawing.
            //
            DrawingGroup blurGroup = new DrawingGroup();
            blurGroup.Children.Add(ellipseDrawing);
            BlurBitmapEffect blurEffect = new BlurBitmapEffect();
            blurEffect.Radius = 5;
            blurGroup.BitmapEffect = blurEffect;

            // Add the DrawingGroup to the main DrawingGroup.
            mainGroup.Children.Add(blurGroup);

            //
            // Create an ImageDrawing.
            //
            ImageDrawing kiwiPictureDrawing =
                new ImageDrawing(
                    new BitmapImage(new Uri(@"sampleImages\kiwi.png", UriKind.Relative)),
                    new Rect(50, 50, 100, 100));

            //
            // Use a DrawingGroup to apply an opacity mask
            // and a bevel.
            //
            DrawingGroup maskedAndBeveledGroup = new DrawingGroup();
            maskedAndBeveledGroup.Children.Add(kiwiPictureDrawing);

            // Create an opacity mask.
            RadialGradientBrush rgBrush =new RadialGradientBrush();
            rgBrush.GradientStops.Add(new GradientStop(Color.FromArgb(0,0,0,0), 0.55));
            rgBrush.GradientStops.Add(new GradientStop(Color.FromArgb(255,0,0,0), 0.65));
            rgBrush.GradientStops.Add(new GradientStop(Color.FromArgb(0,0,0,0), 0.75));
            rgBrush.GradientStops.Add(new GradientStop(Color.FromArgb(255,0,0,0), 0.80));
            rgBrush.GradientStops.Add(new GradientStop(Color.FromArgb(0,0,0,0), 0.90));
            rgBrush.GradientStops.Add(new GradientStop(Color.FromArgb(255,0,0,0), 1.0));
            maskedAndBeveledGroup.OpacityMask = rgBrush;

            // Apply a bevel.
            maskedAndBeveledGroup.BitmapEffect = new BevelBitmapEffect();

            // Add the DrawingGroup to the main group.
            mainGroup.Children.Add(maskedAndBeveledGroup);

            //
            // Create another GeometryDrawing.
            //
            GeometryDrawing ellipseDrawing2 =
              new GeometryDrawing(
                  new SolidColorBrush(Color.FromArgb(102, 181, 243, 20)),
                  new Pen(Brushes.Black, 4),
                  new EllipseGeometry(new Point(150, 150), 50, 50)
              );

            // Add the DrawingGroup to the main group.
            mainGroup.Children.Add(ellipseDrawing2);

            // </SnippetGraphicsMMMultipleDrawingGroupsExample>

            //
            // Use a DrawingImage and an Image to display the DrawingGroup.
            //
            DrawingImage drawingImageSource = new DrawingImage(mainGroup);

            // Freeze the DrawingImage for performance benefits.
            drawingImageSource.Freeze();

            Image anImage = new Image();
            anImage.Source = drawingImageSource;
            anImage.Stretch = Stretch.None;
            anImage.HorizontalAlignment = HorizontalAlignment.Left;

            Border imageBorder = new Border();
            imageBorder.BorderBrush = Brushes.Gray;
            imageBorder.BorderThickness = new Thickness(1);
            imageBorder.HorizontalAlignment = HorizontalAlignment.Left;
            imageBorder.Margin = new Thickness(10);
            imageBorder.Child = anImage;

            examplePanel.Children.Add(imageBorder);
        }
    }
}
// </SnippetDrawingGroupExampleWholePage>
