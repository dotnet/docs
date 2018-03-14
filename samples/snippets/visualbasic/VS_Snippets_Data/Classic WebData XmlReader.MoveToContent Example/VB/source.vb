Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Xml.Xsl
Imports System.Xml.XPath
Imports System.Xml.Schema

Public Class Class1
    Private reader As XmlReader
    Private _price As String
    
    Public Sub Method1()
        ' <Snippet1>
        If reader.MoveToContent() = XmlNodeType.Element And reader.Name = "price" Then
            _price = reader.ReadString()
        End If
        ' </Snippet1>
    End Sub 'Method1
End Class 'Class1
