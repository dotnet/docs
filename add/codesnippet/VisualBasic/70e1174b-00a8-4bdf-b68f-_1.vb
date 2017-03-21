    Public Shared Sub Base64DecodeImageFile() 
        
        Dim buffer(999) As Byte
        Dim readBytes As Integer = 0
        
        Using reader As XmlReader = XmlReader.Create("output.xml")

                Dim outputFile As New FileStream("C:\artFiles\data\newImage.jpg", FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write)
                ' Read to the image element.
                reader.ReadToFollowing("image")
                ' Read the Base64 data.
                Console.WriteLine(vbCr + vbLf + "Reading Base64...")
                Dim bw As New BinaryWriter(outputFile)
                readBytes = reader.ReadElementContentAsBase64(buffer, 0, 50)
                While (readBytes > 0)
                    bw.Write(buffer, 0, readBytes)
                    readBytes = reader.ReadElementContentAsBase64(buffer, 0, 50)
                End While
                outputFile.Close()
            
        End Using
    
    End Sub 'Base64DecodeImageFile