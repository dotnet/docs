//This is a list of commonly used namespaces for a pane.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;

namespace ButtonResources
{
	/// <summary>
	/// Interaction logic for Pane1.xaml
	/// </summary>

	public partial class Pane1 : StackPanel
	{
	void OnClick1(object sender, RoutedEventArgs e)
		 {
                  //<SnippetFontResourcesCode>
                  Button btncsharp = new Button();
                  btncsharp.Content = "SystemFonts";
                  btncsharp.Background = SystemColors.ControlDarkDarkBrush;
                  btncsharp.FontSize = SystemFonts.IconFontSize;
                  btncsharp.FontWeight = SystemFonts.MessageFontWeight;
                  btncsharp.FontFamily = SystemFonts.CaptionFontFamily;
                  cv1.Children.Add(btncsharp);
                  //</SnippetFontResourcesCode>
                  } 
        void OnClick2(object sender, RoutedEventArgs e)
		 {
                  //<SnippetParameterResourcesCode>
                  Button btncsharp = new Button();
                  btncsharp.Content = "SystemParameters";
                  btncsharp.FontSize = 8;
                  btncsharp.Background = SystemColors.ControlDarkDarkBrush;
                  btncsharp.Height = SystemParameters.CaptionHeight;
                  btncsharp.Width = SystemParameters.IconGridWidth;
                  cv2.Children.Add(btncsharp);
                  //</SnippetParameterResourcesCode>
                  }                	
        }
}