' <Snippet1>
Option Explicit On
Option Strict On
Imports System.Xml

Public Class TagSample

    Public Shared Sub Main()
        'Create the XmlDocument.
        Dim doc As New XmlDocument()
        doc.Load("books.xml")

        'Display all the book titles.
        Dim elemList As XmlNodeList = doc.GetElementsByTagName("title")
        Dim i As Integer
        For i = 0 To elemList.Count - 1
            Console.WriteLine(elemList(i).InnerXml)
        Next i
    End Sub
End Class
' </Snippet1>
