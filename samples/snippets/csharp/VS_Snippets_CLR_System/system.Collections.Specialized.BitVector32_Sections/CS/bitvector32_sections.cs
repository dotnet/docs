// The following code example uses a BitVector32 as a collection of sections.


// <snippet1>
using System;
using System.Collections.Specialized;


public class SamplesBitVector32  {

   public static void Main()  {

      // Creates and initializes a BitVector32.
      BitVector32 myBV = new BitVector32( 0 );

      // Creates four sections in the BitVector32 with maximum values 6, 3, 1, and 15.
      // mySect3, which uses exactly one bit, can also be used as a bit flag.
      BitVector32.Section mySect1 = BitVector32.CreateSection( 6 );
      BitVector32.Section mySect2 = BitVector32.CreateSection( 3, mySect1 );
      BitVector32.Section mySect3 = BitVector32.CreateSection( 1, mySect2 );
      BitVector32.Section mySect4 = BitVector32.CreateSection( 15, mySect3 );

      // Displays the values of the sections.
      Console.WriteLine( "Initial values:" );
      Console.WriteLine( "\tmySect1: {0}", myBV[mySect1] );
      Console.WriteLine( "\tmySect2: {0}", myBV[mySect2] );
      Console.WriteLine( "\tmySect3: {0}", myBV[mySect3] );
      Console.WriteLine( "\tmySect4: {0}", myBV[mySect4] );

      // Sets each section to a new value and displays the value of the BitVector32 at each step.
      Console.WriteLine( "Changing the values of each section:" );
      Console.WriteLine( "\tInitial:    \t{0}", myBV.ToString() );
      myBV[mySect1] = 5;
      Console.WriteLine( "\tmySect1 = 5:\t{0}", myBV.ToString() );
      myBV[mySect2] = 3;
      Console.WriteLine( "\tmySect2 = 3:\t{0}", myBV.ToString() );
      myBV[mySect3] = 1;
      Console.WriteLine( "\tmySect3 = 1:\t{0}", myBV.ToString() );
      myBV[mySect4] = 9;
      Console.WriteLine( "\tmySect4 = 9:\t{0}", myBV.ToString() );

      // Displays the values of the sections.
      Console.WriteLine( "New values:" );
      Console.WriteLine( "\tmySect1: {0}", myBV[mySect1] );
      Console.WriteLine( "\tmySect2: {0}", myBV[mySect2] );
      Console.WriteLine( "\tmySect3: {0}", myBV[mySect3] );
      Console.WriteLine( "\tmySect4: {0}", myBV[mySect4] );

   }

}

/*
This code produces the following output.

Initial values:
        mySect1: 0
        mySect2: 0
        mySect3: 0
        mySect4: 0
Changing the values of each section:
        Initial:        BitVector32{00000000000000000000000000000000}
        mySect1 = 5:    BitVector32{00000000000000000000000000000101}
        mySect2 = 3:    BitVector32{00000000000000000000000000011101}
        mySect3 = 1:    BitVector32{00000000000000000000000000111101}
        mySect4 = 9:    BitVector32{00000000000000000000001001111101}
New values:
        mySect1: 5
        mySect2: 3
        mySect3: 1
        mySect4: 9

*/
// </snippet1>
