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

		
         private void PrintText(object sender, SelectionChangedEventArgs args)

         {
           ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
           if( lbi == null ) return; // don't tostring null
           label1.Content = "You chose " + lbi.Content.ToString() + "."; 
           
         } 
       }
     
    
    
}