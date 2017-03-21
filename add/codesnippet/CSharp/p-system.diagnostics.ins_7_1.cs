    // Display the contents of an InstanceDataCollection.
    public static void ProcessInstanceDataCollection(InstanceDataCollection idCol)
    {

        InstanceData[] instDataArray = new InstanceData[idCol.Count];

        Console.WriteLine("  InstanceDataCollection for \"{0}\" " +
            "has {1} elements.", idCol.CounterName, idCol.Count);

        // Copy and process the InstanceData array.
        idCol.CopyTo(instDataArray, 0);

        int idX;
        for(idX=0; idX<instDataArray.Length; idX++)
        {
            ProcessInstanceDataObject(instDataArray[idX].InstanceName, instDataArray[idX].Sample);
        }
    }