
         Dim scServices() As ServiceController
         scServices = ServiceController.GetServices()
       
         ' Display the list of services currently running on this computer.
         Console.WriteLine("Services running on the local computer:")

         Dim scTemp As ServiceController
         For Each scTemp In  scServices

            If scTemp.Status = ServiceControllerStatus.Running Then
               ' Write the service name and the display name
               ' for each running service.
               Console.WriteLine()
               Console.WriteLine("  Service :        {0}", scTemp.ServiceName)
               Console.WriteLine("    Display name:    {0}", scTemp.DisplayName)
               
               ' Query WMI for additional information about this service.
               ' Display the start name (LocalSytem, etc) and the service
               ' description.
               Dim wmiService As ManagementObject
               wmiService = New ManagementObject("Win32_Service.Name='" + scTemp.ServiceName + "'")
               wmiService.Get()
               Console.WriteLine("    Start name:      {0}", wmiService("StartName"))
               Console.WriteLine("    Description:     {0}", wmiService("Description"))
            End If

         Next scTemp
      