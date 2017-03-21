            StringReader sr = new StringReader(@"<myExtension xmlns=""myExtNs"" />");
            eab.SetExtensionReader(XmlDictionaryReader.CreateDictionaryReader(XmlReader.Create(sr)));