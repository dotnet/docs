' <Snippet1>
Option Explicit
Option Strict

Imports System
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
        
        'Clone the root node.  The cloned node includes
        'child nodes. This is similar to calling CloneNode(true).
        Dim clone As XmlNode = root.Clone()
        Console.WriteLine(clone.OuterXml)
    End Sub 'Main
End Class 'Sample
' </Snippet1>
