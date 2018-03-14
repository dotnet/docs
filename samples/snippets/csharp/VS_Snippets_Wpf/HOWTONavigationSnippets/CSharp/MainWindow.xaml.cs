using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace HOWTONavigationSnippets
{
    public partial class MainWindow : NavigationWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            //<SnippetNavigateToPageCODE>
            //<SnippetNavigateToPageSrcCODE>
            // Navigate to URI using the Source property
            //<SnippetNavigateAndCancelCODE1>
            this.Source = new Uri("HomePage.xaml", UriKind.Relative);           
            //</SnippetNavigateAndCancelCODE1>
            //</SnippetNavigateToPageSrcCODE>
            
            //<SnippetNavigateToPageNavCODE>
            // Navigate to URI using the Navigate method
            this.Navigate(new Uri("HomePage.xaml", UriKind.Relative));
            //</SnippetNavigateToPageNavCODE>

            //<SnippetNavigateToPageObjCODE>
            // Navigate to object using the Navigate method
            this.Navigate(new HomePage());
            //</SnippetNavigateToPageObjCODE>
            //</SnippetNavigateToPageCODE>        

            Button navigateRefreshButton = new Button();
            navigateRefreshButton.Click += navigateRefreshButton_Click;

            Button navigateStopButton = new Button();
            navigateStopButton.Click += navigateStopButton_Click;
        }

        //<SnippetNavigateStopLoadingCODE>
        void navigateStopButton_Click(object sender, RoutedEventArgs e)
        {
            this.StopLoading();
        }
        //</SnippetNavigateStopLoadingCODE>

        //<SnippetNavigateRefreshCODE>
        void navigateRefreshButton_Click(object sender, RoutedEventArgs e)
        {
            this.Refresh();
        }
        //</SnippetNavigateRefreshCODE>

    }
}