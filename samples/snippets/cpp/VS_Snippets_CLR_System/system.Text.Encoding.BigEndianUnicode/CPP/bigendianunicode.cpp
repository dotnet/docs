
// <Snippet1>
using namespace System;
using namespace System::IO;
int main()
{
   
   // Read a text file saved with Big Endian Unicode encoding.
   System::Text::Encoding^ encoding = System::Text::Encoding::BigEndianUnicode;
   StreamReader^ reader = gcnew StreamReader( "TextFile.txt",encoding );
   String^ line = reader->ReadLine();
   while ( line != nullptr )
   {
      Console::WriteLine( line );
      line = reader->ReadLine();
   }
}

// </Snippet1>
