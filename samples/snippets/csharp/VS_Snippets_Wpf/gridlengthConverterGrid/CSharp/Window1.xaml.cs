using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace GridLengthConverter_grid
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>

	public partial class Window1 : Window
	{
        
        private void changeRowVal(object sender, RoutedEventArgs e)
        {
            txt2.Text = "Current Grid Row is " + hs2.Value.ToString();
        }
        
        // <Snippet1>
        private void changeColVal(object sender, RoutedEventArgs e) 
		{
            txt1.Text = "Current Grid Column is " + hs1.Value.ToString();
        }

        private void changeCol(object sender, SelectionChangedEventArgs args)
        {
            ListBoxItem li = ((sender as ListBox).SelectedItem as ListBoxItem);
            GridLengthConverter myGridLengthConverter = new GridLengthConverter();
            if (hs1.Value == 0)
            {
                GridLength gl1 = (GridLength)myGridLengthConverter.ConvertFromString(li.Content.ToString());
                col1.Width = gl1;
            }
            else if (hs1.Value == 1)
            {
                GridLength gl2 = (GridLength)myGridLengthConverter.ConvertFromString(li.Content.ToString());
                col2.Width = gl2;
            }
            else if (hs1.Value == 2)
            {
                GridLength gl3 = (GridLength)myGridLengthConverter.ConvertFromString(li.Content.ToString());
                col3.Width = gl3;
            }
        }
        //</Snippet1>
        private void changeRow(object sender, SelectionChangedEventArgs args)
        {
            ListBoxItem li2 = ((sender as ListBox).SelectedItem as ListBoxItem);
            GridLengthConverter myGridLengthConverter2 = new GridLengthConverter();

            if (hs2.Value == 0)
            {
                GridLength gl4 = (GridLength)myGridLengthConverter2.ConvertFromString(li2.Content.ToString());
                row1.Height = gl4;
            }
             else if (hs2.Value == 1)
            {
                GridLength gl5 = (GridLength)myGridLengthConverter2.ConvertFromString(li2.Content.ToString());
                row2.Height = gl5;
            }
             else if (hs2.Value == 2)
            {
               GridLength gl6 = (GridLength)myGridLengthConverter2.ConvertFromString(li2.Content.ToString());
               row3.Height = gl6;
            }

        }

        private void setMinWidth(object sender, RoutedEventArgs e)
        {
            col1.MinWidth = 100;
            col2.MinWidth = 100;
            col3.MinWidth = 100;
        }
        private void setMaxWidth(object sender, RoutedEventArgs e)
        {
            col1.MaxWidth = 125;
            col2.MaxWidth = 125;
            col3.MaxWidth = 125;
        }
        private void setMinHeight(object sender, RoutedEventArgs e)
        {
            row1.MinHeight = 50;
            row2.MinHeight = 50;
            row3.MinHeight = 50;
        }
        private void setMaxHeight(object sender, RoutedEventArgs e)
        {
            row1.MaxHeight = 75;
            row2.MaxHeight = 75;
            row3.MaxHeight = 75;
        }

    }
}