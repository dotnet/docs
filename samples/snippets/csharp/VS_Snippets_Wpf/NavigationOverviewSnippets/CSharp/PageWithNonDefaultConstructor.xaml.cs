//<SnippetPageWithNonDefaultConstructorCODEBEHIND>
using System.Windows.Controls; // Page

namespace SDKSample
{
    public partial class PageWithNonDefaultConstructor : Page
    {
        public PageWithNonDefaultConstructor(string message)
        {
            InitializeComponent();

            this.Content = message;
        }
    }
}
//</SnippetPageWithNonDefaultConstructorCODEBEHIND>