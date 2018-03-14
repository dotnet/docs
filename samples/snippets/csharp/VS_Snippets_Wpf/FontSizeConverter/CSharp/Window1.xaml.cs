using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Media;

namespace FontSizeConverter_Csharp
{
	public partial class Window1 : Window
	{
        // <Snippet1>
        private void changeSize(object sender, SelectionChangedEventArgs args)
        {
			ListBoxItem li = ((sender as ListBox).SelectedItem as ListBoxItem);
			FontSizeConverter myFontSizeConverter = new FontSizeConverter();
			text1.FontSize = (Double)myFontSizeConverter.ConvertFromString(li.Content.ToString());
        }

        private void changeFamily(object sender, SelectionChangedEventArgs args)
		{
			ListBoxItem li2 = ((sender as ListBox).SelectedItem as ListBoxItem);
            text1.FontFamily = new System.Windows.Media.FontFamily(li2.Content.ToString());
        }
        //</Snippet1>
	}
}