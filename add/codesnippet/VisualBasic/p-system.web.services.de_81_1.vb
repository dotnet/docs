         Dim myServiceDescription As ServiceDescription = _
            ServiceDescription.Read("MathService_VB.wsdl")
         Dim myServiceCollection As ServiceCollection = _
            myServiceDescription.Services
         
         Dim noOfServices As Integer = myServiceCollection.Count
         Console.WriteLine(ControlChars.Newline & _
            "Total number of services: " & noOfServices.ToString())

         ' Get a reference to the service.
         Dim myOldService As Service = myServiceCollection(0)
         Console.WriteLine("No.of Ports in the Service" &  _
            myServiceCollection(0).Ports.Count.ToString())
         Console.WriteLine("These are the ports in the service:")
         Dim i As Integer
         For i = 0 To myOldService.Ports.Count - 1
            Console.WriteLine("Port name: " & myOldService.Ports(i).Name)
         Next i
         Console.WriteLine("Service name: " & myOldService.Name)
         
         Dim myService As New Service()
         myService.Name = "MathService"

         ' Add the ports to the newly created service.
         For i = 0 To myOldService.Ports.Count - 1
            Dim PortName As String = myServiceCollection(0).Ports(i).Name
            Dim BindingName As String = _
               myServiceCollection(0).Ports(i).Binding.Name
            myService.Ports.Add(CreatePort(PortName, BindingName, _
               myServiceDescription.TargetNamespace))
         Next i

         Console.WriteLine("Newly created ports -")
         For i = 0 To myService.Ports.Count - 1
            Console.WriteLine("Port Name: " & myOldService.Ports(i).Name)
         Next i 

         ' Add the extensions to the newly created service.
         Dim noOfExtensions As Integer = myOldService.Extensions.Count
         Console.WriteLine("No. of extensions: " & noOfExtensions.ToString())

         If noOfExtensions > 0 Then
            For i = 0 To myOldService.Ports.Count - 1
               myService.Extensions.Add(myServiceCollection(0).Extensions(i))
            Next i
         End If 

         ' Remove the service from the collection.
         myServiceCollection.Remove(myOldService)

         ' Add the newly created service.
         myServiceCollection.Add(myService)
         myServiceDescription.Write("MathService_New.wsdl")