using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace UsingPageFunctionsSample
{
    //<SnippetPageFunctionReturnAResultCODEBEHIND>
    public partial class GetStringPageFunction : PageFunction<String>
    {
        public GetStringPageFunction()
        {
            InitializeComponent();
        }

        public GetStringPageFunction(string initialValue) : this()
        {
            this.stringTextBox.Text = initialValue;
        }

        void okButton_Click(object sender, RoutedEventArgs e)
        {
            // Page function is accepted, so return a result
            OnReturn(new ReturnEventArgs<string>(this.stringTextBox.Text));
        }

        void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Page function is cancelled, so don't return a result
            OnReturn(new ReturnEventArgs<string>(null));
        }
    }
    //</SnippetPageFunctionReturnAResultCODEBEHIND>
}