         Dim myService As Service
         Dim myPortCollection As PortCollection

         Dim myServiceDescription As ServiceDescription = _
            ServiceDescription.Read("MathServiceItem_vb.wsdl")

         Console.WriteLine("Total number of services : " & _
            myServiceDescription.Services.Count.ToString)

         Dim i As Integer
         For i = 0 to myServiceDescription.Services.Count - 1
            myService = myServiceDescription.Services(i)
            Console.WriteLine("Name : " & myService.Name)

            myPortCollection = myService.Ports

            ' Create an array of ports.
            Console.WriteLine(ControlChars.NewLine & "Port collection :")
            Dim i1 As Integer
            For i1 = 0 to myService.Ports.Count - 1
               Console.WriteLine("Port[" & i1.ToString & "] : " & _
                  myPortCollection(i1).Name)
            Next