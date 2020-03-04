
//<Snippet1>
// Example of the Buffer::ByteLength method.
using namespace System;

void ArrayInfo( Array^ arr, String^ name )
{
   int byteLength = Buffer::ByteLength( arr );
   
   // Display the array name, type, Length, and ByteLength.
   Console::WriteLine( "{0,10}{1,20}{2,9}{3,12}", name, arr->GetType(), arr->Length, byteLength );
}

int main()
{
   array<unsigned char>^bytes = {1,2,3,4,5,6,7,8,9,0};
   array<bool>^bools = {true,false,true,false,true};
   array<Char>^chars = {' ','$','\"','A','{'};
   array<short>^shorts = {258,259,260,261,262,263};
   array<float>^singles = {1,678,2.37E33F,.00415F,8.9F};
   array<double>^doubles = {2E-22,.003,4.4E44,555E55};
   array<long>^longs = {1,10,100,1000,10000,100000};
   Console::WriteLine( "This example of the Buffer::ByteLength( Array* ) "
   "\nmethod generates the following output.\n" );
   Console::WriteLine( "{0,10}{1,20}{2,9}{3,12}", "Array name", "Array type", "Length", "ByteLength" );
   Console::WriteLine( "{0,10}{1,20}{2,9}{3,12}", "----------", "----------", "------", "----------" );
   
   // Display the Length and ByteLength for each array.
   ArrayInfo( bytes, "bytes" );
   ArrayInfo( bools, "bools" );
   ArrayInfo( chars, "chars" );
   ArrayInfo( shorts, "shorts" );
   ArrayInfo( singles, "singles" );
   ArrayInfo( doubles, "doubles" );
   ArrayInfo( longs, "longs" );
}

/*
This example of the Buffer::ByteLength( Array* )
method generates the following output.

Array name          Array type   Length  ByteLength
----------          ----------   ------  ----------
     bytes       System.Byte[]       10          10
     bools    System.Boolean[]        5           5
     chars       System.Char[]        5          10
    shorts      System.Int16[]        6          12
   singles     System.Single[]        5          20
   doubles     System.Double[]        4          32
     longs      System.Int32[]        6          24
*/
//</Snippet1>
