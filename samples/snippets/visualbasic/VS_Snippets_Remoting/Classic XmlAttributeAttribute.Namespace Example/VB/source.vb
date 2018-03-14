Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization


' <Snippet1>
Public Class Car
    <XmlAttribute(Namespace := "Make")> _
    Public MakerName As String    

    <XmlAttribute(Namespace := "Model")> _
    Public ModelName As String
End Class

' </Snippet1>
