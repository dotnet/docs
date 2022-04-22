Imports System.IO
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Xml.Schema

Public Class Test

    Public Class DownloadAuthorization
    End Class

    Shared Sub Main()
        Console.WriteLine("Hello")
    End Sub

    '<snippet1>
    <WebMethod(), SoapDocumentMethodAttribute(ParameterStyle:=SoapParameterStyle.Bare)>
    Public Function DownloadSong(ByVal Authorization As DownloadAuthorization, ByVal filePath As String) As SongStream

        ' Turn off response buffering.
        System.Web.HttpContext.Current.Response.Buffer = False
        ' Return a song.
        Dim song As New SongStream(filePath)
        Return song

    End Function
End Class
'</snippet1>

'<snippet2>
<XmlSchemaProvider("MySchema")>
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

    Sub WriteXml(ByVal writer As System.Xml.XmlWriter) Implements IXmlSerializable.WriteXml
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

    Function GetSchema() As System.Xml.Schema.XmlSchema Implements IXmlSerializable.GetSchema
        Throw New System.NotImplementedException()
    End Function

    Sub ReadXml(ByVal reader As System.Xml.XmlReader) Implements IXmlSerializable.ReadXml
        Throw New System.NotImplementedException()
    End Sub
End Class

'</snippet2>
Public Delegate Sub ProgressMade(ByVal Progress As Double)

'<snippet3>
Public Class SongFile
    Implements IXmlSerializable
    Public Shared Event OnProgress As ProgressMade

    Public Sub New()

    End Sub

    Private Const ns As String = "http://demos.teched2004.com/webservices"
    Public Shared MusicPath As String
    Private filePath As String
    Private size As Double

    Sub ReadXml(ByVal reader As System.Xml.XmlReader) Implements IXmlSerializable.ReadXml
        reader.ReadStartElement("DownloadSongResult", ns)
        ReadFileName(reader)
        ReadSongSize(reader)
        ReadAndSaveSong(reader)
        reader.ReadEndElement()
    End Sub

    Sub ReadFileName(ByVal reader As XmlReader)
        Dim fileName As String = reader.ReadElementString("fileName", ns)
        Me.filePath = Path.Combine(MusicPath, Path.ChangeExtension(fileName, ".mp3"))

    End Sub

    Sub ReadSongSize(ByVal reader As XmlReader)
        Me.size = Convert.ToDouble(reader.ReadElementString("size", ns))

    End Sub

    Sub ReadAndSaveSong(ByVal reader As XmlReader)
        Dim outFile As FileStream = File.Open(Me.filePath, FileMode.Create, FileAccess.Write)

        Dim songBase64 As String
        Dim songBytes() As Byte
        reader.ReadStartElement("song", ns)
        Dim totalRead As Double = 0
        While True
            If reader.IsStartElement("chunk", ns) Then
                songBase64 = reader.ReadElementString()
                totalRead += songBase64.Length
                songBytes = Convert.FromBase64String(songBase64)
                outFile.Write(songBytes, 0, songBytes.Length)
                outFile.Flush()
                RaiseEvent OnProgress((100 * (totalRead / size)))
            Else
                Exit While
            End If
        End While

        outFile.Close()
        reader.ReadEndElement()
    End Sub

    Public Sub Play()
        System.Diagnostics.Process.Start(Me.filePath)
    End Sub

    Function GetSchema() As System.Xml.Schema.XmlSchema Implements IXmlSerializable.GetSchema
        Throw New System.NotImplementedException()
    End Function

    Public Sub WriteXml(ByVal writer As XmlWriter) Implements IXmlSerializable.WriteXml
        Throw New System.NotImplementedException()
    End Sub
End Class
'</snippet3>


