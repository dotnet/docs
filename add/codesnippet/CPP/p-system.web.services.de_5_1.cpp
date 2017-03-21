      OperationFaultCollection^ myOperationFaultCollection = myOperation->Faults;
      OperationFault^ myOperationFault = myOperationFaultCollection[ "ErrorString" ];
      if ( myOperationFault != nullptr )
            myOperationFaultCollection->Remove( myOperationFault );