// The following code example passes an ArraySegment to a method.

// <Snippet1>
using System;

public class SamplesArray  {
 
   public static void Main()  {
 
      // Create and initialize a new string array.
      String[] myArr = { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };
 
      // Display the initial contents of the array.
      Console.WriteLine( "The original array initially contains:" );
      PrintIndexAndValues( myArr );

      // Define an array segment that contains the entire array.
      ArraySegment<String> myArrSegAll = new ArraySegment<String>( myArr );

      // Display the contents of the ArraySegment.
      Console.WriteLine( "The first array segment (with all the array's elements) contains:" );
      PrintIndexAndValues( myArrSegAll );

      // Define an array segment that contains the middle five values of the array.
      ArraySegment<String> myArrSegMid = new ArraySegment<String>( myArr, 2, 5 );

      // Display the contents of the ArraySegment.
      Console.WriteLine( "The second array segment (with the middle five elements) contains:" );
      PrintIndexAndValues( myArrSegMid );

      // Modify the fourth element of the first array segment myArrSegAll.
      myArrSegAll.Array[3] = "LION";

      // Display the contents of the second array segment myArrSegMid.
      // Note that the value of its second element also changed.
      Console.WriteLine( "After the first array segment is modified, the second array segment now contains:" );
      PrintIndexAndValues( myArrSegMid );

   }
 
   public static void PrintIndexAndValues( ArraySegment<String> arrSeg )  {
      for ( int i = arrSeg.Offset; i < (arrSeg.Offset + arrSeg.Count); i++ )  {
         Console.WriteLine( "   [{0}] : {1}", i, arrSeg.Array[i] );
      }
      Console.WriteLine();
   }

   public static void PrintIndexAndValues( String[] myArr )  {
      for ( int i = 0; i < myArr.Length; i++ )  {
         Console.WriteLine( "   [{0}] : {1}", i, myArr[i] );
      }
      Console.WriteLine();
   }

}


/* 
This code produces the following output.

The original array initially contains:
   [0] : The
   [1] : quick
   [2] : brown
   [3] : fox
   [4] : jumps
   [5] : over
   [6] : the
   [7] : lazy
   [8] : dog

The first array segment (with all the array's elements) contains:
   [0] : The
   [1] : quick
   [2] : brown
   [3] : fox
   [4] : jumps
   [5] : over
   [6] : the
   [7] : lazy
   [8] : dog

The second array segment (with the middle five elements) contains:
   [2] : brown
   [3] : fox
   [4] : jumps
   [5] : over
   [6] : the

After the first array segment is modified, the second array segment now contains:
   [2] : brown
   [3] : LION
   [4] : jumps
   [5] : over
   [6] : the

*/

// </Snippet1>
