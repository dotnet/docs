'<snippet1>
Imports System
Imports System.IO
Imports System.Xml

Public Class Sample

  Public Shared Sub Main()

     ' Create an XmlWriter to write XML fragments.
     Dim settings As XmlWriterSettings = new XmlWriterSettings()
     settings.ConformanceLevel = ConformanceLevel.Fragment
     settings.Indent = true
     Dim writer As XmlWriter = XmlWriter.Create(Console.Out, settings)
	
     ' Write an XML fragment.
     writer.WriteStartElement("book")
     writer.WriteElementString("title", "Pride And Prejudice")
     writer.WriteEndElement()
     writer.Flush()

     ' Write another XML fragment.
     writer.WriteStartElement("cd")
     writer.WriteElementString("title", "Americana")
     writer.WriteEndElement()
     writer.Flush()  

     'Close the writer.
     writer.Close()

  End Sub
End Class
'</snippet1>