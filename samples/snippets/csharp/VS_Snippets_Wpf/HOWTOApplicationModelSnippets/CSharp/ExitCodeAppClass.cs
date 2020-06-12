using System;
using System.Windows;

namespace SDKSample
{
    class ExitCodeAppClass : Application
    {
        protected override void OnExit(ExitEventArgs e)
        {
            //<SnippetShutdownExitCode>
            Application.Current.Shutdown(11);
            //</SnippetShutdownExitCode>

            //<SnippetGetExitCode>
            int exitCode = e.ApplicationExitCode;
            //</SnippetGetExitCode>

            //<SnippetSetExitCode>
            e.ApplicationExitCode = 11;
            //</SnippetSetExitCode>
        }
    }
}
