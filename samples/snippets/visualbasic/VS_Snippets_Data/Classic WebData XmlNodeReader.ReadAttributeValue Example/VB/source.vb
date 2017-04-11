' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    
    Public Shared Sub Main()
        Dim reader As XmlNodeReader = Nothing
        
        Try
            'Create and load an XML document.
            Dim doc As New XmlDocument()
            doc.LoadXml("<!DOCTYPE book [<!ENTITY h 'harcover'>]>" & _
                        "<book genre='novel' misc='sale-item &h; 1987'>" & _
                        "</book>")
            
            'Create the reader. 
            reader = New XmlNodeReader(doc)
            
            'Read the misc attribute. The attribute is parsed into multiple 
            'text and entity reference nodes.
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
