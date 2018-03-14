using System;
using System.Xml;
using System.Data;
using System.Data.Odbc;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;


    // <Snippet1>
    public void CreateMyProc(OdbcConnection connection)
    {
        OdbcCommand command = connection.CreateCommand();
        command.CommandText = "{ call MyProc(?,?,?) }";

        OdbcParameter param = new OdbcParameter();
        param.DbType = DbType.Int32;
        param.Value = 1;
        command.Parameters.Add(param);

        param = new OdbcParameter();
        param.DbType = DbType.Decimal;
        param.Value = 1;
        command.Parameters.Add(param);

        param = new OdbcParameter();
        param.DbType = DbType.Decimal;
        param.Value = 1;
        command.Parameters.Add(param);

        command.ExecuteNonQuery();

     }
    // </Snippet1>

}
