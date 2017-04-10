using System;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
  protected DataSet DataSet1;
  protected DataColumnMappingCollection columnMappings;

// <Snippet1>

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
// </Snippet1>

}
