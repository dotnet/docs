using System;
using System.Data;

public class Sample
{

// <Snippet1>

 public static void ClearConstraints(DataSet dataSet) 
 {
    foreach (DataTable table in dataSet.Tables)
      table.Constraints.Clear();
 }
// </Snippet1>

}
