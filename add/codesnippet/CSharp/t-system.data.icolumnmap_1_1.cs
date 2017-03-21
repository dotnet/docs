
    public void ShowColumnMappings() 
    {
        // ...
        // create tableMapping
        // ...
        tableMapping.ColumnMappings.Add("Category Name","DataCategory");
        tableMapping.ColumnMappings.Add("Description","DataDescription");
        tableMapping.ColumnMappings.Add("Picture","DataPicture");
        Console.WriteLine("Column Mappings");
        for(int i=0;i < tableMapping.ColumnMappings.Count;i++) 
        {
            Console.WriteLine("  {0} {1}", i,
                tableMapping.ColumnMappings[i].ToString());
        }
    }