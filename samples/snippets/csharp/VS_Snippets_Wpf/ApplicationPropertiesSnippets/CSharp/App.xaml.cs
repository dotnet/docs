//<SnippetHandleStartupCODEBEHIND>
using System;
using System.Windows;

namespace CSharp
{
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            // Parse command line arguments for "/SafeMode"
            this.Properties["SafeMode"] = false;
            for (int i = 0; i != e.Args.Length; ++i)
            {
                if (e.Args[i].ToLower() == "/safemode")
                {
                    this.Properties["SafeMode"] = true;
                    break;
                }
            }
        }
    }
}
//</SnippetHandleStartupCODEBEHIND>