using System;
using System.Collections;
using System.Data;
using System.Data.Common;


class Class1
{
    // <Snippet1>
    public static void Main()
    {
        try
        {
            DataTable userTable = new DataTable("peopleTable");

            userTable.Columns.Add("Id", typeof(int));
            userTable.Columns.Add("Name", typeof(string));

            // Note that even if you create the DataTableReader
            // before adding the rows, the enumerator can still
            // visit all the rows.
            DataTableReader reader = userTable.CreateDataReader();
            userTable.Rows.Add(new object[] { 1, "Peter" });
            userTable.Rows.Add(new object[] { 2, "Mary" });
            userTable.Rows.Add(new object[] { 3, "Andy" });
            userTable.Rows.Add(new object[] { 4, "Russ" });

            IEnumerator enumerator = reader.GetEnumerator();
            // Keep track of whether the row to be deleted
            // has actually been deleted yet. This allows
            // this sample to demonstrate that the enumerator
            // is able to survive row deletion.
            bool isRowDeleted = false;
            while (enumerator.MoveNext())
            { 
                DbDataRecord dataRecord = (DbDataRecord)enumerator.Current;

                // While the enumerator is active, delete a row.
                // This doesn't affect the behavior of the enumerator.
                if (!isRowDeleted)
                {
                    isRowDeleted = true;
                    userTable.Rows[2].Delete();
                }
                Console.WriteLine(dataRecord.GetString(1));
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        Console.ReadLine();
    }
    // </Snippet1>
}

