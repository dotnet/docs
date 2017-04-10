' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

Public Class Sample

    Public Shared Sub Main()
        Dim reader As XmlTextReader = Nothing

        Try
            'Create the XML fragment to be parsed.
            Dim xmlFrag As String = "<book> " & _
                                    "<title>Pride And Prejudice</title>" & _
                                    "<bk:genre>novel</bk:genre>" & _
                                    "</book>"

            'Create the XmlNamespaceManager that is used to
            'look up namespace information.
            Dim nt As New NameTable()
            Dim nsmgr As New XmlNamespaceManager(nt)
            nsmgr.AddNamespace("bk", "urn:sample")

            'Create the XmlParserContext.
            Dim context As New XmlParserContext(Nothing, nsmgr, Nothing, XmlSpace.None)

            'Implement the reader. 
            reader = New XmlTextReader(xmlFrag, XmlNodeType.Element, context)

            'Parse the XML fragment.  If they exist, display the   
            'prefix and namespace URI of each element.
            While reader.Read()
                If reader.IsStartElement() Then
                    If reader.Prefix = String.Empty Then
                        Console.WriteLine("<{0}>", reader.LocalName)
                    Else
                        Console.Write("<{0}:{1}>", reader.Prefix, reader.LocalName)
                        Console.WriteLine(" The namespace URI is " & reader.NamespaceURI)
                    End If
                End If
            End While
        Finally
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
        End Try
    End Sub 'Main
End Class 'Sample 
' </Snippet1>
