//<SNIPPET1>
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.Deployment.Application;
using System.Reflection;

namespace ClickOnce.SatelliteAssemblies
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ja-JP");

            // Call this before initializing the main form, which will cause the resource manager
            // to look for the appropriate satellite assembly.
            GetSatelliteAssemblies(Thread.CurrentThread.CurrentCulture.ToString());

            Application.Run(new Form1());
        }

        static void GetSatelliteAssemblies(string groupName)
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment deploy = ApplicationDeployment.CurrentDeployment;

                if (deploy.IsFirstRun)
                {
                    try
                    {
                        deploy.DownloadFileGroup(groupName);
                    }
                    catch (DeploymentException de)
                    {
                        // Log error. Do not report error to the user, as there may not be a satellite
                        // assembly if the user's culture and the application's default culture match.
                    }
                }
            }
        }

    }
}
//</SNIPPET1>