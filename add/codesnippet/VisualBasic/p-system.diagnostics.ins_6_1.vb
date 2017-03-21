
        ' Process the InstanceDataCollectionCollection for this category.
        Dim pcc As New PerformanceCounterCategory(categoryName)
        Dim idColCol As InstanceDataCollectionCollection = pcc.ReadCategory()

        Dim idColColKeys As ICollection = idColCol.Keys
        Dim idCCKeysArray(idColColKeys.Count - 1) As String
        idColColKeys.CopyTo(idCCKeysArray, 0)

        Dim idColColValues As ICollection = idColCol.Values
        Dim idCCValuesArray(idColColValues.Count - 1) As InstanceDataCollection
        idColColValues.CopyTo(idCCValuesArray, 0)

        Console.WriteLine("InstanceDataCollectionCollection for ""{0}"" " & _
            "has {1} elements.", categoryName, idColCol.Count)

        ' Display the InstanceDataCollectionCollection Keys and Values.
        ' The Keys and Values collections have the same number of elements.
        Dim index As Integer
        For index = 0 To idCCKeysArray.Length - 1
            Console.WriteLine("  Next InstanceDataCollectionCollection " & _
                "Key is ""{0}""", idCCKeysArray(index))
            ProcessInstanceDataCollection(idCCValuesArray(index))
        Next index