// System.Diagnostics.PerformanceCounterInstaller
/*
The following example demonstrates 'PerformanceCounterInstaller' class.
A class is inherited from 'Installer' having 'RunInstallerAttribute' set to true.
A new instance of 'PerformanceCounterInstaller' is created and its 'CategoryName'
is set. Then this instance is added to 'InstallerCollection'.
Note: 
1)To run this example use the following command:
   InstallUtil.exe PerformanceCounterInstaller.exe
2)To uninstall the perfomance counter use the following command:
   InstallUtil.exe /u PerformanceCounterInstaller.exe
*/
// <Snippet1>
using System;
using System.Configuration.Install;
using System.Diagnostics;
using System.ComponentModel;

[RunInstaller(true)]
public class MyPerformanceCounterInstaller : Installer
{
    public MyPerformanceCounterInstaller()
    {
        try
        {
            // Create an instance of 'PerformanceCounterInstaller'.
            PerformanceCounterInstaller myPerformanceCounterInstaller =
               new PerformanceCounterInstaller();
            // Set the 'CategoryName' for performance counter.
            myPerformanceCounterInstaller.CategoryName =
               "MyPerformanceCounter";
            CounterCreationData myCounterCreation = new CounterCreationData();
            myCounterCreation.CounterName = "MyCounter";
            myCounterCreation.CounterHelp = "Counter Help";
            // Add a counter to collection of  myPerformanceCounterInstaller.
            myPerformanceCounterInstaller.Counters.Add(myCounterCreation);
            Installers.Add(myPerformanceCounterInstaller);
        }
        catch (Exception e)
        {
            this.Context.LogMessage("Error occured :" + e.Message);
        }
    }
    public static void Main()
    {
    }
}
// </Snippet1>
