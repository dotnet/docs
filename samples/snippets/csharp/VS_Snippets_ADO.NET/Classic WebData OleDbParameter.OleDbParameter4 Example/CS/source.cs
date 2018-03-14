using System;
using System.Data;

using System.Data.OleDb;

class Program
{
    static void Main()
    {
    }


    // <Snippet1>
    public void CreateOleDbParameter()
    {
        OleDbParameter parameter = new OleDbParameter(
            "Description", OleDbType.VarChar, 11, 
            ParameterDirection.Output, true, 0, 0, "Description",
            DataRowVersion.Current, "garden hose");
        Console.WriteLine(parameter.ToString());
    }
    // </Snippet1>

}
