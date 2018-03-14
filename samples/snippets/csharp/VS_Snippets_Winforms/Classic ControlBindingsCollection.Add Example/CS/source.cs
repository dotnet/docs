using System;
using System.Data;
using System.Windows.Forms;

public class Form1 : Form {

    protected TextBox textBox1;
    protected DataSet ds;

// <Snippet1>
protected void BindControls()
{
   /* Create a new Binding using the DataSet and a 
   navigation path(TableName.RelationName.ColumnName).
   Add event delegates for the Parse and Format events to 
   the Binding object, and add the object to the third 
   TextBox control's BindingsCollection. The delegates 
   must be added before adding the Binding to the 
   collection; otherwise, no formatting occurs until 
   the Current object of the BindingManagerBase for 
   the data source changes. */
   Binding b = new Binding
   ("Text", ds, "customers.custToOrders.OrderAmount");
   b.Parse+=new ConvertEventHandler(CurrencyStringToDecimal);
   b.Format+=new ConvertEventHandler(DecimalToCurrencyString);
   textBox1.DataBindings.Add(b);
}
// </Snippet1>

    // method added so sample will compile
    private void CurrencyStringToDecimal(object sender, ConvertEventArgs e) {}

    // method added so sample will compile
    private void DecimalToCurrencyString(object sender, ConvertEventArgs e) {}
    
}

