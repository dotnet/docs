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
        doc.LoadXml("<items/>")
        
        ' Create a document fragment.
        Dim docFrag As XmlDocumentFragment = doc.CreateDocumentFragment()
        
        ' Display the owner document of the document fragment.
        Console.WriteLine(docFrag.OwnerDocument.OuterXml)
        
        ' Add nodes to the document fragment. Notice that the
        ' new element is created using the owner document of 
        ' the document fragment.
        Dim elem As XmlElement = doc.CreateElement("item")
        elem.InnerText = "widget"
        docFrag.AppendChild(elem)
        
        Console.WriteLine("Display the document fragment...")
        Console.WriteLine(docFrag.OuterXml)
    End Sub 'Main
End Class 'Sample
' </Snippet1>