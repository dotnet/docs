//<SnippetZoomCODEBEHIND>
using System.Windows;
using System.Windows.Input;

namespace SDKSample
{
    public partial class Zoom : Window
    {
        public Zoom()
        {
            InitializeComponent();
        }

        void navigationCommandZoom_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            bool canExecute;

            // Can zoom if there is a document
            canExecute = (this.flowDocumentPageViewer.Document != null);

            // Can zoom if the current zoom is not the same as the desired zoom
            if (e.Parameter != null)
            {
                double desiredZoom = double.Parse(e.Parameter.ToString());
                canExecute = (this.flowDocumentPageViewer.Zoom != desiredZoom);
            }

            e.CanExecute = canExecute;
        }

        void navigationCommandZoom_Executed(object target, ExecutedRoutedEventArgs e)
        {
            // Change zoom
            double desiredZoom = double.Parse(e.Parameter.ToString());
            this.flowDocumentPageViewer.Zoom = desiredZoom;
        }
    }
}
//</SnippetZoomCODEBEHIND>