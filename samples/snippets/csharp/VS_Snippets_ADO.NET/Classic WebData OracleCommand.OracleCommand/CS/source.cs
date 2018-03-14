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
 public void CreateOracleCommand() 
 {
    OracleCommand command = new OracleCommand();
    command.CommandType = CommandType.Text;
 }
// </Snippet1>

}
