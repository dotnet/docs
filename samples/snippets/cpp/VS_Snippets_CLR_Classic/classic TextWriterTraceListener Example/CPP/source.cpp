#using <System.dll>
using namespace System;
using namespace System::IO;
using namespace System::Diagnostics;

// <Snippet1>
void main()
{
   #if defined(TRACE)
   // Create a file for output named TestFile.txt.
   Stream^ myFile = File::Create( "TestFile.txt" );
   
   // Create a new text writer using the output stream and
   // add it to the trace listeners.
   TextWriterTraceListener^ myTextListener = 
      gcnew TextWriterTraceListener( myFile );
   Trace::Listeners->Add( myTextListener );
  
   // Write output to the file.
   Trace::Write( "Test output " );
  
   // Flush the output.
   Trace::Flush();
   Trace::Close();
   #endif
}
// </Snippet1>
