Option Explicit
Option Strict


Imports System
Imports System.Xml
Imports System.IO
Imports System.Xml.Serialization

public class DummyClass
   Shared Sub Main()
   End Sub
End Class

' <Snippet1>
' This is the class that will be serialized.
Public Class XClass
   ' The XML element name will be XName
   ' instead of the default ClassName.
   <XmlElement(ElementName := "XName")> Public ClassName() As String
End Class
' </Snippet1>
