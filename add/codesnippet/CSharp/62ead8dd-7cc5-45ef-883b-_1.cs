         Service myService;
         PortCollection myPortCollection;

         ServiceDescription myServiceDescription =
            ServiceDescription.Read("MathServiceItem_cs.wsdl");

         Console.WriteLine("Total number of services : "
            + myServiceDescription.Services.Count);

         for(int i=0; i < myServiceDescription.Services.Count; ++i)
         {
            myService = myServiceDescription.Services[i];
            Console.WriteLine("Name : " + myService.Name);

            myPortCollection = myService.Ports;

            // Create an array of ports.
            Console.WriteLine("\nPort collection :");
            for(int i1=0 ; i1 < myService.Ports.Count ; ++i1)
            {
               Console.WriteLine("Port[" + i1+"] : " +
                  myPortCollection[i1].Name);
            }

            string strPort = myPortCollection[0].Name;
            Port myPort = myPortCollection[strPort];
            Console.WriteLine("\nIndex of Port[" + strPort + "] : " +
               myPortCollection.IndexOf(myPort));


            Port myPortTestRemove = myPortCollection[0];

            Console.WriteLine("\nTotal number of ports before removing "
               + "a port '" + myPortTestRemove.Name +"' is : "
               + myService.Ports.Count);

            myPortCollection.Remove(myPortTestRemove);

            Console.WriteLine("Total number of ports after removing "
               + "a port '" + myPortTestRemove.Name +"' is : "
               + myService.Ports.Count);

            // Create the WSDL file.
            myPortCollection.Insert(0, myPortTestRemove);
            myServiceDescription.Write("MathServiceItemNew_cs.wsdl");