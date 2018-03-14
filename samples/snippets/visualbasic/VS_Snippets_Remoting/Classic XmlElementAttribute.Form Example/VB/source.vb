Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization



' <Snippet1>
Public Class MyClass1
    <XmlElement(Form := XmlSchemaForm.Unqualified)> _
    Public ClassName As String
End Class

' </Snippet1>
