//This is a list of commonly used namespaces for a window.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;

namespace Canvas_Positioning_Properties
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>

	public partial class Window1 : Window
	{
        // <Snippet2>
		private void ChangeLeft(object sender, SelectionChangedEventArgs args)
		{
			ListBoxItem li = ((sender as ListBox).SelectedItem as ListBoxItem);
			LengthConverter myLengthConverter = new LengthConverter();
			Double db1 = (Double)myLengthConverter.ConvertFromString(li.Content.ToString());
			Canvas.SetLeft(text1, db1);
			String st1 = (String)myLengthConverter.ConvertToString(Canvas.GetLeft(text1));
			canvasLeft.Text = "Canvas.Left = " + st1;
		}
        //</Snippet2>

		private void ChangeRight(object sender, SelectionChangedEventArgs args)
		{
            ListBoxItem li2 = ((sender as ListBox).SelectedItem as ListBoxItem);
            LengthConverter myLengthConverter = new LengthConverter();
			Double db2 = (Double)myLengthConverter.ConvertFromString(li2.Content.ToString());
			Canvas.SetRight(text1, db2);
			String st1 = (String)myLengthConverter.ConvertToString(Canvas.GetRight(text1));
			canvasRight.Text = "Canvas.Right = " + st1;
		}

		private void ChangeTop(object sender, SelectionChangedEventArgs args)
		{
            ListBoxItem li3 = ((sender as ListBox).SelectedItem as ListBoxItem);
            LengthConverter myLengthConverter = new LengthConverter();
			Double db3 = (Double)myLengthConverter.ConvertFromString(li3.Content.ToString());
			Canvas.SetTop(text1, db3);
			String st1 = (String)myLengthConverter.ConvertToString(Canvas.GetTop(text1));
			canvasTop.Text = "Canvas.Top = " + st1;
		}

		private void ChangeBottom(object sender, SelectionChangedEventArgs args)
		{
            ListBoxItem li4 = ((sender as ListBox).SelectedItem as ListBoxItem);
            LengthConverter myLengthConverter = new LengthConverter();
			Double db4 = (Double)myLengthConverter.ConvertFromString(li4.Content.ToString());
			Canvas.SetBottom(text1, db4);
			String st1 = (String)myLengthConverter.ConvertToString(Canvas.GetBottom(text1));
            canvasBottom.Text = "Canvas.Bottom = " + st1;
        }
	}
}