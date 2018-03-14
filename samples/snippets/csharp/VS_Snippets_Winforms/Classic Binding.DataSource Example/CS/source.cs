using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox text1;
// <Snippet1>
private void GetDataSource()
{
   DataSet ds = (DataSet) text1.DataBindings[0].DataSource;
   Console.WriteLine(ds.Tables[0].TableName); 
}

// </Snippet1>
}
