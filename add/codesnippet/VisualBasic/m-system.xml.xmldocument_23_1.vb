Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    
    Public Shared Sub Main()
        'Create the XmlDocument.
        Dim doc As New XmlDocument()
        
        'Load the the document with the last book node.
        Dim reader As New XmlTextReader("books.xml")
        reader.WhitespaceHandling = WhitespaceHandling.None
        reader.MoveToContent()
        reader.Read()
        reader.Skip() 'Skip the first book.
        reader.Skip() 'Skip the second book.
        doc.Load(reader)
        
        doc.Save(Console.Out)
    End Sub 'Main
End Class 'Sample