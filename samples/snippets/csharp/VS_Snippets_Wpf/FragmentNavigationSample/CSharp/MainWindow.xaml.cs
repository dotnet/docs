using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace FragmentNavigationSample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void goButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to Uri, with or with out fragment
            // NOTE - Uri with fragment looks like "DocumentPage.xaml#Fragment5"
            Uri uri = new Uri(this.addressTextBox.Text, UriKind.RelativeOrAbsolute);
            this.browserFrame.Navigate(uri);
        }
        //<SnippetFEBringIntoView>
        void browserFrame_FragmentNavigation(object sender, FragmentNavigationEventArgs e)
        {
            object content = ((ContentControl)e.Navigator).Content;
            FrameworkElement fragmentElement = LogicalTreeHelper.FindLogicalNode((DependencyObject)content, e.Fragment) as FrameworkElement;
            if (fragmentElement == null)
            {
                // Redirect to error page
                // Note - You can't navigate from within a FragmentNavigation event handler,
                //        hence creation of an async dispatcher work item
                this.Dispatcher.BeginInvoke(
                    DispatcherPriority.Send,
                    (DispatcherOperationCallback) delegate(object unused) 
                    {
                        this.browserFrame.Navigate(new Uri("FragmentNotFoundPage.xaml", UriKind.Relative));
                        return null;
                    },
                    null);
                e.Handled = true;
            }
        }
        //</SnippetFEBringIntoView>
    }
}