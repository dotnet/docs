' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    Public Shared Sub Main()
        Dim doc As New XmlDocument()
        doc.LoadXml("<book genre='novel' ISBN='1-861001-57-5'>"  & _
                    "<title>Pride And Prejudice</title>"  & _
                    "</book>")
        
        'Create an attribute.
        Dim attr As XmlAttribute = doc.CreateAttribute("publisher")
        attr.Value = "WorldWide Publishing"
        
        'Add the new node to the document. 
        doc.DocumentElement.SetAttributeNode(attr)
        
        Console.WriteLine("Display the modified XML...")
        doc.Save(Console.Out)
    End Sub 'Main
End Class 'Sample
' </Snippet1>
