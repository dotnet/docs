//<SnippetSearchCODEBEHIND>
using System.Windows;
using System.Windows.Input;

namespace SDKSample
{
    public partial class Search : Window
    {
        public Search()
        {
            InitializeComponent();
        }

        void navigationCommandSearch_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            // Can search of there is a document
            e.CanExecute = (this.flowDocumentPageViewer.Document != null);
        }

        void navigationCommandSearch_Executed(object target, ExecutedRoutedEventArgs e)
        {
            // Implement custom Search handling code
        }
    }
}
//</SnippetSearchCODEBEHIND>