#using <System.Xml.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Data;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;
   TextBox^ textBox2;
   TextBox^ textBox3;
   TextBox^ textBox4;
   DateTimePicker^ DateTimePicker1;
   BindingManagerBase^ bmCustomers;
   BindingManagerBase^ bmOrders;
   DataSet^ ds;

   // <Snippet1>
   void BindControls()
   {
      
      /* Create two Binding objects for the first two TextBox 
         controls. The data-bound property for both controls 
         is the Text property. The data source is a DataSet 
         (ds). The data member is specified by a navigation 
         path in the form : TableName.ColumnName. */
      textBox1->DataBindings->Add( gcnew Binding( "Text",ds,"customers.custName" ) );
      textBox2->DataBindings->Add( gcnew Binding( "Text",ds,"customers.custID" ) );
      
      /* Bind the DateTimePicker control by adding a new Binding. 
         The data member of the DateTimePicker is specified by a 
         navigation path in the form: TableName.RelationName.ColumnName. */
      DateTimePicker1->DataBindings->Add( gcnew Binding( "Value",ds,"customers.CustToOrders.OrderDate" ) );
      
      /* Create a new Binding using the DataSet and a 
         navigation path(TableName.RelationName.ColumnName).
         Add event delegates for the Parse and Format events to 
         the Binding object, and add the object to the third 
         TextBox control's BindingsCollection. The delegates 
         must be added before adding the Binding to the 
         collection; otherwise, no formatting occurs until 
         the Current object of the BindingManagerBase for 
         the data source changes. */
      Binding^ b = gcnew Binding( "Text",ds,"customers.custToOrders.OrderAmount" );
      b->Parse += gcnew ConvertEventHandler( this, &Form1::CurrencyStringToDecimal );
      b->Format += gcnew ConvertEventHandler( this, &Form1::DecimalToCurrencyString );
      textBox3->DataBindings->Add( b );
      
      /*Bind the fourth TextBox to the Value of the 
         DateTimePicker control. This demonstrates how one control
         can be bound to another.*/
      textBox4->DataBindings->Add( "Text", DateTimePicker1, "Value" );
      BindingManagerBase^ bmText = this->BindingContext[ DateTimePicker1 ];
      
      /* Print the Type of the BindingManagerBase, which is 
         a PropertyManager because the data source
         returns only a single property value. */
      Console::WriteLine( bmText->GetType() );
      
      // Print the count of managed objects, which is 1.
      Console::WriteLine( bmText->Count );
      
      // Get the BindingManagerBase for the Customers table. 
      bmCustomers = this->BindingContext[ds, "Customers"];
      
      /* Print the Type and count of the BindingManagerBase.
         Because the data source inherits from IBindingList,
         it is a RelatedCurrencyManager (derived from CurrencyManager). */
      Console::WriteLine( bmCustomers->GetType() );
      Console::WriteLine( bmCustomers->Count );
      
      /* Get the BindingManagerBase for the Orders of the current
         customer using a navigation path: TableName.RelationName. */
      bmOrders = this->BindingContext[ds, "customers.CustToOrders"];
   }
   // </Snippet1>

private:

   // method added so sample will compile
   void CurrencyStringToDecimal( Object^ /*sender*/, ConvertEventArgs^ /*e*/ ){}

   // method added so sample will compile
   void DecimalToCurrencyString( Object^ /*sender*/, ConvertEventArgs^ /*e*/ ){}

};
