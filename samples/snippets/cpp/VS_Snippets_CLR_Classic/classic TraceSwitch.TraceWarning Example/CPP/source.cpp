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
   // Class-level declaration.
   /* Create a TraceSwitch to use in the entire application.*/
private:
   static TraceSwitch^ mySwitch = gcnew TraceSwitch( "General", "Entire Application" );

public:
   static void MyMethod()
   {
      // Write the message if the TraceSwitch level is set to Warning or higher.
      if ( mySwitch->TraceWarning )
         Console::WriteLine( "My error message." );

      // Write the message if the TraceSwitch level is set to Verbose.
      if ( mySwitch->TraceVerbose )
         Console::WriteLine( "My second error message." );
   }

   static void main()
   {
      // Run the method that prints error messages based on the switch level.
      MyMethod();
   }
   // </Snippet1>
};

int main()
{
   Form1::main();
}
