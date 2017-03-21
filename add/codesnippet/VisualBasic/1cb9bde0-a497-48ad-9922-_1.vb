        ' Tests for the presence of a DesignerVerb in the collection, 
        ' and retrieves its index if it is found.
        Dim testVerb As New DesignerVerb("Example designer verb", New EventHandler(AddressOf Me.ExampleEvent))
        Dim itemIndex As Integer = -1
        If collection.Contains(testVerb) Then
            itemIndex = collection.IndexOf(testVerb)
        End If