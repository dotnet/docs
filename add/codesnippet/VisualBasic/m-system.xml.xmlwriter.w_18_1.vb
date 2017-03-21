    Public Shared Sub Base64EncodeImageFile() 
        
        Dim bufferSize As Integer = 1000
        Dim buffer(bufferSize) As Byte
        Dim readBytes As Integer = 0
        
        Using writer As XmlWriter = XmlWriter.Create("output.xml")

                Dim inputFile As New FileStream("C:\artFiles\sunset.jpg", FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read)
                writer.WriteStartDocument()
                writer.WriteStartElement("image")
                Dim br As New BinaryReader(inputFile)
                Console.WriteLine(vbCr + vbLf + "Writing Base64 data...")
                
                Do
                    readBytes = br.Read(buffer, 0, bufferSize)
                    writer.WriteBase64(buffer, 0, readBytes)
                Loop While bufferSize <= readBytes
                br.Close()
            
            writer.WriteEndElement() ' </image>
            writer.WriteEndDocument()

        End Using
     
    End Sub 'Base64EncodeImageFile
    