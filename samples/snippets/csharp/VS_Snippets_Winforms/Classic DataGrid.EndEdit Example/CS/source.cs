using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
 protected DataGrid dataGrid1;
 protected DataSet ds;
// <Snippet1>
private void EditValue()
{ 
   int rowtoedit = 1;
   CurrencyManager myCurrencyManager = 
   (CurrencyManager)this.BindingContext[ds.Tables["Suppliers"]];
   myCurrencyManager.Position=rowtoedit;
   DataGridColumnStyle dgc = dataGrid1.TableStyles[0].GridColumnStyles[0];
   dataGrid1.BeginEdit(dgc, rowtoedit);
   // Insert code to edit the value.
   dataGrid1.EndEdit(dgc, rowtoedit, false);
}
// </Snippet1>
}
