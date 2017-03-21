
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