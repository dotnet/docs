' <Snippet1>
Option Explicit On
Option Strict On

Imports System
Imports System.IO
Imports System.Xml

Public Class Sample

    Public Shared Sub Main()
        Dim reader As XmlTextReader = Nothing
        Try
            'Create the XML fragment to be parsed.
            Dim xmlFrag As String = "<book genre='novel' misc='sale-item &h;'></book>"

            'Create the XmlParserContext. The XmlParserContext provides the 
            'necessary DTD information so that the entity reference can be expanded.
            Dim context As XmlParserContext
            Dim subset As String = "<!ENTITY h 'hardcover'>"
            context = New XmlParserContext(Nothing, Nothing, "book", Nothing, Nothing, subset, "", "", XmlSpace.None)

            'Create the reader. 
            reader = New XmlTextReader(xmlFrag, XmlNodeType.Element, context)

            'Read the all the attributes on the book element.
            reader.MoveToContent()
            While reader.MoveToNextAttribute()
                Console.WriteLine("{0} = {1}", reader.Name, reader.Value)
            End While
        Finally
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
        End Try
    End Sub 'Main
End Class 'Sample
' </Snippet1>
