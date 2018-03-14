' System.ServiceProcess.ServiceController
'
' The following example application performs basic service queries/commands.

Imports System
Imports System.Collections
Imports System.Data
Imports System.ServiceProcess
Imports System.Management

Namespace ServiceControllerSample

   Class ServiceControllerInfo
      
      ' The main entry point for the application.
      Shared Sub Main()
         Try
            ' This is a simple interface for exercising the snippet code.
            Console.WriteLine("Service options:")
            Console.WriteLine("  1. Ensure the Alerter service is started")
            Console.WriteLine("  2. Toggle the Telnet service state (stop/start)")
            Console.WriteLine("  3. List services dependent on the Event Log service")
            Console.WriteLine("  4. List services that the Messenger service depends on")
            Console.WriteLine("  5. List device driver services on this computer")
            Console.WriteLine("  6. List the running services on this computer")
            Console.WriteLine("Enter the desired option (or any other key to quit): ")
            
            ' Get the input number. 
            Dim inputText As String = Console.ReadLine()
            Dim inputNum As Integer = 0
            
            If inputText.Length > 0 Then
               inputNum = Int32.Parse(inputText)
            End If
            
            ' Perform the requested option.
            Select Case inputNum
               Case 1
                  CheckAlerterServiceStarted()
               Case 2
                  ToggleTelNetServiceState()
               Case 3
                  CheckDependenciesOnEventLogService()
               Case 4
                  CheckMessengerServiceDependencies()
               Case 5
                  ListDeviceDriverServices()
               Case 6
                  ListRunningServices()
               Case Else
                  ' Quit, if input was any other key.
            End Select 
         
         Catch e As Exception
            Console.WriteLine("Exception:")
            Console.WriteLine(e)
         End Try
      End Sub 'Main
      
      
      Private Shared Sub CheckAlerterServiceStarted()
         
         ' The following example uses the ServiceController class to 
         ' check whether the Alerter service is stopped.  If the service is 
         ' stopped, the example starts the service and waits until
         ' the service status is set to "Running".

         '  <snippet1>

         ' Check whether the Alerter service is started.

         Dim sc As New ServiceController()
         sc.ServiceName = "Alerter"
         Console.WriteLine("The Alerter service status is currently set to {0}", sc.Status)
         
         If sc.Status = ServiceControllerStatus.Stopped Then
            ' Start the service if the current status is stopped.
            Console.WriteLine("Starting the Alerter service...")

            Try
               ' Start the service, and wait until its status is "Running".
               sc.Start()
               sc.WaitForStatus(ServiceControllerStatus.Running)
               
               ' Display the current service status.
               Console.WriteLine("The Alerter service status is now set to {0}.", sc.Status)
            Catch 
               Console.WriteLine("Could not start the Alerter service.")
            End Try
         End If

         ' </snippet1>

      End Sub 'CheckAlerterServiceStarted
      
      Private Shared Sub ToggleTelNetServiceState()

      ' The following example uses the ServiceController class to 
      ' check the current status of the TelNet service.  
      ' If the service is stopped, the example starts the service.
      ' If the service is running, the example stops the service.
         
         Console.WriteLine()

         ' <snippet2>

         ' Toggle the Telnet service - 
         ' If it is started (running, paused, etc), stop the service.
         ' If it is stopped, start the service.
         Dim sc As New ServiceController("Telnet")
         Console.WriteLine("The Telnet service status is currently set to {0}", sc.Status)
         
         If sc.Status.Equals(ServiceControllerStatus.Stopped) Or sc.Status.Equals(ServiceControllerStatus.StopPending) Then
            ' Start the service if the current status is stopped.
            Console.WriteLine("Starting the Telnet service...")
            sc.Start()
         Else
            ' Stop the service if its status is not set to "Stopped".
            Console.WriteLine("Stopping the Telnet service...")
            sc.Stop()
         End If
         
         ' Refresh and display the current service status.
         sc.Refresh()
         Console.WriteLine("The Telnet service status is now set to {0}.", sc.Status)

         ' </snippet2>

      End Sub 'ToggleTelNetServiceState
     
      
      
      Private Shared Sub CheckDependenciesOnEventLogService()

         ' The following example uses the ServiceController class to 
         ' display the set of services that are dependent on the 
         ' Event Log service.

         Console.WriteLine()
         
         ' <snippet3>

         Dim sc As New ServiceController("Event Log")
         Dim scServices As ServiceController() = sc.DependentServices
         
         ' Display the list of services dependent on the Event Log service.
         If scServices.Length = 0 Then
            Console.WriteLine("There are no services dependent on {0}", sc.ServiceName)
         Else
            Console.WriteLine("Services dependent on {0}:", sc.ServiceName)
            
            Dim scTemp As ServiceController
            For Each scTemp In  scServices
               Console.WriteLine(" {0}", scTemp.DisplayName)
            Next scTemp
         End If

         ' </snippet3>

      End Sub 'CheckDependenciesOnEventLogService
       
      
      Private Shared Sub CheckMessengerServiceDependencies()

         ' The following example uses the ServiceController class to 
         ' display the set of services that the Messenger service
         ' is dependent on.

         Console.WriteLine()
         
         ' <snippet4>

         Dim sc As New ServiceController("Messenger")
         Dim scServices As ServiceController() = sc.ServicesDependedOn
         
         ' Display the services that the Messenger service is dependent on.
         If scServices.Length = 0 Then
            Console.WriteLine("{0} service is not dependent on any other services.", sc.ServiceName)
         Else
            Console.WriteLine("{0} service is dependent on the following:", sc.ServiceName)
            
            Dim scTemp As ServiceController
            For Each scTemp In  scServices
               Console.WriteLine(" {0}", scTemp.DisplayName)
            Next scTemp
         End If

         ' </snippet4>

      End Sub 'CheckMessengerServiceDependencies
      
      Private Shared Sub ListDeviceDriverServices()
         
         ' The following example uses the ServiceController class to 
         ' display the device driver services on the local computer. 
        
         Console.WriteLine()
         
         ' <snippet5>

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

         ' </snippet5>

      End Sub 'ListDeviceDriverServices
      
      Private Shared Sub ListRunningServices()

         ' The following example uses the ServiceController class to 
         ' display the services that are running on the local computer.

         Console.WriteLine()
         
         ' <snippet6>

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
      
         ' </snippet6>

      End Sub 'ListRunningServices 

   End Class 'ServiceControllerInfo
    
End Namespace 'ServiceControllerSample