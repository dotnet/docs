using System;
using System.Data;
using System.Windows.Forms;
using System.Globalization; 

public class Form1: Form
{
 protected TextBox text1;
// <Snippet1>
private void BindTextBoxControl()
{
   DataSet myDataSet = new DataSet();
   /* Insert code to populate the DataSet with tables, 
   columns, and data. */

   // Creates a new Binding object. 
   Binding myBinding = new Binding
   ("Text", myDataSet, "customers.custToOrders.OrderAmount");

   // Adds event delegates for the Parse and Format events.
   myBinding.Parse += new ConvertEventHandler(CurrencyToDecimal);
   myBinding.Format += new ConvertEventHandler(DecimalToCurrency);

   // Adds the new Binding to the BindingsCollection.
   text1.DataBindings.Add(myBinding);
}

private void DecimalToCurrency(object sender, 
   ConvertEventArgs cevent)
{
   /* This method is the Format event handler. Whenever the 
   control displays a new value, the value is converted from 
   its native Decimal type to a string. The ToString method 
   then formats the value as a Currency, by using the 
   formatting character "c". */
   cevent.Value = ((decimal) cevent.Value).ToString("c");
}

private void CurrencyToDecimal(object sender, 
   ConvertEventArgs cevent)
{   
   /* This method is the Parse event handler. The Parse event 
   occurs whenever the displayed value changes. The static 
   Parse method of the Decimal structure converts the 
   string back to its native Decimal type. */
   cevent.Value = Decimal.Parse(cevent.Value.ToString(),
   NumberStyles.Currency, null);
}

// </Snippet1>
}
