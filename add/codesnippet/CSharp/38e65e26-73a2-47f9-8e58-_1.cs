    public void FindDataColumnMapping() 
    {
        // ...
        // create mappings and mapping
        // ...
        if (mappings.IndexOfDataSetColumn("datadescription") != -1)
            mapping = mappings.GetByDataSetColumn("datadescription");
    }