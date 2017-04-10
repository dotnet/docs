' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    
    Public Shared Sub Main()
        'Create a writer to write XML to the console.
        Dim writer As XmlTextWriter = Nothing
        writer = New XmlTextWriter(Console.Out)
        
        'Use indentation for readability.
        writer.Formatting = Formatting.Indented
        writer.Indentation = 4
        
        'Write an element (this one is the root).
        writer.WriteStartElement("book")
        
        'Write the title element.
        writer.WriteStartElement("title")
        writer.WriteString("Pride And Prejudice")
        writer.WriteEndElement()
        
        'Write the close tag for the root element.
        writer.WriteEndElement()
        
        'Write the XML to file and close the writer.
        writer.Close()
    End Sub 'Main 
End Class 'Sample
' </Snippet1>