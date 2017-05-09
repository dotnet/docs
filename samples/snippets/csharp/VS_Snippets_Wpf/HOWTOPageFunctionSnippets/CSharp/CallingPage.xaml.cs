using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace UsingPageFunctionsSample
{
    public partial class CallingPage : Page
    {
        public CallingPage()
        {
            InitializeComponent();
        }

        void callPageFunctionLikeAPage_Click(object sender, RoutedEventArgs e)
        {
            //<SnippetNavigateToAPageFunctionLikeAPageCODEBEHIND>
            // Navigate to a page function like a page
            Uri pageFunctionUri = new Uri("GetStringPageFunction.xaml", UriKind.Relative);
            this.NavigationService.Navigate(pageFunctionUri);
            //</SnippetNavigateToAPageFunctionLikeAPageCODEBEHIND>
        }

        //<SnippetCallAPageFunctionCODEBEHIND>
        void callPageFunctionHyperlink_Click(object sender, RoutedEventArgs e)
        {
            // Call a page function
            GetStringPageFunction pageFunction = new GetStringPageFunction("initialValue");
            this.NavigationService.Navigate(pageFunction);
        }
        //</SnippetCallAPageFunctionCODEBEHIND>

        //<SnippetGetPageFunctionResultCODEBEHIND>
        void callPageFunctionAndReturnHyperlink_Click(object sender, RoutedEventArgs e)
        {
            // Call a page function and hook up page function's return event to get result
            GetStringPageFunction pageFunction = new GetStringPageFunction();
            pageFunction.Return += new ReturnEventHandler<String>(GetStringPageFunction_Returned);
            this.NavigationService.Navigate(pageFunction);
        }
        void GetStringPageFunction_Returned(object sender, ReturnEventArgs<String> e)
        {
            // Get the result, if a result was passed.
            if (e.Result != null)
            {
                Console.WriteLine(e.Result);
            }
        }
        //</SnippetGetPageFunctionResultCODEBEHIND>
    }
}