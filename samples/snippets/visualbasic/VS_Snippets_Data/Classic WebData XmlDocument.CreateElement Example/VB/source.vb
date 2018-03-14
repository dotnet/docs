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
        doc.LoadXml("<book genre='novel' ISBN='1-861001-57-5'>"  & _
                    "<title>Pride And Prejudice</title>"  & _
                    "</book>")
        
        'Create a new node and add it to the document.
        'The text node is the content of the price element.
        Dim elem As XmlElement = doc.CreateElement("price")
        Dim text As XmlText = doc.CreateTextNode("19.95")
        doc.DocumentElement.AppendChild(elem)
        doc.DocumentElement.LastChild.AppendChild(text)
        
        Console.WriteLine("Display the modified XML...")
        doc.Save(Console.Out)
    End Sub 'Main 
End Class 'Sample
' </Snippet1>
