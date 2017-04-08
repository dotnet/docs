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
        
        Dim doctype As XmlDocumentType = doc.DocumentType
        
        ' Determine whether the node is read-only.
        If doctype.IsReadOnly Then
            Console.WriteLine("Document type nodes are always read-only")
        End If 
    End Sub 'Main
End Class 'Sample
' </Snippet1>
