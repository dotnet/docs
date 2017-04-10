Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization


' <Snippet1>
Public Class MyClass1
    <XmlArrayAttribute()> Public MyStringArray() As String
    <XmlArrayAttribute()> Public MyIntegerArray() As Integer
End Class

' </Snippet1>
