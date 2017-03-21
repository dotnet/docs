
 public void AddDataColumnMapping() {
    // ...
    // create columnMappings
    // ...
    DataColumnMapping mapping =
       new DataColumnMapping("Description","DataDescription");
    columnMappings.Add((Object) mapping);
    Console.WriteLine("Column {0} added to column mapping collection {1}.", 
        mapping.ToString(), columnMappings.ToString());
 }