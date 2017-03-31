
//<snippet1>
// Sample for String::LastIndexOf(String, Int32, Int32)
using namespace System;
int main()
{
   String^ br1 = "0----+----1----+----2----+----3----+----4----+----5----+----6----+-";
   String^ br2 = "0123456789012345678901234567890123456789012345678901234567890123456";
   String^ str = "Now is the time for all good men to come to the aid of their party.";
   int start;
   int at;
   int count;
   int end;
   start = str->Length - 1;
   end = start / 2 - 1;
   Console::WriteLine( "All occurrences of 'he' from position {0} to {1}.", start, end );
   Console::WriteLine( "{1}{0}{2}{0}{3}{0}", Environment::NewLine, br1, br2, str );
   Console::Write( "The string 'he' occurs at position(s): " );
   count = 0;
   at = 0;
   while ( (start > -1) && (at > -1) )
   {
      count = start - end; //Count must be within the substring.
      at = str->LastIndexOf( "he", start, count );
      if ( at > -1 )
      {
         Console::Write( "{0} ", at );
         start = at - 1;
      }
   }

   Console::Write( "{0} {0} {0}", Environment::NewLine );
}

/*
This example produces the following results:
All occurrences of 'he' from position 66 to 32.
0----+----1----+----2----+----3----+----4----+----5----+----6----+-
0123456789012345678901234567890123456789012345678901234567890123456
Now is the time for all good men to come to the aid of their party.

The string 'he' occurs at position(s): 56 45
*/
//</snippet1>
