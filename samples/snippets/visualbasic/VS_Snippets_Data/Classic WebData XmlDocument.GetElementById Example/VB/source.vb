' <Snippet1>
Option Explicit
Option Strict

Imports System
Imports System.Xml

Public Class Sample
    
    Public Shared Sub Main()
        Dim doc As New XmlDocument()
        doc.Load("ids.xml")
        
        'Get the first element with an attribute of type ID and value of A111.
        'This displays the node <Person SSN="A111" Name="Fred"/>.
        Dim elem As XmlElement = doc.GetElementById("A111")
        Console.WriteLine(elem.OuterXml)
        
        'Get the first element with an attribute of type ID and value of A222.
        'This displays the node <Person SSN="A222" Name="Tom"/>.
        elem = doc.GetElementById("A222")
        Console.WriteLine(elem.OuterXml)
    End Sub 'Main 
End Class 'Sample
' </Snippet1>