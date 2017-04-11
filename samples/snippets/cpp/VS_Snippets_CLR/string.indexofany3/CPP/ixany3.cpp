
//<snippet1>
// Sample for String::IndexOfAny(Char[], Int32, Int32)
using namespace System;
int main()
{
   String^ br1 = "0----+----1----+----2----+----3----+----4----+----5----+----6----+-";
   String^ br2 = "0123456789012345678901234567890123456789012345678901234567890123456";
   String^ str = "Now is the time for all good men to come to the aid of their party.";
   int start;
   int at;
   int count;
   String^ target = "aid";
   array<Char>^anyOf = target->ToCharArray();
   start = (str->Length - 1) / 3;
   count = (str->Length - 1) / 4;
   Console::WriteLine();
   Console::WriteLine( "The first character occurrence from position {0} for {1} characters.", start, count );
   Console::WriteLine( "{1}{0}{2}{0}{3}{0}", Environment::NewLine, br1, br2, str );
   Console::Write( "A character in '{0}' occurs at position: ", target );
   at = str->IndexOfAny( anyOf, start, count );
   if ( at > -1 )
      Console::Write( at );
   else
      Console::Write( "(not found)" );

   Console::WriteLine();
}

/*

The first character occurrence from position 22 for 16 characters.
0----+----1----+----2----+----3----+----4----+----5----+----6----+-
0123456789012345678901234567890123456789012345678901234567890123456
Now is the time for all good men to come to the aid of their party.

A character in 'aid' occurs at position: 27

*/
//</snippet1>
