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



        // To use PaneLoaded put Loaded="PaneLoaded" in root element of .xaml file.
        // private void PaneLoaded(object sender, EventArgs e) {}
        // Sample event handler:  
        //<SnippetControlEvents1>
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
        //</SnippetControlEvents1>
        
        //<SnippetControlEvents2>
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
        //</SnippetControlEvents2>

        //<SnippetAdditionalControlProps1>
        void ChangeBorderThickness(object sender, RoutedEventArgs e)
        {
            if (btn9.BorderThickness.Left == 5.0)
            {
                btn9.BorderThickness = new Thickness(2.0);
                btn9.Content = "Control BorderThickness changes from 5 to 2.";
        
            }
            else
            {
                btn9.BorderThickness = new Thickness(5.0);
                btn9.Content = "BorderThickness";
            }
        }
        //</SnippetAdditionalControlProps1>

        //<SnippetAdditionalControlProps2>
        void ChangeFontStretch(object sender, RoutedEventArgs e)
        {
            if (btn10.FontStretch == FontStretches.Condensed)
            {
                btn10.FontStretch = FontStretches.Normal;
                btn10.Content = "Control FontStretch changes from Condensed to Normal.";

            }
            else
            {
                btn10.FontStretch = FontStretches.Condensed;
                btn10.Content = "FontStretch";
            }
        }
        //</SnippetAdditionalControlProps2>

        //<SnippetAdditionalControlProps3>
        void ChangePadding(object sender, RoutedEventArgs e)
        {
            if (btn11.Padding.Left == 5.0)
            {
                btn11.Padding = new Thickness(2.0);
                btn11.Content = "Control Padding changes from 5 to 2.";

            }
            else
            {
                btn11.Padding = new Thickness(5.0);
                btn11.Content = "Padding";
            }
        }
        //</SnippetAdditionalControlProps3>

        //<SnippetAdditionalControlProps4>
        void IsTabStop(object sender, RoutedEventArgs e)
        {
            if (btn13.IsTabStop == true)
            {
                btn13.Content = "Control is a tab stop.";
            }
        }
        //</SnippetAdditionalControlProps4>
        
    }
}