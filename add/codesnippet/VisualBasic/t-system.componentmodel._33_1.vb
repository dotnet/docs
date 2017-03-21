        ' Creates an empty DesignerVerbCollection.
        Dim collection As New DesignerVerbCollection()

        ' Adds a DesignerVerb to the collection.
        collection.Add(New DesignerVerb("Example designer verb", New EventHandler(AddressOf Me.ExampleEvent)))

        ' Adds an array of DesignerVerb objects to the collection.
        Dim verbs As DesignerVerb() = {New DesignerVerb("Example designer verb", New EventHandler(AddressOf Me.ExampleEvent)), New DesignerVerb("Example designer verb", New EventHandler(AddressOf Me.ExampleEvent))}
        collection.AddRange(verbs)

        ' Adds a collection of DesignerVerb objects to the collection.
        Dim verbsCollection As New DesignerVerbCollection()
        verbsCollection.Add(New DesignerVerb("Example designer verb", New EventHandler(AddressOf Me.ExampleEvent)))
        verbsCollection.Add(New DesignerVerb("Example designer verb", New EventHandler(AddressOf Me.ExampleEvent)))
        collection.AddRange(verbsCollection)

        ' Tests for the presence of a DesignerVerb in the collection, 
        ' and retrieves its index if it is found.
        Dim testVerb As New DesignerVerb("Example designer verb", New EventHandler(AddressOf Me.ExampleEvent))
        Dim itemIndex As Integer = -1
        If collection.Contains(testVerb) Then
            itemIndex = collection.IndexOf(testVerb)
        End If

        ' Copies the contents of the collection, beginning at index 0, 
        ' to the specified DesignerVerb array.
        ' 'verbs' is a DesignerVerb array.
        collection.CopyTo(verbs, 0)

        ' Retrieves the count of the items in the collection.
        Dim collectionCount As Integer = collection.Count

        ' Inserts a DesignerVerb at index 0 of the collection.
        collection.Insert(0, New DesignerVerb("Example designer verb", New EventHandler(AddressOf Me.ExampleEvent)))

        ' Removes the specified DesignerVerb from the collection.
        Dim verb As New DesignerVerb("Example designer verb", New EventHandler(AddressOf Me.ExampleEvent))
        collection.Remove(verb)

        ' Removes the DesignerVerb at index 0.
        collection.RemoveAt(0)