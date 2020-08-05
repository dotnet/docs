/*
OpacityExample.cs

*/

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Microsoft.Samples.BrushExamples
{
    public partial class OpacityExample : Page
    {
        public OpacityExample()
        {
            this.WindowTitle = "Opacity Example";
            this.Background = Brushes.White;

            StackPanel myStackPanel = new StackPanel();
            myStackPanel.Margin = new Thickness(20);

            // <Snippet2>
            //
            // Both the button and its text are made 25% opaque.
            //
            Button myTwentyFivePercentOpaqueButton = new Button();
            myTwentyFivePercentOpaqueButton.Opacity = new Double();
            myTwentyFivePercentOpaqueButton.Opacity = 0.25;
            myTwentyFivePercentOpaqueButton.Content = "A Button";
            // </Snippet2>

            myStackPanel.Children.Add(myTwentyFivePercentOpaqueButton);

            // <Snippet3>
            //
            // The image contained within this button has an
            // effective opacity of 0.125 (0.25*0.5 = 0.125);
            //
            Button myImageButton = new Button();
            myImageButton.Opacity = new Double();
            myImageButton.Opacity = 0.25;

            StackPanel myImageStackPanel = new StackPanel();
            myImageStackPanel.Orientation = Orientation.Horizontal;

            TextBlock myTextBlock = new TextBlock();
            myTextBlock.VerticalAlignment = VerticalAlignment.Center;
            myTextBlock.Margin = new Thickness(10);
            myTextBlock.Text = "A Button";
            myImageStackPanel.Children.Add(myTextBlock);

            Image myImage = new Image();
            BitmapImage myBitmapImage = new BitmapImage();
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri("sampleImages/berries.jpg",UriKind.Relative);
            myBitmapImage.EndInit();
            myImage.Source = myBitmapImage;
            ImageBrush myImageBrush = new ImageBrush(myBitmapImage);
            myImage.Width = 50;
            myImage.Height = 50;
            myImage.Opacity = 0.5;
            myImageStackPanel.Children.Add(myImage);
            myImageButton.Content = myImageStackPanel;
            // </Snippet3>

            myStackPanel.Children.Add(myImageButton);

            // <Snippet4>
            //
            //  This button's background is made 25% opaque,
            // but its text remains 100% opaque.
            //
            Button myOpaqueTextButton = new Button();
            SolidColorBrush mySolidColorBrush = new SolidColorBrush(Colors.Gray);
            mySolidColorBrush.Opacity = 0.25;
            myOpaqueTextButton.Background = mySolidColorBrush;
            myOpaqueTextButton.Content = "A Button";
            // </Snippet4>

            myStackPanel.Children.Add(myOpaqueTextButton);

            this.Content = myStackPanel;
        }
    }
}
