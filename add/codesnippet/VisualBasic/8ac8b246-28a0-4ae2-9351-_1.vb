    ' Display the contents of an InstanceDataCollection.
    Sub ProcessInstanceDataCollection(ByVal idCol As InstanceDataCollection)

        Dim instDataArray(idCol.Count - 1) As InstanceData

        Console.WriteLine("  InstanceDataCollection for ""{0}"" " & _
            "has {1} elements.", idCol.CounterName, idCol.Count)

        ' Copy and process the InstanceData array.
        idCol.CopyTo(instDataArray, 0)

        Dim idX As Integer
        For idX = 0 To instDataArray.Length - 1
            ProcessInstanceDataObject(instDataArray(idX).InstanceName, _
                instDataArray(idX).Sample)
        Next idX
    End Sub