    public void CreateColumnMappings() 
    {
        DataColumnMappingCollection mappings = 
            new DataColumnMappingCollection();
        mappings.Add("Category Name","DataCategory");
        mappings.Add("Description","DataDescription");
        mappings.Add("Picture","DataPicture");
        string message = "ColumnMappings:\n";
        for(int i=0;i < mappings.Count;i++)
        {
            message += i.ToString() + " " 
                + mappings[i].ToString() + "\n";
        }
        Console.WriteLine(message);
    }