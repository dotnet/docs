' <Snippet1>
Imports System
Imports System.Xml

Public Class Sample

    Public Shared Sub Main()

        Dim reader As XmlTextReader = Nothing

        Try

            ' Create the string containing the XML to read.
            Dim xmlFrag As String
            xmlFrag = "<book>" & _
                           "<title>Pride And Prejudice</title>" & _
                           "<author>" & _
                           "<first-name>Jane</first-name>" & _
                           "<last-name>Austen</last-name>" & _
                           "</author>" & _
                           "<curr:price>19.95</curr:price>" & _
                           "<misc>&h;</misc>" & _
                           "</book>"

            ' Create an XmlNamespaceManager to resolve namespaces.
            Dim nt As NameTable = New NameTable()
            Dim nsmgr As XmlNamespaceManager = New XmlNamespaceManager(nt)
            nsmgr.AddNamespace(String.Empty, "urn:samples") 'default namespace
            nsmgr.AddNamespace("curr", "urn:samples:dollar")

            ' Create an XmlParserContext.  The XmlParserContext contains all the information
            ' required to parse the XML fragment, including the entity information and the
            ' XmlNamespaceManager to use for namespace resolution.
            Dim context As XmlParserContext
            Dim subset As String = "<!ENTITY h 'hardcover'>"
            context = New XmlParserContext(nt, nsmgr, "book", Nothing, Nothing, subset, Nothing, Nothing, XmlSpace.None)

            ' Create the reader.
            reader = New XmlTextReader(xmlFrag, XmlNodeType.Element, context)

            ' Parse the file and display the node values.
            While (reader.Read())
                If (reader.HasValue) Then
                    Console.WriteLine("{0} [{1}] = {2}", reader.NodeType, reader.Name, reader.Value)
                Else
                    Console.WriteLine("{0} [{1}]", reader.NodeType, reader.Name)
                End If
            End While

        Finally
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
        End Try
    End Sub
End Class
' </Snippet1>

