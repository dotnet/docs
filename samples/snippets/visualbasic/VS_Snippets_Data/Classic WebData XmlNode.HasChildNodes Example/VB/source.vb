' <Snippet1>
Option Strict
Option Explicit

Imports System.IO
Imports System.Xml

Public Class Sample
    
    Public Shared Sub Main()
        
        Dim doc As New XmlDocument()
        doc.LoadXml("<book ISBN='1-861001-57-5'>" & _
                    "<title>Pride And Prejudice</title>" & _
                    "<price>19.95</price>" & _
                    "</book>")
        
        Dim root As XmlNode = doc.FirstChild
        
        'Display the contents of the child nodes.
        If root.HasChildNodes Then
            Dim i As Integer
            For i = 0 To root.ChildNodes.Count - 1
                Console.WriteLine(root.ChildNodes(i).InnerText)
            Next i
        End If
    End Sub
End Class
' </Snippet1>
