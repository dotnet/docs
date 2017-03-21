    Private Sub serializer_UnknownNode _
                    (ByVal sender As Object, _
                     ByVal e As XmlNodeEventArgs)
        Console.WriteLine("UnknownNode Name: " & e.Name)
    End Sub