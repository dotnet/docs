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
        doc.LoadXml("<bookstore>" & _
                    "<book genre='novel' ISBN='1-861001-57-5'>" & _
                    "<title>Pride And Prejudice</title>" & _
                    "</book>" & _
                    "</bookstore>")
        
        'Create a reader.
        Dim reader As New XmlTextReader("cd.xml")
        reader.MoveToContent() 'Move to the cd element node.
        'Create a node representing the cd element node.
        Dim cd As XmlNode = doc.ReadNode(reader)
        
        'Insert the new node into the document.
        doc.DocumentElement.AppendChild(cd)
        
        Console.WriteLine("Display the modified XML...")
        doc.Save(Console.Out)
    End Sub 'Main 
End Class 'Sample
' </Snippet1>
