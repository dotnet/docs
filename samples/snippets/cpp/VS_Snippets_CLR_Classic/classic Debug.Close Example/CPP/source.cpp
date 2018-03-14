// <Snippet1>
// Specify /DDEBUG when compiling.

#using <System.dll>
using namespace System;
using namespace System::IO;
using namespace System::Diagnostics;

void main()
{
     #if defined(DEBUG)
    // Create a new stream object for an output file named TestFile.txt.
    FileStream^ myFileStream = 
        gcnew FileStream( "TestFile.txt", FileMode::Append );
   
    // Add the stream object to the trace listeners.
    TextWriterTraceListener^ myTextListener = 
        gcnew TextWriterTraceListener( myFileStream );
    Debug::Listeners->Add( myTextListener );
   
    // Write output to the file.
    Debug::WriteLine( "Test output" );
   
    // Flush and close the output stream.
    Debug::Flush();
    Debug::Close();
    #endif
}
// </Snippet1>
