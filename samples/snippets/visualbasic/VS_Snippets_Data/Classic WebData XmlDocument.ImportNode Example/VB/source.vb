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
        doc.LoadXml("<bookstore>" & _
                    "<book genre='novel' ISBN='1-861001-57-5'>" & _
                    "<title>Pride And Prejudice</title>" & _
                    "</book>" & _
                    "</bookstore>")
        
        'Create another XmlDocument which holds a list of books.
        Dim doc2 As New XmlDocument()
        doc2.Load("books.xml")
        
        'Import the last book node from doc2 into the original document.
        Dim newBook As XmlNode = doc.ImportNode(doc2.DocumentElement.LastChild, True)
        doc.DocumentElement.AppendChild(newBook)
        
        Console.WriteLine("Display the modified XML...")
        doc.Save(Console.Out)
    End Sub 'Main 
End Class 'Sample
' </Snippet1>
