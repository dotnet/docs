//<SnippetDataBindingCODEBEHIND>
using System.Windows;

namespace SDKSample
{
    public partial class DataBindingWindow : Window
    {
        public DataBindingWindow()
        {
            InitializeComponent();

            // Create Person data source
            Person person = new Person();

            // Make data source available for binding
            this.DataContext = person;
        }
    }
}
//</SnippetDataBindingCODEBEHIND>