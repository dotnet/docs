//<SnippetAddInUICodeBehind>
using System.Windows;
using System.Windows.Controls;

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