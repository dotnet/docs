Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization


Public Class Sample
    
    ' <Snippet1>
    Private Sub TestDocument _
                    (ByVal filename As String, _
                     ByVal objType As Type)
        ' Using a FileStream, create an XmlTextReader.
        Dim fs As New FileStream(filename, FileMode.Open)
        Dim reader As New XmlTextReader(fs)
        Dim serializer As New XmlSerializer(objType)
        If serializer.CanDeserialize(reader) Then
            Dim o As Object = serializer.Deserialize(reader)
        End If
        fs.Close()
    End Sub
    ' </Snippet1>
End Class
