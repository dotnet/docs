// System.Diagnostics.EventLogInstaller

// The following example demonstrates the EventLogInstaller class.
// It defines the instance MyEventLogInstaller with the
// attribute RunInstallerAttribute.
//
// The Log and Source properties of the new instance are set,
// and the instance is added to the Installers collection.
//
// Note:
//     1) Run this program using the following command: 
//          InstallUtil.exe  <filename.exe>
//     2) Uninstall the event log created in step 1 using the
//        following command:
//          InstallUtil.exe /u <filename.exe>

// <Snippet1>
using System;
using System.Configuration.Install;
using System.Diagnostics;
using System.ComponentModel;

[RunInstaller(true)]
public class MyEventLogInstaller: Installer
{
    private EventLogInstaller myEventLogInstaller;

    public MyEventLogInstaller() 
    {
        // Create an instance of an EventLogInstaller.
        myEventLogInstaller = new EventLogInstaller();

        // Set the source name of the event log.
        myEventLogInstaller.Source = "NewLogSource";

        // Set the event log that the source writes entries to.
        myEventLogInstaller.Log = "MyNewLog";

        // Add myEventLogInstaller to the Installer collection.
        Installers.Add(myEventLogInstaller);   
    }

    public static void Main()
    {
        MyEventLogInstaller myInstaller = new MyEventLogInstaller();
    }
}
// </Snippet1> 
