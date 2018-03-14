#using <System.dll>
using namespace System;
using namespace System::Diagnostics;

// <Snippet1>
void main()
{
   #if defined(TRACE)
   // Create a text writer that writes to the console screen and add
   // it to the trace listeners.
   TextWriterTraceListener^ myWriter = gcnew TextWriterTraceListener;
   myWriter->Writer = System::Console::Out;
   Trace::Listeners->Add( myWriter );
   
   // Write the output to the console screen.
   myWriter->Write( "Write to the Console screen. " );
   myWriter->WriteLine( "Again, write to console screen." );
   
   // Flush and close the output.
   myWriter->Flush();
   myWriter->Close();
   #endif
}
// </Snippet1>
