using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Media;

namespace ThicknessConverter_Csharp
{
	public partial class Window1 : Window
	{
        // <Snippet1>
        private void changeThickness(object sender, SelectionChangedEventArgs args)
        {
			ListBoxItem li = ((sender as ListBox).SelectedItem as ListBoxItem);
			ThicknessConverter myThicknessConverter = new ThicknessConverter();
			Thickness th1 = (Thickness)myThicknessConverter.ConvertFromString(li.Content.ToString());
            border1.BorderThickness = th1;
            bThickness.Text = "Border.BorderThickness =" + li.Content.ToString();
        }
        //</Snippet1>

        private void changeColor(object sender, SelectionChangedEventArgs args)
		{
			ListBoxItem li2 = ((sender as ListBox).SelectedItem as ListBoxItem);
            BrushConverter myBrushConverter = new BrushConverter();
            border1.BorderBrush = (Brush)myBrushConverter.ConvertFromString((string)li2.Content);
            bColor.Text = "Border.Borderbrush =" + li2.Content.ToString();
        }
	}
}