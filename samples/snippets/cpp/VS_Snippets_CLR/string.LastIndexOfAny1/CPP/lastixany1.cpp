
//<snippet1>
// Sample for String::LastIndexOfAny(Char[])
using namespace System;
int main()
{
   String^ br1 = "0----+----1----+----2----+----3----+----4----+----5----+----6----+-";
   String^ br2 = "0123456789012345678901234567890123456789012345678901234567890123456";
   String^ str = "Now is the time for all good men to come to the aid of their party.";
   int start;
   int at;
   String^ target = "is";
   array<Char>^anyOf = target->ToCharArray();
   start = str->Length - 1;
   Console::WriteLine( "The last character occurrence  from position {0} to 0.", start );
   Console::WriteLine( "{1}{0}{2}{0}{3}{0}", Environment::NewLine, br1, br2, str );
   Console::Write( "A character in '{0}' occurs at position: ", target );
   at = str->LastIndexOfAny( anyOf );
   if ( at > -1 )
      Console::Write( at );
   else
      Console::Write( "(not found)" );

   Console::Write( "{0}{0}{0}", Environment::NewLine );
}

/*
This example produces the following results:
The last character occurrence  from position 66 to 0.
0----+----1----+----2----+----3----+----4----+----5----+----6----+-
0123456789012345678901234567890123456789012345678901234567890123456
Now is the time for all good men to come to the aid of their party.

A character in 'is' occurs at position: 58


*/
//</snippet1>
