//<SnippetMarkupAndCodeBehindWindowCODEBEHIND>
using System.Windows;

namespace SDKSample
{
    public partial class MarkupAndCodeBehindWindow : Window
    {
        public MarkupAndCodeBehindWindow()
        {
            InitializeComponent();

            // Register event handler with button Click event
            button.Click += new RoutedEventHandler(button_Click);
        }

        void button_Click(object sender, RoutedEventArgs e)
        {
            // Show message box when button is clicked
            MessageBox.Show("Hello, Windows Presentation Foundation!");
        }
    }
}
//</SnippetMarkupAndCodeBehindWindowCODEBEHIND>