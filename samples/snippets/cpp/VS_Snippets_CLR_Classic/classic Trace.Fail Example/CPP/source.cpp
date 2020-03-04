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
   void Method( Option option )
   {
      try
      {
         // try something here
      }
      // <Snippet1>
      catch ( Exception^ ) 
      {
         #if defined(TRACE)
         Trace::Fail( "Unknown Option " + option + ", using the default." );
         #endif
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
            Trace::Fail(String::Format("Unknown Option {0}", option));
            #endif
            result = 1.0;
            break;
      }
      // </Snippet2>
   }
};
