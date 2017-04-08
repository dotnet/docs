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
        
        'Create a document type node and  
        'add it to the document.
        Dim doctype As XmlDocumentType
        doctype = doc.CreateDocumentType("book", Nothing, Nothing, "<!ELEMENT book ANY>")
        doc.AppendChild(doctype)
        
        'Create the root element and 
        'add it to the document.
        doc.AppendChild(doc.CreateElement("book"))
        
        Console.WriteLine("Display the modified XML...")
        doc.Save(Console.Out)
    End Sub 'Main
End Class 'Sample
' </Snippet1>