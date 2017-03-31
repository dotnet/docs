//<Snippet1>
// Example of the Random class constructors and Random.NextDouble( ) 
// method.
using System;
using System.Threading;

public class RandomObjectDemo  
{
    // Generate random numbers from the specified Random object.
    static void RunIntNDoubleRandoms( Random randObj )
    {
        // Generate the first six random integers.
        for( int j = 0; j < 6; j++ )
            Console.Write( " {0,10} ", randObj.Next( ) );
        Console.WriteLine( );

        // Generate the first six random doubles.
        for( int j = 0; j < 6; j++ )
            Console.Write( " {0:F8} ", randObj.NextDouble( ) );
        Console.WriteLine( );
    }

    // Create a Random object with the specified seed.
    static void FixedSeedRandoms( int seed )
    {
        Console.WriteLine( 
            "\nRandom numbers from a Random object with " +
            "seed = {0}:", seed );
        Random fixRand = new Random( seed );

        RunIntNDoubleRandoms( fixRand );
    }

    // Create a random object with a timer-generated seed.
    static void AutoSeedRandoms( )
    {
        // Wait to allow the timer to advance.
        Thread.Sleep( 1 );

        Console.WriteLine( 
            "\nRandom numbers from a Random object " +
            "with an auto-generated seed:" );
        Random autoRand = new Random( );

        RunIntNDoubleRandoms( autoRand );
    }

    static void Main( )
    {	
        Console.WriteLine(
            "This example of the Random class constructors and " +
            "Random.NextDouble( ) \n" +
            "generates the following output.\n" );
        Console.WriteLine(
            "Create Random objects, and then generate and " +
            "display six integers and \nsix doubles from each.");

        FixedSeedRandoms( 123 );
        FixedSeedRandoms( 123 );

        FixedSeedRandoms( 456 );
        FixedSeedRandoms( 456 );

        AutoSeedRandoms( );
        AutoSeedRandoms( );
        AutoSeedRandoms( );
    }
}

/*
This example of the Random class constructors and Random.NextDouble( )
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
  380213349   127379247  1969091178  1983029819  1963098450  1648433124
 0.08824121  0.41249688  0.36445811  0.05637512  0.62702451  0.49595560

Random numbers from a Random object with an auto-generated seed:
  861793304  2133528783  1947358439   124230908   921262645  1087892791
 0.56880819  0.42934091  0.60162512  0.74388610  0.99432979  0.30310005

Random numbers from a Random object with an auto-generated seed:
 1343373259  1992194672  1925625700   412915644  2026910487   527352458
 0.04937517  0.44618494  0.83879212  0.43139707  0.36163507  0.11024451
*/
//</Snippet1>

// Code added to show how to initialize Random objects with the
// same timer value that will produce unique random number sequences.
public class FixTimerResolution
{
   public static void CreateEnginesWithSameTimer()
   {
// <Snippet3>   
      int randomInstancesToCreate = 4;
      Random[] randomEngines = new Random[randomInstancesToCreate];
      for (int ctr = 0; ctr < randomInstancesToCreate; ctr++)
      {
         randomEngines[ctr] = new Random(unchecked((int) (DateTime.Now.Ticks >> ctr)));
      }
// </Snippet3>      
      for (int ctr = 0; ctr < randomInstancesToCreate; ctr++)
      {
         Console.WriteLine(randomEngines[ctr].Next());
      }
   }
}
