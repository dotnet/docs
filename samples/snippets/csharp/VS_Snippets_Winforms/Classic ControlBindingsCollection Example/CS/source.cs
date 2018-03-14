using System;
using System.Data;
using System.Windows.Forms;

public class Form1 : Form {

    protected TextBox textBox1;
    protected TextBox textBox2;
    protected TextBox textBox3;
    protected TextBox textBox4;
    protected DateTimePicker DateTimePicker1;

    protected BindingManagerBase bmCustomers;
    protected BindingManagerBase bmOrders;

    protected DataSet ds;

// <Snippet1>
protected void BindControls()
{
   /* Create two Binding objects for the first two TextBox 
   controls. The data-bound property for both controls 
   is the Text property. The data source is a DataSet 
   (ds). The data member is the navigation path: 
   TableName.ColumnName. */
   textBox1.DataBindings.Add(new Binding
   ("Text", ds, "customers.custName"));
   textBox2.DataBindings.Add(new Binding
   ("Text", ds, "customers.custID"));
      
   /* Bind the DateTimePicker control by adding a new Binding. 
   The data member of the DateTimePicker is a navigation path:
   TableName.RelationName.ColumnName. */
   DateTimePicker1.DataBindings.Add(new 
   Binding("Value", ds, "customers.CustToOrders.OrderDate"));

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
   textBox3.DataBindings.Add(b);

   /*Bind the fourth TextBox to the Value of the 
   DateTimePicker control. This demonstates how one control
   can be data-bound to another.*/
   textBox4.DataBindings.Add("Text", DateTimePicker1,"Value");

   // Get the BindingManagerBase for the textBox4 Binding.
   BindingManagerBase bmText = this.BindingContext
   [DateTimePicker1];

   /* Print the Type of the BindingManagerBase, which is 
   a PropertyManager because the data source
   returns only a single property value. */
   Console.WriteLine(bmText.GetType().ToString());

   // Print the count of managed objects, which is one.
   Console.WriteLine(bmText.Count);

   // Get the BindingManagerBase for the Customers table. 
   bmCustomers = this.BindingContext [ds, "Customers"];

   /* Print the Type and count of the BindingManagerBase.
   Because the data source inherits from IBindingList,
   it is a RelatedCurrencyManager (a derived class of
   CurrencyManager). */
   Console.WriteLine(bmCustomers.GetType().ToString());
   Console.WriteLine(bmCustomers.Count);
   
   /* Get the BindingManagerBase for the Orders of the current
   customer using a navigation path: TableName.RelationName. */ 
   bmOrders = this.BindingContext[ds, "customers.CustToOrders"];
}
// </Snippet1>

    // method added so sample will compile
    private void CurrencyStringToDecimal(object sender, ConvertEventArgs e) {}

    // method added so sample will compile
    private void DecimalToCurrencyString(object sender, ConvertEventArgs e) {}
    
}

