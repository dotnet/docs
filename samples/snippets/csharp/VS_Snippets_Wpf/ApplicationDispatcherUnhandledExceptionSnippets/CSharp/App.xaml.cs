//<SnippetHandleDispatcherUnhandledExceptionCODEBEHIND1>
using System.Windows;
using System.Windows.Threading;

namespace SDKSample
{
    public partial class App : Application
    {
        void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // Process unhandled exception
            //</SnippetHandleDispatcherUnhandledExceptionCODEBEHIND1>
          
            // Prevent snippet weirdness

            //<SnippetHandleDispatcherUnhandledExceptionCODEBEHIND2>
            // Prevent default unhandled exception processing
            e.Handled = true;
        }
    }
}
//</SnippetHandleDispatcherUnhandledExceptionCODEBEHIND2>