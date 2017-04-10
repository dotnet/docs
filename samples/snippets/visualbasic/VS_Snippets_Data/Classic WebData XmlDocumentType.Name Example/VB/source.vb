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
        doc.LoadXml("<!DOCTYPE book [<!ENTITY h 'hardcover'>]>" & _
                    "<book genre='novel' ISBN='1-861001-57-5'>" & _
                    "<title>Pride And Prejudice</title>" & _
                    "<style>&h;</style>" & _
                    "</book>")
        
        ' Display information on the DocumentType node.
        Dim doctype As XmlDocumentType = doc.DocumentType
        Console.WriteLine("Name of the document type:  {0}", doctype.Name)
        Console.WriteLine("The internal subset of the document type:  {0}", doctype.InternalSubset)
    End Sub 'Main 
End Class 'Sample
' </Snippet1>
