
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
