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
        doc.LoadXml("<!DOCTYPE book [<!ENTITY h 'hardcover'>]>" & _
                    "<book genre='novel' ISBN='1-861001-57-5'>" & _
                    "<title>Pride And Prejudice</title>" & _
                    "<style>&h;</style>" & _
                    "</book>")
        
        ' Determine whether the node is read-only.
        Dim entref As XmlEntityReference = CType(doc.DocumentElement.LastChild.FirstChild, XmlEntityReference)
        If entref.IsReadOnly Then
            Console.WriteLine("Entity reference nodes are always read-only")
        End If
    End Sub 'Main
End Class 'Sample 
' </Snippet1>
