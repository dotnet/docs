   Class MyClass1
      Shared Sub Main()
         Try
            ' Create the file stream.
            Dim discoStream As _
                New FileStream("Service1_vb.disco", FileMode.Open)

            ' Create the discovery document.
            Dim myDiscoveryDocument As _
                DiscoveryDocument = DiscoveryDocument.Read(discoStream)

            ' Get the first ContractReference in the collection.
            Dim myContractReference As ContractReference = _
                CType(myDiscoveryDocument.References(0), ContractReference)

            ' Set the client protocol.
            myContractReference.ClientProtocol = New DiscoveryClientProtocol()
            myContractReference.ClientProtocol.Credentials = _
                CredentialCache.DefaultCredentials

            ' Get the service description.
            Dim myContract As ServiceDescription = myContractReference.Contract

            ' Create the service description file.
            myContract.Write("MyService1.wsdl")
            Console.WriteLine("The WSDL file created is MyService1.wsdl")

            discoStream.Close()

         Catch ex As Exception
            Console.WriteLine("Exception: " + ex.Message)
         End Try
      End Sub 'Main
   End Class 'MyClass1