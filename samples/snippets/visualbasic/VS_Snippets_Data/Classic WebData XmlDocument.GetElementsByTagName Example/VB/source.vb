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
        doc.Load("books.xml")
        
        'Display all the book titles.
        Dim elemList As XmlNodeList = doc.GetElementsByTagName("title")
        Dim i As Integer
        For i = 0 To elemList.Count - 1
            Console.WriteLine(elemList(i).InnerXml)
        Next i
    End Sub 'Main 
End Class 'Sample
' </Snippet1>