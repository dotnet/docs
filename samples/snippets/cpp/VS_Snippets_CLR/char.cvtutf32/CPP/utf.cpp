
//<snippet1>
// This example demonstrates the Char.ConvertFromUtf32() method
//                           and Char.ConvertToUtf32() overloads.
using namespace System;
void Show( String^ s )
{
//   Console::Write( "0x{0:X}, 0x{1:X}", (int)s->get_Chars( 0 ), (int)s->get_Chars( 1 ) );
   Console::Write( "0x{0:X}, 0x{1:X}", (int)s[ 0 ], (int)s[ 1 ] );
}

int main()
{
   int music = 0x1D161; //U+1D161 = MUSICAL SYMBOL SIXTEENTH NOTE

   String^ s1;
   String^ comment1a = "Create a UTF-16 encoded string from a code point.";
   String^ comment1b = "Create a code point from a surrogate pair at a certain position in a string.";
   String^ comment1c = "Create a code point from a high surrogate and a low surrogate code point.";
   
   // -------------------------------------------------------------------
   //  Convert the code point U+1D161 to UTF-16. The UTF-16 equivalent of 
   //  U+1D161 is a surrogate pair with hexadecimal values D834 and DD61.
   Console::WriteLine( comment1a );
   s1 = Char::ConvertFromUtf32( music );
   Console::Write( "    1a) 0x{0:X} => ", music );
   Show( s1 );
   Console::WriteLine();
   
   //  Convert the surrogate pair in the string at index position 
   //  zero to a code point.
   Console::WriteLine( comment1b );
   music = Char::ConvertToUtf32( s1, 0 );
   Console::Write( "    1b) " );
   Show( s1 );
   Console::WriteLine( " => 0x{0:X}", music );
   
   //  Convert the high and low characters in the surrogate pair into a code point.
   Console::WriteLine( comment1c );
   music = Char::ConvertToUtf32( s1[ 0 ], s1[ 1 ] );
   Console::Write( "    1c) " );
   Show( s1 );
   Console::WriteLine( " => 0x{0:X}", music );
}

/*
This example produces the following results:

Create a UTF-16 encoded string from a code point.
    1a) 0x1D161 => 0xD834, 0xDD61
Create a code point from a surrogate pair at a certain position in a string.
    1b) 0xD834, 0xDD61 => 0x1D161
Create a code point from a high surrogate and a low surrogate code point.
    1c) 0xD834, 0xDD61 => 0x1D161

*/
//</snippet1>
