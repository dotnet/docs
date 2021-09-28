//<SnippetWindowWithFileExitCODEBEHIND>
using System.Windows;

namespace SDKSample
{
    public partial class WindowWithFileExit : System.Windows.Window
    {
        public WindowWithFileExit()
        {
            InitializeComponent();
        }

        void fileExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Close this window
            this.Close();
        }
    }
}
//</SnippetWindowWithFileExitCODEBEHIND>