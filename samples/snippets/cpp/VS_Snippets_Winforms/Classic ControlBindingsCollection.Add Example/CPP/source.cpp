#using <System.Xml.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;
   DataSet^ ds;

   // <Snippet1>
protected:
   void BindControls()
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
      Binding^ b = gcnew Binding(
         "Text",ds,"customers.custToOrders.OrderAmount" );
      b->Parse += gcnew ConvertEventHandler(
         this, &Form1::CurrencyStringToDecimal );
      b->Format += gcnew ConvertEventHandler(
         this, &Form1::DecimalToCurrencyString );
      textBox1->DataBindings->Add( b );
   }
   // </Snippet1>

private:
   // method added so sample will compile
   void CurrencyStringToDecimal( Object^ /*sender*/, ConvertEventArgs^ /*e*/ ){}

   // method added so sample will compile
   void DecimalToCurrencyString( Object^ /*sender*/, ConvertEventArgs^ /*e*/ ){}
};
