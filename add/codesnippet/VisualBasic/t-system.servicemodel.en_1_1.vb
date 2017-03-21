            Dim eab As New EndpointAddressBuilder()
            eab.Uri = New Uri("http://localhost/Uri")
            eab.Headers.Add(AddressHeader.CreateAddressHeader("n", "ns", "val"))

            eab.Identity = EndpointIdentity.CreateUpnIdentity("foo")

            Dim xdrExtensions As XmlDictionaryReader = eab.GetReaderAtExtensions()

            Dim sr As New StringReader("<myExtension xmlns=""myExtNs"" />")
            eab.SetExtensionReader(XmlDictionaryReader.CreateDictionaryReader(XmlReader.Create(sr)))

            Dim ea As EndpointAddress = eab.ToEndpointAddress()

            sr = New StringReader("<myMetadata xmlns=""myMetaNs"" />")
            Dim xdrMetaData As XmlDictionaryReader = eab.GetReaderAtMetadata()

            eab.SetMetadataReader(XmlDictionaryReader.CreateDictionaryReader(XmlReader.Create(sr)))