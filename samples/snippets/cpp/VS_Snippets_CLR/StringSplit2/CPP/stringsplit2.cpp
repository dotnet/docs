
//<snippet1>
using namespace System;
using namespace System::Collections;
int main()
{
   String^ delimStr = " ,.:";
   array<Char>^delimiter = delimStr->ToCharArray();
   String^ words = "one two,three:four.";
   array<String^>^split = nullptr;
   Console::WriteLine( "The delimiters are -{0}-", delimStr );
   for ( int x = 1; x <= 5; x++ )
   {
      split = words->Split( delimiter, x );
      Console::WriteLine( "\ncount = {0, 2} ..............", x );
      IEnumerator^ myEnum = split->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         String^ s = safe_cast<String^>(myEnum->Current);
         Console::WriteLine( "-{0}-", s );
      }

   }
}
// The example displays the following output:
//       The delimiters are - ,.:-
//       count =  1 ..............
//       -one two,three:four.-
//       count =  2 ..............
//       -one-
//       -two,three:four.-
//       count =  3 ..............
//       -one-
//       -two-
//       -three:four.-
//       count =  4 ..............
//       -one-
//       -two-
//       -three-
//       -four.-
//       count =  5 ..............
//       -one-
//       -two-
//       -three-
//       -four-
//       --
//</snippet1>
