//<SnippetAppCODEBEHIND>
using System.Windows;
namespace SDKSample
{
    public partial class App : Application
    {
        void app_Startup(object sender, StartupEventArgs e)
        {
            // Create a window
            MarkupAndCodeBehindWindow window = new MarkupAndCodeBehindWindow();

            // Open a window
            window.Show();
        }
    }
}
//</SnippetAppCODEBEHIND>