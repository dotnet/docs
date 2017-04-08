Imports System
Imports System.Text
Imports System.IO
Imports System.Xml

Class Read_Write_BinaryMethods 
    
    Shared Sub Main() 
        
        BinHexEncodeImageFile()
        BinHexDecodeImageFile()
        
       Base64EncodeImageFile()
       Base64DecodeImageFile()
    
    End Sub 'Main
     
    '<snippet1>
    Public Shared Sub BinHexEncodeImageFile() 
        
        Dim bufferSize As Integer = 1000
        Dim buffer(bufferSize) As Byte
        Dim readBytes As Integer = 0
        
        Using writer As XmlWriter = XmlWriter.Create("output.xml")

                Dim inputFile As New FileStream("C:\artFiles\sunset.jpg", FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read)
                writer.WriteStartDocument()
                writer.WriteStartElement("image")
                Dim br As New BinaryReader(inputFile)
                Console.WriteLine(vbCr + vbLf + "Writing BinHex data...")
                
                Do
                    readBytes = br.Read(buffer, 0, bufferSize)
                    writer.WriteBinHex(buffer, 0, readBytes)
                Loop While bufferSize <= readBytes
                br.Close()

            writer.WriteEndElement() ' </image>
            writer.WriteEndDocument()

        End Using
     
    End Sub 'BinHexEncodeImageFile
    
    '</snippet1>
    '<snippet2>
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
    
    '</snippet2>
    '<snippet3>
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
    
    '</snippet3>
    '<snippet4>
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
 '</snippet4>
End Class 'Read_Write_BinaryMethods
' end class.