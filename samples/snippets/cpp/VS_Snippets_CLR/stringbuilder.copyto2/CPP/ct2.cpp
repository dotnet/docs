//<snippet1>
// This example demonstrates the CopyTo(Int32, Char[], Int32, Int32) method.
// Typically the destination array is small, preallocated, and global while 
// the StringBuilder is large with programmatically defined data. 
// However, for this example both the array and StringBuilder are small 
// and the StringBuilder has predefined data.

using namespace System;
using namespace System::Text;

int main()
{
   array<Char>^dest = gcnew array<Char>(6);
   StringBuilder^ src = gcnew StringBuilder( "abcdefghijklmnopqrstuvwxyz!" );
   dest[ 1 ] = ')';
   dest[ 2 ] = ' ';

   // Copy the source to the destination in 9 pieces, 3 characters per piece.
   Console::WriteLine( "\nPiece) Data:" );
   for ( int ix = 0; ix < 9; ix++ )
   {
      dest[ 0 ] = ix.ToString()[ 0 ];
      src->CopyTo( ix * 3, dest, 3, 3 );
      Console::Write( "    " );
      Console::WriteLine( dest );
   }
}

/*
This example produces the following results:

Piece) Data:
    0) abc
    1) def
    2) ghi
    3) jkl
    4) mno
    5) pqr
    6) stu
    7) vwx
    8) yz!
*/
//</snippet1>
