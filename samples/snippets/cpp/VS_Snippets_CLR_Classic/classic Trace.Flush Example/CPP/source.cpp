// <Snippet1>
// Specify /DTRACE when compiling.

#using <System.dll>
using namespace System;
using namespace System::IO;
using namespace System::Diagnostics;

void main()
{
     #if defined(TRACE)
    // Create a file for output named TestFile.txt.
    FileStream^ myFileStream = 
        gcnew FileStream( "TestFile.txt", FileMode::Append );
   
    // Create a new text writer using the output stream 
    // and add it to the trace listeners.
    TextWriterTraceListener^ myTextListener = 
        gcnew TextWriterTraceListener( myFileStream );
    Trace::Listeners->Add( myTextListener );
   
    // Write output to the file.
    Trace::WriteLine( "Test output" );
   
    // Flush and close the output stream.
    Trace::Flush();
    Trace::Close();
    #endif
}
// </Snippet1>
