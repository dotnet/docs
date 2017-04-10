//<SnippetAddInUICodeBehind>
using System.Windows; // MessageBox, RoutedEventArgs
using System.Windows.Controls; // UserControl

namespace WPFAddIn1
{
    public partial class AddInUI : UserControl
    {
        public AddInUI()
        {
            InitializeComponent();
        }

        void clickMeButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello from WPFAddIn1");
        }
    }
}
//</SnippetAddInUICodeBehind>