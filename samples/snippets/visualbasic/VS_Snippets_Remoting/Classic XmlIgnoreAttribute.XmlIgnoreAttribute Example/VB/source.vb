Option Explicit
Option Strict

Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization


' <Snippet1>
Public Class Group
    ' the XmlSerializer ignores this field.
    <XmlIgnore()> Public Comment As String
    
    ' The XmlSerializer serializes this field.
    Public GroupName As String
End Class

' </Snippet1>
