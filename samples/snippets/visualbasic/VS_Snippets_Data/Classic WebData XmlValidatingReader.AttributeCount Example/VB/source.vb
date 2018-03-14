' <Snippet1>
Option Strict
Option Explicit

Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    
    Public Shared Sub Main()
        Dim reader As XmlValidatingReader = Nothing
        
        Try
            'Create the string to parse.
            Dim xmlFrag As String = "<book genre='novel' ISBN='1-861003-78' pubdate='1987'></book> "
            
            'Create the XmlNamespaceManager.
            Dim nt As New NameTable()
            Dim nsmgr As New XmlNamespaceManager(nt)
            
            'Create the XmlParserContext.
            Dim context As New XmlParserContext(Nothing, nsmgr, Nothing, XmlSpace.None)
            
            'Create the XmlValidatingReader .
            reader = New XmlValidatingReader(xmlFrag, XmlNodeType.Element, context)
            
            'Read the attributes on the root element.
            reader.MoveToContent()
            If reader.HasAttributes Then
                Dim i As Integer
                For i = 0 To reader.AttributeCount - 1
                    reader.MoveToAttribute(i)
                    Console.WriteLine("{0} = {1}", reader.Name, reader.Value)
                Next i
                'Move the reader back to the node that owns the attribute.
                reader.MoveToElement()
            End If
        
        
        Finally
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
        End Try
    End Sub 'Main ' End class
End Class 'Sample 
' </Snippet1>
