using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox text1;
 protected DataSet ds;
// <Snippet1>
private void DecimalToCurrency(object sender, ConvertEventArgs cevent)
{
   // The method converts only to string type. Test this using the DesiredType.
   if (cevent.DesiredType != typeof(string)) return;

   // Use the ToString method to format the value as currency ("c").
   cevent.Value = ((decimal) cevent.Value).ToString("c");
}

private void CurrencyToDecimal(object sender, ConvertEventArgs cevent)
{
   // ' The method converts only to decimal type. 
   if (cevent.DesiredType != typeof(decimal)) return;

   // Converts the string back to decimal using the static ToDecimal method.
   cevent.Value = Convert.ToDecimal(cevent.Value.ToString());
}

private void BindControl()
{
   // Creates the binding first. The OrderAmount is typed as Decimal.
   Binding b = new Binding
      ("Text", ds, "customers.custToOrders.OrderAmount");
   // Add the delegates to the events.
   b.Format += new ConvertEventHandler(DecimalToCurrency);
   b.Parse += new ConvertEventHandler(CurrencyToDecimal);
   text1.DataBindings.Add(b);
}

// </Snippet1>
}
