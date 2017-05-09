' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    
    Public Shared Sub Main()
        
        Dim doc As New XmlDocument()
        doc.Load("2books.xml")
        
        ' Create a new element.
        Dim elem As XmlElement = doc.CreateElement("misc")
        elem.InnerText = "hardcover"
        elem.SetAttribute("publisher", "WorldWide Publishing")
        
        ' Clone the element so we can add one to each of the book nodes.
        Dim elem2 As XmlNode = elem.CloneNode(True)
        
        ' Add the new elements.
        doc.DocumentElement.FirstChild.AppendChild(elem)
        doc.DocumentElement.LastChild.AppendChild(elem2)
        
        Console.WriteLine("Display the modified XML...")
        doc.Save(Console.Out)
    End Sub 'Main 
End Class 'Sample
' </Snippet1>