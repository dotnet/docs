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