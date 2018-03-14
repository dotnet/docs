Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Xml.Xsl
Imports System.Xml.XPath
Imports System.Xml.Schema



Public Class Class1
    
    Public Sub Method1()
        ' <Snippet1>
        Dim imp As New XmlImplementation()
        Dim doc1 As XmlDocument = imp.CreateDocument()
        Dim doc2 As XmlDocument = imp.CreateDocument()
        ' </Snippet1>
    End Sub 'Method1 
End Class 'Class1
