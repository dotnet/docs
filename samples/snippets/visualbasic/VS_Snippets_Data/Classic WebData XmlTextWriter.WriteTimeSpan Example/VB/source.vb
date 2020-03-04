' <Snippet1>
Imports System.Xml

Public Class Sample 
 
    Public Shared Sub Main() 
   
        Dim writer As XmlTextWriter = Nothing

        Try 

            writer = new XmlTextWriter(Console.Out)

            ' Write an element.
            writer.WriteStartElement("address")
     
            ' Write an email address using entities
            ' for the @ and . characters.
            writer.WriteString("someone")
            writer.WriteCharEntity("@"c)
            writer.WriteString("example")
            writer.WriteCharEntity("."c)
            writer.WriteString("com")
            writer.WriteEndElement()        
 
        Finally
            ' Close the writer.
            If writer IsNot Nothing
                writer.Close()
            End If
        End Try

    End Sub
End Class
' </Snippet1>
