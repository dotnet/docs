
//<snippet1>
// This example demonstrates the Console.Read() method.
using namespace System;
int main()
{
   String^ m1 = "\nType a string of text then press Enter. "
   "Type '+' anywhere in the text to quit:\n";
   String^ m2 = "Character '{0}' is hexadecimal 0x{1:x4}.";
   String^ m3 = "Character     is hexadecimal 0x{0:x4}.";
   Char ch;
   int x;
   
   //
   Console::WriteLine( m1 );
   do
   {
      x = Console::Read();
      try
      {
         ch = Convert::ToChar( x );
         if ( Char::IsWhiteSpace( ch ) )
         {
            Console::WriteLine( m3, x );
            if ( ch == 0x0a )
                        Console::WriteLine( m1 );
         }
         else
                  Console::WriteLine( m2, ch, x );
      }
      catch ( OverflowException^ e ) 
      {
         Console::WriteLine( "{0} Value read = {1}.", e->Message, x );
         ch = Char::MinValue;
         Console::WriteLine( m1 );
      }

   }
   while ( ch != '+' );
}

/*
This example produces the following results:

Type a string of text then press Enter. Type '+' anywhere in the text to quit:

The quick brown fox.
Character 'T' is hexadecimal 0x0054.
Character 'h' is hexadecimal 0x0068.
Character 'e' is hexadecimal 0x0065.
Character     is hexadecimal 0x0020.
Character 'q' is hexadecimal 0x0071.
Character 'u' is hexadecimal 0x0075.
Character 'i' is hexadecimal 0x0069.
Character 'c' is hexadecimal 0x0063.
Character 'k' is hexadecimal 0x006b.
Character     is hexadecimal 0x0020.
Character 'b' is hexadecimal 0x0062.
Character 'r' is hexadecimal 0x0072.
Character 'o' is hexadecimal 0x006f.
Character 'w' is hexadecimal 0x0077.
Character 'n' is hexadecimal 0x006e.
Character     is hexadecimal 0x0020.
Character 'f' is hexadecimal 0x0066.
Character 'o' is hexadecimal 0x006f.
Character 'x' is hexadecimal 0x0078.
Character '.' is hexadecimal 0x002e.
Character     is hexadecimal 0x000d.
Character     is hexadecimal 0x000a.

Type a string of text then press Enter. Type '+' anywhere in the text to quit:

^Z
Value was either too large or too small for a character. Value read = -1.

Type a string of text then press Enter. Type '+' anywhere in the text to quit:

+
Character '+' is hexadecimal 0x002b.

*/
//</snippet1>
