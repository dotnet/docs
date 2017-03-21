    Private Sub serializer_UnknownNode _
                    (ByVal sender As Object, _
                     ByVal e As XmlNodeEventArgs)
        Dim myNodeType As XmlNodeType = e.NodeType
        Console.WriteLine(myNodeType)
    End Sub