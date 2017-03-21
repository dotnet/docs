         OperationFaultCollection myOperationFaultCollection = myOperation.Faults;
         OperationFault myOperationFault = new OperationFault();
         myOperationFault.Name = "ErrorString";
         myOperationFault.Message = new XmlQualifiedName("s0:GetTradePriceStringFault");
         myOperationFaultCollection.Add(myOperationFault);