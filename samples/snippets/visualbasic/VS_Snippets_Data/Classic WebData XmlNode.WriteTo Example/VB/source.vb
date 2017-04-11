' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    
    Public Shared Sub Main()
        
        Dim doc As New XmlDocument()
        doc.LoadXml("<book xmlns:bk='urn:samples' bk:ISBN='1-861001-57-5'>" & _
                    "<title>Pride And Prejudice</title>" & _
                    "</book>")
        
        Dim root As XmlNode = doc.FirstChild
        
        Console.WriteLine("Display the root node...")
        Dim writer As New XmlTextWriter(Console.Out)
        writer.Formatting = Formatting.Indented
        root.WriteTo(writer)
    End Sub 'Main 
End Class 'Sample
' </Snippet1>