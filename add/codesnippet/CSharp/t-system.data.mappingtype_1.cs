        static private void GetColumnMapping(DataTable dataTable)
        {
            foreach (DataColumn dataColumn in dataTable.Columns)
            {
                Console.WriteLine(dataColumn.ColumnMapping.ToString());
            }
        }