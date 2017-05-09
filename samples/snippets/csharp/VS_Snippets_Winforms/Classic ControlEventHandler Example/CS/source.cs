using System;
using System.Data;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox text1;
 protected DataSet ds;
// <Snippet1>
private void BindControl()
{
   // Create the binding first. The OrderAmount is typed as Decimal.
   Binding b = new Binding
      ("Text", ds, "customers.custToOrders.OrderAmount");
   // Add the delegates to the events.
   b.Format += new ConvertEventHandler(DecimalToCurrencyString);
   b.Parse += new ConvertEventHandler(CurrencyStringToDecimal);
   text1.DataBindings.Add(b);
}

private void DecimalToCurrencyString(object sender, ConvertEventArgs cevent)
{
   // Check for the appropriate DesiredType.
   if(cevent.DesiredType != typeof(string)) return;

   // Use the ToString method to format the value as currency ("c").
   cevent.Value = ((decimal) cevent.Value).ToString("c");
}

private void CurrencyStringToDecimal(object sender, ConvertEventArgs cevent)
{
   // Check for the appropriate DesiredType. 
   if(cevent.DesiredType != typeof(decimal)) return;

   // Convert the string back to decimal using the static Parse method.
   cevent.Value = Decimal.Parse(cevent.Value.ToString(),
   NumberStyles.Currency, null);
}

// </Snippet1>
}
