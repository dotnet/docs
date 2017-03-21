      Dim myDiscoFile As String = "http://localhost/MathService_vb.vsdisco"
      Dim myUrlKey As String = "http://localhost/MathService_vb.asmx?wsdl"
      Dim myDiscoveryClientProtocol As New DiscoveryClientProtocol()
      
      ' Get the discovery document.
      Dim myDiscoveryDocument As DiscoveryDocument = myDiscoveryClientProtocol.Discover(myDiscoFile)
      Dim myEnumerator As IEnumerator = myDiscoveryDocument.References.GetEnumerator()
      While myEnumerator.MoveNext()
        Dim myContractReference As ContractReference = CType(myEnumerator.Current, ContractReference)
         
        ' Get the DiscoveryClientProtocol from the ContractReference.
         myDiscoveryClientProtocol = myContractReference.ClientProtocol
         myDiscoveryClientProtocol.ResolveAll()

         Dim myExceptionDictionary As DiscoveryExceptionDictionary = myDiscoveryClientProtocol.Errors

         If myExceptionDictionary.Contains(myUrlKey) Then
            Console.WriteLine("System generated exceptions.")
            
            ' Get the exception from the DiscoveryExceptionDictionary.
            Dim myException As Exception = myExceptionDictionary(myUrlKey)
            
            Console.WriteLine(" Source : " & myException.Source)
            Console.WriteLine(" Exception : " & myException.Message)
            Console.WriteLine()
         End If
      End While