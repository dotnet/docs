
// <Snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Text;
int main()
{
   StringBuilder^ strBuilder = gcnew StringBuilder( "file path characters are: " );
   StringWriter^ strWriter = gcnew StringWriter( strBuilder );
   strWriter->Write( Path::InvalidPathChars, 0, Path::InvalidPathChars->Length );
   
   // <Snippet2>
   strWriter->Close();
   
   // Since the StringWriter is closed, an exception will 
   // be thrown if the Write method is called. However, 
   // the StringBuilder can still manipulate the string.
   strBuilder->Insert( 0, "Invalid " );
   Console::WriteLine( strWriter->ToString() );
   
   // </Snippet2>
}

// </Snippet1>
