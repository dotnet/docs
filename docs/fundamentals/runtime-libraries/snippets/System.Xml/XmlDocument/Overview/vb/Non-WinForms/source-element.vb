' <Snippet1>
Option Strict On
Option Explicit On
Imports System.Xml

Public Class ElementSample
    Public Shared Sub Main()
        'Create the XmlDocument.
        Dim doc As New XmlDocument()
        doc.LoadXml("<?xml version='1.0' ?>" &
                    "<book genre='novel' ISBN='1-861001-57-5'>" &
                    "<title>Pride And Prejudice</title>" &
                    "</book>")

        'Display the document element.
        Console.WriteLine(doc.DocumentElement.OuterXml)
    End Sub
End Class
' </Snippet1>
