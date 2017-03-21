    private void AddRelation() 
    {
        DataTable table = new DataTable();
        DataColumn column1 = table.Columns.Add("Column1");
        DataColumn column2 = table.Columns.Add("Column2");
        table.ChildRelations.Add("New Relation", column1, column2);
    }