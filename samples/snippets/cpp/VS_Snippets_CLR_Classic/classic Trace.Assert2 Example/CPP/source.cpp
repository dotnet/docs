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
public:
   static void MyMethod( Type^ type, Type^ baseType )
   {
      #if defined(TRACE)
      Trace::Assert( type != nullptr, "Type parameter is null", "Can't get object for null type" );
      #endif
      
      // Perform some processing.
   }
   // </Snippet1>
};
