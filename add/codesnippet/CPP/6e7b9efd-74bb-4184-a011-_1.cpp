      OperationFaultCollection^ myOperationFaultCollection = myOperation->Faults;
      OperationFault^ myOperationFault = gcnew OperationFault;
      myOperationFault->Name = "ErrorString";
      myOperationFault->Message = gcnew XmlQualifiedName( "s0:GetTradePriceStringFault" );
      myOperationFaultCollection->Add( myOperationFault );