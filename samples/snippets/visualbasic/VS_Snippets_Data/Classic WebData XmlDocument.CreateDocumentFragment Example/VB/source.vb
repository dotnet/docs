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
        doc.LoadXml("<items/>")
        
        'Create a document fragment.
        Dim docFrag As XmlDocumentFragment = doc.CreateDocumentFragment()
        
        'Set the contents of the document fragment.
        docFrag.InnerXml = "<item>widget</item>"
        
        'Add the children of the document fragment to the
        'original document.
        doc.DocumentElement.AppendChild(docFrag)
        
        Console.WriteLine("Display the modified XML...")
        Console.WriteLine(doc.OuterXml)
    End Sub 'Main 
End Class 'Sample
' </Snippet1>