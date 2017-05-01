//<SnippetBrowseHomeCODEBEHIND>
using System.Windows;
using System.Windows.Input;

namespace SDKSample
{
    public partial class BrowseHome : Window
    {
        public BrowseHome()
        {
            InitializeComponent();
        }

        void navigationCommandBrowseHome_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // Can always navigate home
            e.CanExecute = true;
        }

        void navigationCommandBrowseHome_Executed(object target, ExecutedRoutedEventArgs e)
        {
            // Implement custom BrowseHome handling code
        }
    }
}
//</SnippetBrowseHomeCODEBEHIND>