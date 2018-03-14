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
 public void CreateOracleParameter() 
 {
    OracleParameter parameter = new OracleParameter("DName",OracleType.VarChar);
    parameter.Direction = ParameterDirection.Output;
    parameter.Size = 14;
 }
   // </Snippet1>

}
