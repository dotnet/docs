
// <Snippet1>
using namespace System;
using namespace System::Text;
int main()
{
   ASCIIEncoding^ ascii = gcnew ASCIIEncoding;
   String^ encodingName = ascii->EncodingName;
   Console::WriteLine( "Encoding name: {0}", encodingName );
}

// </Snippet1>
