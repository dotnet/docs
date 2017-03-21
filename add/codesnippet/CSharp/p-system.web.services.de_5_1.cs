         OperationFaultCollection myOperationFaultCollection = 
            myOperation.Faults;
         OperationFault myOperationFault = 
            myOperationFaultCollection["ErrorString"];
         if( myOperationFault != null )
         {
            myOperationFaultCollection.Remove(myOperationFault);
         }