
//<snippet1>
using namespace System;
using namespace System::Text;
int main()
{
   Encoding^ unicode = Encoding::Unicode;
   
   // Get the preamble for the Unicode encoder. 
   // In this case the preamblecontains the Byte order mark (BOM).
   array<Byte>^preamble = unicode->GetPreamble();
   
   // Make sure a preamble was returned 
   // and is large enough to containa BOM.
   if ( preamble->Length >= 2 )
   {
      
      // if (preamble->Item[0] == 0xFE && preamble->Item[1] == 0xFF) 
      if ( preamble[ 0 ] == 0xFE && preamble[ 1 ] == 0xFF )
      {
         Console::WriteLine( "The Unicode encoder is encoding in big-endian order." );
      }
      // else if (preamble->Item[0] == 0xFF && preamble->Item[1] == 0xFE) 
      else
      
      // else if (preamble->Item[0] == 0xFF && preamble->Item[1] == 0xFE) 
      if ( preamble[ 0 ] == 0xFF && preamble[ 1 ] == 0xFE )
      {
         Console::WriteLine( "The Unicode encoder is encoding in little-endian order." );
      }
   }
}

/*
This code produces the following output.

The Unicode encoder is encoding in little-endian order.

*/

//</snippet1>
