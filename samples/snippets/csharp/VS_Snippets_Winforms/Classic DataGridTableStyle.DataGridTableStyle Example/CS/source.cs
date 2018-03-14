using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

public class Form1: Form
{
protected DataGrid dataGrid1;
protected DataSet myDataSet;
// <Snippet1>
private void AddGridTable(){
   DataGridTableStyle myGridTableStyle;
   myGridTableStyle = new DataGridTableStyle();
   myGridTableStyle.MappingName = "Customers";
   dataGrid1.TableStyles.Add(myGridTableStyle);
}

// </Snippet1>
}
