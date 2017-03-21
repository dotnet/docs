<XmlSchemaProvider("MySchema")>  _
Public Class SongStream
    Implements IXmlSerializable
    
    Private Const ns As String = "http://demos.Contoso.com/webservices"
    Private filePath As String
    
    Public Sub New() 
    
    End Sub
     
    Public Sub New(ByVal filePath As String) 
        Me.filePath = filePath
    End Sub
    
    
    ' This is the method named by the XmlSchemaProviderAttribute applied to the type.
    Public Shared Function MySchema(ByVal xs As XmlSchemaSet) As XmlQualifiedName 
        ' This method is called by the framework to get the schema for this type.
        ' We return an existing schema from disk.
        Dim schemaSerializer As New XmlSerializer(GetType(XmlSchema))
        Dim xsdPath As String = Nothing
        ' NOTE: replace SongStream.xsd with your own schema file.
        xsdPath = System.Web.HttpContext.Current.Server.MapPath("SongStream.xsd")
        Dim s As XmlSchema = CType(schemaSerializer.Deserialize(New XmlTextReader(xsdPath)), XmlSchema)
        xs.XmlResolver = New XmlUrlResolver()
        xs.Add(s)
        
        Return New XmlQualifiedName("songStream", ns)
    
    End Function
    
    
    
    Sub WriteXml(ByVal writer As System.Xml.XmlWriter)  Implements IXmlSerializable.WriteXml
        ' This is the chunking code.
        ' ASP.NET buffering must be turned off for this to work.
        
        Dim bufferSize As Integer = 4096
        Dim songBytes(bufferSize) As Char
        Dim inFile As FileStream = File.Open(Me.filePath, FileMode.Open, FileAccess.Read)
        
        Dim length As Long = inFile.Length
        
        ' Write the file name.
        writer.WriteElementString("fileName", ns, Path.GetFileNameWithoutExtension(Me.filePath))
        
        ' Write the size.
        writer.WriteElementString("size", ns, length.ToString())
        
        ' Write the song bytes.
        writer.WriteStartElement("song", ns)
        
        Dim sr As New StreamReader(inFile, True)
        Dim readLen As Integer = sr.Read(songBytes, 0, bufferSize)
        
        While readLen > 0
            writer.WriteStartElement("chunk", ns)
            writer.WriteChars(songBytes, 0, readLen)
            writer.WriteEndElement()
            
            writer.Flush()
            readLen = sr.Read(songBytes, 0, bufferSize)
        End While
        
        writer.WriteEndElement()
        inFile.Close()
    End Sub 
        
    Function GetSchema() As System.Xml.Schema.XmlSchema  Implements IXmlSerializable.GetSchema
        Throw New System.NotImplementedException()
    End Function
    
    Sub ReadXml(ByVal reader As System.Xml.XmlReader)  Implements IXmlSerializable.ReadXml
        Throw New System.NotImplementedException()
    End Sub 
End Class 
