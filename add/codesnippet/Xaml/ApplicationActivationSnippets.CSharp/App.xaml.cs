//<SnippetDetectActivationStateCODEBEHIND>
using System; // EventArgs
using System.Windows; // Application

namespace SDKSample
{
    public partial class App : Application
    {
        bool isApplicationActive;

        void App_Activated(object sender, EventArgs e)
        {
            // Application activated
            this.isApplicationActive = true;
        }

        void App_Deactivated(object sender, EventArgs e)
        {
            // Application deactivated
            this.isApplicationActive = false;
        }
    }
}
//</SnippetDetectActivationStateCODEBEHIND>