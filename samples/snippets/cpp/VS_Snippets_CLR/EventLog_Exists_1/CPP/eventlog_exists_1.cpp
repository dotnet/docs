

// System::Diagnostics::EventLog::Exists(String)
/*
The following sample demonstrates the 'Exists(String)'method of
'EventLog' class. It checks for the existence of a log and displays
the result accordingly.
*/
#using <System.dll>

using namespace System;
using namespace System::Diagnostics;
void main()
{
   try
   {
      
      // <Snippet1>
      String^ myLog = "myNewLog";
      if ( EventLog::Exists( myLog ) )
      {
         Console::WriteLine( "Log '{0}' exists.", myLog );
      }
      else
      {
         Console::WriteLine( "Log '{0}' does not exist.", myLog );
      }
   }
   catch ( Exception^ e ) 
   {
      Console::WriteLine( "Exception: {0}", e->Message );
   }

}

//</Snippet1>
