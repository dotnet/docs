        ' Adds an array of DesignerVerb objects to the collection.
        Dim verbs As DesignerVerb() = {New DesignerVerb("Example designer verb", New EventHandler(AddressOf Me.ExampleEvent)), New DesignerVerb("Example designer verb", New EventHandler(AddressOf Me.ExampleEvent))}
        collection.AddRange(verbs)

        ' Adds a collection of DesignerVerb objects to the collection.
        Dim verbsCollection As New DesignerVerbCollection()
        verbsCollection.Add(New DesignerVerb("Example designer verb", New EventHandler(AddressOf Me.ExampleEvent)))
        verbsCollection.Add(New DesignerVerb("Example designer verb", New EventHandler(AddressOf Me.ExampleEvent)))
        collection.AddRange(verbsCollection)