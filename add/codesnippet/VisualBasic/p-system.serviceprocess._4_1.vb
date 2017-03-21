
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
