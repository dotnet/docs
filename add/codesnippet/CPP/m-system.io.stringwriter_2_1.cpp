using namespace System;
using namespace System::IO;
using namespace System::Text;
int main()
{
   StringWriter^ strWriter = gcnew StringWriter;
   
   // Use the three overloads of the Write method that are 
   // overridden by the StringWriter class.
   strWriter->Write( "file path characters are: " );
   strWriter->Write( Path::InvalidPathChars, 0, Path::InvalidPathChars->Length );
   strWriter->Write( Char::Parse( "." ) );
   
   // Use the underlying StringBuilder for more complex 
   // manipulations of the string.
   strWriter->GetStringBuilder()->Insert( 0, "Invalid " );
   
   Console::WriteLine( "The following string is {0} encoded.\n{1}", strWriter->Encoding->EncodingName, strWriter->ToString() );
   
}
