Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Xml.Xsl
Imports System.Xml.XPath
Imports System.Xml.Schema



Public Class Class1

    
    Public Shared Sub Main()

    Dim xsc As XmlSchemaCollection
        ' <Snippet1>
        If xsc.Contains("urn:bookstore-schema") Then
            Dim schema As XmlSchema = xsc("urn:bookstore-schema")
            Dim sw As New StringWriter()
            Dim xmlWriter As New XmlTextWriter(sw)
            xmlWriter.Formatting = Formatting.Indented
            xmlWriter.Indentation = 2
            schema.Write(xmlWriter)
            Console.WriteLine(sw.ToString())
        End If
        ' </Snippet1>
    End Sub 'Method1 
End Class 'Class1
