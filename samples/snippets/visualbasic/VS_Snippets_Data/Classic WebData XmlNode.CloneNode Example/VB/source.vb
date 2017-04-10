' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml

Public Class Sample
    
    Public Shared Sub Main()
        
        Dim doc As New XmlDocument()
        doc.LoadXml("<book ISBN='1-861001-57-5'>" & _
                    "<title>Pride And Prejudice</title>" & _
                    "<price>19.95</price>" & _
                    "</book>")
        
        Dim root As XmlNode = doc.FirstChild
        
        'Create a deep clone.  The cloned node 
        'includes the child nodes.
        Dim deep As XmlNode = root.CloneNode(True)
        Console.WriteLine(deep.OuterXml)
        
        'Create a shallow clone.  The cloned node does not 
        'include the child nodes, but does include its attribute.
        Dim shallow As XmlNode = root.CloneNode(False)
        Console.WriteLine(shallow.OuterXml)
    End Sub 'Main
End Class 'Sample
' </Snippet1>
