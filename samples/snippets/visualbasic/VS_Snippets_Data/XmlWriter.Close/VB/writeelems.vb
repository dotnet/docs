'<snippet1>
Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    
  Public Shared Sub Main()

     ' Create a writer to write XML to the console.
     Dim settings As XmlWriterSettings = new XmlWriterSettings()
     settings.Indent = true
     settings.OmitXmlDeclaration = true
     Dim writer As XmlWriter = XmlWriter.Create(Console.Out, settings)

     ' Write the book element.
     writer.WriteStartElement("book")
        
     ' Write the title element.
     writer.WriteStartElement("title")
     writer.WriteString("Pride And Prejudice")
     writer.WriteEndElement()
        
     ' Write the close tag for the root element.
     writer.WriteEndElement()
        
     ' Write the XML and close the writer.
     writer.Close()

  End Sub 'Main 
End Class 'Sample
'</snippet1>