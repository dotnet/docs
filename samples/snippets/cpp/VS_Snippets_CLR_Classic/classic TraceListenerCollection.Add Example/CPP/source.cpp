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
      /* Create a listener, which outputs to the console screen, and 
       * add it to the trace listeners. */
      TextWriterTraceListener^ myWriter = gcnew TextWriterTraceListener;
      myWriter->Writer = System::Console::Out;
      Trace::Listeners->Add( myWriter );
      // </Snippet1>
   }
};
