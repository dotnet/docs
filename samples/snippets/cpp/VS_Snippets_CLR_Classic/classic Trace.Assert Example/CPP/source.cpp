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
   // <Snippet1>
protected:
   // Create an index for an array.
   int index;

   void Method()
   {
      // Perform some action that sets the index.
      // Test that the index value is valid.
      #if defined(TRACE)
      Trace::Assert( index > -1 );
      #endif
   }
   // </Snippet1>
};
