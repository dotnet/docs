            EndpointAddressBuilder eab = new EndpointAddressBuilder();
            eab.Uri = new Uri("http://localhost/Uri");
            eab.Headers.Add(AddressHeader.CreateAddressHeader("n", "ns", "val"));

            eab.Identity = EndpointIdentity.CreateUpnIdentity("identity");

            XmlDictionaryReader xdrExtensions = eab.GetReaderAtExtensions();

            StringReader sr = new StringReader(@"<myExtension xmlns=""myExtNs"" />");
            eab.SetExtensionReader(XmlDictionaryReader.CreateDictionaryReader(XmlReader.Create(sr)));

            EndpointAddress ea = eab.ToEndpointAddress();

            sr = new StringReader(@"<myMetadata xmlns=""myMetaNs"" />");
            XmlDictionaryReader xdrMetaData = eab.GetReaderAtMetadata();

            eab.SetMetadataReader(XmlDictionaryReader.CreateDictionaryReader(XmlReader.Create(sr)));