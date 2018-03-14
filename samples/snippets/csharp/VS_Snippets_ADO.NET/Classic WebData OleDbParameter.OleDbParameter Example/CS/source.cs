using System;
using System.Xml;
using System.Data;
using System.Data.OleDb;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
  protected DataSet DataSet1;
  protected DataGrid dataGrid1;


// <Snippet1>
 public void CreateOleDbParameter() 
 {
    OleDbParameter parameter = new OleDbParameter();
    parameter.ParameterName = "Description";
    parameter.OleDbType = OleDbType.VarChar;
    parameter.Direction = ParameterDirection.Output;
    parameter.Size = 88;
 }
   // </Snippet1>

}
