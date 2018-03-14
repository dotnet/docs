#using <System.Xml.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Globalization;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TextBox^ text1;
   DataSet^ ds;

   // <Snippet1>
private:
   void DecimalToCurrencyString( Object^ /*sender*/, ConvertEventArgs^ cevent )
   {
      // The method converts only to string type. Test this using the DesiredType.
      if ( cevent->DesiredType != String::typeid )
      {
         return;
      }
      
      // Use the ToString method to format the value as currency ("c").
      cevent->Value = ( (Decimal)(cevent->Value) ).ToString( "c" );
   }

   void CurrencyStringToDecimal( Object^ /*sender*/, ConvertEventArgs^ cevent )
   {
      // The method converts back to decimal type only.
      if ( cevent->DesiredType != Decimal::typeid )
      {
         return;
      }
      
      // Converts the string back to decimal using the static Parse method.
      cevent->Value = Decimal::Parse( cevent->Value->ToString(),
         NumberStyles::Currency, nullptr );
   }

   void BindControl()
   {
      // Creates the binding first. The OrderAmount is typed as Decimal.
      Binding^ b = gcnew Binding(
         "Text", ds, "customers.custToOrders.OrderAmount" );
      // Add the delegates to the event.
      b->Format += gcnew ConvertEventHandler( this, &Form1::DecimalToCurrencyString );
      b->Parse += gcnew ConvertEventHandler( this, &Form1::CurrencyStringToDecimal );
      text1->DataBindings->Add( b );
   }
   // </Snippet1>
};
