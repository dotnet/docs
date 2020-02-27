
//<Snippet1>
// Example of the TimeSpan relational operators.
using namespace System;
const __wchar_t * protoFmt = L"{0,35}    {1}";

// Compare TimeSpan parameters, and display them with the results.
void CompareTimeSpans( TimeSpan Left, TimeSpan Right, String^ RightText )
{
   String^ dataFmt = gcnew String( protoFmt );
   Console::WriteLine();
   Console::WriteLine( dataFmt, String::Concat( "Right: ", RightText ), Right );
   Console::WriteLine( dataFmt, "Left == Right", Left == Right );
   Console::WriteLine( dataFmt, "Left >  Right", Left > Right );
   Console::WriteLine( dataFmt, "Left >= Right", Left >= Right );
   Console::WriteLine( dataFmt, "Left != Right", Left != Right );
   Console::WriteLine( dataFmt, "Left <  Right", Left < Right );
   Console::WriteLine( dataFmt, "Left <= Right", Left <= Right );
}

int main()
{
   TimeSpan Left = TimeSpan(2,0,0);
   Console::WriteLine( "This example of the TimeSpan relational operators "
   "generates \nthe following output. It creates several "
   "different TimeSpan \nobjects and compares them with "
   "a 2-hour TimeSpan.\n" );
   Console::WriteLine( gcnew String( protoFmt ), "Left: TimeSpan( 2, 0, 0 )", Left );
   
   // Create objects to compare with a 2-hour TimeSpan.
   CompareTimeSpans( Left, TimeSpan(0,120,0), "TimeSpan( 0, 120, 0 )" );
   CompareTimeSpans( Left, TimeSpan(2,0,1), "TimeSpan( 2, 0, 1 )" );
   CompareTimeSpans( Left, TimeSpan(2,0,-1), "TimeSpan( 2, 0, -1 )" );
   CompareTimeSpans( Left, TimeSpan::FromDays( 1.0 / 12. ), "TimeSpan::FromDays( 1 / 12 )" );
}

/*
This example of the TimeSpan relational operators generates
the following output. It creates several different TimeSpan
objects and compares them with a 2-hour TimeSpan.

          Left: TimeSpan( 2, 0, 0 )    02:00:00

       Right: TimeSpan( 0, 120, 0 )    02:00:00
                      Left == Right    True
                      Left >  Right    False
                      Left >= Right    True
                      Left != Right    False
                      Left <  Right    False
                      Left <= Right    True

         Right: TimeSpan( 2, 0, 1 )    02:00:01
                      Left == Right    False
                      Left >  Right    False
                      Left >= Right    False
                      Left != Right    True
                      Left <  Right    True
                      Left <= Right    True

        Right: TimeSpan( 2, 0, -1 )    01:59:59
                      Left == Right    False
                      Left >  Right    True
                      Left >= Right    True
                      Left != Right    True
                      Left <  Right    False
                      Left <= Right    False

Right: TimeSpan::FromDays( 1 / 12 )    02:00:00
                      Left == Right    True
                      Left >  Right    False
                      Left >= Right    True
                      Left != Right    False
                      Left <  Right    False
                      Left <= Right    True
*/
//</Snippet1>
