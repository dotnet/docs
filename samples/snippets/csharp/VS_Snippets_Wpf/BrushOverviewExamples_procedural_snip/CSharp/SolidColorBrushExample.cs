using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Microsoft.Samples.BrushExamples
{

    public class SolidColorBrushExample : Page
    {

        private StackPanel myMainPanel;

        public SolidColorBrushExample()
        {
            this.WindowTitle = "SolidColorBrush Example";
            this.Background = Brushes.White;

            myMainPanel = new StackPanel();
            predefinedBrushExample();
            predefinedColorExample();
            fromScRgbExample();
            fromArgbExample();
            this.Content = myMainPanel;
        }

        private void predefinedBrushExample()
        {

            // <SnippetSolidColorBrushPredefinedBrush1CSharp>
            Button myButton = new Button();
            myButton.Content = "A Button";
            myButton.Background = Brushes.Red;
            // </SnippetSolidColorBrushPredefinedBrush1CSharp>

            myMainPanel.Children.Add(myButton);
        }

        private void predefinedColorExample()
        {

            // <SnippetSolidColorBrushPredefinedColor1CSharp>
            Button myButton = new Button();
            myButton.Content = "A Button";

            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Colors.Red;
            myButton.Background = mySolidColorBrush;
            // </SnippetSolidColorBrushPredefinedColor1CSharp>

            myMainPanel.Children.Add(myButton);
        }

        // Create a button and paint its background red.
        private void fromScRgbExample()
        {

            // <SnippetSolidColorBrushfromScRgbExample1CSharp>
            Button myButton = new Button();
            myButton.Content = "A Button";

            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color =
                Color.FromScRgb(
                    1.0f, // Specifies the transparency of the color.
                    1.0f, // Specifies the amount of red.
                    0.0f, // specifies the amount of green.
                    0.0f); // Specifies the amount of blue.

            myButton.Background = mySolidColorBrush;
            // </SnippetSolidColorBrushfromScRgbExample1CSharp>

            myMainPanel.Children.Add(myButton);
        }

        // Create a button and paint its background red.
        private void fromArgbExample()
        {

            // <SnippetSolidColorBrushfromArgbExample1CSharp>
            Button myButton = new Button();
            myButton.Content = "A Button";

            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color =
                Color.FromArgb(
                    255, // Specifies the transparency of the color.
                    255, // Specifies the amount of red.
                    0, // specifies the amount of green.
                    0); // Specifies the amount of blue.

            myButton.Background = mySolidColorBrush;
            // </SnippetSolidColorBrushfromArgbExample1CSharp>

            myMainPanel.Children.Add(myButton);
        }
    }
}