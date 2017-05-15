//<SnippetCalledPageFunctionCODEBEHIND1>
//<SnippetAcceptsInitialDataCODEBEHIND1>
//<SnippetReturnCODEBEHIND1>
using System;
using System.Windows;
using System.Windows.Navigation;

namespace StructuredNavigationSample
{
    public partial class CalledPageFunction : PageFunction<String>
    {
        //</SnippetReturnCODEBEHIND1>
        //</SnippetAcceptsInitialDataCODEBEHIND1>
        public CalledPageFunction()
        {
            InitializeComponent();
        }
        //</SnippetCalledPageFunctionCODEBEHIND1>
        //<SnippetAcceptsInitialDataCODEBEHIND2>
        public CalledPageFunction(string initialDataItem1Value)
        {
            InitializeComponent();

            //</SnippetAcceptsInitialDataCODEBEHIND2>
            this.okButton.Click += new RoutedEventHandler(okButton_Click);
            this.cancelButton.Click += new RoutedEventHandler(cancelButton_Click);
            //<SnippetAcceptsInitialDataCODEBEHIND3>
            // Set initial value
            this.dataItem1TextBox.Text = initialDataItem1Value;
        }
        //<SnippetReturnCODEBEHIND2>
        //</SnippetAcceptsInitialDataCODEBEHIND3>
        void okButton_Click(object sender, RoutedEventArgs e)
        {
            // Accept when Ok button is clicked
            OnReturn(new ReturnEventArgs<string>(this.dataItem1TextBox.Text));
        }

        void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Cancel 
            OnReturn(null);
        }
        //<SnippetAcceptsInitialDataCODEBEHIND4>
        //<SnippetCalledPageFunctionCODEBEHIND2>
    }
}
//</SnippetReturnCODEBEHIND2>
//</SnippetAcceptsInitialDataCODEBEHIND4>
//</SnippetCalledPageFunctionCODEBEHIND2>