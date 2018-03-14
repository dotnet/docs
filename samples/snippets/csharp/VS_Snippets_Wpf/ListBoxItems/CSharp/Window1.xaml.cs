using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Data;

namespace ListBox_Index
{
	public partial class Window1 : Window
	{
	public Window1()
	{
	  InitializeComponent();
	}

	 //<Snippet2>	
         private void GetIndex0(object sender, RoutedEventArgs e)
         {
           ListBoxItem lbi = (ListBoxItem)
               (lb.ItemContainerGenerator.ContainerFromIndex(0));
           //<Snippet3>
           Item.Content = "The contents of the item at index 0 are: " +
               (lbi.Content.ToString()) + ".";
           //</Snippet3>
         }
         //</Snippet2>           
         private void GetIndex1(object sender, RoutedEventArgs e)
         {
           ListBoxItem lbi = (ListBoxItem)
               (lb.ItemContainerGenerator.ContainerFromIndex(1));
           Item.Content = "The contents of the item at index 1 are: " +
               (lbi.Content.ToString()) + ".";
         } 
         private void GetIndex2(object sender, RoutedEventArgs e)
         {
           ListBoxItem lbi = (ListBoxItem)
               (lb.ItemContainerGenerator.ContainerFromIndex(2));
           Item.Content = "The contents of the item at index 2 are: " +
               (lbi.Content.ToString()) + ".";
         } 
         private void GetIndex3(object sender, RoutedEventArgs e)
         {
          ListBoxItem lbi = (ListBoxItem)
               (lb.ItemContainerGenerator.ContainerFromIndex(3));
          Item.Content = "The contents of the item at index 3 are: " +
               (lbi.Content.ToString()) + ".";
         } 
    }
}