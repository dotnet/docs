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
   void Method()
   {
      // <Snippet1>
      Trace::WriteLine( "List of errors:" );
      Trace::Indent();
      Trace::WriteLine( "Error 1: File not found" );
      Trace::WriteLine( "Error 2: Directory not found" );
      Trace::Unindent();
      Trace::WriteLine( "End of list of errors" );
      // </Snippet1>
   }
};
