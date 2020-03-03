#using <System.Xml.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Globalization;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TextBox^ text1;
   DataSet^ ds;

   // <Snippet1>
private:
   void BindControl()
   {
      // Create the binding first. The OrderAmount is typed as Decimal.
      Binding^ b = gcnew Binding(
         "Text",ds,"customers.custToOrders.OrderAmount" );
      // Add the delegates to the events.
      b->Format += gcnew ConvertEventHandler( this, &Form1::DecimalToCurrencyString );
      b->Parse += gcnew ConvertEventHandler( this, &Form1::CurrencyStringToDecimal );
      text1->DataBindings->Add( b );
   }

   void DecimalToCurrencyString( Object^ /*sender*/, ConvertEventArgs^ cevent )
   {
      // Check for the appropriate DesiredType.
      if ( cevent->DesiredType != String::typeid )
      {
         return;
      }

      // Use the ToString method to format the value as currency ("c").
      cevent->Value = ( (Decimal^)(cevent->Value) )->ToString( "c" );
   }

   void CurrencyStringToDecimal( Object^ /*sender*/, ConvertEventArgs^ cevent )
   {
      // Check for the appropriate DesiredType. 
      if ( cevent->DesiredType != Decimal::typeid )
      {
         return;
      }

      // Convert the string back to decimal using the static Parse method.
      cevent->Value = Decimal::Parse( cevent->Value->ToString(),
         NumberStyles::Currency, nullptr );
   }
   // </Snippet1>
};
