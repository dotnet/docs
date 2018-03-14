//<SNIPPET1>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Deployment.Application;
using Microsoft.Samples.ClickOnceOnDemand;

//<SNIPPET2>
namespace ClickOnceOnDemand
{
    [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand, Unrestricted=true)]
    public class Form1 : Form
    {
        // Maintain a dictionary mapping DLL names to download file groups. This is trivial for this sample,
        // but will be important in real-world applications where a feature is spread across multiple DLLs,
        // and you want to download all DLLs for that feature in one shot. 
        Dictionary<String, String> DllMapping = new Dictionary<String, String>();

        public static void Main()
        {
            Form1 NewForm = new Form1();
            Application.Run(NewForm);
        }

        public Form1()
        {
            // Configure form. 
            this.Size = new Size(500, 200);
            Button getAssemblyButton = new Button();
            getAssemblyButton.Size = new Size(130, getAssemblyButton.Size.Height);
            getAssemblyButton.Text = "Test Assembly";
            getAssemblyButton.Location = new Point(50, 50);
            this.Controls.Add(getAssemblyButton);
            getAssemblyButton.Click += new EventHandler(getAssemblyButton_Click);

            DllMapping["ClickOnceLibrary"] = "ClickOnceLibrary";
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
        }

        /*
         * Use ClickOnce APIs to download the assembly on demand.
         */
        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            Assembly newAssembly = null;

            if (ApplicationDeployment.IsNetworkDeployed)
            {
                ApplicationDeployment deploy = ApplicationDeployment.CurrentDeployment;

                // Get the DLL name from the Name argument.
                string[] nameParts = args.Name.Split(',');
                string dllName = nameParts[0];
                string downloadGroupName = DllMapping[dllName];

                try
                {
                    deploy.DownloadFileGroup(downloadGroupName);
                }
                catch (DeploymentException de)
                {
                    MessageBox.Show("Downloading file group failed. Group name: " + downloadGroupName + "; DLL name: " + args.Name);
                    throw (de);
                }

                // Load the assembly.
                // Assembly.Load() doesn't work here, as the previous failure to load the assembly
                // is cached by the CLR. LoadFrom() is not recommended. Use LoadFile() instead.
                try
                {
                    newAssembly = Assembly.LoadFile(Application.StartupPath + @"\" + dllName + ".dll," +  
			"Version=1.0.0.0, Culture=en, PublicKeyToken=03689116d3a4ae33");
                }
                catch (Exception e)
                {
                    throw (e);
                }
            }
            else
            {
                //Major error - not running under ClickOnce, but missing assembly. Don't know how to recover.
                throw (new Exception("Cannot load assemblies dynamically - application is not deployed using ClickOnce."));
            }


            return (newAssembly);
        }

        //<SNIPPET3>
        private void getAssemblyButton_Click(object sender, EventArgs e)
        {
            DynamicClass dc = new DynamicClass();
            MessageBox.Show("Message: " + dc.Message);
        }
        //</SNIPPET3>
    }
}
//</SNIPPET2>
//</SNIPPET1>