//<SnippetPassingDataCODEBEHIND1>
//<SnippetCallingPageDefaultCODEBEHIND1>
//<SnippetSendDataCODEBEHIND1>
//<SnippetProcessResultCODEBEHIND1>
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace StructuredNavigationSample
{
    public partial class CallingPage : Page
    {
        //</SnippetProcessResultCODEBEHIND1>
        public CallingPage()
        {
            InitializeComponent();
            //</SnippetCallingPageDefaultCODEBEHIND1>
            this.pageFunctionHyperlink.Click += new RoutedEventHandler(pageFunctionHyperlink_Click);
            //<SnippetCallingPageDefaultCODEBEHIND2>
        }
        //</SnippetCallingPageDefaultCODEBEHIND2>
        //<SnippetProcessResultCODEBEHIND2>
        void pageFunctionHyperlink_Click(object sender, RoutedEventArgs e)
        {
            
            // Instantiate and navigate to page function
            CalledPageFunction CalledPageFunction = new CalledPageFunction("Initial Data Item Value");
            //</SnippetPassingDataCODEBEHIND1>
            //</SnippetSendDataCODEBEHIND1>
            CalledPageFunction.Return += pageFunction_Return;
            //<SnippetSendDataCODEBEHIND2>
            this.NavigationService.Navigate(CalledPageFunction);
            //<SnippetPassingDataCODEBEHIND2>
        }
        //</SnippetPassingDataCODEBEHIND2>
        //</SnippetSendDataCODEBEHIND2>
        void pageFunction_Return(object sender, ReturnEventArgs<string> e)
        {
            this.pageFunctionResultsTextBlock.Visibility = Visibility.Visible;

            // Display result
            this.pageFunctionResultsTextBlock.Text = (e != null ? "Accepted" : "Canceled");

            // If page function returned, display result and data
            if (e != null)
            {
                this.pageFunctionResultsTextBlock.Text += "\n" + e.Result;
            }
        }
        //<SnippetSendDataCODEBEHIND3>
        //<SnippetPassingDataCODEBEHIND3>
        //<SnippetCallingPageDefaultCODEBEHIND3>
    }
}
//</SnippetProcessResultCODEBEHIND2>
//</SnippetSendDataCODEBEHIND3>
//</SnippetPassingDataCODEBEHIND3>
//</SnippetCallingPageDefaultCODEBEHIND3>