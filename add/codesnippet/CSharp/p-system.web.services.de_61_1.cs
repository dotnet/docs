         PortTypeCollection myPortTypeCollection = 
            myServiceDescription.PortTypes;
         PortType myPortType = myPortTypeCollection[0];
         OperationCollection myOperationCollection = myPortType.Operations;
         Operation myOperation = myOperationCollection[0];
         OperationFaultCollection myOperationFaultCollection = 
            myOperation.Faults;

         // Reverse the operation fault order.
         if(myOperationFaultCollection.Count > 1)
         {
            OperationFault myOperationFault = myOperationFaultCollection[0];
            OperationFault[] myOperationFaultArray = 
               new OperationFault[myOperationFaultCollection.Count];

            // Copy the operation faults to a temporary array.
            myOperationFaultCollection.CopyTo(myOperationFaultArray, 0);

            // Remove all the operation faults from the collection.
            for(int i = 0; i < myOperationFaultArray.Length; i++)
            {
               myOperationFaultCollection.Remove(myOperationFaultArray[i]);
            }

            // Insert the operation faults in the reverse order.
            for(int i = 0, j = (myOperationFaultArray.Length - 1);
               i < myOperationFaultArray.Length; i++, j--)
            {
               myOperationFaultCollection.Insert(
                  i, myOperationFaultArray[j]);
            }
            if ( myOperationFaultCollection.Contains(myOperationFault) &&
               (myOperationFaultCollection.IndexOf(myOperationFault) 
               == myOperationFaultCollection.Count-1))
            {
               Console.WriteLine(
                  "Succeeded in reversing the operation faults.");
            }
            else 
            {
               Console.WriteLine("Error while reversing the faults.");
            }
         }