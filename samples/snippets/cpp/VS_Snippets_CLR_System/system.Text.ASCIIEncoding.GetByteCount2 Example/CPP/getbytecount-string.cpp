
// <Snippet1>
using namespace System;
using namespace System::Text;
int main()
{
   String^ chars = "ASCII Encoding Example";
   ASCIIEncoding^ ascii = gcnew ASCIIEncoding;
   int byteCount = ascii->GetByteCount( chars );
   Console::WriteLine( " {0} bytes needed to encode string.", byteCount );
}

// </Snippet1>
