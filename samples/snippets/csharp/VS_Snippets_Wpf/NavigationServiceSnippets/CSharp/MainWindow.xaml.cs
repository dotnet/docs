using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Diagnostics;

namespace NavigationServiceSnippetSample_CSharp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        NavigationService NavigationService
        {
            get
            {
                return this.browserFrame.NavigationService;
            }
        }

        void MainWindow_Loaded(object sender, EventArgs e)
        {
            this.NavigationService.Navigating += new NavigatingCancelEventHandler(NavigationService_Navigating);
            this.NavigationService.Navigated += new NavigatedEventHandler(NavigationService_Navigated);
            this.NavigationService.NavigationProgress += new NavigationProgressEventHandler(NavigationService_NavigationProgress);
            this.NavigationService.LoadCompleted += new LoadCompletedEventHandler(NavigationService_LoadCompleted);
            this.NavigationService.NavigationStopped += new NavigationStoppedEventHandler(NavigationService_NavigationStopped);
            this.NavigationService.FragmentNavigation += NavigationService_FragmentNavigation;
            this.NavigationService.NavigationFailed += new NavigationFailedEventHandler(NavigationService_NavigationFailed);
            this.NavigationService.Navigate(new Uri(this.addressTextBox.Text));
        }

        //<SnippetMainWindowNavigateCODE>
        void goButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri(this.addressTextBox.Text));
        }
        //</SnippetMainWindowNavigateCODE>

        //<SnippetMainWindowNavigateObjectCODE>
        void goObjectButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ContentPage());
        }
        //</SnippetMainWindowNavigateObjectCODE>

        //<SnippetMainWindowBackCODE>
        void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }
        //</SnippetMainWindowBackCODE>
        //<SnippetMainWindowForwardCODE>
        void forwardButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoForward)
            {
                this.NavigationService.GoForward();
            }
        }
        //</SnippetMainWindowForwardCODE>
        //<SnippetMainWindowStopLoadingCODE>
        void stopButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.StopLoading();
        }
        //</SnippetMainWindowStopLoadingCODE>
        //<SnippetMainWindowRefreshCODE>
        void refreshButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Refresh();
        }
        //</SnippetMainWindowRefreshCODE>

        //<SnippetMainWindowNavigatingCODE>
        void NavigationService_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            // Don't allow refreshing of a static page
            if ((e.NavigationMode == NavigationMode.Refresh) &&
                (e.Uri.OriginalString == "StaticPage.xaml"))
            {
                e.Cancel = true;
            }
        }
        //</SnippetMainWindowNavigatingCODE>

        //<SnippetMainWindowNavigatedCODE>
        void NavigationService_Navigated(object sender, NavigationEventArgs e)
        {
            string msg = string.Format("Downloading {0}.", e.Uri.OriginalString);
            this.progressStatusBarItem.Content = msg;
        }
        //</SnippetMainWindowNavigatedCODE>

        //<SnippetMainWindowNavigationProgressCODE>
        void NavigationService_NavigationProgress(object sender, NavigationProgressEventArgs e)
        {
            string msg = string.Format("{0} of {1} bytes retrieved.", e.BytesRead, e.MaxBytes);
            this.progressStatusBarItem.Content = msg;
        }
        //</SnippetMainWindowNavigationProgressCODE>

        //<SnippetMainWindowLoadCompletedCODE>
        void NavigationService_LoadCompleted(object sender, NavigationEventArgs e)
        {
            string msg = string.Format("{0} loaded.", e.Uri.OriginalString);
            this.progressStatusBarItem.Content = msg;
        }
        //</SnippetMainWindowLoadCompletedCODE>

        //<SnippetMainWindowNavigationStoppedCODE>
        void NavigationService_NavigationStopped(object sender, NavigationEventArgs e)
        {
            this.progressStatusBarItem.Content = "Navigation stopped.";
        }
        //</SnippetMainWindowNavigationStoppedCODE>

        //<SnippetMainWindowNavigationFailedCODE>
        void NavigationService_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            string msg = string.Format("Navigation to {0} failed: {1}.", e.Uri.OriginalString, e.Exception.Message);
            this.progressStatusBarItem.Content = msg;
        }
        //</SnippetMainWindowNavigationFailedCODE>
        
        //<SnippetMainWindowFragmentNavigationCODE>
        void NavigationService_FragmentNavigation(object sender, FragmentNavigationEventArgs e)
        {
            // Get content the ContentControl that contains the XAML page that was navigated to
            object content = ((ContentControl)e.Navigator).Content;

            // Find the fragment, which is the FrameworkElement with its Name attribute set
            FrameworkElement fragmentElement = LogicalTreeHelper.FindLogicalNode((DependencyObject)content, e.Fragment) as FrameworkElement;

            // If fragment found, bring it into view, or open an error page
            if (fragmentElement == null)
            {
                this.NavigationService.Navigate(new FragmentNotFoundPage());

                // Don't let NavigationService handle this event, since we just did
                e.Handled = true;
            }
        }
        //</SnippetMainWindowFragmentNavigationCODE>
    }
}