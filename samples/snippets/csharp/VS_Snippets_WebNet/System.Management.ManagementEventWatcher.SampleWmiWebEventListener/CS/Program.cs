//<snippet1>
using System;
using System.Text;
using System.Management;

namespace SamplesAspNet
{
    // Capture WMI events associated with 
    // ASP.NET health monitoring types. 
    class SampleWmiWebEventListener
    {
        // Displays event-related information.
        static void DisplayEventInformation(
            ManagementBaseObject ev)
        {

            // This will hold the name of the 
            // event class as defined in the 
            // Aspnet.mof file.
            string eventTypeName;

            // Get the name of the WMI-raised event.
            eventTypeName = ev.ClassPath.ToString();

            // Process the raised event.
            switch (eventTypeName)
            {
                // Process the heartbeat event.  
                case "HeartBeatEvent":
                    Console.WriteLine("HeartBeat");
                    Console.WriteLine("\tProcess: {0}",
                        ev["ProcessName"]);
                    Console.WriteLine("\tApp: {0}",
                        ev["ApplicationUrl"]);
                    Console.WriteLine("\tWorkingSet: {0}",
                        ev["WorkingSet"]);
                    Console.WriteLine("\tThreads: {0}",
                        ev["ThreadCount"]);
                    Console.WriteLine("\tManagedHeap: {0}",
                        ev["ManagedHeapSize"]);
                    Console.WriteLine("\tAppDomainCount: {0}",
                        ev["AppDomainCount"]);
                    break;

                // Process the request error event. 
                case "RequestErrorEvent":
                    Console.WriteLine("Error");
                    Console.WriteLine("Url: {0}",
                        ev["RequestUrl"]);
                    Console.WriteLine("Path: {0}",
                        ev["RequestPath"]);
                    Console.WriteLine("Message: {0}",
                        ev["EventMessage"]);
                    Console.WriteLine("Stack: {0}",
                        ev["StackTrace"]);
                    Console.WriteLine("UserName: {0}",
                        ev["UserName"]);
                    Console.WriteLine("ThreadID: {0}",
                        ev["ThreadAccountName"]);
                    break;

                // Process the application lifetime event. 
                case "ApplicationLifetimeEvent":
                    Console.WriteLine("App Lifetime Event {0}",
                        ev["EventMessage"]);

                    break;

                // Handle events for which processing is not
                // provided.
                default:
                    Console.WriteLine("ASP.NET Event {0}",
                        ev["EventMessage"]);
                    break;
            }
        } // End DisplayEventInformation.

        // The main entry point for the application.
        static void Main(string[] args)
        {
            // Get the name of the computer on 
            // which this program runs.
            // Note that the monitored application must also run 
            // on this computer.
            string machine = Environment.MachineName;

            // Define the Common Information Model (CIM) path 
            // for WMI monitoring. 
            string path = String.Format("\\\\{0}\\root\\aspnet", machine);

            // Create a managed object watcher as 
            // defined in System.Management.
            string query = "select * from BaseEvent";
            ManagementEventWatcher watcher =
                new ManagementEventWatcher(query);

            // Set the watcher options.
            TimeSpan timeInterval = new TimeSpan(0, 1, 30);
            watcher.Options =
                new EventWatcherOptions(null,
                timeInterval, 1);

            // Set the scope of the WMI events to 
            // watch to be ASP.NET applications.
            watcher.Scope =
                new ManagementScope(new ManagementPath(path));

            // Set the console background.
            Console.BackgroundColor = ConsoleColor.Blue;
            // Set the foreground color.
            Console.ForegroundColor = ConsoleColor.Yellow;
            // Clear the console.
            Console.Clear();

            // Loop indefinitely to catch the events.
            Console.WriteLine(
                "Listener started. Enter Cntl-C to terminate");


            while (true)
            {
                try
                {
                    // Capture the WMI event related to 
                    // the Web event.
                    ManagementBaseObject ev =
                        watcher.WaitForNextEvent();
                    // Display the Web event information.
                    DisplayEventInformation(ev);

                    // Prompt the user.
                    Console.Beep();

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: {0}", e);
                    break;
                }
            }
        }
    }
}
//</snippet1>