'<snippet1>
Imports System.IO
Imports System.Xml

Public Class Sample

    Public Shared Sub Main()

        Dim reader As XmlTextReader = Nothing

        Try
            ' Create the XML fragment to be parsed.
            Dim xmlFrag As String = "<book genre='novel' misc='sale-item &h; 1987'></book>"
 
            Dim subset As String = "<!ENTITY h 'hardcover'>"
			' Create the XmlParserContext.
            Dim context As New XmlParserContext(Nothing, Nothing, "book", Nothing, Nothing, subset, "", "", XmlSpace.None)
        
		    'Create the reader.
		    reader = New XmlTextReader(xmlFrag, XmlNodeType.Element, context)
  
            'Read the misc attribute. The attribute is parsed
            'into multiple text and entity reference nodes.
            reader.MoveToContent()
            reader.MoveToAttribute("misc")
            While (reader.ReadAttributeValue())
                If (reader.NodeType = XmlNodeType.EntityReference)
                    Console.WriteLine($"{reader.NodeType} {reader.Name}")
                Else
                    Console.WriteLine($"{reader.NodeType} {reader.Value}")
                End If
            End While

        Finally 
            If reader IsNot Nothing
                reader.Close()
            End if
        End Try
    End Sub
End Class
'</snippet1>


