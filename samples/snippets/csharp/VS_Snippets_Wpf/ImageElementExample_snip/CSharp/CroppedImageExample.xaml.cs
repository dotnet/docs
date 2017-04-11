//This is a list of commonly used namespaces for a pane.
using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace ImageElementExample
{
    public partial class CroppedImageExample : Page
    {
        public CroppedImageExample()
        {
        }

        private void PageLoaded(object sender, RoutedEventArgs args)
        {
            //<SnippetCroppedCSharp1>
            //our new image element
            Image croppedImage = new Image();
            croppedImage.Width = 200;
            croppedImage.Margin = new Thickness(5);

            //Create croppedbitmap based off of xaml defined resource
            CroppedBitmap cb = new CroppedBitmap(
               (BitmapSource)this.Resources["masterImage"],
               new Int32Rect(30, 20, 105, 50));       //select region rect
            croppedImage.Source = cb;                 //set image source to cropped
            //</SnippetCroppedCSharp1>

            //Add Image to the UI
            Grid.SetColumn(croppedImage, 1);
            Grid.SetRow(croppedImage, 1);
            croppedGrid.Children.Add(croppedImage);

            //<SnippetCroppedCSharp2>
            //Our chained image element
            Image chainImage = new Image();
            chainImage.Width = 200;
            chainImage.Margin = new Thickness(5);

            //Create the cropped image based on previous croppedbitmap
            CroppedBitmap chained = new CroppedBitmap(cb,
               new Int32Rect(30, 0, (int)cb.Width - 30, (int)cb.Height)); // select region
            //Set the elements source
            chainImage.Source = chained;
            //</SnippetCroppedCSharp2>

            //Add Image to the UI
            Grid.SetColumn(chainImage, 1);
            Grid.SetRow(chainImage, 3);
            croppedGrid.Children.Add(chainImage);

            //<SnippetCroppedCSharpUsingClip1>
            //Create the image for clipping
            Image clipImage = new Image();
            clipImage.Width = 200;
            clipImage.Margin = new Thickness(5);
 
            //Create & Set source
            BitmapImage bi = new BitmapImage();
            //BitmapImage.UriSource must be in a BeginInit/EndInit block
            bi.BeginInit();
            bi.UriSource = new Uri("pack://application:,,/sampleImages/gecko.jpg");
            bi.EndInit();
            clipImage.Source = bi;

            //Clip the using an EllipseGeometry
            EllipseGeometry clipGeometry = new EllipseGeometry(new Point(75, 50), 50, 25);
            clipImage.Clip = clipGeometry;
            //</SnippetCroppedCSharpUsingClip1>

            //Add Image to the UI
            Grid.SetColumn(clipImage, 1);
            Grid.SetRow(clipImage, 5);
            croppedGrid.Children.Add(clipImage);
            
            

        }


    }
}