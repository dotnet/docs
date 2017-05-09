//<SnippetHandlingSessionEndingCODEBEHIND>
using System.Windows;

namespace SDKSample
{
    public partial class App : Application
    {
        void App_SessionEnding(object sender, SessionEndingCancelEventArgs e)
        {
            // Ask the user if they want to allow the session to end
            string msg = string.Format("{0}. End session?", e.ReasonSessionEnding);
            MessageBoxResult result = MessageBox.Show(msg, "Session Ending", MessageBoxButton.YesNo);

            // End session, if specified
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
//</SnippetHandlingSessionEndingCODEBEHIND>