Imports System

'Module Module1

'    Sub Main()
'        Dim test As New XMLWrite
'        test.WriteXML()
'        Dim test2 As New XMLRead
'        test2.ReadXML()
'        Console.ReadLine()
'    End Sub
'End Module

' How to: Write Class Data to an XML File
' <snippet1>
Public Module XMLWrite

    Sub Main()
        WriteXML()
    End Sub

    Public Class Book
        Public Title As String
    End Class

    Public Sub WriteXML()
        Dim overview As New Book
        overview.Title = "Serialization Overview"
        Dim writer As New System.Xml.Serialization.XmlSerializer(GetType(Book))
        Dim file As New System.IO.StreamWriter(
            "c:\temp\SerializationOverview.xml")
        writer.Serialize(file, overview)
        file.Close()
    End Sub
End Module
' </snippet1>

Public Class XMLRead
    ' How to: Read Class Data from an XML File 

    ' <snippet2>
    Public Class Book
        Public Title As String
    End Class

    Public Sub ReadXML()
        Dim reader As New System.Xml.Serialization.XmlSerializer(GetType(Book))
        Dim file As New System.IO.StreamReader(
            "c:\temp\SerializationOverview.xml")
        Dim overview As Book
        overview = CType(reader.Deserialize(file), Book)
        Console.WriteLine(overview.Title)
    End Sub
    ' </snippet2>

End Class
