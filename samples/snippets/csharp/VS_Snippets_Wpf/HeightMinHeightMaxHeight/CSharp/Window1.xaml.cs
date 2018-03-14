using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Height_MinHeight_MaxHeight
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>

	public partial class Window1 : Window
    {
        // <Snippet3>
        private void changeHeight(object sender, SelectionChangedEventArgs args)
        {
            ListBoxItem li = ((sender as ListBox).SelectedItem as ListBoxItem);
            Double sz1 = Double.Parse(li.Content.ToString());
            rect1.Height = sz1;
            rect1.UpdateLayout();
            txt1.Text= "ActualHeight is set to " + rect1.ActualHeight;
            txt2.Text= "Height is set to " + rect1.Height;
            txt3.Text= "MinHeight is set to " + rect1.MinHeight;
            txt4.Text= "MaxHeight is set to " + rect1.MaxHeight;
        }
        private void changeMinHeight(object sender, SelectionChangedEventArgs args)
        {
            ListBoxItem li = ((sender as ListBox).SelectedItem as ListBoxItem);
            Double sz1 = Double.Parse(li.Content.ToString());
            rect1.MinHeight = sz1;
            rect1.UpdateLayout();
            txt1.Text= "ActualHeight is set to " + rect1.ActualHeight;
            txt2.Text= "Height is set to " + rect1.Height;
            txt3.Text= "MinHeight is set to " + rect1.MinHeight;
            txt4.Text= "MaxHeight is set to " + rect1.MaxHeight;
        }
        private void changeMaxHeight(object sender, SelectionChangedEventArgs args)
        {
            ListBoxItem li = ((sender as ListBox).SelectedItem as ListBoxItem);
            Double sz1 = Double.Parse(li.Content.ToString());
            rect1.MaxHeight = sz1;
            rect1.UpdateLayout();
            txt1.Text= "ActualHeight is set to " + rect1.ActualHeight;
            txt2.Text= "Height is set to " + rect1.Height;
            txt3.Text= "MinHeight is set to " + rect1.MinHeight;
            txt4.Text= "MaxHeight is set to " + rect1.MaxHeight;
        }
        //</Snippet3>

        private void clipRect(object sender, RoutedEventArgs args)
        {
            myCanvas.ClipToBounds = true;
            txt5.Text= "Canvas.ClipToBounds is set to " + myCanvas.ClipToBounds;
        }
        private void unclipRect(object sender, RoutedEventArgs args)
        {
            myCanvas.ClipToBounds = false;
            txt5.Text= "Canvas.ClipToBounds is set to " + myCanvas.ClipToBounds;
        }
    }
}