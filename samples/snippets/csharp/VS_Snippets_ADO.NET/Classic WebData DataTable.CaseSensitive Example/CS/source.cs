using System;
using System.Xml;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
  protected DataSet DataSet1;
  protected DataGrid dataGrid1;


// <Snippet1>
private static void ToggleCaseSensitive()
{
    DataTable t;
    DataRow[] foundRows;

    t = CreateDataSet().Tables[0];

    t.CaseSensitive = false;
    foundRows = t.Select("item = 'abc'");

    // Print out DataRow values.
    PrintRowValues(foundRows, "CaseSensitive = False");

    t.CaseSensitive = true;
    foundRows = t.Select("item = 'abc'");

    PrintRowValues(foundRows, "CaseSensitive = True");
}

public static DataSet CreateDataSet()
{
    // Create a DataSet with one table, two columns
    DataSet ds = new DataSet();
    DataTable t = new DataTable("Items");

    // Add table to dataset
    ds.Tables.Add(t);

    // Add two columns
    DataColumn c;

    // First column
    c = t.Columns.Add("id", typeof(int));
    c.AutoIncrement = true;

    // Second column
    t.Columns.Add("item", typeof(string));

    // Set primary key
    t.PrimaryKey = new DataColumn[] { t.Columns["id"] };

    // Add twelve rows
    for (int i = 0; i < 10; i++)
    {
        t.Rows.Add(new object[] { i, i.ToString() });
    }
    t.Rows.Add(new object[] { 11, "abc" });
    t.Rows.Add(new object[] { 15, "ABC" });

    return ds;
}

private static void PrintRowValues(DataRow[] rows, string label)
{
    Console.WriteLine();
    Console.WriteLine(label);
    if (rows.Length <= 0)
    {
        Console.WriteLine("no rows found");
        return;
    }
    foreach (DataRow r in rows)
    {
        foreach (DataColumn c in r.Table.Columns)
        {
            Console.Write("\t {0}", r[c]);
        }
        Console.WriteLine();
    }
}
 // </Snippet1>

}
