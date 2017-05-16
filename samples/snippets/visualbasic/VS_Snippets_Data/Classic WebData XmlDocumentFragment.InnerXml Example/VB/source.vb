' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    
    Public Shared Sub Main()
        ' Create the XmlDocument.
        Dim doc As New XmlDocument()
        
        ' Create a document fragment.
        Dim docFrag As XmlDocumentFragment = doc.CreateDocumentFragment()
        
        ' Set the contents of the document fragment.
        docFrag.InnerXml = "<item>widget</item>"
        
        ' Display the document fragment.
        Console.WriteLine(docFrag.InnerXml)
    End Sub 'Main 
End Class 'Sample
' </Snippet1>