    public bool PushIntoArray() 
    {
        // ...
        // create mappings
        // ...
        DataColumnMapping[] columns = new DataColumnMapping[0];
        mappings.CopyTo(columns, 0);
        mappings.Clear();
        return true;
    }