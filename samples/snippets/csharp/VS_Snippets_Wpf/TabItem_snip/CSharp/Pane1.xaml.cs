using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Threading;

namespace TabControl
{
	/// <summary>
	/// Interaction logic for Pane1.xaml
	/// </summary>
        	
        public partial class Pane1 : StackPanel
	{
        
	 System.Windows.Controls.TabControl tabcon;
         System.Windows.Controls.TabItem ti1, ti2, ti3;

         void OnClick(object sender, RoutedEventArgs e)
         {
         //<Snippet2>
         tabcon = new System.Windows.Controls.TabControl();
         ti1 = new TabItem();
         ti1.Header = "Background";
         tabcon.Items.Add(ti1);
         ti2 = new TabItem();
         ti2.Header = "Foreground";
         tabcon.Items.Add(ti2);
         ti3 = new TabItem();
         ti3.Header = "FontFamily";
         tabcon.Items.Add(ti3);
         
	 cv2.Children.Add(tabcon);
         //</Snippet2>
         }
        void OnSelectionChanged(object sender, RoutedEventArgs e)
         {
           //<SnippetTabItemPlacement>
           if(tabItem1.TabStripPlacement == Dock.Left)
             {
              btnPlacement.Content = "TabItems are placed on the left";
             }
            //</SnippetTabItemPlacement>
         }
       }
}