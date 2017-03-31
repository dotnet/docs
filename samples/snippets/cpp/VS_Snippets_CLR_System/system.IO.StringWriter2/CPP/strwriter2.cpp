
// <Snippet1>
using namespace System;
using namespace System::Globalization;
using namespace System::IO;
int main()
{
   StringWriter^ strWriter = gcnew StringWriter( gcnew CultureInfo(  "ar-DZ" ) );
   strWriter->Write( DateTime::Now );
   
   // <Snippet2>
   Console::WriteLine( "Current date and time using the invariant culture: {0}\n"
   "Current date and time using the Algerian culture: {1}", DateTime::Now.ToString(), strWriter->ToString() );
   
   // </Snippet2>
}

// </Snippet1>
