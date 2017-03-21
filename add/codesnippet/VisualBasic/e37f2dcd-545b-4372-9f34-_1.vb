            Dim sc As XmlSchemaCollection = New XmlSchemaCollection()
            AddHandler sc.ValidationEventHandler, AddressOf ValidationCallBack

            ' Create a resolver with the necessary credentials.
            Dim resolver As XmlUrlResolver = New XmlUrlResolver()
            resolver.Credentials = System.Net.CredentialCache.DefaultCredentials

            ' Add the new schema to the collection.
            sc.Add("", New XmlTextReader("sample.xsd"), resolver)