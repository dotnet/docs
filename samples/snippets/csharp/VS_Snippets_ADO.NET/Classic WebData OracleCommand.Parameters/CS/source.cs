using System;
using System.Xml;
using System.Data;
using System.Data.OracleClient;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;


    // <Snippet1>
    public void CreateOracleCommand(OracleConnection connection,
        string queryString, OracleParameter[] myParamArray)
    {

        OracleCommand command = new OracleCommand(queryString, connection);
        command.CommandText = 
            "SELECT * FROM Emp WHERE Job = :pJob AND Sal = :pSal";

        for (int j = 0; j < myParamArray.Length; j++)
            command.Parameters.Add(myParamArray[j]);

        string message = "";

        for (int i = 0; i < command.Parameters.Count; i++) 
            message += command.Parameters[i].ToString() + "\n";

        Console.WriteLine(message);

        using (OracleDataReader row = command.ExecuteReader()) 
        {
            while(row.Read()) 
            {
                Console.WriteLine(row.GetValue(0));
            }
        }
    }

    // </Snippet1>

}
