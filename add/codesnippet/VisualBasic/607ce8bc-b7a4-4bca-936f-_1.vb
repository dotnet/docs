            Dim sr As New StringReader("<myExtension xmlns=""myExtNs"" />")
            eab.SetExtensionReader(XmlDictionaryReader.CreateDictionaryReader(XmlReader.Create(sr)))