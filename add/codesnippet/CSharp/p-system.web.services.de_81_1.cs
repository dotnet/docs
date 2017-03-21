         ServiceDescription myServiceDescription = 
            ServiceDescription.Read("MathService_CS.wsdl");
         ServiceCollection myServiceCollection = 
            myServiceDescription.Services;

         int noOfServices = myServiceCollection.Count;
         Console.WriteLine("\nTotal number of services: " + noOfServices);

         // Get a reference to the service.
         Service myOldService = myServiceCollection[0];
         Console.WriteLine("No. of Ports in the Service" + 
            myServiceCollection[0].Ports.Count);
         Console.WriteLine("These are the ports in the service:");
         for(int i = 0; i < myOldService.Ports.Count; i++)
            Console.WriteLine("Port name: " + myOldService.Ports[i].Name);
         Console.WriteLine("Service name: " + myOldService.Name);

         Service  myService = new Service();
         myService.Name = "MathService";

         // Add the ports to the newly created service.
         for(int i = 0; i < myOldService.Ports.Count; i++)
         {
            string PortName = myServiceCollection[0].Ports[i].Name;
            string BindingName = 
               myServiceCollection[0].Ports[i].Binding.Name;
            myService.Ports.Add(CreatePort(PortName, BindingName, 
               myServiceDescription.TargetNamespace));
         }

         Console.WriteLine("Newly created ports -");
         for(int i = 0; i < myService.Ports.Count; i++)
            Console.WriteLine("Port Name: " + myOldService.Ports[i].Name);

         // Add the extensions to the newly created service.
         int noOfExtensions = myOldService.Extensions.Count;
         Console.WriteLine("No. of extensions: " + noOfExtensions);
         if (noOfExtensions > 0)
         {
            for(int i = 0; i <myOldService.Ports.Count; i++)
               myService.Extensions.Add(
                  myServiceCollection[0].Extensions[i]);
         }

         // Remove the service from the collection.
         myServiceCollection.Remove(myOldService);

         // Add the newly created service.
         myServiceCollection.Add(myService);
         myServiceDescription.Write("MathService_New.wsdl");