using System;
using System.Windows;
using System.Windows.Navigation;

namespace CSharp
{
    public partial class GetStringPageFunction : PageFunction<String>
    {
        public GetStringPageFunction()
        {
            InitializeComponent();

            // Retain this PageFunction in navigation history
            // after it has returned
            this.RemoveFromJournal = false;
        }

        // Only called the first time a PageFunction is navigated to
        protected override void Start()
        {
            base.Start();

            // Perform first time initialization
        }

        //<SnippetCallOnReturnCODE>
        void doneButton_Click(object sender, RoutedEventArgs e)
        {
            // Complete the page function and return data of type T
            OnReturn(new ReturnEventArgs<String>(this.pageFunctionData.Text));
        }
        //</SnippetCallOnReturnCODE>
    }
}