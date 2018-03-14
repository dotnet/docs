Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Xml.Xsl
Imports System.Xml.XPath

Public Class Class1
    ' <Snippet1>
    Public Sub DisplayAttributes(reader As XmlReader)
        If reader.HasAttributes Then
            Console.WriteLine("Attributes of <" & reader.Name & ">")
            Dim i As Integer
            For i = 0 To reader.AttributeCount - 1
                reader.MoveToAttribute(i)
                Console.Write(" {0}={1}", reader.Name, reader.Value)
            Next i
            reader.MoveToElement() 'Moves the reader back to the element node.
        End If
    End Sub 'DisplayAttributes
    ' </Snippet1>
End Class 'Class1 
