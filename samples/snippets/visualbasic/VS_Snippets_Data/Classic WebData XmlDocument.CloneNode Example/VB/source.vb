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
        
        'Create a deep clone.  The cloned node 
        'includes the child node.
        Dim deep As XmlDocument = CType(doc.CloneNode(True), XmlDocument)
        Console.WriteLine(deep.ChildNodes.Count)
        
        'Create a shallow clone.  The cloned node does not 
        'include the child node.
        Dim shallow As XmlDocument = CType(doc.CloneNode(False), XmlDocument)
        Console.WriteLine(shallow.Name + shallow.OuterXml)
        Console.WriteLine(shallow.ChildNodes.Count)
    End Sub 'Main 
End Class 'Sample
' </Snippet1>
