        ' Removes the specified DesignerVerb from the collection.
        Dim verb As New DesignerVerb("Example designer verb", New EventHandler(AddressOf Me.ExampleEvent))
        collection.Remove(verb)