NotInheritable Public Class ShowWriteStartObject
     
    Public Shared Sub WriteObjectData(ByVal path As String) 
        ' Create the object to serialize.
        Dim p As New Person("Lynn", "Tsoflias", 9876)
        
        ' Create the writer.
        Dim fs As New FileStream(path, FileMode.Create)
        Dim writer As XmlDictionaryWriter = XmlDictionaryWriter.CreateTextWriter(fs)
        
        Dim ser As New System.Runtime.Serialization.NetDataContractSerializer()        

        ' Use the writer to start a document.
        writer.WriteStartDocument(True)
        
        ' Use the serializer to write the start of the 
        ' object data. Use it again to write the object
        ' data. 
        ser.WriteStartObject(writer, p)
        writer.WriteStartAttribute("MyAttribute")
        writer.WriteString("My Text")
        writer.WriteEndAttribute()

        ser.WriteObjectContent(writer, p)
                
        ' Use the serializer to write the end of the 
        ' object data. Then use the writer to write the end
        ' of the document.
        ser.WriteEndObject(writer)
        writer.WriteEndDocument()
        
        Console.WriteLine("Done")
        
        ' Close and release the writer resources.
        writer.Flush()
        fs.Flush()
        fs.Close()
    
    End Sub 