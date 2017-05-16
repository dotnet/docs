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
    public void CreateOracleParamColl(OracleConnection connection) 
    {
        OracleCommand command = new OracleCommand(
            "SELECT Ename, DeptNo FROM Emp WHERE EmpNo = :pEmpNo", connection);
        OracleParameterCollection paramCollection = command.Parameters;
        OracleParameter parameter = paramCollection.Add(
            "pEmpNo", OracleType.Number, 4);
    }
    // </Snippet1>

}
