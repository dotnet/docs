using System;
using System.Data;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
private void DecimalToCurrencyString(object sender, ConvertEventArgs cevent)
{
   // The method converts only to string type. 
   if(cevent.DesiredType != typeof(string)) return;

   cevent.Value = ((decimal) cevent.Value).ToString("c");
}

private void CurrencyStringToDecimal(object sender, ConvertEventArgs cevent)
{   
   // The method converts only to decimal type.
   if(cevent.DesiredType != typeof(decimal)) return;

   cevent.Value = Decimal.Parse(cevent.Value.ToString(),
   NumberStyles.Currency, null);
}

// </Snippet1>
}
