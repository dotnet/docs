      Dim myProtocol As New DiscoveryClientProtocol()

      ' Get the DiscoveryDocument.
      Dim myDiscoveryDocument As DiscoveryDocument = _
          myProtocol.Discover("http://localhost/ContractReference/Test_vb.disco")
      Dim myArrayList As ArrayList = _
          CType(myDiscoveryDocument.References, ArrayList)

      ' Get the ContractReference.
      Dim myContractRefrence As ContractReference = _
          CType(myArrayList(0), ContractReference)

      ' Get the DefaultFileName associated with the .disco file.
      Dim myFileName As String  = myContractRefrence.DefaultFilename

      ' Get the URL associated with the .disco file.
      Dim myUrl As String  = myContractRefrence.Url
      Console.WriteLine("The DefaulFilename is: " + myUrl)
      Console.WriteLine("The URL is: " + myUrl)