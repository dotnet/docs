// System.ServiceProcess.ServiceController
//
// The following example application performs basic service queries/commands.
#using <System.ServiceProcess.dll>
#using <System.Data.dll>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Management.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Data;
using namespace System::ServiceProcess;
using namespace System::Management;

namespace ServiceControllerSample
{
   public ref class ServiceControllerInfo
   {
   public:
      ServiceControllerInfo()
      {
         // Constructor... 
      }

   public:
      ~ServiceControllerInfo()
      {
         // destructor...   
      }

   public:
      static void Main()
      {
         try
         {
            // This is a simple interface for exercising the snippet code.
            Console::WriteLine(  "Service options:" );
            Console::WriteLine(  "  1. Ensure the Alerter service is started" );
            Console::WriteLine(  "  2. Toggle the Telnet service state (stop/start)" );
            Console::WriteLine(  "  3. List services dependent on the Event Log service" );
            Console::WriteLine(  "  4. List services that the Messenger service depends on" );
            Console::WriteLine(  "  5. List device driver services on this computer" );
            Console::WriteLine(  "  6. List the running services on this computer" );
            Console::WriteLine(  "Enter the desired option (or any other key to quit): " );

            // Get the input number. 
            String^ inputText = Console::ReadLine();
            int inputNum = 0;
            if ( (inputText) && (inputText->Length > 0) )
            {
               inputNum = Int32::Parse( inputText );
            }

            // Perform the requested option.
            switch ( inputNum )
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
         catch ( Object^ e ) 
         {
            Console::WriteLine(  "Exception:" );
            Console::WriteLine( e->ToString() );
         }

      }

   private:
      static void CheckAlerterServiceStarted()
      {
         // The following example uses the ServiceController class to 
         // check whether the Alerter service is stopped.  If the service is 
         // stopped, the example starts the service and waits until
         // the service status is set to "Running".
         //  <snippet1>
         // Check whether the Alerter service is started.
         ServiceController^ sc = gcnew ServiceController;
         if ( sc )
         {
            sc->ServiceName =  "Alerter";
            Console::WriteLine(  "The Alerter service status is currently set to {0}", sc->Status );
            if ( sc->Status == (ServiceControllerStatus::Stopped) )
            {
               // Start the service if the current status is stopped.
               Console::WriteLine(  "Starting the Alerter service..." );
               try
               {
                  // Start the service, and wait until its status is "Running".
                  sc->Start();
                  sc->WaitForStatus( ServiceControllerStatus::Running );
                  
                  // Display the current service status.
                  Console::WriteLine(  "The Alerter service status is now set to {0}.", sc->Status );
               }
               catch ( InvalidOperationException^ e ) 
               {
                  Console::WriteLine(  "Could not start the Alerter service." );
               }
            }
         }
         // </snippet1>
      }

      static void ToggleTelNetServiceState()
      {
         // The following example uses the ServiceController class to 
         // check the current status of the TelNet service.  
         // If the service is stopped, the example starts the service.
         // If the service is running, the example stops the service.
         Console::WriteLine();

         // <snippet2>
         // Toggle the Telnet service - 
         // If it is started (running, paused, etc), stop the service.
         // If it is stopped, start the service.
         ServiceController^ sc = gcnew ServiceController(  "Telnet" );
         if ( sc )
         {
            Console::WriteLine(  "The Telnet service status is currently set to {0}", sc->Status );
            if ( (sc->Status == (ServiceControllerStatus::Stopped) ) || (sc->Status == (ServiceControllerStatus::StopPending) ) )
            {
               // Start the service if the current status is stopped.
               Console::WriteLine(  "Starting the Telnet service..." );
               sc->Start();
            }
            else
            {
               // Stop the service if its status is not set to "Stopped".
               Console::WriteLine(  "Stopping the Telnet service..." );
               sc->Stop();
            }

            // Refresh and display the current service status.
            sc->Refresh();
            Console::WriteLine(  "The Telnet service status is now set to {0}.", sc->Status );
            // </snippet2>
         }
      }

      static void CheckDependenciesOnEventLogService()
      {
         Console::WriteLine();

         // The following example uses the ServiceController class to 
         // display the set of services that are dependent on the 
         // Event Log service.
         // <snippet3>
         ServiceController^ sc = gcnew ServiceController(  "Event Log" );
         array<ServiceController^>^scServices = nullptr;
         if ( sc )
         {
            scServices = sc->DependentServices;
         }

         if ( sc && scServices )
         {
            // Display the list of services dependent on the Event Log service.
            if ( scServices->Length == 0 )
            {
               Console::WriteLine(  "There are no services dependent on {0}", sc->ServiceName );
            }
            else
            {
               Console::WriteLine(  "Services dependent on {0}:", sc->ServiceName );
               for each (ServiceController^ scTemp in scServices)
               {
                  Console::WriteLine(" {0}", scTemp->DisplayName);
               }
            }
         }
         // </snippet3>
      }

      static void CheckMessengerServiceDependencies()
      {
         // The following example uses the ServiceController class to 
         // display the set of services that the "Messenger" service
         // is dependent on.
         Console::WriteLine();

         // <snippet4>
         ServiceController^ sc = gcnew ServiceController(  "Messenger" );
         array<ServiceController^>^scServices = nullptr;
         if ( sc )
         {
            scServices = sc->ServicesDependedOn;
         }

         if ( sc && scServices )
         {
            // Display the services that the Messenger service is dependent on.
            if ( scServices->Length == 0 )
            {
               Console::WriteLine(  "{0} service is not dependent on any other services.", sc->ServiceName );
            }
            else
            {
               Console::WriteLine(  "{0} service is dependent on the following:", sc->ServiceName );
               for each (ServiceController^ scTemp in scServices)
               {
                  Console::WriteLine(" {0}", scTemp->DisplayName);
               }
            }
         }
         // </snippet4>
      }

      static void ListDeviceDriverServices()
      {
         // The following example uses the ServiceController class to 
         // display the device driver services on the local computer. 
         Console::WriteLine();
         
         // <snippet5>
         array<ServiceController^>^scDevices = ServiceController::GetDevices();
         if ( scDevices->Length )
         {
            int numAdapter = 0,numFileSystem = 0,numKernel = 0,numRecognizer = 0;

            // Display the list of device driver services.
            Console::WriteLine(  "Device driver services on the local computer:" );

            for each (ServiceController^ scTemp in scDevices)
            {
               // Display the status and the service name, for example,
               //   [Running] PCI Bus Driver
               //             Type = KernelDriver
               Console::WriteLine(  " [{0}] {1}", scTemp->Status, scTemp->DisplayName );
               Console::WriteLine(  "           Type = {0}", scTemp->ServiceType );

               // Update counters using the service type bit flags.
               if ( (scTemp->ServiceType & ServiceType::Adapter) != (ServiceType)0 )
               {
                  numAdapter++;
               }
               if ( (scTemp->ServiceType & ServiceType::FileSystemDriver) != (ServiceType)0 )
               {
                  numFileSystem++;
               }
               if ( (scTemp->ServiceType & ServiceType::KernelDriver) != (ServiceType)0 )
               {
                  numKernel++;
               }
               if ( (scTemp->ServiceType & ServiceType::RecognizerDriver) != (ServiceType)0 )
               {
                  numRecognizer++;
               }
            }
            Console::WriteLine();
            Console::WriteLine(  "Total of {0} device driver services", scDevices->Length.ToString() );
            Console::WriteLine(  "  {0} are adapter drivers", numAdapter.ToString() );
            Console::WriteLine(  "  {0} are file system drivers", numFileSystem.ToString() );
            Console::WriteLine(  "  {0} are kernel drivers", numKernel.ToString() );
            Console::WriteLine(  "  {0} are file system recognizer drivers", numRecognizer.ToString() );
            // </snippet5>
         }
      }

      static void ListRunningServices()
      {
         // The following example uses the ServiceController class to 
         // display the services that are running on the local computer.
         Console::WriteLine();

         // <snippet6>
         array<ServiceController^>^scServices = ServiceController::GetServices();

         // Display the list of services currently running on this computer.
         Console::WriteLine(  "Services running on the local computer:" );
         for each (ServiceController^ scTemp in scServices)
         {
            if ( scTemp->Status == ServiceControllerStatus::Running )
            {
               // Write the service name and the display name
               // for each running service.
               Console::WriteLine();
               Console::WriteLine(  "  Service :        {0}", scTemp->ServiceName );
               Console::WriteLine(  "    Display name:    {0}", scTemp->DisplayName );

               // Query WMI for additional information about this service.
               // Display the start name (LocalSytem, etc) and the service
               // description.
               ManagementObject^ wmiService;
               String^ objPath;
               objPath = String::Format( "Win32_Service.Name='{0}'", scTemp->ServiceName );
               wmiService = gcnew ManagementObject( objPath );
               if ( wmiService )
               {
                  wmiService->Get();
                  Object^ objStartName = wmiService["StartName"];
                  Object^ objDescription = wmiService["Description"];
                  if ( objStartName )
                  {
                     Console::WriteLine(  "    Start name:      {0}", objStartName->ToString() );
                  }
                  if ( objDescription )
                  {
                     Console::WriteLine(  "    Description:     {0}", objDescription->ToString() );
                  }
               }
            }
         }
         //</snippet6>
      }
   };
}

// end of class
// end of namespace
/// The main entry point for the application.

[STAThread]
int main()
{
   ServiceControllerSample::ServiceControllerInfo::Main();
}
