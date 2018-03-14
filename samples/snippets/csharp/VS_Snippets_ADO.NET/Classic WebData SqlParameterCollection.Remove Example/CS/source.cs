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
    protected SqlCommand command;
    protected SqlParameter param;

    // <Snippet1>
    public void SearchSqlParams() 
    {
        // ...
        // create SqlCommand command and SqlParameter param
        // ...
        if (command.Parameters.Contains(param))
            command.Parameters.Remove(param);
    }
    // </Snippet1>

}
