' <Snippet1>
Option Explicit
Option Strict

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
        
        ' OuterXml includes the markup of current node.
        Console.WriteLine("Display the OuterXml property...")
        Console.WriteLine(root.OuterXml)
        
        ' InnerXml does not include the markup of the current node.
        ' As a result, the attributes are not displayed.
        Console.WriteLine()
        Console.WriteLine("Display the InnerXml property...")
        Console.WriteLine(root.InnerXml)
        
    End Sub 'Main 
End Class 'Sample
' </Snippet1>
