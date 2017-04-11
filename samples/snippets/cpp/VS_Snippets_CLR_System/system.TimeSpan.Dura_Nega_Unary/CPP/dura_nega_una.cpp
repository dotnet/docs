
//<Snippet1>
// Example of the TimeSpan::Duration( ) and TimeSpan::Negate( ) methods,
// and the TimeSpan Unary Negation and Unary Plus operators.
using namespace System;
const __wchar_t * protoFmt = L"{0,22}{1,22}{2,22}";
void ShowDurationNegate( TimeSpan interval )
{
   
   // Display the TimeSpan value and the results of the 
   // Duration and Negate methods.
   Console::WriteLine( gcnew String( protoFmt ), interval, interval.Duration(), interval.Negate() );
}

int main()
{
   Console::WriteLine( "This example of TimeSpan::Duration( ), "
   "TimeSpan::Negate( ), \nand the TimeSpan Unary "
   "Negation and Unary Plus operators \n"
   "generates the following output.\n" );
   Console::WriteLine( gcnew String( protoFmt ), "TimeSpan", "Duration( )", "Negate( )" );
   Console::WriteLine( gcnew String( protoFmt ), "--------", "-----------", "---------" );
   
   // Create TimeSpan objects and apply the Unary Negation
   // and Unary Plus operators to them.
   ShowDurationNegate( TimeSpan(1) );
   ShowDurationNegate( TimeSpan( -1234567) );
   ShowDurationNegate(  +TimeSpan(0,0,10,-20,-30) );
   ShowDurationNegate(  +TimeSpan(0,-10,20,-30,40) );
   ShowDurationNegate(  -TimeSpan(1,10,20,40,160) );
   ShowDurationNegate(  -TimeSpan( -10,-20,-30,-40,-50) );
}

/*
This example of TimeSpan::Duration( ), TimeSpan::Negate( ),
and the TimeSpan Unary Negation and Unary Plus operators
generates the following output.

              TimeSpan           Duration( )             Negate( )
              --------           -----------             ---------
      00:00:00.0000001      00:00:00.0000001     -00:00:00.0000001
     -00:00:00.1234567      00:00:00.1234567      00:00:00.1234567
      00:09:39.9700000      00:09:39.9700000     -00:09:39.9700000
     -09:40:29.9600000      09:40:29.9600000      09:40:29.9600000
   -1.10:20:40.1600000    1.10:20:40.1600000    1.10:20:40.1600000
   10.20:30:40.0500000   10.20:30:40.0500000  -10.20:30:40.0500000
*/
//</Snippet1>
