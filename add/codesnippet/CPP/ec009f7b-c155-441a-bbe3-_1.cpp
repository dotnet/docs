      // Create a ContractReference using a service description and
      // an XML Web service.
      ContractReference^ myContractReference = gcnew ContractReference(
         "http://localhost/Service1::asmx?wsdl","http://localhost/Service1::asmx" );