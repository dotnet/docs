    private static void DisplayColumnNames(DataTableReader reader)
    {
        // Given a DataTableReader, display column names.
        for (int i = 0; i < reader.FieldCount; i++) 
        {
            Console.WriteLine("{0}: {1}", i, reader.GetName(i));
        }
    }