using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected DataGrid dataGrid1;
 protected DataSet dataSet1;
// <Snippet1>
private void SetHeaderText()
{
    DataGridColumnStyle dgCol;
    DataColumn dataCol1;
    DataTable dataTable1;
    dgCol = dataGrid1.TableStyles[0].GridColumnStyles[0];
    dataTable1 = dataSet1.Tables[dataGrid1.DataMember];
    dataCol1 = dataTable1.Columns[dgCol.MappingName];
    dgCol.HeaderText = dataCol1.Caption;
}
 
// </Snippet1>
}
