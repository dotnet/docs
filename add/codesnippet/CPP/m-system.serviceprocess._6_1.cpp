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