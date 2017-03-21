            myPortCollection = myService.Ports;

            // Create an array of Port objects.
            Console.WriteLine("\nPort collection :");
            Port[] myPortArray = new Port[myService.Ports.Count];
            myPortCollection.CopyTo(myPortArray, 0);
            for(int i1=0 ; i1 < myService.Ports.Count ; ++i1)
            {
               Console.WriteLine("Port[" + i1+ "] : " + myPortArray[i1].Name);
            }