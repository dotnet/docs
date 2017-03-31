using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CSharp
{
    public partial class GetStringPageFunctionCaller : Page
    {
        public GetStringPageFunctionCaller()
        {
            InitializeComponent();
        }

        //<SnippetHandlePageFunctionReturnCODE>
        void callPageFunctionButton_Click(object sender, RoutedEventArgs e)
        {
            // Create page function object
            GetStringPageFunction pageFunction = new GetStringPageFunction();

            // Detect when page function returns
            pageFunction.Return += new ReturnEventHandler<String>(PageFunction_Return);

            // Call page function
            this.NavigationService.Navigate(pageFunction);
        }

        void PageFunction_Return(object sender, ReturnEventArgs<String> e)
        {
            // Retrieve page function return value
            string returnValue = e.Result;
        }
        //</SnippetHandlePageFunctionReturnCODE>
    }
}