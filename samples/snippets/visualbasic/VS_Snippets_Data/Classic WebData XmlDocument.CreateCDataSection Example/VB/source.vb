' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    
    Public Shared Sub Main()
        Dim doc As New XmlDocument()
        doc.LoadXml("<book genre='novel' ISBN='1-861001-57-5'>"  & _
                    "<title>Pride And Prejudice</title>"  & _
                    "</book>")
        
        'Create a CData section.
        Dim CData As XmlCDataSection
        CData = doc.CreateCDataSection("All Jane Austen novels 25% off starting 3/23!")
        
        'Add the new node to the document.
        Dim root As XmlElement = doc.DocumentElement
        root.AppendChild(CData)
        
        Console.WriteLine("Display the modified XML...")
        doc.Save(Console.Out)
    End Sub 'Main
End Class 'Sample
' </Snippet1>
