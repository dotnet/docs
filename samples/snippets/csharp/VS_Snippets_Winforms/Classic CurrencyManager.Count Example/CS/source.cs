using System;
using System.Windows.Forms;
using System.Data;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
    private void PrintListItems() {
    // Get the CurrencyManager of a TextBox control.
    CurrencyManager myCurrencyManager = (CurrencyManager)textBox1.BindingContext[0];
    // Presuming the list is a DataView, create a DataRowView variable.
    DataRowView drv;
    for(int i = 0; i < myCurrencyManager.Count; i++) {
        myCurrencyManager.Position = i;
        drv = (DataRowView)myCurrencyManager.Current;
        // Presuming a column named CompanyName exists.
        Console.WriteLine(drv["CompanyName"]);
    }
}
      
// </Snippet1>
}
