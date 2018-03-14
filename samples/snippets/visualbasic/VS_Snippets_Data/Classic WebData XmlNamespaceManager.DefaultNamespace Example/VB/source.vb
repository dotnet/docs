Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Xml.Xsl
Imports System.Xml.XPath
Imports System.Xml.Schema



Public Class Class1
    Private nsmgr As XmlNamespaceManager
    
    Public Sub Method1()
        ' <Snippet1>
        If nsmgr.HasNamespace(String.Empty) Then
            Console.WriteLine(nsmgr.DefaultNamespace)
        End If
        ' </Snippet1>
    End Sub 'Method1
End Class 'Class1
