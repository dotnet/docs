Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization


' <Snippet1>
Public Class MyClass1
    <XmlArray(IsNullable := True)> _
    Public IsNullableIsTrueArray() As String

    <XmlArray(IsNullable := False)> _
    Public IsNullableIsFalseArray() As String
End Class

' </Snippet1>
