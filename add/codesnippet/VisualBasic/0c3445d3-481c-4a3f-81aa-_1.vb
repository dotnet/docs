    Public Shared Sub WriteObjectContentInDocument(ByVal path As String) 
        ' Create the object to serialize.
        Dim p As New Person("Lynn", "Tsoflias", 9876)
        
        ' Create the writer.
        Dim fs As New FileStream(path, FileMode.Create)
        Dim writer As XmlDictionaryWriter = XmlDictionaryWriter.CreateTextWriter(fs)
        
        Dim ser As New DataContractSerializer(GetType(Person))
        
        ' Use the writer to start a document.
        writer.WriteStartDocument(True)
        ' Use the writer to write the root element.
        writer.WriteStartElement("Company")
        ' Use the writer to write an element.
        writer.WriteElementString("Name", "Microsoft")

        ' Use the serializer to write the start,
        ' content, and end data.
        ser.WriteStartObject(writer, p)
        ser.WriteObjectContent(writer, p)
        ser.WriteEndObject(writer)
        
        ' Use the writer to write the end element and
        ' the end of the document.
        writer.WriteEndElement()
        writer.WriteEndDocument()
        
        ' Close and release the writer resources.
        writer.Flush()
        fs.Flush()
        fs.Close()
    
    End Sub     