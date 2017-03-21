
         ' Create a Port.
         Dim postPort As New Port()
         postPort.Name = "PortServiceHttpPost"
         postPort.Binding = New XmlQualifiedName("s0:PortServiceHttpPost")


         ' Create an HttpAddressBinding.
         Dim postAddressBinding As New HttpAddressBinding()
         postAddressBinding.Location = _
            "http://localhost/PortClass/PortService.vb.asmx"

         ' Add the HttpAddressBinding to the Port.
         postPort.Extensions.Add(postAddressBinding)

         ' Get the Service of the postPort.
         Dim myService As Service = postPort.Service

         ' Print the service name for the port.
         Console.WriteLine("This is the service name of the postPort:*" & _
            myDescription.Services(0).Ports(0).Service.Name & "*")

         ' Add the Port to the PortCollection of the ServiceDescription.
         myDescription.Services(0).Ports.Add(postPort)
