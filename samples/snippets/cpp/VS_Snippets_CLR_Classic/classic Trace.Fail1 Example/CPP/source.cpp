#using <System.dll>
#using <System.Data.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Data;
using namespace System::Diagnostics;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
public:
   enum class Option
   {
      First, Second
   };

protected:
   double result;

public:
   void Method( Option option, String^ userInput )
   {
      int value = 0;
      int newValue = 1;
      try
      {
         value = Int32::Parse( userInput );
      }
      // <Snippet1>
      catch ( Exception^ ) 
      {
        #if defined(TRACE)
        Trace::Fail( String::Format( "Invalid value: {0}", value ),
            "Resetting value to newValue." );
         #endif
         value = newValue;
      }
      // </Snippet1>

      // <Snippet2>
      switch ( option )
      {
         case Option::First:
            result = 1.0;
            break;

         // Insert additional cases.

         default:
            #if defined(TRACE)
            Trace::Fail( String::Format( "Unsupported option {0}", option ),
               "Result set to 1.0" );
            #endif
            result = 1.0;
            break;
      }
      // </Snippet2>
   }

};

void main()
{
   Form1^ myForm = gcnew Form1;
   myForm->Method( Form1::Option::Second, "not an integer string" );
}
