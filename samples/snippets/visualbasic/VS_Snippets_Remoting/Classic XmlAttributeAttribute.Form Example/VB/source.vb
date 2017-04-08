Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization


' <Snippet1>
Public Class Vehicle
    <XmlAttribute(Form := XmlSchemaForm.Qualified)> _
    Public Maker As String    

    <XmlAttribute(Form := XmlSchemaForm.Unqualified)> _
    Public ModelID As String
End Class

' </Snippet1>
