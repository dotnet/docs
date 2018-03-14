//<SnippetMarkupAndCodeBehindWindowCODEBEHIND>
using System.Windows;

namespace SDKSample
{
    public partial class MarkupAndCodeBehindWindow : Window
    {
        public MarkupAndCodeBehindWindow()
        {
            InitializeComponent();
        }

        void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button was clicked.");
        }
    }
}
//</SnippetMarkupAndCodeBehindWindowCODEBEHIND>