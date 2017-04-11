' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    
    Public Shared Sub Main()
        Dim doc As New XmlDocument()
        doc.LoadXml("<book genre='novel' ISBN='1-861001-57-5'>" & _
                    "<title>Pride And Prejudice</title>"  & _
                    "</book>")
        
        'Create a comment.
        Dim newComment As XmlComment
        newComment = doc.CreateComment("Sample XML document")
        
        'Add the new node to the document.
        Dim root As XmlElement = doc.DocumentElement
        doc.InsertBefore(newComment, root)
        
        Console.WriteLine("Display the modified XML...")
        doc.Save(Console.Out)
    End Sub 'Main 
End Class 'Sample
' </Snippet1>
