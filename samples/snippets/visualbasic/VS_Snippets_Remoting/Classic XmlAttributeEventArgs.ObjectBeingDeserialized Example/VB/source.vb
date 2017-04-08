Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization


Public Class Sample
    
    ' <Snippet1>
    Private Sub serializer_UnknownAttribute(sender As Object, _
                                                  e As XmlAttributeEventArgs)
        Dim attr As System.Xml.XmlAttribute = e.Attr
        
        Console.WriteLine("Unknown Attribute Name and Value:" & attr.Name & _
                          "='" & attr.Value & "'")
        Dim x As Object = e.ObjectBeingDeserialized
        Console.WriteLine("ObjectBeingDeserialized: " & x.ToString())
    End Sub
End Class

' </Snippet1>