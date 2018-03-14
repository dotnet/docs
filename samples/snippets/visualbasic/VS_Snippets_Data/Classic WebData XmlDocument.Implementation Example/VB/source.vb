Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Xml.Xsl
Imports System.Xml.XPath
Imports System.Xml.Schema



Public Class Class1
    
    Sub Method1()
        ' <Snippet1>
        Dim doc1 As New XmlDocument()
        doc1.Load("books.xml")
        Dim doc2 As XmlDocument = doc1.Implementation.CreateDocument()
        ' </Snippet1>
    End Sub 'Method1 
End Class 'Class1
