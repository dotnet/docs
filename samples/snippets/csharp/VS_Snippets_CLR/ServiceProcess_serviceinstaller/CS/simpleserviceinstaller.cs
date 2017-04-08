// System.ServiceProcess.ServiceInstaller

// The following example demonstrates the ServiceInstaller class.
// It defines the instance SimpleServiceInstaller with the
// attribute RunInstallerAttribute.
//
// When this file is built with the SimpleService.cs file, 
// the resulting executable can be used to install the service.
//
// Steps:
//     1) Run this program using the following command: 
//          InstallUtil.exe  <filename.exe>
//     2) Uninstall the service created in step 1 using the
//        following command:
//          InstallUtil.exe /u <filename.exe>

// 
using System;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

[RunInstaller(true)]
public class SimpleServiceInstaller : System.Configuration.Install.Installer
{
    private System.ServiceProcess.ServiceInstaller simpleServiceInstaller;
    private System.ServiceProcess.ServiceProcessInstaller simpleServiceProcessInstaller;

    public SimpleServiceInstaller()
    {
        // <Snippet3>
        simpleServiceProcessInstaller = new ServiceProcessInstaller();
        simpleServiceInstaller = new ServiceInstaller();
                       
        // Set the account properties for the service process.
        simpleServiceProcessInstaller.Account = ServiceAccount.LocalService;
             
        // Set the installation properties for the service.
        // The ServiceInstaller.ServiceName must match the 
        // ServiceBase.ServiceName set in the service
        // implementation that is installed by this installer.
        simpleServiceInstaller.ServiceName = "SimpleService";

        simpleServiceInstaller.DisplayName = "Simple Service";
        simpleServiceInstaller.Description = "A simple service that runs on the local computer.";
        simpleServiceInstaller.StartType = ServiceStartMode.Manual;

        // Add the installers to the Installer collection.
        Installers.Add(simpleServiceInstaller);
        Installers.Add(simpleServiceProcessInstaller);
        // </Snippet3>
        
    }

    public static void InstallMain()
    {
        Console.WriteLine("Usage: InstallUtil.exe [<install>.exe | <install>.dll]");
    }

}
// 