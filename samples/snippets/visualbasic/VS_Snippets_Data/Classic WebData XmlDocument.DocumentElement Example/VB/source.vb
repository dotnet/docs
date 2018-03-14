' <Snippet1>
Option Strict
Option Explicit

Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    
    Public Shared Sub Main()
        'Create the XmlDocument.
        Dim doc As New XmlDocument()
        doc.LoadXml("<?xml version='1.0' ?>" & _
                    "<book genre='novel' ISBN='1-861001-57-5'>" & _
                    "<title>Pride And Prejudice</title>" & _
                    "</book>")
        
        'Display the document element.
        Console.WriteLine(doc.DocumentElement.OuterXml)
    End Sub 'Main
End Class 'Sample
' </Snippet1>
