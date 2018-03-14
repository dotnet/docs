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
public void CreateOracleDbParameter() 
 {
    OracleParameter parameter = new OracleParameter();
    parameter.ParameterName = "pDName";
    parameter.DbType = DbType.String;
    parameter.Value = "ENGINEERING";
    parameter.SourceColumn = "DName";
 }

// </Snippet1>

}
