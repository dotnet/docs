// <Snippet1>
 using System;
 using System.Collections;
 public class SamplesBitArray  {
 
    public static void Main()  {
 
       // Creates and initializes two BitArrays of the same size.
       BitArray myBA1 = new BitArray( 4 );
       BitArray myBA2 = new BitArray( 4 );
       myBA1[0] = myBA1[1] = false;
       myBA1[2] = myBA1[3] = true;
       myBA2[0] = myBA2[2] = false;
       myBA2[1] = myBA2[3] = true;
 
       // Performs a bitwise XOR operation between BitArray instances of the same size.
       Console.WriteLine( "Initial values" );
       Console.Write( "myBA1:" );
       PrintValues( myBA1, 8 );
       Console.Write( "myBA2:" );
       PrintValues( myBA2, 8 );
       Console.WriteLine();
 
       Console.WriteLine( "Result" );
       Console.Write( "XOR:" );
       PrintValues( myBA1.Xor( myBA2 ), 8 );
       Console.WriteLine();
 
       Console.WriteLine( "After XOR" );
       Console.Write( "myBA1:" );
       PrintValues( myBA1, 8 );
       Console.Write( "myBA2:" );
       PrintValues( myBA2, 8 );
       Console.WriteLine();
 
       // Performing XOR between BitArray instances of different sizes returns an exception.
       try  {
          BitArray myBA3 = new BitArray( 8 );
          myBA3[0] = myBA3[1] = myBA3[2] = myBA3[3] = false;
          myBA3[4] = myBA3[5] = myBA3[6] = myBA3[7] = true;
          myBA1.Xor( myBA3 );
       } catch ( Exception myException )  {
          Console.WriteLine("Exception: " + myException.ToString());
       }
    }
 
 
    public static void PrintValues( IEnumerable myList, int myWidth )  {
       int i = myWidth;
       foreach ( Object obj in myList ) {
          if ( i <= 0 )  {
             i = myWidth;
             Console.WriteLine();
          }
          i--;
          Console.Write( "{0,8}", obj );
       }
       Console.WriteLine();
    }

 }


 /* 
 This code produces the following output.
 
 Initial values
 myBA1:   False   False    True    True
 myBA2:   False    True   False    True

 Result
 XOR:   False    True    True   False

 After XOR
 myBA1:   False    True    True   False
 myBA2:   False    True   False    True

 Exception: System.ArgumentException: Array lengths must be the same.
    at System.Collections.BitArray.Xor(BitArray value)
    at SamplesBitArray.Main()

 */ 
// </Snippet1>

