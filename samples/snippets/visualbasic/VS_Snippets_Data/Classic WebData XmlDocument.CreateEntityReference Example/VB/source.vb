' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    
    Public Shared Sub Main()
        'Create the XmlDocument.
        Dim doc As New XmlDocument()
        doc.LoadXml("<!DOCTYPE book [<!ENTITY h 'hardcover'>]>" & _
                    "<book genre='novel' ISBN='1-861001-57-5'>"  & _
                    "<title>Pride And Prejudice</title>"  & _
                    "<misc/>"  & _
                    "</book>")
        
        'Create an entity reference node. The child count should be 0 
        'since the node has not been expanded.
        Dim entityref As XmlEntityReference = doc.CreateEntityReference("h")
        Console.WriteLine(entityref.ChildNodes.Count)
        
        'After the the node has been added to the document, its parent node
        'is set and the entity reference node is expanded.  It now has a child
        'node containing the entity replacement text. 
        doc.DocumentElement.LastChild.AppendChild(entityref)
        Console.WriteLine(entityref.FirstChild.InnerText)
        
        'Create and insert an undefined entity reference node.  When the entity
        'reference node is expanded, because the entity reference is undefined
        'the child is an empty text node.
        Dim entityref2 As XmlEntityReference = doc.CreateEntityReference("p")
        doc.DocumentElement.LastChild.AppendChild(entityref2)
        Console.WriteLine(entityref2.FirstChild.InnerText)
    End Sub 'Main 
End Class 'Sample
' </Snippet1>
