// System.ServiceProcess.ServiceController
//
// The following example application performs basic service queries/commands.

using System;
using System.Collections;
using System.Data;
using System.ServiceProcess;
using System.Management;

namespace ServiceControllerSample
{

   class ServiceControllerInfo
   {
      /// The main entry point for the application.
      [STAThread]
      static void Main()
      {
         try 
         {
            // This is a simple interface for exercising the snippet code.
            Console.WriteLine("Service options:");
            Console.WriteLine("  1. Ensure the Alerter service is started");
            Console.WriteLine("  2. Toggle the Telnet service state (stop/start)");
            Console.WriteLine("  3. List services dependent on the Event Log service");
            Console.WriteLine("  4. List services that the Messenger service depends on");
            Console.WriteLine("  5. List device driver services on this computer");
            Console.WriteLine("  6. List the running services on this computer");
            Console.WriteLine("Enter the desired option (or any other key to quit): ");

            // Get the input number. 
            String inputText = Console.ReadLine();
            int option = 0;

            if (inputText.Length > 0)
            {
               option = Int32.Parse(inputText);
            }

            // Perform the requested option.
            switch (option)
            {
               case 1:
                  CheckAlerterServiceStarted();
                  break;
               case 2:
                  ToggleTelNetServiceState();
                  break;
               case 3:
                  CheckDependenciesOnEventLogService();
                  break;
               case 4:
                  CheckMessengerServiceDependencies();
                  break;
               case 5:
                  ListDeviceDriverServices();
                  break;
               case 6:
                  ListRunningServices();
                  break;
               default:
                  // Quit if input was any other key.
                  break;
            }

         }
         catch (Exception e)
         {
            Console.WriteLine("Exception:");
            Console.WriteLine(e);
         }
      }

      private static void CheckAlerterServiceStarted()
      {
         // The following example uses the ServiceController class to 
         // check whether the Alerter service is stopped.  If the service is 
         // stopped, the example starts the service and waits until
         // the service status is set to "Running".

         //  <snippet1>

         // Check whether the Alerter service is started.

         ServiceController sc  = new ServiceController();
         sc.ServiceName = "Alerter";
         Console.WriteLine("The Alerter service status is currently set to {0}", 
                            sc.Status.ToString());

         if (sc.Status == ServiceControllerStatus.Stopped)
         {
            // Start the service if the current status is stopped.

            Console.WriteLine("Starting the Alerter service...");
            try 
            {
               // Start the service, and wait until its status is "Running".
               sc.Start();
               sc.WaitForStatus(ServiceControllerStatus.Running);
            
               // Display the current service status.
               Console.WriteLine("The Alerter service status is now set to {0}.", 
                                  sc.Status.ToString());
            }
            catch (InvalidOperationException)
            {
               Console.WriteLine("Could not start the Alerter service.");
            }
         }
         // </snippet1>
      }

      private static void ToggleTelNetServiceState()
      {
         // The following example uses the ServiceController class to 
         // check the current status of the TelNet service.  
         // If the service is stopped, the example starts the service.
         // If the service is running, the example stops the service.

         Console.WriteLine();

         // <snippet2>

         // Toggle the Telnet service - 
         // If it is started (running, paused, etc), stop the service.
         // If it is stopped, start the service.
         ServiceController sc = new ServiceController("Telnet");
         Console.WriteLine("The Telnet service status is currently set to {0}", 
                           sc.Status.ToString());

         if  ((sc.Status.Equals(ServiceControllerStatus.Stopped)) ||
              (sc.Status.Equals(ServiceControllerStatus.StopPending)))
         {
            // Start the service if the current status is stopped.

            Console.WriteLine("Starting the Telnet service...");
            sc.Start();
         }  
         else
         {
            // Stop the service if its status is not set to "Stopped".

            Console.WriteLine("Stopping the Telnet service...");
            sc.Stop();
         }  

         // Refresh and display the current service status.
         sc.Refresh();
         Console.WriteLine("The Telnet service status is now set to {0}.", 
                            sc.Status.ToString());
         
         // </snippet2>
      }

      private static void CheckDependenciesOnEventLogService()
      {
         Console.WriteLine();
         
         // The following example uses the ServiceController class to 
         // display the set of services that are dependent on the 
         // Event Log service.

         // <snippet3>

         ServiceController sc =  new ServiceController("Event Log");
         ServiceController[] scServices = sc.DependentServices;
       
         // Display the list of services dependent on the Event Log service.
         if (scServices.Length == 0)
         {
            Console.WriteLine("There are no services dependent on {0}", 
                               sc.ServiceName);
         }
         else 
         {
            Console.WriteLine("Services dependent on {0}:",
                               sc.ServiceName);

            foreach (ServiceController scTemp in scServices)
            {
               Console.WriteLine(" {0}", scTemp.DisplayName);
            }
         }

         // </snippet3>
      }

      private static void CheckMessengerServiceDependencies()
      {
         // The following example uses the ServiceController class to 
         // display the set of services that the "Messenger" service
         // is dependent on.

         Console.WriteLine();

      
         // <snippet4>
         ServiceController sc = new ServiceController("Messenger");
         ServiceController[] scServices= sc.ServicesDependedOn;

         // Display the services that the Messenger service is dependent on.
         if (scServices.Length == 0)
         {
            Console.WriteLine("{0} service is not dependent on any other services.", 
                               sc.ServiceName);
         }
         else 
         {
            Console.WriteLine("{0} service is dependent on the following:",
                               sc.ServiceName);

            foreach (ServiceController scTemp in scServices)
            {
               Console.WriteLine(" {0}", scTemp.DisplayName);
            }
         }
         // </snippet4>
      }

      private static void ListDeviceDriverServices()
      {
         // The following example uses the ServiceController class to 
         // display the device driver services on the local computer. 

         Console.WriteLine();

         // <snippet5>
         ServiceController[] scDevices;
         scDevices = ServiceController.GetDevices();

         int numAdapter = 0,
             numFileSystem = 0, 
             numKernel = 0, 
             numRecognizer = 0;
       
         // Display the list of device driver services.
         Console.WriteLine("Device driver services on the local computer:");

         foreach (ServiceController scTemp in scDevices)
         {
            // Display the status and the service name, for example,
            //   [Running] PCI Bus Driver
            //             Type = KernelDriver

            Console.WriteLine(" [{0}] {1}", 
                              scTemp.Status, scTemp.DisplayName);
            Console.WriteLine("           Type = {0}", scTemp.ServiceType); 

            // Update counters using the service type bit flags.
            if ((scTemp.ServiceType & ServiceType.Adapter) != 0)
            {
               numAdapter++;
            } 
            if ((scTemp.ServiceType & ServiceType.FileSystemDriver) != 0)
            {
               numFileSystem++;
            }  
            if ((scTemp.ServiceType & ServiceType.KernelDriver) != 0)
            {
               numKernel++;
            } 
            if ((scTemp.ServiceType & ServiceType.RecognizerDriver) != 0)
            {
               numRecognizer++;
            }

         }

         Console.WriteLine();
         Console.WriteLine("Total of {0} device driver services", scDevices.Length);
         Console.WriteLine("  {0} are adapter drivers", numAdapter);
         Console.WriteLine("  {0} are file system drivers", numFileSystem);
         Console.WriteLine("  {0} are kernel drivers", numKernel);
         Console.WriteLine("  {0} are file system recognizer drivers", numRecognizer);

         // </snippet5>
      }

      private static void ListRunningServices()
      {
         // The following example uses the ServiceController class to 
         // display services that are running on the local computer.

         Console.WriteLine();

         // <snippet6>
         ServiceController[] scServices;
         scServices = ServiceController.GetServices();

         // Display the list of services currently running on this computer.

         Console.WriteLine("Services running on the local computer:");
         foreach (ServiceController scTemp in scServices)
         {
            if (scTemp.Status == ServiceControllerStatus.Running)
            {
               // Write the service name and the display name
               // for each running service.
               Console.WriteLine();
               Console.WriteLine("  Service :        {0}", scTemp.ServiceName);
               Console.WriteLine("    Display name:    {0}", scTemp.DisplayName);

               // Query WMI for additional information about this service.
               // Display the start name (LocalSytem, etc) and the service
               // description.
               ManagementObject wmiService;
               wmiService = new ManagementObject("Win32_Service.Name='" + scTemp.ServiceName + "'");
               wmiService.Get();
               Console.WriteLine("    Start name:      {0}", wmiService["StartName"]);
               Console.WriteLine("    Description:     {0}", wmiService["Description"]);
            }
         }
         // </snippet6>
      }

     
   }
}
