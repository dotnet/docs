'<snippet1>
Option Strict
Option Explicit

Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    Private Shared m_Document As String = "sampledata.xml"
    
    Public Shared Sub Main()
        Dim writer As XmlWriter = Nothing
        
      Try

        Dim settings As XmlWriterSettings = new XmlWriterSettings()
        settings.Indent = true
        writer = XmlWriter.Create (m_Document, settings)
            
        writer.WriteComment("sample XML fragment")
            
        ' Write an element (this one is the root).
        writer.WriteStartElement("book")
            
        ' Write the namespace declaration.
        writer.WriteAttributeString("xmlns", "bk", Nothing, "urn:samples")
            
        ' Write the genre attribute.
        writer.WriteAttributeString("genre", "novel")
            
        ' Write the title.
        writer.WriteStartElement("title")
        writer.WriteString("The Handmaid's Tale")
        writer.WriteEndElement()
            
        ' Write the price.
        writer.WriteElementString("price", "19.95")
            
        ' Lookup the prefix and write the ISBN element.
        Dim prefix As String = writer.LookupPrefix("urn:samples")
        writer.WriteStartElement(prefix, "ISBN", "urn:samples")
        writer.WriteString("1-861003-78")
        writer.WriteEndElement()
            
        ' Write the style element (shows a different way to handle prefixes).
        writer.WriteElementString("style", "urn:samples", "hardcover")
            
        ' Write the close tag for the root element.
        writer.WriteEndElement()
            
        ' Write the XML to file and close the writer.
        writer.Flush()
        writer.Close()
        
        Finally
            If Not (writer Is Nothing) Then
                writer.Close()
            End If
        End Try

    End Sub 'Main 
End Class 'Sample
'</snippet1>