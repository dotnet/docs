' <snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Text
Imports Microsoft.VisualBasic

Public Class Sample 

  Public Shared Sub Main() 
  
    Dim writer As XmlWriter = Nothing

    Try 

       ' Create an XmlWriterSettings object with the correct options. 
       Dim settings As XmlWriterSettings = New XmlWriterSettings()
       settings.Indent = true
       settings.IndentChars = (ControlChars.Tab)
       settings.OmitXmlDeclaration = true

       ' Create the XmlWriter object and write some content.
       writer = XmlWriter.Create("data.xml", settings)
       writer.WriteStartElement("book")
       writer.WriteElementString("item", "tesing")
       writer.WriteEndElement()
	
       writer.Flush()

      Finally
         If Not (writer Is Nothing) Then
            writer.Close()
         End If
      End Try

   End Sub 
End Class 
' </snippet1>