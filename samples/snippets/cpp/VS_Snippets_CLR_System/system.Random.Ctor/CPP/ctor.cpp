
//<Snippet1>
// Example of the Random class constructors and Random::NextDouble( ) 
// method.
using namespace System;
using namespace System::Threading;

// Generate random numbers from the specified Random object.
void RunIntNDoubleRandoms( Random^ randObj )
{
   
   // Generate the first six random integers.
   for ( int j = 0; j < 6; j++ )
      Console::Write( " {0,10} ", randObj->Next() );
   Console::WriteLine();
   
   // Generate the first six random doubles.
   for ( int j = 0; j < 6; j++ )
      Console::Write( " {0:F8} ", randObj->NextDouble() );
   Console::WriteLine();
}


// Create a Random object with the specified seed.
void FixedSeedRandoms( int seed )
{
   Console::WriteLine( "\nRandom numbers from a Random object with seed = {0}:", seed );
   Random^ fixRand = gcnew Random( seed );
   RunIntNDoubleRandoms( fixRand );
}


// Create a random object with a timer-generated seed.
void AutoSeedRandoms()
{
   
   // Wait to allow the timer to advance.
   Thread::Sleep( 1 );
   Console::WriteLine( "\nRandom numbers from a Random object "
   "with an auto-generated seed:" );
   Random^ autoRand = gcnew Random;
   RunIntNDoubleRandoms( autoRand );
}

int main()
{
   Console::WriteLine( "This example of the Random class constructors and Random"
   "::NextDouble( ) \ngenerates the following output.\n" );
   Console::WriteLine( "Create Random objects, and then generate and "
   "display six integers and \nsix doubles from each." );
   FixedSeedRandoms( 123 );
   FixedSeedRandoms( 123 );
   FixedSeedRandoms( 456 );
   FixedSeedRandoms( 456 );
   AutoSeedRandoms();
   AutoSeedRandoms();
   AutoSeedRandoms();
}

/*
This example of the Random class constructors and Random::NextDouble( )
generates the following output.

Create Random objects, and then generate and display six integers and
six doubles from each.

Random numbers from a Random object with seed = 123:
 2114319875  1949518561  1596751841  1742987178  1586516133   103755708
 0.01700087  0.14935942  0.19470390  0.63008947  0.90976122  0.49519146

Random numbers from a Random object with seed = 123:
 2114319875  1949518561  1596751841  1742987178  1586516133   103755708
 0.01700087  0.14935942  0.19470390  0.63008947  0.90976122  0.49519146

Random numbers from a Random object with seed = 456:
 2044805024  1323311594  1087799997  1907260840   179380355   120870348
 0.21988117  0.21026556  0.39236514  0.42420498  0.24102703  0.47310170

Random numbers from a Random object with seed = 456:
 2044805024  1323311594  1087799997  1907260840   179380355   120870348
 0.21988117  0.21026556  0.39236514  0.42420498  0.24102703  0.47310170

Random numbers from a Random object with an auto-generated seed:
 1624372556  1894939458   302472229   588108304    23919954  1085111949
 0.14595512  0.30162298  0.92267372  0.55707657  0.25430079  0.74143239

Random numbers from a Random object with an auto-generated seed:
 2105952511  1753605347   280739490   876793040  1129567796   524571616
 0.62652210  0.31846701  0.15984073  0.24458755  0.62160607  0.54857684

Random numbers from a Random object with an auto-generated seed:
  440048819  1612271236   259006751  1165477776    87731991  2111514930
 0.10708907  0.33531104  0.39700773  0.93209853  0.98891135  0.35572129
*/
//</Snippet1>
