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
     Dim writer As XmlWriter = XmlWriter.Create(Console.Out, settings)
        
     ' Write the root element.
     writer.WriteStartElement("order")
        
     ' Write an element with attributes.
     writer.WriteStartElement("item")
     writer.WriteAttributeString("date", "2/19/01")
     writer.WriteAttributeString("orderID", "136A5")
        
     ' Write a full end element. Because this element has no
     ' content, calling WriteEndElement would have written a
     ' short end tag '/>'.
     writer.WriteFullEndElement()
        
     writer.WriteEndElement()

     ' Write the XML to file and close the writer
     writer.Close()

    End Sub 'Main
End Class 'Sample
'</snippet1>