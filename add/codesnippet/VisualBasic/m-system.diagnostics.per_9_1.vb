
        ' Process the InstanceDataCollectionCollection for this category.
        Dim pcc As New PerformanceCounterCategory(categoryName)
        Dim idColCol As InstanceDataCollectionCollection = pcc.ReadCategory()
        Dim idColArray(idColCol.Count - 1) As InstanceDataCollection

        Console.WriteLine("InstanceDataCollectionCollection for ""{0}"" " & _
            "has {1} elements.", categoryName, idColCol.Count)