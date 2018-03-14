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
            'Create and load the XML document.
            Dim doc As New XmlDocument()
            doc.LoadXml("<!-- sample XML -->" & _
                       "<book>" & _
                       "<title>Pride And Prejudice</title>" & _
                       "<price>19.95</price>" & _
                       "</book>")
            
            'Load the XmlNodeReader 
            reader = New XmlNodeReader(doc)
            
            reader.MoveToContent() 'Move to the book node.
            reader.Read() 'Read the book start tag.
            reader.Skip() 'Skip the title element.
            Console.WriteLine(reader.ReadOuterXml()) 'Read the price element.
        Finally
            If Not (reader Is Nothing) Then
                reader.Close()
            End If
        End Try
    End Sub 'Main
End Class 'Sample 
' </Snippet1>
