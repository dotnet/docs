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
