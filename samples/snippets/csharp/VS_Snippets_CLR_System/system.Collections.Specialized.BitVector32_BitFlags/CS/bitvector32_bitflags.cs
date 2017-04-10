// The following code example uses a BitVector32 as a collection of bit flags.


// <snippet1>
using System;
using System.Collections.Specialized;


public class SamplesBitVector32  {

   public static void Main()  {

      // Creates and initializes a BitVector32 with all bit flags set to FALSE.
      BitVector32 myBV = new BitVector32( 0 );

      // Creates masks to isolate each of the first five bit flags.
      int myBit1 = BitVector32.CreateMask();
      int myBit2 = BitVector32.CreateMask( myBit1 );
      int myBit3 = BitVector32.CreateMask( myBit2 );
      int myBit4 = BitVector32.CreateMask( myBit3 );
      int myBit5 = BitVector32.CreateMask( myBit4 );

      // Sets the alternating bits to TRUE.
      Console.WriteLine( "Setting alternating bits to TRUE:" );
      Console.WriteLine( "   Initial:         {0}", myBV.ToString() );
      myBV[myBit1] = true;
      Console.WriteLine( "   myBit1 = TRUE:   {0}", myBV.ToString() );
      myBV[myBit3] = true;
      Console.WriteLine( "   myBit3 = TRUE:   {0}", myBV.ToString() );
      myBV[myBit5] = true;
      Console.WriteLine( "   myBit5 = TRUE:   {0}", myBV.ToString() );

   }

}

/*
This code produces the following output.

Setting alternating bits to TRUE:
   Initial:         BitVector32{00000000000000000000000000000000}
   myBit1 = TRUE:   BitVector32{00000000000000000000000000000001}
   myBit3 = TRUE:   BitVector32{00000000000000000000000000000101}
   myBit5 = TRUE:   BitVector32{00000000000000000000000000010101}


*/
// </snippet1>
