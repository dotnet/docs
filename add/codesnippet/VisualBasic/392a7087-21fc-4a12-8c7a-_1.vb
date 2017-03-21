
        ' Process the InstanceDataCollectionCollection for this category.
        Dim pcc As New PerformanceCounterCategory(categoryName)
        Dim idColCol As InstanceDataCollectionCollection = pcc.ReadCategory()
        Dim idColArray(idColCol.Count - 1) As InstanceDataCollection

        Console.WriteLine("InstanceDataCollectionCollection for ""{0}"" " & _
            "has {1} elements.", categoryName, idColCol.Count)

        ' Copy and process the InstanceDataCollection array.
        idColCol.CopyTo(idColArray, 0)

        Dim idCol As InstanceDataCollection
        For Each idCol In idColArray
            ProcessInstanceDataCollection(idCol)
        Next idCol