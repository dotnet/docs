Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization


' <Snippet1>
Public Class MyClass1
    <XmlElement(IsNullable := False)> Public Group As String
End Class

' </Snippet1>
