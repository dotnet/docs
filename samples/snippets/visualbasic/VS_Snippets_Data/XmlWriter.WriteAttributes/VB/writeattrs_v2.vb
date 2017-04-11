'<snippet1>
Option Strict
Option Explicit

Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    
  Public Shared Sub Main()

    Dim reader As XmlReader = XmlReader.Create("test1.xml")
    Dim settings As XmlWriterSettings = new XmlWriterSettings()
    settings.Indent = true
    Dim writer As XmlWriter = XmlWriter.Create(Console.Out)
        
      While reader.Read()
          If reader.NodeType = XmlNodeType.Element Then
              writer.WriteStartElement(reader.Name.ToUpper())
              writer.WriteAttributes(reader, False)
              If reader.IsEmptyElement Then
                 writer.WriteEndElement()
              End If
          Else
              If reader.NodeType = XmlNodeType.EndElement Then
                  writer.WriteEndElement()
              End If
          End If
      End While
      writer.Close()
      reader.Close()

    End Sub 'Main
End Class 'Sample
'</snippet1>