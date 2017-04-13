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
            'Create the XML fragment to be parsed.
            Dim xmlFrag As String = "<book genre='novel' misc='sale-item &h; 1987'></book>"
            
            'Create the XmlParserContext.
            Dim context As XmlParserContext
            Dim subset As String = "<!ENTITY h 'hardcover'>"
            context = New XmlParserContext(Nothing, Nothing, "book", Nothing, Nothing, subset, "", "", XmlSpace.None)
            
            'Create the reader and set it to not expand general entities. 
            reader = New XmlValidatingReader(xmlFrag, XmlNodeType.Element, context)
            reader.ValidationType = ValidationType.None
            reader.EntityHandling = EntityHandling.ExpandCharEntities
            
            'Read the misc attribute. Because EntityHandling is set to
            'ExpandCharEntities, the attribute is parsed into multiple text
            'and entity reference nodes.
            reader.MoveToContent()
            reader.MoveToAttribute("misc")
            While reader.ReadAttributeValue()
                If reader.NodeType = XmlNodeType.EntityReference Then
                    'To expand the entity, call ResolveEntity.
                    Console.WriteLine("{0} {1}", reader.NodeType, reader.Name)
                Else
                    Console.WriteLine("{0} {1}", reader.NodeType, reader.Value)
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
