// <Snippet1>
#using <System.dll>
using namespace System;
using namespace System::IO;
using namespace System::Diagnostics;

void main()
{
   #if defined(TRACE)
   TextWriterTraceListener^ myTextListener = nullptr;
   
   // Create a file for output named TestFile.txt.
   String^ myFileName = "TestFile.txt";
   StreamWriter^ myOutputWriter = gcnew StreamWriter( myFileName,true );
   
   // Add a TextWriterTraceListener for the file.
   if ( myOutputWriter )
   {
      myTextListener = gcnew TextWriterTraceListener( myOutputWriter );
      Trace::Listeners->Add( myTextListener );
   }

   // Write trace output to all trace listeners.
   Trace::WriteLine( 
      String::Concat( DateTime::Now.ToString(), " - Trace output" ) );
   if ( myTextListener )
   {
      // Remove and close the file writer/trace listener.
      myTextListener->Flush();
      Trace::Listeners->Remove( myTextListener );
      myTextListener->Close();
   }
   #endif
}
// </Snippet1>
