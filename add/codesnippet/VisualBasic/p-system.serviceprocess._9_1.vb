
         Dim scDevices() As ServiceController
         scDevices = ServiceController.GetDevices()

         Dim numAdapter As Integer
         Dim numFileSystem As Integer
         Dim numKernel As Integer
         Dim numRecognizer As Integer
         
         ' Display the list of device driver services.
         Console.WriteLine("Device driver services on the local computer:")
         
         Dim scTemp As ServiceController
         For Each scTemp In  scDevices
            ' Display the status and the service name, for example,
            '   [Running] PCI Bus Driver
            '             Type = KernelDriver

            Console.WriteLine(" [{0}] {1}", scTemp.Status, scTemp.DisplayName)
            Console.WriteLine("           Type = {0}", scTemp.ServiceType)

            ' Update counters using the service type bit flags.
            If (scTemp.ServiceType And ServiceType.Adapter) <> 0 Then
               numAdapter = numAdapter + 1
            End If
            If (scTemp.ServiceType And ServiceType.FileSystemDriver) <> 0 Then
               numFileSystem = numFileSystem + 1
            End If
            If (scTemp.ServiceType And ServiceType.KernelDriver) <> 0 Then
               numKernel = numKernel + 1
            End If
            If (scTemp.ServiceType And ServiceType.RecognizerDriver) <> 0 Then
               numRecognizer = numRecognizer + 1
            End If

         Next scTemp

         Console.WriteLine()
         Console.WriteLine("Total of {0} device driver services", scDevices.Length)
         Console.WriteLine("  {0} are adapter drivers", numAdapter)
         Console.WriteLine("  {0} are file system drivers", numFileSystem)
         Console.WriteLine("  {0} are kernel drivers", numKernel)
         Console.WriteLine("  {0} are file system recognizer drivers", numRecognizer)
