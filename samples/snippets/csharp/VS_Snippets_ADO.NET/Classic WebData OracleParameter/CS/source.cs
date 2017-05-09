using System;
using System.Xml;
using System.Data;
using System.Data.OracleClient;
using System.Data.Common;
using System.Windows.Forms;

public class Form1: Form
{
  protected DataSet dataSet;
  protected OracleDataAdapter adapter;


// <Snippet1>
public void AddOracleParameters() 
 {
 // ...
 // create dataSet and adapter
 // ...
   adapter.SelectCommand.Parameters.Add("pEName", OracleType.VarChar, 80).Value = "Smith";
   adapter.SelectCommand.Parameters.Add("pEmpNo", OracleType.Int32).Value = 7369;
   adapter.Fill(dataSet);
 }

// </Snippet1>

}
