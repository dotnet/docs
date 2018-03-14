using System;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
    protected DataSet DataSet1;
    protected DataGrid dataGrid1;


    // <Snippet1>
    public void CreateSqlParameter() 
    {
        SqlParameter parameter = new SqlParameter(
            "@Description", SqlDbType.VarChar);
        parameter.IsNullable = true;
        parameter.Direction = ParameterDirection.Output;
        parameter.SourceColumn = "Description";
    }
    // </Snippet1>

}
