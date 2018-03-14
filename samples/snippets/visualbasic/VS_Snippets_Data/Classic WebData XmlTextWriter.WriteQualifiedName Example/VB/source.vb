' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    Private Shared filename As String = "sampledata.xml"
    Public Shared Sub Main()
        Dim writer As XmlTextWriter = Nothing
        
        writer = New XmlTextWriter(filename, Nothing)
        ' Use indenting for readability.
        writer.Formatting = Formatting.Indented
        
        ' Write the root element.
        writer.WriteStartElement("schema")
        
        ' Write the namespace declarations.
        writer.WriteAttributeString("xmlns", Nothing, "http://www.w3.org/2001/XMLSchema")
        writer.WriteAttributeString("xmlns", "po", Nothing, "http://contoso.com/po")
        
        writer.WriteStartElement("element")
        
        writer.WriteAttributeString("name", "purchaseOrder")
        
        ' Write the type attribute.
        writer.WriteStartAttribute(Nothing, "type", Nothing)
        writer.WriteQualifiedName("PurchaseOrder", "http://contoso.com/po")
        writer.WriteEndAttribute()
        
        writer.WriteEndElement()
        
        ' Write the close tag for the root element.
        writer.WriteEndElement()
        
        ' Write the XML to file and close the writer.
        writer.Flush()
        writer.Close()
        
        ' Read the file back in and parse to ensure well formed XML.
        Dim doc As New XmlDocument()
        ' Preserve white space for readability.
        doc.PreserveWhitespace = True
        ' Load the file.
        doc.Load(filename)
        
        ' Write the XML content to the console.
        Console.Write(doc.InnerXml)
    End Sub 'Main 
End Class 'Sample

' </Snippet1>