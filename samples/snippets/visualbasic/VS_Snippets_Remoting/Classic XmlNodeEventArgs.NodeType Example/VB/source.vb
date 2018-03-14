Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

Public Class Sample
    
    ' <Snippet1>
    Private Sub serializer_UnknownNode _
                    (ByVal sender As Object, _
                     ByVal e As XmlNodeEventArgs)
        Dim myNodeType As XmlNodeType = e.NodeType
        Console.WriteLine(myNodeType)
    End Sub
    ' </Snippet1>
End Class

