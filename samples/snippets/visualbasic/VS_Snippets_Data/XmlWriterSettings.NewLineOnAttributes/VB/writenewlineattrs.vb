Imports System.IO
Imports System.Xml

Public Class Sample 

    Public Shared Sub Main() 
  
        Dim writer As XmlWriter = Nothing

        Try 
            '<snippet1>
            Dim settings As New XmlWriterSettings()
            settings.Indent = True
            settings.OmitXmlDeclaration = True
            settings.NewLineOnAttributes = True
       
            writer = XmlWriter.Create(Console.Out, settings)

            writer.WriteStartElement("order")
            writer.WriteAttributeString("orderID", "367A54")
            writer.WriteAttributeString("date", "2001-05-03")
            writer.WriteElementString("price", "19.95")
            writer.WriteEndElement()
	
            writer.Flush()
            '</snippet1>
     
        Finally
           If writer IsNot Nothing Then
                writer.Close()
           End If
        End Try

    End Sub 
End Class 