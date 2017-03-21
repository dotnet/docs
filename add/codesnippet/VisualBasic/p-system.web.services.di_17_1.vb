
         ' Reference the schema document.
         Dim myStringUrl As String = "c:\\Inetpub\\wwwroot\\dataservice.xsd"
         Dim myXmlSchema As XmlSchema

         ' Create the client protocol.
         Dim myDiscoveryClientProtocol As DiscoveryClientProtocol = _
             New DiscoveryClientProtocol()
         myDiscoveryClientProtocol.Credentials = _
             CredentialCache.DefaultCredentials

         ' Create a schema reference.
         Dim mySchemaReferenceNoParam As SchemaReference = New SchemaReference()

         Dim mySchemaReference As SchemaReference = _
             New SchemaReference(myStringUrl)

         ' Set the client protocol.
         mySchemaReference.ClientProtocol = myDiscoveryClientProtocol

         ' Access the default file name associated with the schema reference.
         Console.WriteLine("Default filename is : " & _
             mySchemaReference.DefaultFilename)

         ' Access the namespace associated with schema reference class.
         Console.WriteLine("Namespace is : " & SchemaReference.Namespace)

         Dim myStream As FileStream = _
             New FileStream(myStringUrl, FileMode.OpenOrCreate)

         ' Read the document in a stream.
         mySchemaReference.ReadDocument(myStream)

         ' Get the schema of the referenced document.
         myXmlSchema = mySchemaReference.Schema

         Console.WriteLine("Reference is : " & mySchemaReference.Ref)

         Console.WriteLine("Target namespace (default empty) is : " & _
             mySchemaReference.TargetNamespace)

         Console.WriteLine("URL is : " & mySchemaReference.Url)

         ' Write the document in the stream.
         mySchemaReference.WriteDocument(myXmlSchema, myStream)

         myStream.Close()
         mySchemaReference = Nothing