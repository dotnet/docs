'<snippet1>
Imports System.Xml

Public Class Sample

    Public Shared Sub Main()
        Dim writer As New XmlTextWriter("out.xml", Nothing)
        Dim tag As String = "item name"

        Try
	
            ' Write the root element.
            writer.WriteStartElement("root")

            writer.WriteStartElement(XmlConvert.VerifyName(tag))

        Catch e As XmlException
            Console.WriteLine(e.Message)
            Console.WriteLine("Convert to a valid name...")
            writer.WriteStartElement(XmlConvert.EncodeName(tag))
        End Try

        writer.WriteString("hammer")
        writer.WriteEndElement()

        ' Write the end tag for the root element.
        writer.WriteEndElement()
 
        writer.Close()
  
    End Sub
End Class
'</snippet1>