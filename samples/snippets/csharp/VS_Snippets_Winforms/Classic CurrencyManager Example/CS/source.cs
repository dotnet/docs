using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
private CurrencyManager myCurrencyManager;
 
 private void BindControl(DataTable myTable){
    // Bind a TextBox control to a DataTable column in a DataSet.
    textBox1.DataBindings.Add("Text", myTable, "CompanyName");
    // Specify the CurrencyManager for the DataTable.
    myCurrencyManager = (CurrencyManager)this.BindingContext[myTable];
    // Set the initial Position of the control.
    myCurrencyManager.Position = 0;
 }
 
 private void MoveNext(CurrencyManager myCurrencyManager){
    if (myCurrencyManager.Position == myCurrencyManager.Count - 1){
       MessageBox.Show("You're at end of the records");
    }
    else{
      myCurrencyManager.Position += 1;
    }
 }
 
 private void MoveFirst(CurrencyManager myCurrencyManager){
    myCurrencyManager.Position = 0;
 }
 
 private void MovePrevious(CurrencyManager myCurrencyManager ){
    if(myCurrencyManager.Position == 0) {
       MessageBox.Show("You're at the beginning of the records.");
    }   
    else{
       myCurrencyManager.Position -= 1;
    }
 }
 
 private void MoveLast(CurrencyManager myCurrencyManager){
    myCurrencyManager.Position = myCurrencyManager.Count - 1;
 }

// </Snippet1>
}
