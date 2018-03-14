// <SnippetGraphicsMMVisualBrushReflectionExampleWholePage>
using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Shapes;
namespace SDKSample
{
    public partial class ReflectionExample : Page
    {
        public ReflectionExample()
        {
            // Create a name scope for the page.
            NameScope.SetNameScope(this, new NameScope());

            this.Background = Brushes.Black;
            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Margin = new Thickness(50);

            Border myReflectedBorder = new Border();
            this.RegisterName("ReflectedVisual", myReflectedBorder);

            // Create a gradient background for the border.
            GradientStop firstStop = new GradientStop();
            firstStop.Offset = 0.0;
            Color firstStopColor = new Color();
            firstStopColor.R = 204;
            firstStopColor.G = 204;
            firstStopColor.B = 255;
            firstStopColor.A = 255;
            firstStop.Color = firstStopColor;
            GradientStop secondStop = new GradientStop();
            secondStop.Offset = 1.0;
            secondStop.Color = Colors.White;

            GradientStopCollection myGradientStopCollection = new GradientStopCollection();
            myGradientStopCollection.Add(firstStop);
            myGradientStopCollection.Add(secondStop);

            LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush();
            myLinearGradientBrush.StartPoint = new Point(0, 0.5);
            myLinearGradientBrush.EndPoint = new Point(1, 0.5);
            myLinearGradientBrush.GradientStops = myGradientStopCollection;

            myReflectedBorder.Background = myLinearGradientBrush;

            // Add contents to the border.
            StackPanel borderStackPanel = new StackPanel();
            borderStackPanel.Orientation = Orientation.Horizontal;
            borderStackPanel.Margin = new Thickness(10);

            TextBlock myTextBlock = new TextBlock();
            myTextBlock.TextWrapping = TextWrapping.Wrap;
            myTextBlock.Width = 200;
            myTextBlock.Text = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit." +
                               " Suspendisse vel ante. Donec luctus tortor sit amet est." +
                               " Nullam pulvinar odio et wisi." +
                               " Pellentesque quis magna. Sed pellentesque." +
                               " Nulla euismod." +
                               "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.";

            borderStackPanel.Children.Add(myTextBlock);

            StackPanel ellipseStackPanel = new StackPanel();

            Ellipse ellipse1 = new Ellipse();
            ellipse1.Margin = new Thickness(10);
            ellipse1.Height = 50;
            ellipse1.Width = 50;
            ellipse1.Fill = Brushes.Black;
            ellipseStackPanel.Children.Add(ellipse1);
            Ellipse ellipse2 = new Ellipse();
            ellipse2.Margin = new Thickness(10);
            ellipse2.Height = 50;
            ellipse2.Width = 50;
            ellipse2.Fill = Brushes.Black;
            ellipseStackPanel.Children.Add(ellipse2);
            Ellipse ellipse3 = new Ellipse();
            ellipse3.Margin = new Thickness(10);
            ellipse3.Height = 50;
            ellipse3.Width = 50;
            ellipse3.Fill = Brushes.Black;
            ellipseStackPanel.Children.Add(ellipse3);
            borderStackPanel.Children.Add(ellipseStackPanel);

            myReflectedBorder.Child = borderStackPanel;

            // Create divider rectangle
            Rectangle dividerRectangle = new Rectangle();
            dividerRectangle.Height = 1;
            dividerRectangle.Fill = Brushes.Gray;
            dividerRectangle.HorizontalAlignment = HorizontalAlignment.Stretch;

            // Create the object to contain the reflection.
            Rectangle reflectionRectangle = new Rectangle();

            // Bind the height of the rectangle to the border height.
            Binding heightBinding = new Binding();
            heightBinding.ElementName = "ReflectedVisual";
            heightBinding.Path = new PropertyPath(Rectangle.HeightProperty);
            BindingOperations.SetBinding(reflectionRectangle, Rectangle.HeightProperty, heightBinding);

            // Bind the width of the rectangle to the border width.
            Binding widthBinding = new Binding();
            widthBinding.ElementName = "ReflectedVisual";
            widthBinding.Path = new PropertyPath(Rectangle.WidthProperty);
            BindingOperations.SetBinding(reflectionRectangle, Rectangle.WidthProperty, widthBinding);

            // Creates the reflection.
            VisualBrush myVisualBrush = new VisualBrush();
            myVisualBrush.Opacity = 0.75;
            myVisualBrush.Stretch = Stretch.None;
            Binding reflectionBinding = new Binding();
            reflectionBinding.ElementName = "ReflectedVisual";
            BindingOperations.SetBinding(myVisualBrush, VisualBrush.VisualProperty, reflectionBinding);

            ScaleTransform myScaleTransform = new ScaleTransform();
            myScaleTransform.ScaleX = 1;
            myScaleTransform.ScaleY = -1;
            TranslateTransform myTranslateTransform = new TranslateTransform();
            myTranslateTransform.Y = 1;

            TransformGroup myTransformGroup = new TransformGroup();
            myTransformGroup.Children.Add(myScaleTransform);
            myTransformGroup.Children.Add(myTranslateTransform);

            myVisualBrush.RelativeTransform = myTransformGroup;

            reflectionRectangle.Fill = myVisualBrush;

            // Create a gradient background for the border.
            GradientStop firstStop2 = new GradientStop();
            firstStop2.Offset = 0.0;
            Color c1 = new Color();
            c1.R = 0;
            c1.G = 0;
            c1.B = 0;
            c1.A = 255;
            firstStop2.Color = c1;
            GradientStop secondStop2 = new GradientStop();
            secondStop2.Offset = 0.5;
            Color c2 = new Color();
            c2.R = 0;
            c2.G = 0;
            c2.B = 0;
            c2.A = 51;
            firstStop2.Color = c2;
            GradientStop thirdStop = new GradientStop();
            thirdStop.Offset = 0.75;
            Color c3 = new Color();
            c3.R = 0;
            c3.G = 0;
            c3.B = 0;
            c3.A = 0;
            thirdStop.Color = c3;

            GradientStopCollection myGradientStopCollection2 = new GradientStopCollection();
            myGradientStopCollection2.Add(firstStop2);
            myGradientStopCollection2.Add(secondStop2);
            myGradientStopCollection2.Add(thirdStop);

            LinearGradientBrush myLinearGradientBrush2 = new LinearGradientBrush();
            myLinearGradientBrush2.StartPoint = new Point(0.5, 0);
            myLinearGradientBrush2.EndPoint = new Point(0.5, 1);
            myLinearGradientBrush2.GradientStops = myGradientStopCollection2;

            reflectionRectangle.OpacityMask = myLinearGradientBrush2;

            BlurBitmapEffect myBlurBitmapEffect = new BlurBitmapEffect();
            myBlurBitmapEffect.Radius = 1.5;

            reflectionRectangle.BitmapEffect = myBlurBitmapEffect;

            myStackPanel.Children.Add(myReflectedBorder);
            myStackPanel.Children.Add(dividerRectangle);
            myStackPanel.Children.Add(reflectionRectangle);
            this.Content = myStackPanel;

        }
        /*
    <Rectangle 
      Height="{Binding Path=ActualHeight, ElementName=ReflectedVisual}" 
      Width="{Binding Path=ActualWidth, ElementName=ReflectedVisual}">

      <Rectangle.OpacityMask>
        <LinearGradientBrush StartPoint="0.5,0" EndPoint="0.5,1">
          <GradientStop Color="#FF000000" Offset="0.0" />
          <GradientStop Color="#33000000" Offset="0.5" />
          <GradientStop Color="#00000000" Offset="0.75" />
        </LinearGradientBrush>
      </Rectangle.OpacityMask>

      <Rectangle.BitmapEffect>
        <BlurBitmapEffect Radius="1.5" />
      </Rectangle.BitmapEffect>
      
    </Rectangle>
  </StackPanel>
</Page>

*/
        
    }
}
// </SnippetGraphicsMMVisualBrushReflectionExampleWholePage>