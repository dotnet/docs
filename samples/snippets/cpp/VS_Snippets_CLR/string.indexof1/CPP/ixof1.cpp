
//<snippet1>
// Sample for String::IndexOf(Char, Int32)
using namespace System;
int main()
{
   String^ br1 = "0----+----1----+----2----+----3----+----4----+----5----+----6----+-";
   String^ br2 = "0123456789012345678901234567890123456789012345678901234567890123456";
   String^ str = "Now is the time for all good men to come to the aid of their party.";
   int start;
   int at;
   Console::WriteLine();
   Console::WriteLine( "All occurrences of 't' from position 0 to {0}.", str->Length - 1 );
   Console::WriteLine( "{1}{0}{2}{0}{3}{0}", Environment::NewLine, br1, br2, str );
   Console::Write( "The letter 't' occurs at position(s): " );
   at = 0;
   start = 0;
   while ( (start < str->Length) && (at > -1) )
   {
      at = str->IndexOf( 't', start );
      if ( at == -1 )
            break;

      Console::Write( "{0} ", at );
      start = at + 1;
   }

   Console::WriteLine();
}

/*
This example produces the following results:

All occurrences of 't' from position 0 to 66.
0----+----1----+----2----+----3----+----4----+----5----+----6----+-
0123456789012345678901234567890123456789012345678901234567890123456
Now is the time for all good men to come to the aid of their party.

The letter 't' occurs at position(s): 7 11 33 41 44 55 64

*/
//</snippet1>
