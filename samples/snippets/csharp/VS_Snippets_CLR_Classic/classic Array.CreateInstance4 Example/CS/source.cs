// <Snippet1>
 using System;
 public class SamplesArray  {
 
    public static void Main()  {
 
       // Creates and initializes a multidimensional Array of type String.
       int[] myLengthsArray = new int[2] { 3, 5 };
       int[] myBoundsArray = new int[2] { 2, 3 };
       Array myArray=Array.CreateInstance( typeof(String), myLengthsArray, myBoundsArray );
       for ( int i = myArray.GetLowerBound(0); i <= myArray.GetUpperBound(0); i++ )
          for ( int j = myArray.GetLowerBound(1); j <= myArray.GetUpperBound(1); j++ )  {
             int[] myIndicesArray = new int[2] { i, j };
             myArray.SetValue( Convert.ToString(i) + j, myIndicesArray );
          }
 
       // Displays the lower bounds and the upper bounds of each dimension.
       Console.WriteLine( "Bounds:\tLower\tUpper" );
       for ( int i = 0; i < myArray.Rank; i++ )
          Console.WriteLine( "{0}:\t{1}\t{2}", i, myArray.GetLowerBound(i), myArray.GetUpperBound(i) );
 
       // Displays the values of the Array.
       Console.WriteLine( "The Array contains the following values:" );
       PrintValues( myArray );
    }
 
 
    public static void PrintValues( Array myArr )  {
       System.Collections.IEnumerator myEnumerator = myArr.GetEnumerator();
       int i = 0;
       int cols = myArr.GetLength( myArr.Rank - 1 );
       while ( myEnumerator.MoveNext() )  {
          if ( i < cols )  {
             i++;
          } else  {
             Console.WriteLine();
             i = 1;
          }
          Console.Write( "\t{0}", myEnumerator.Current );
       }
       Console.WriteLine();
    }
 }
 /* 
 This code produces the following output.
 
 Bounds:    Lower    Upper
 0:    2    4
 1:    3    7
 The Array contains the following values:
     23    24    25    26    27
     33    34    35    36    37
     43    44    45    46    47
 */
// </Snippet1>

