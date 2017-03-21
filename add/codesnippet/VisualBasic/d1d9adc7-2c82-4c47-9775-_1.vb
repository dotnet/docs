    Public Shared Sub BinHexDecodeImageFile() 
        
        Dim buffer(999) As Byte
        Dim readBytes As Integer = 0
        
        Using reader As XmlReader = XmlReader.Create("output.xml")
                
                Dim outputFile As New FileStream("C:\artFiles\data\newImage.jpg", FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write)
                ' Read to the image element.
                reader.ReadToFollowing("image")
                ' Read the BinHex data.
                Console.WriteLine(vbCr + vbLf + "Reading BinHex...")
                Dim bw As New BinaryWriter(outputFile)
                readBytes = reader.ReadElementContentAsBinHex(buffer, 0, 50)
                While (readBytes > 0)
                    bw.Write(buffer, 0, readBytes)
                    readBytes = reader.ReadElementContentAsBinHex(buffer, 0, 50)
                End While
                outputFile.Close()
            
        End Using
    
    End Sub 'BinHexDecodeImageFile
    