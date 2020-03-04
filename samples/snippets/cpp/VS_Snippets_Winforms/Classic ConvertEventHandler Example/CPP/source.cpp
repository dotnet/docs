#using <System.Xml.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TextBox^ text1;
   DataSet^ ds;

   // <Snippet1>
private:
   void DecimalToCurrency( Object^ /*sender*/, ConvertEventArgs^ cevent )
   {
      // The method converts only to string type. Test this using the DesiredType.
      if ( cevent->DesiredType != String::typeid )
      {
         return;
      }
      
      // Use the ToString method to format the value as currency ("c").
      cevent->Value = ( (Decimal^)(cevent->Value) )->ToString( "c" );
   }

   void CurrencyToDecimal( Object^ /*sender*/, ConvertEventArgs^ cevent )
   {
      // ' The method converts only to decimal type. 
      if ( cevent->DesiredType != Decimal::typeid )
      {
         return;
      }

      // Converts the string back to decimal using the static ToDecimal method.
      cevent->Value = Convert::ToDecimal( cevent->Value->ToString() );
   }

   void BindControl()
   {
      // Creates the binding first. The OrderAmount is typed as Decimal.
      Binding^ b = gcnew Binding(
         "Text",ds,"customers.custToOrders.OrderAmount" );
      
      // Add the delegates to the events.
      b->Format += gcnew ConvertEventHandler(
         this, &Form1::DecimalToCurrency );
      b->Parse += gcnew ConvertEventHandler(
         this, &Form1::CurrencyToDecimal );
      text1->DataBindings->Add( b );
   }
   // </Snippet1>
};
