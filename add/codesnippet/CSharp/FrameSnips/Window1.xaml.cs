using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Navigation;



namespace FrameSnips
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Page
    {

        public Window1()
        {
            InitializeComponent();
        }

        private void InitializeFrameSnip(object sender, EventArgs e)
        {
            //<SnippetFrameSource>
            myFrame.Source = new Uri("http://www.msn.com");
            //</SnippetFrameSource>
        }

        int i = 0;
        private void onClick(object sender, RoutedEventArgs args)
        {
            i++;
          //<SnippetFrameNavigateSetup>  
            StackPanel myStackPanel = new StackPanel();
            Button myButton = new Button();
            myButton.Content = "Press me";
            myStackPanel.Children.Add(myButton);
          //</SnippetFrameNavigateSetup>  
      
          //<SnippetFrameNavigateObject>       
            myFrame.Navigate(myStackPanel);
          //</SnippetFrameNavigateObject>

            //<SnippetFrameNavigateObjectObject>   
            myFrame.Navigate(myStackPanel, myFrame);
            //</SnippetFrameNavigateObjectObject>  
 
           //<SnippetFrameNavigateUri>   
           myFrame.Navigate(new Uri("http://www.yahoo.com"));
           //</SnippetFrameNavigateUri>  

	   //<SnippetFrameNavigateUriObject>
            myFrame.Navigate(new Uri("http://www.yahoo.com"),myFrame);
           //</SnippetFrameNavigateUriObject>
 

           //<SnippetFrameNavigateRefresh>
           myFrame.Refresh();
           //</SnippetFrameNavigateRefresh>
        }

        private void onNavigated(object sender, NavigationEventArgs args)
        {
            
        }
        

    }
}