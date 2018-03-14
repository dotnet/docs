Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Xml.Xsl
Imports System.Xml.XPath
Imports System.Xml.Schema



Public Class Class1
    ' <Snippet1>
    Public Sub DisplayAttributes(reader As XmlReader)
        If reader.HasAttributes Then
            Console.WriteLine("Attributes of <" & reader.Name & ">")
            While reader.MoveToNextAttribute()
                Console.WriteLine(" {0}={1}", reader.Name, reader.Value)
            End While
        End If
    End Sub 'DisplayAttributes
    ' </Snippet1>
End Class 'Class1 
