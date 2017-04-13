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
        
        Console.WriteLine("Display the price element...")
        Console.WriteLine(root.LastChild.OuterXml)
    End Sub 'Main
End Class 'Sample
' </Snippet1>
