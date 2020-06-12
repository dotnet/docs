using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Collections.ObjectModel;
using System.Windows.Shapes;
namespace SDKSample
{
    public partial class CreateColorsFromExample : Page
    {
        public CreateColorsFromExample()
        {

            // Add Image to the UI
            StackPanel myStackPanel = new StackPanel();
            //myStackPanel.Children.Add(myImage);

            //////// FromRgb Rectangle ///////
            Rectangle fromRgbRect = new Rectangle();
            fromRgbRect.Width = 50;
            fromRgbRect.Height = 50;

            // Create a brush for the rectangle fill.
            SolidColorBrush fromRgbSolidColorBrush = new SolidColorBrush();
            fromRgbSolidColorBrush.Color = FromRgbExample();
            fromRgbRect.Fill = fromRgbSolidColorBrush;

            //////// FromScRgb Rectangle ///////
            Rectangle fromScRgbRect = new Rectangle();
            fromScRgbRect.Width = 50;
            fromScRgbRect.Height = 50;
            SolidColorBrush fromScRgbSolidColorBrush = new SolidColorBrush();
            fromScRgbSolidColorBrush.Color = FromScRgbExample();
            fromScRgbRect.Fill = fromScRgbSolidColorBrush;

            //////// FromArgb Rectangle ///////
            Rectangle fromArgbRect = new Rectangle();
            fromArgbRect.Width = 50;
            fromArgbRect.Height = 50;
            SolidColorBrush fromArgbSolidColorBrush = new SolidColorBrush();
            fromArgbSolidColorBrush.Color = FromScRgbExample();
            fromArgbRect.Fill = fromArgbSolidColorBrush;

            //////// FromAValues Rectangle ///////
            Rectangle fromAValuesRect = new Rectangle();
            fromAValuesRect.Width = 50;
            fromAValuesRect.Height = 50;
            SolidColorBrush fromAValuesSolidColorBrush = new SolidColorBrush();
            fromAValuesSolidColorBrush.Color = FromAValuesExample();
            fromAValuesRect.Fill = fromAValuesSolidColorBrush;

            //////// FromValues Rectangle ///////
            Rectangle fromValuesRect = new Rectangle();
            fromValuesRect.Width = 50;
            fromValuesRect.Height = 50;
            SolidColorBrush fromValuesSolidColorBrush = new SolidColorBrush();
            fromValuesSolidColorBrush.Color = FromValuesExample();
            fromValuesRect.Fill = fromValuesSolidColorBrush;

            myStackPanel.Children.Add(fromRgbRect);
            myStackPanel.Children.Add(fromScRgbRect);
            myStackPanel.Children.Add(fromArgbRect);
            myStackPanel.Children.Add(fromAValuesRect);
            myStackPanel.Children.Add(fromValuesRect);
            this.Content = myStackPanel;
        }
        // <SnippetFromRgbExample>
        private Color FromRgbExample()
        {
            // Create a green color using the FromRgb static method.
            Color myRgbColor = new Color();
            myRgbColor = Color.FromRgb(0, 255, 0);
            return myRgbColor;
        }
        // </SnippetFromRgbExample>
        // <SnippetFromScRgbExample>
        private Color FromScRgbExample()
        {
            // Create a blue color using the FromScRgb static method.
            Color myScRgbColor = new Color();
            myScRgbColor = Color.FromScRgb(1, 0, 0, 1);
            return myScRgbColor;
        }
        // </SnippetFromScRgbExample>
        // <SnippetFromArgbExample>
        private Color FromArgbExample()
        {
            // Create a blue color using the FromArgb static method.
            Color myArgbColor = new Color();
            myArgbColor = Color.FromArgb(255, 0, 255, 0);
            return myArgbColor;
        }
        // </SnippetFromArgbExample>
        // <SnippetFromAValuesExample>
        private Color FromAValuesExample()
        {
            // Create a brown color using the FromAValues static method.
            Color myAValuesColor = new Color();
            float [] colorValues = new float[4];
            colorValues[0] = 0.0f;
            colorValues[1] = 0.5f;
            colorValues[2] = 0.5f;
            colorValues[3] = 0.5f;

            // Uri to sample color profile. This color profile is used to
            // determine what the colors the colorValues map to.
            Uri iccUri = new Uri("C:\\sampleColorProfile.icc");

            // The FromAValues method requires an explicit value for alpha
            // (first parameter). The values given by the second parameter are
            // used with the color profile specified by the third parameter to
            // determine the color.
            myAValuesColor = Color.FromAValues(1.0f, colorValues, iccUri);
            return myAValuesColor;
        }
        // </SnippetFromAValuesExample>
        // <SnippetFromValuesExample>
        private Color FromValuesExample()
        {
            // Create a brown color using the FromValues static method.
            Color myValuesColor = new Color();
            float[] colorValues = new float[4];
            colorValues[0] = 0.0f;
            colorValues[1] = 0.5f;
            colorValues[2] = 0.5f;
            colorValues[3] = 0.5f;

            // Uri to sample color profile. This color profile is used to
            // determine what the colors the colorValues map to.
            Uri myIccUri = new Uri("C:\\sampleColorProfile.icc");

            // The values given by the first parameter are used with the color
            // profile specified by the second parameter to determine the color.
            myValuesColor = Color.FromValues(colorValues, myIccUri);
            return myValuesColor;
        }
        // </SnippetFromValuesExample>
    }
}