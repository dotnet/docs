#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
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
   TextBox^ textBox1;

   // <Snippet1>
private:
   void DecimalToCurrencyString( Object^ /*sender*/, ConvertEventArgs^ cevent )
   {
      // The method converts only to string type. 
      if ( cevent->DesiredType != String::typeid )
      {
         return;
      }

      cevent->Value = ( (Decimal^)(cevent->Value) )->ToString( "c" );
   }

   void CurrencyStringToDecimal( Object^ /*sender*/, ConvertEventArgs^ cevent )
   {
      // The method converts only to decimal type.
      if ( cevent->DesiredType != Decimal::typeid )
      {
         return;
      }

      cevent->Value = Decimal::Parse( cevent->Value->ToString(),
         NumberStyles::Currency, nullptr );
   }
   // </Snippet1>
};
