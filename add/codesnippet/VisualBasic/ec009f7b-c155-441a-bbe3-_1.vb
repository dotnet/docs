         ' Create a ContractReference using a service description 
         ' and an XML Web service.
         Dim myContractReference As New ContractReference  _
             ("http://localhost/Service1.asmx?wsdl", _
              "http://localhost/Service1.asmx")