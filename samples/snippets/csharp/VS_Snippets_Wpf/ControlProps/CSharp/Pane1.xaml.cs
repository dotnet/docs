//This is a list of commonly used namespaces for a pane.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;

namespace ControlProps
{
    /// <summary>
    /// Interaction logic for Pane1.xaml
    /// </summary>


    public partial class Pane1 : StackPanel
    {

        string str;
        FontFamily ffamily;
        Double fsize;

        // To use PaneLoaded put Loaded="PaneLoaded" in root element of .xaml file.
        // private void PaneLoaded(object sender, EventArgs e) {}
        // Sample event handler:  
        //<Snippet1>
        void ChangeBackground(object sender, RoutedEventArgs e)
        {
            if (btn.Background == Brushes.Red)
            {
                btn.Background = new LinearGradientBrush(Colors.LightBlue, Colors.SlateBlue, 90);
                btn.Content = "Control background changes from red to a blue gradient.";
            }
            else
            {
                btn.Background = Brushes.Red;
                btn.Content = "Background";
            }
        }
        //</Snippet1>


        //<Snippet2>
        void ChangeForeground(object sender, RoutedEventArgs e)
        {
            if (btn1.Foreground == Brushes.Green)
            {
                btn1.Foreground = Brushes.Black;
                btn1.Content = "Foreground";
            }
            else
            {
                btn1.Foreground = Brushes.Green;
                btn1.Content = "Control foreground(text) changes from black to green.";
            }
        }
        //</Snippet2>

        //<Snippet3>
        void ChangeFontFamily(object sender, RoutedEventArgs e)
        {

            ffamily = btn2.FontFamily;
            str = ffamily.ToString();
            if (str == ("Arial Black"))
            {
                btn2.FontFamily = new FontFamily("Arial");
                btn2.Content = "FontFamily";
            }
            else
            {
                btn2.FontFamily = new FontFamily("Arial Black");
                btn2.Content = "Control font family changes from Arial to Arial Black.";

            }
        }
        //</Snippet3>

        //<Snippet4>
        void ChangeFontSize(object sender, RoutedEventArgs e)
        {
            fsize = btn3.FontSize;
            if (fsize == 16.0)
            {
                btn3.FontSize = 10.0;
                btn3.Content = "FontSize";
            }
            else
            {
                btn3.FontSize = 16.0;
                btn3.Content = "Control font size changes from 10 to 16.";
            }
        }
        //</Snippet4>

        //<Snippet5>
        void ChangeFontStyle(object sender, RoutedEventArgs e)
        {
            if (btn4.FontStyle == FontStyles.Italic)
            {
                btn4.FontStyle = FontStyles.Normal;
                btn4.Content = "FontStyle";
            }
            else
            {
                btn4.FontStyle = FontStyles.Italic;
                btn4.Content = "Control font style changes from Normal to Italic.";
            }
        }
        //</Snippet5>


        //<Snippet6>
        void ChangeFontWeight(object sender, RoutedEventArgs e)
        {
            if (btn5.FontWeight == FontWeights.Bold)
            {
                btn5.FontWeight = FontWeights.Normal;
                btn5.Content = "FontWeight";
            }
            else
            {
                btn5.FontWeight = FontWeights.Bold;
                btn5.Content = "Control font weight changes from Normal to Bold.";
            }
        }
        //</Snippet6>

        //<Snippet7>
        void ChangeBorderBrush(object sender, RoutedEventArgs e)
        {
            if (btn6.BorderBrush == Brushes.Red)
            {
                btn6.BorderBrush = Brushes.Black;
                btn6.Content = "Control border brush changes from red to black.";

            }
            else
            {
                btn6.BorderBrush = Brushes.Red;
                btn6.Content = "BorderBrush";
                }
        }
        //</Snippet7>

        //<Snippet8>
        void ChangeHorizontalContentAlignment(object sender, RoutedEventArgs e)
        {
            if (btn7.HorizontalContentAlignment == HorizontalAlignment.Left)
            {
                btn7.HorizontalContentAlignment = HorizontalAlignment.Right;
                btn7.Content = "Control horizontal alignment changes from left to right.";

            }
            else
            {
                btn7.HorizontalContentAlignment = HorizontalAlignment.Left;
                btn7.Content = "HorizontalContentAlignment";
            }
        }
        //</Snippet8>


        //<Snippet9>
        void ChangeVerticalContentAlignment(object sender, RoutedEventArgs e)
        {
            if (btn8.VerticalContentAlignment == VerticalAlignment.Top)
            {
                btn8.VerticalContentAlignment = VerticalAlignment.Bottom;
                btn8.Content = "Control vertical alignment changes from top to bottom.";

            }
            else
            {
                btn8.VerticalContentAlignment = VerticalAlignment.Top;
                btn8.Content = "VerticalContentAlignment";
            }
        }
        //</Snippet9>
        
    }
}   