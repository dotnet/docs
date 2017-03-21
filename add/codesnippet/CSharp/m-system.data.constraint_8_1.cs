
 public static void ClearConstraints(DataSet dataSet) 
 {
    foreach (DataTable table in dataSet.Tables)
      table.Constraints.Clear();
 }