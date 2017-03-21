' This is the class that will be serialized.
Public Class XClass
   ' The XML element name will be XName
   ' instead of the default ClassName.
   <XmlElement(ElementName := "XName")> Public ClassName() As String
End Class