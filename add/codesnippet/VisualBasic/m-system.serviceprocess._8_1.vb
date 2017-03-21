
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
