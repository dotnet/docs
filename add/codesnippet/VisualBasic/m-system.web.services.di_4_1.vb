         ' Check whether the given XmlTextReader is readable.
         If DiscoveryDocument.CanRead(myXmlTextReader) = True Then
            ' Read the given XmlTextReader.
            myDiscoveryDocument = DiscoveryDocument.Read(myXmlTextReader)
         Else
            Console.WriteLine("The supplied file is not readable")
         End If