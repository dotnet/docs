
//<Snippet3>
// Example of the Buffer::GetByte method.
using namespace System;
#define formatter "{0,10}{1,10}{2,9} {3}"

// Display the array contents in hexadecimal.
void DisplayArray( Array^ arr, String^ name )
{
   
   // Get the array element width; format the formatting string.
   int elemWidth = Buffer::ByteLength( arr ) / arr->Length;
   String^ format = String::Format( " {{0:X{0}}}", 2 * elemWidth );
   
   // Display the array elements from right to left.
   Console::Write( "{0,5}:", name );
   for ( int loopX = arr->Length - 1; loopX >= 0; loopX-- )
      Console::Write( format, arr->GetValue( loopX ) );
   Console::WriteLine();
}

void ArrayInfo( Array^ arr, String^ name, int index )
{
   unsigned char value = Buffer::GetByte( arr, index );
   
   // Display the array name, index, and byte to be viewed.
   Console::WriteLine( formatter, name, index, value, String::Format( "0x{0:X2}", value ) );
}

int main()
{
   
   // These are the arrays to be viewed with GetByte.
   array<__int64>^longs = {333333333333333333,666666666666666666,999999999999999999};
   array<int>^ints = {111111111,222222222,333333333,444444444,555555555};
   Console::WriteLine( "This example of the "
   "Buffer::GetByte( Array*, int ) \n"
   "method generates the following output.\n"
   "Note: The arrays are displayed from right to left.\n" );
   Console::WriteLine( "  Values of arrays:\n" );
   
   // Display the values of the arrays.
   DisplayArray( longs, "longs" );
   DisplayArray( ints, "ints" );
   Console::WriteLine();
   Console::WriteLine( formatter, "Array", "index", "value", "" );
   Console::WriteLine( formatter, "-----", "-----", "-----", "----" );
   
   // Display the Length and ByteLength for each array.
   ArrayInfo( ints, "ints", 0 );
   ArrayInfo( ints, "ints", 7 );
   ArrayInfo( ints, "ints", 10 );
   ArrayInfo( ints, "ints", 17 );
   ArrayInfo( longs, "longs", 0 );
   ArrayInfo( longs, "longs", 6 );
   ArrayInfo( longs, "longs", 10 );
   ArrayInfo( longs, "longs", 17 );
   ArrayInfo( longs, "longs", 21 );
}

/*
This example of the Buffer::GetByte( Array*, int )
method generates the following output.
Note: The arrays are displayed from right to left.

  Values of arrays:

longs: 0DE0B6B3A763FFFF 094079CD1A42AAAA 04A03CE68D215555
 ints: 211D1AE3 1A7DAF1C 13DE4355 0D3ED78E 069F6BC7

     Array     index    value
     -----     -----    ----- ----
      ints         0      199 0xC7
      ints         7       13 0x0D
      ints        10      222 0xDE
      ints        17       26 0x1A
     longs         0       85 0x55
     longs         6      160 0xA0
     longs        10       66 0x42
     longs        17      255 0xFF
     longs        21      182 0xB6
*/
//</Snippet3>
