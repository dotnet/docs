using System;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox text1;
 protected TextBox text2;
 protected TextBox text3;
 protected TextBox text4;
 protected DateTimePicker DateTimePicker1;
 protected DataSet ds;
 protected BindingManagerBase bmCustomers;
 protected BindingManagerBase bmOrders;

public class Test{
    static void Main(){}
}
 
// <Snippet1>
   protected void BindControls()
   {
      /* Create two Binding objects for the first two TextBox 
         controls. The data-bound property for both controls 
         is the Text property. The data source is a DataSet 
         (ds). The data member is a navigation path in the form: 
         "TableName.ColumnName". */
      text1.DataBindings.Add(new Binding
      ("Text", ds, "customers.custName"));
      text2.DataBindings.Add(new Binding
      ("Text", ds, "customers.custID"));
      
      /* Bind the DateTimePicker control by adding a new Binding. 
         The data member of the DateTimePicker is a navigation path:
         TableName.RelationName.ColumnName string. */
      DateTimePicker1.DataBindings.Add(new 
      Binding("Value", ds, "customers.CustToOrders.OrderDate"));

      /* Add event delegates for the Parse and Format events to a 
         new Binding object, and add the object to the third 
         TextBox control's BindingsCollection. The delegates 
         must be added before adding the Binding to the 
         collection; otherwise, no formatting occurs until 
         the Current object of the BindingManagerBase for 
         the data source changes. */
         Binding b = new Binding
         ("Text", ds, "customers.custToOrders.OrderAmount");
      b.Parse+=new ConvertEventHandler(CurrencyStringToDecimal);
      b.Format+=new ConvertEventHandler(DecimalToCurrencyString);
      text3.DataBindings.Add(b);

      // Get the BindingManagerBase for the Customers table. 
      bmCustomers = this.BindingContext [ds, "Customers"];

      /* Get the BindingManagerBase for the Orders table using the 
         RelationName. */ 
      bmOrders = this.BindingContext[ds, "customers.CustToOrders"];

      /* Bind the fourth TextBox control's Text property to the
      third control's Text property. */
      text4.DataBindings.Add("Text", text3, "Text");
   }

// </Snippet1>

   private void CurrencyStringToDecimal(object sender, ConvertEventArgs cevent) {
      // does nothing
   }

   private void DecimalToCurrencyString(object sender, ConvertEventArgs cevent) {
      // does nothing
   }	
}
