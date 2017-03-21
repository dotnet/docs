    private void GetChildRowsFromDataRelation(DataTable table)
    {
        DataRow[] rowArray;
        foreach(DataRelation relation in table.ParentRelations)
        {
            foreach(DataRow row in table.Rows)
            {
                rowArray = row.GetParentRows(relation);
                // Print values of rows.
                for(int i = 0; i < rowArray.Length; i++)
                {
                    foreach(DataColumn column in table.Columns)
                    {
                        Console.WriteLine(rowArray[i][column]);
                    }
                }
            }
        }
    }