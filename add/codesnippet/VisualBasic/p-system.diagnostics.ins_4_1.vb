    ' Display the contents of an InstanceDataCollection.
    Sub ProcessInstanceDataCollection(ByVal idCol As InstanceDataCollection)

        Dim idColKeys As ICollection = idCol.Keys
        Dim idColKeysArray(idColKeys.Count - 1) As String
        idColKeys.CopyTo(idColKeysArray, 0)

        Dim idColValues As ICollection = idCol.Values
        Dim idColValuesArray(idColValues.Count - 1) As InstanceData
        idColValues.CopyTo(idColValuesArray, 0)

        Console.WriteLine("  InstanceDataCollection for ""{0}"" " & _
            "has {1} elements.", idCol.CounterName, idCol.Count)

        ' Display the InstanceDataCollection Keys and Values.
        ' The Keys and Values collections have the same number of elements.
        Dim index As Integer
        For index = 0 To idColKeysArray.Length - 1
            Console.WriteLine("    Next InstanceDataCollection " & _
                "Key is ""{0}""", idColKeysArray(index))
            ProcessInstanceDataObject(idColValuesArray(index))
        Next index
    End Sub