    Private Sub serializer_UnknownNode _
                    (ByVal sender As Object, _
                     ByVal e As XmlNodeEventArgs)
        Console.WriteLine("UnknownNode Namespace URI: " & e.NamespaceURI)
    End Sub