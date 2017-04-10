
//<Snippet1>
// Example of the Random::Next( ) methods.
using namespace System;

// Generate random numbers with no bounds specified.
void NoBoundsRandoms( int seed )
{
   Console::WriteLine( "\nRandom object, seed = {0}, no bounds:", seed );
   Random^ randObj = gcnew Random( seed );
   
   // Generate six random integers from 0 to int.MaxValue.
   for ( int j = 0; j < 6; j++ )
      Console::Write(  "{0,11} ", randObj->Next() );
   Console::WriteLine();
}


// Generate random numbers with an upper bound specified.
void UpperBoundRandoms( int seed, int upper )
{
   Console::WriteLine( "\nRandom object, seed = {0}, upper bound = {1}:", seed, upper );
   Random^ randObj = gcnew Random( seed );
   
   // Generate six random integers from 0 to the upper bound.
   for ( int j = 0; j < 6; j++ )
      Console::Write(  "{0,11} ", randObj->Next( upper ) );
   Console::WriteLine();
}


// Generate random numbers with both bounds specified.
void BothBoundsRandoms( int seed, int lower, int upper )
{
   Console::WriteLine( "\nRandom object, seed = {0}, lower = {1}, upper = {2}:", seed, lower, upper );
   Random^ randObj = gcnew Random( seed );
   
   // Generate six random integers from the lower to 
   // upper bounds.
   for ( int j = 0; j < 6; j++ )
      Console::Write(  "{0,11} ", randObj->Next( lower, upper ) );
   Console::WriteLine();
}

int main()
{
   Console::WriteLine( "This example of the Random::Next( ) methods\n"
   "generates the following output.\n" );
   Console::WriteLine( "Create Random objects all with the same seed and "
   "generate\nsequences of numbers with different "
   "bounds. Note the effect\nthat the various "
   "combinations of bounds have on the sequences." );
   NoBoundsRandoms( 234 );
   UpperBoundRandoms( 234, Int32::MaxValue );
   UpperBoundRandoms( 234, 2000000000 );
   UpperBoundRandoms( 234, 200000000 );
   BothBoundsRandoms( 234, 0, Int32::MaxValue );
   BothBoundsRandoms( 234, Int32::MinValue, Int32::MaxValue );
   BothBoundsRandoms( 234, -2000000000, 2000000000 );
   BothBoundsRandoms( 234, -200000000, 200000000 );
   BothBoundsRandoms( 234, -2000, 2000 );
}

/*
This example of the Random::Next( ) methods
generates the following output.

Create Random objects all with the same seed and generate
sequences of numbers with different bounds. Note the effect
that the various combinations of bounds have on the sequences.

Random object, seed = 234, no bounds:
 2091148258  1024955023   711273344  1081917183  1833298756   109460588

Random object, seed = 234, upper bound = 2147483647:
 2091148258  1024955023   711273344  1081917183  1833298756   109460588

Random object, seed = 234, upper bound = 2000000000:
 1947533580   954563751   662424922  1007613896  1707392518   101943116

Random object, seed = 234, upper bound = 200000000:
  194753358    95456375    66242492   100761389   170739251    10194311

Random object, seed = 234, lower = 0, upper = 2147483647:
 2091148258  1024955023   711273344  1081917183  1833298756   109460588

Random object, seed = 234, lower = -2147483648, upper = 2147483647:
 2034812868   -97573602  -724936960    16350718  1519113864 -1928562472

Random object, seed = 234, lower = -2000000000, upper = 2000000000:
 1895067160   -90872498  -675150156    15227793  1414785036 -1796113767

Random object, seed = 234, lower = -200000000, upper = 200000000:
  189506716    -9087250   -67515016     1522779   141478503  -179611377

Random object, seed = 234, lower = -2000, upper = 2000:
       1895         -91        -676          15        1414       -1797
*/
//</Snippet1>
