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

  public OracleConnection connection;
// <Snippet1>
public void CreateOracleParamColl() {
    OracleCommand command = new OracleCommand( 
        "SELECT Ename, DeptNo FROM Emp WHERE EmpNo = :pEmpNo", connection);
    OracleParameterCollection paramCollection = command.Parameters;
    object parameter = new OracleParameter("pEmpNo", OracleType.Number);
    int pIndex = paramCollection.Add(parameter);
 }
// </Snippet1>

}
