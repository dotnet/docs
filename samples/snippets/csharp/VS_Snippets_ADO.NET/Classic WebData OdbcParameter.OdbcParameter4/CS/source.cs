using System;
using System.Data;
using System.Data.Odbc;

class Program
{
    static void Main()
    {
    }


    // <Snippet1>
    public void CreateOdbcParameter()
    {
        OdbcParameter parameter = new OdbcParameter(
            "Description", OdbcType.VarChar, 11, 
            ParameterDirection.Output, true, 0, 0, "Description",
            DataRowVersion.Current, "garden hose");
        Console.WriteLine(parameter.ToString());
    }
    // </Snippet1>

}
