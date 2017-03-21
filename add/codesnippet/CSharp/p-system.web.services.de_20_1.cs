     // Create a Port.
     Port postPort = new Port();
     postPort.Name = "PortServiceHttpPost";
     postPort.Binding = new XmlQualifiedName("s0:PortServiceHttpPost");

     // Create an HttpAddressBinding.
     HttpAddressBinding postAddressBinding = new HttpAddressBinding();
     postAddressBinding.Location = 
        "http://localhost/PortClass/PortService_cs.asmx";

     // Add the HttpAddressBinding to the Port.
     postPort.Extensions.Add(postAddressBinding);