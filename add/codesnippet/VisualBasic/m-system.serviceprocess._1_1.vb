
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
