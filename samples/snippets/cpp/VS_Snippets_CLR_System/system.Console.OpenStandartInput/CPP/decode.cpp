// System.Console.OpenStandartInput
// <Snippet1>

using namespace System;
using namespace System::Text;
using namespace System::IO;

int main()
{
   Stream^ inputStream = Console::OpenStandardInput();
   array<Byte>^bytes = gcnew array<Byte>(100);
   Console::WriteLine( "To decode, type or paste the UTF7 encoded string and press enter:" );
   Console::WriteLine( "(Example: \"M+APw-nchen ist wundervoll\")" );
   int outputLength = inputStream->Read( bytes, 0, 100 );
   array<Char>^chars = Encoding::UTF7->GetChars( bytes, 0, outputLength );
   Console::WriteLine( "Decoded string:" );
   Console::WriteLine( gcnew String( chars ) );
}

// </Snippet1>
