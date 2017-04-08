Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Xml.Xsl
Imports System.Xml.XPath
Imports System.Xml.Schema



Public Class Class1
    
    ' <Snippet1>
    Public Shared Sub WriteXml(doc As XmlDocument)
        Dim writer As New XmlTextWriter(Console.Out)
        writer.Formatting = Formatting.Indented
        doc.WriteTo(writer)
        writer.Flush()
        Console.WriteLine()
    End Sub 'WriteXml
    ' </Snippet1>
End Class 'Class1 
