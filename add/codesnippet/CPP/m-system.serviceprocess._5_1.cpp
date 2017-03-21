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