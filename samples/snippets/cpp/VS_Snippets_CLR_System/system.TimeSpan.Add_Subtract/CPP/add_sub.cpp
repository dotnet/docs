
//<Snippet1>
// Example of the TimeSpan::Add( ) and TimeSpan::Subtract( ) methods.
using namespace System;

// Pad the end of a TimeSpan string with spaces if it does not 
// contain milliseconds.
String^ Align( TimeSpan interval )
{
   String^ intervalStr = interval.ToString();
   int pointIndex = intervalStr->IndexOf( ':' );
   pointIndex = intervalStr->IndexOf( '.', pointIndex );
   if ( pointIndex < 0 )
      intervalStr = String::Concat( intervalStr, "        " );

   return intervalStr;
}


// Display TimeSpan parameters and their sum and difference.
static void ShowTimeSpanSumDiff( TimeSpan Left, TimeSpan Right )
{
   String^ dataFmt = "{0,-24}{1,24}";
   Console::WriteLine();
   Console::WriteLine( dataFmt, "TimeSpan Left", Align( Left ) );
   Console::WriteLine( dataFmt, "TimeSpan Right", Align( Right ) );
   Console::WriteLine( dataFmt, "Left.Add( Right )", Align( Left.Add( Right ) ) );
   Console::WriteLine( dataFmt, "Left.Subtract( Right )", Align( Left.Subtract( Right ) ) );
}

int main()
{
   Console::WriteLine( "This example of the TimeSpan::Add( ) and "
   "TimeSpan::Subtract( ) \nmethods generates the "
   "following output by creating several \npairs of "
   "TimeSpan objects and calculating and displaying \n"
   "the sum and difference of each." );
   
   // Create pairs of TimeSpan objects.
   ShowTimeSpanSumDiff( TimeSpan(1,20,0), TimeSpan(0,45,10) );
   ShowTimeSpanSumDiff( TimeSpan(1,10,20,30,40), TimeSpan( -1,2,3,4,5) );
   ShowTimeSpanSumDiff( TimeSpan(182,12,30,30,505), TimeSpan(182,11,29,29,495) );
   ShowTimeSpanSumDiff( TimeSpan(888888888888888), TimeSpan(999999999999999) );
}

/*
This example of the TimeSpan::Add( ) and TimeSpan::Subtract( )
methods generates the following output by creating several
pairs of TimeSpan objects and calculating and displaying
the sum and difference of each.

TimeSpan Left                   01:20:00
TimeSpan Right                  00:45:10
Left.Add( Right )               02:05:10
Left.Subtract( Right )          00:34:50

TimeSpan Left                 1.10:20:30.0400000
TimeSpan Right                 -21:56:55.9950000
Left.Add( Right )               12:23:34.0450000
Left.Subtract( Right )        2.08:17:26.0350000

TimeSpan Left               182.12:30:30.5050000
TimeSpan Right              182.11:29:29.4950000
Left.Add( Right )           365.00:00:00
Left.Subtract( Right )          01:01:01.0100000

TimeSpan Left              1028.19:21:28.8888888
TimeSpan Right             1157.09:46:39.9999999
Left.Add( Right )          2186.05:08:08.8888887
Left.Subtract( Right )     -128.14:25:11.1111111
*/
//</Snippet1>
