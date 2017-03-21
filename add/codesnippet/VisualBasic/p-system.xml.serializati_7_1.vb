    Private Sub serializer_UnknownNode _
                    (ByVal sender As Object, _
                     ByVal e As XmlNodeEventArgs)
        Dim o As Object = e.ObjectBeingDeserialized
        Console.WriteLine("Object being deserialized: " & o.ToString())
    End Sub