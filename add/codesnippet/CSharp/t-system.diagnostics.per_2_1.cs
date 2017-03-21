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