//This is a list of commonly used namespaces for a pane.
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace ListBoxItemStyle
{
	/// <summary>
	/// Interaction logic for Pane1.xaml
	/// </summary>
        
        
	public partial class Pane1 : Grid
	{
        private void OnClick(object sender, RoutedEventArgs e) 
        {
        sp2.Children.Clear();
        //<Snippet1>       
        Style style = new Style(typeof(ListBoxItem));
        style.Setters.Add(new Setter(ListBoxItem.HorizontalContentAlignmentProperty,
             HorizontalAlignment.Stretch));
        ListBox lb = new ListBox();
        lb.ItemContainerStyle = style;
        ListBoxItem lbi1 = new ListBoxItem();
        Button btn = new Button();
        btn.Content = "Button as styled list box item.";
        lbi1.Content = (btn);
        lb.Items.Add(lbi1);
        //</Snippet1>

        ListBoxItem lbi2 = new ListBoxItem();
        Button btn2 = new Button();
        btn2.Content = "Button as styled list box item.";
        lbi2.Content = (btn2);
        lb.Items.Add(lbi2);
                   
        sp2.Children.Add(lb);
        }
         	
        }
        
 }