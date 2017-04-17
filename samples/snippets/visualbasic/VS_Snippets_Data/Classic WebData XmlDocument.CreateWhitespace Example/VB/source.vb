' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.Xml
Imports Microsoft.VisualBasic

Public Class Sample
    
    Public Shared Sub Main()

        Dim doc As New XmlDocument()
        doc.LoadXml("<author>" & _
                    "<first-name>Eva</first-name>" & _
                    "<last-name>Corets</last-name>" & _
                    "</author>")
            
        Console.WriteLine("InnerText before...")
        Console.WriteLine(doc.DocumentElement.InnerText)
            
        ' Add white space.    
        Dim currNode as XmlNode = doc.DocumentElement
        Dim ws As XmlWhitespace = doc.CreateWhitespace(ControlChars.CrLf)
        currNode.InsertAfter(ws, currNode.FirstChild)
            
        Console.WriteLine()
        Console.WriteLine("InnerText after...")
        Console.WriteLine(doc.DocumentElement.InnerText)
        
    End Sub 
End Class 'Sample
' </Snippet1>
