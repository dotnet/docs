//<Snippet1>
using System;
using System.ServiceProcess;
using System.Diagnostics;
using System.Threading;

namespace ServiceControllerSample
{
    class Program
    {
        public enum SimpleServiceCustomCommands
        { StopWorker = 128, RestartWorker, CheckWorker };
        static void Main(string[] args)
        {
            ServiceController[] scServices;
            scServices = ServiceController.GetServices();

            foreach (ServiceController scTemp in scServices)
            {

                if (scTemp.ServiceName == "Simple Service")
                {
                    //<Snippet2>
                    // Display properties for the Simple Service sample
                    // from the ServiceBase example.
                    ServiceController sc = new ServiceController("Simple Service");
                    Console.WriteLine("Status = " + sc.Status);
                    Console.WriteLine("Can Pause and Continue = " + sc.CanPauseAndContinue);
                    Console.WriteLine("Can ShutDown = " + sc.CanShutdown);
                    Console.WriteLine("Can Stop = " + sc.CanStop);
                    //</Snippet2>
                    if (sc.Status == ServiceControllerStatus.Stopped)
                    {
                        sc.Start();
                        while (sc.Status == ServiceControllerStatus.Stopped)
                        {
                            Thread.Sleep(1000);
                            sc.Refresh();
                        }
                    }
                    //<Snippet3>
                    // Issue custom commands to the service
                    // enum SimpleServiceCustomCommands 
                    //    { StopWorker = 128, RestartWorker, CheckWorker };
                    sc.ExecuteCommand((int)SimpleServiceCustomCommands.StopWorker);
                    sc.ExecuteCommand((int)SimpleServiceCustomCommands.RestartWorker);
                    //</Snippet3>
                    //<Snippet4>
                    sc.Pause();
                    while (sc.Status != ServiceControllerStatus.Paused)
                    {
                        Thread.Sleep(1000);
                        sc.Refresh();
                    }
                    Console.WriteLine("Status = " + sc.Status);
                    //</Snippet4>
                    //<Snippet5>
                    sc.Continue();
                    while (sc.Status == ServiceControllerStatus.Paused)
                    {
                        Thread.Sleep(1000);
                        sc.Refresh();
                    }
                    Console.WriteLine("Status = " + sc.Status);
                    //</Snippet5>
                    //<Snippet6>
                    sc.Stop();
                    while (sc.Status != ServiceControllerStatus.Stopped)
                    {
                        Thread.Sleep(1000);
                        sc.Refresh();
                    }
                    Console.WriteLine("Status = " + sc.Status);
                    //</Snippet6>
                    //<Snippet7>
                    String[] argArray = new string[] { "ServiceController arg1", "ServiceController arg2" };
                    sc.Start(argArray);
                    while (sc.Status == ServiceControllerStatus.Stopped)
                    {
                        Thread.Sleep(1000);
                        sc.Refresh();
                    }
                    Console.WriteLine("Status = " + sc.Status);
                    //</Snippet7>
                    // Display the event log entries for the custom commands
                    // and the start arguments.
                    EventLog el = new EventLog("Application");
                    EventLogEntryCollection elec = el.Entries;
                    foreach (EventLogEntry ele in elec)
                    {
                        if (ele.Source.IndexOf("SimpleService.OnCustomCommand") >= 0 |
                            ele.Source.IndexOf("SimpleService.Arguments") >= 0)
                            Console.WriteLine(ele.Message);
                    }
                }
            }


        }
    }
}
// This sample displays the following output if the Simple Service
// sample is running:
//Status = Running
//Can Pause and Continue = True
//Can ShutDown = True
//Can Stop = True
//Status = Paused
//Status = Running
//Status = Stopped
//Status = Running
//4:14:49 PM - Custom command received: 128
//4:14:49 PM - Custom command received: 129
//ServiceController arg1
//ServiceController arg2
//</Snippet1>
