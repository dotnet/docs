    private void AddEventHandler(DataTable table)
    {
        DataColumnCollection columns = table.Columns;
        columns.CollectionChanged += new 
            System.ComponentModel.CollectionChangeEventHandler(
            ColumnsCollection_Changed);
    }
 
    private void ColumnsCollection_Changed(object sender, 
        System.ComponentModel.CollectionChangeEventArgs e)
    {
        DataColumnCollection columns = 
            (DataColumnCollection) sender;
        Console.WriteLine("ColumnsCollectionChanged: " 
            + columns.Count);
    }