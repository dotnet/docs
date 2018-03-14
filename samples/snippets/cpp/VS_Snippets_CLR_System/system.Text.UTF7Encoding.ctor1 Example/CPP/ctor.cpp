
// <Snippet1>
using namespace System;
using namespace System::Text;
int main()
{
   UTF7Encoding^ utf7 = gcnew UTF7Encoding;
   String^ encodingName = utf7->EncodingName;
   Console::WriteLine( "Encoding name: {0}", encodingName );
}

// </Snippet1>
