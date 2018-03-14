' <Snippet1>
Option Strict
Option Explicit

Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    Private Shared filename As String = "sampledata.xml"
    Public Shared Sub Main()
        
        Dim writer As New XmlTextWriter(filename, Nothing)
        'Use indenting for readability.
        writer.Formatting = Formatting.Indented
        
        writer.WriteComment("sample XML fragment")
        
        'Write an element (this one is the root).
        writer.WriteStartElement("bookstore")
        
        'Write the namespace declaration.
        writer.WriteAttributeString("xmlns", "bk", Nothing, "urn:samples")
        
        writer.WriteStartElement("book")
        
        'Lookup the prefix and then write the ISBN attribute.
        Dim prefix As String = writer.LookupPrefix("urn:samples")
        writer.WriteStartAttribute(prefix, "ISBN", "urn:samples")
        writer.WriteString("1-861003-78")
        writer.WriteEndAttribute()
        
        'Write the title.
        writer.WriteStartElement("title")
        writer.WriteString("The Handmaid's Tale")
        writer.WriteEndElement()
        
        'Write the price.
        writer.WriteElementString("price", "19.95")
        
        'Write the style element.
        writer.WriteStartElement(prefix, "style", "urn:samples")
        writer.WriteString("hardcover")
        writer.WriteEndElement()
        
        'Write the end tag for the book element.
        writer.WriteEndElement()
        
        'Write the close tag for the root element.
        writer.WriteEndElement()
        
        'Write the XML to file and close the writer.
        writer.Flush()
        writer.Close()
        
        'Read the file back in and parse to ensure well formed XML.
        Dim doc As New XmlDocument()
        'Preserve white space for readability.
        doc.PreserveWhitespace = True
        'Load the file.
        doc.Load(filename)
        
        'Write the XML content to the console.
        Console.Write(doc.InnerXml)
    End Sub 'Main 
End Class 'Sample
' </Snippet1>