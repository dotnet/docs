 ' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    
    Public Shared Sub Main()
        
        Dim doc As New XmlDocument()
        doc.LoadXml("<book genre='novel' ISBN='1-861001-57-5'>" & _
                    "<title>Pride And Prejudice</title>" & _
                    "</book>")
        
        Dim root As XmlNode = doc.DocumentElement
        
        'Create a new title element.
        Dim elem As XmlElement = doc.CreateElement("title")
        elem.InnerText = "The Handmaid's Tale"
        
        'Replace the title element.
        root.ReplaceChild(elem, root.FirstChild)
        
        Console.WriteLine("Display the modified XML...")
        doc.Save(Console.Out)
    End Sub 'Main 
End Class 'Sample
' </Snippet1>