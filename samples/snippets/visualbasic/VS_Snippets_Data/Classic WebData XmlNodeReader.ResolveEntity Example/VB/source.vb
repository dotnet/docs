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
            doc.LoadXml("<!DOCTYPE book [<!ENTITY h 'hardcover'>]>" & _
                        "<book>" & _
                        "<title>Pride And Prejudice</title>" & _
                        "<misc>&h;</misc>" & _
                        "</book>")
            
            'Create the reader.
            reader = New XmlNodeReader(doc)
            
            reader.MoveToContent() 'Move to the root element.
            reader.Read() 'Move to title start tag.
            reader.Skip() 'Skip the title element.
            'Read the misc start tag.  The reader is now positioned on
            'the entity reference node.
            reader.ReadStartElement()
            
            'You must call ResolveEntity to expand the entity reference.
            'The entity replacement text is then parsed and returned as a child node.
            Console.WriteLine("Expand the entity...")
            reader.ResolveEntity()
            
            Console.WriteLine("The entity replacement text is returned as a text node.")
            reader.Read()
            Console.WriteLine("NodeType: {0} Value: {1}", reader.NodeType, reader.Value)
            
            Console.WriteLine("An EndEntity node closes the entity reference scope.")
            reader.Read()
            Console.WriteLine("NodeType: {0} Name: {1}", reader.NodeType, reader.Name)
        
        Finally
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
        End Try
    End Sub 'Main
End Class 'Sample 
' </Snippet1>
