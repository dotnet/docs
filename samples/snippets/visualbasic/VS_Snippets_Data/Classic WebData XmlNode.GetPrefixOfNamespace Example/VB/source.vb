' <Snippet1>
Option Strict
Option Explicit

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
        
        'Create a new node.
        Dim prefix As String = root.GetPrefixOfNamespace("urn:samples")
        Dim elem As XmlElement = doc.CreateElement(prefix, "style", "urn:samples")
        elem.InnerText = "hardcover"
        
        'Add the node to the document.
        root.AppendChild(elem)
        
        Console.WriteLine("Display the modified XML...")
        doc.Save(Console.Out)
    End Sub 'Main 
End Class 'Sample
' </Snippet1>
