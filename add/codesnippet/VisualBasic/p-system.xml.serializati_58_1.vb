    Private Sub serializer_UnknownNode _
                        (ByVal sender As Object, _
                         ByVal e As XmlNodeEventArgs)                         
        Console.WriteLine("UnknownNode LocalName: " & e.LocalName)
    End Sub