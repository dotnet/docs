' <Snippet1>
Option Strict
Option Explicit

Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    
    Public Shared Sub Main()
        ' Create a writer that outputs to the console.
        Dim writer As New XmlTextWriter(Console.Out)
        writer.Formatting = Formatting.Indented
        
        ' Write the root element.
        writer.WriteStartElement("Items")
        
        ' Write a string using WriteRaw. Note that the special
        ' characters are not escaped.
        writer.WriteStartElement("Item")
        writer.WriteString("Write unescaped text:  ")
        writer.WriteRaw("this & that")
        writer.WriteEndElement()
        
        ' Write the same string using WriteString. Note that the 
        ' special characters are escaped.
        writer.WriteStartElement("Item")
        writer.WriteString("Write the same string using WriteString:  ")
        writer.WriteString("this & that")
        writer.WriteEndElement()
        
        ' Write the close tag for the root element.
        writer.WriteEndElement()
        
        ' Write the XML to file and close the writer.
        writer.Close()
    End Sub 'Main
End Class 'Sample 
' </Snippet1>