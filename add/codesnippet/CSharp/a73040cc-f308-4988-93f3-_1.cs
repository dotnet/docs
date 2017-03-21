            myPortCollection = myService.Ports;

            // Create an array of Port objects.
            Console.WriteLine("\nPort collection :");
            Port[] myPortArray = new Port[myService.Ports.Count];
            myPortCollection.CopyTo(myPortArray, 0);
            for(int i1=0 ; i1 < myService.Ports.Count ; ++i1)
            {
               Console.WriteLine("Port[" + i1+ "] : " + myPortArray[i1].Name);
            }
            Port myIndexPort = myPortCollection[0];
            Console.WriteLine("\n\nThe index of port '"
               +  myIndexPort.Name + "' is : "
               +  myPortCollection.IndexOf(myIndexPort));

            Port myPortTestInsert =myPortCollection[0];
            myPortCollection.Remove(myPortTestInsert);
            myPortCollection.Insert(0, myPortTestInsert);
            Console.WriteLine("\n\nTotal Number of Ports after inserting "
               + "a new port '" + myPortTestInsert.Name +"' is : "
               + myService.Ports.Count);
            for(int i1=0 ; i1 < myService.Ports.Count ; ++i1)
            {
               Console.WriteLine("Port[" + i1+"]  : " + myPortArray[i1].Name);
            }
            myServiceDescription.Write("MathServiceCopyToNew_cs.wsdl");