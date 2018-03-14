// <Snippet1>
 using System;
 public class SamplesArray  {
 
    public static void Main()  {
 
       // Creates and initializes a two-dimensional Array of type String.
       Array my2DArray=Array.CreateInstance( typeof(String), 2, 3 );
       for ( int i = my2DArray.GetLowerBound(0); i <= my2DArray.GetUpperBound(0); i++ )
          for ( int j = my2DArray.GetLowerBound(1); j <= my2DArray.GetUpperBound(1); j++ )
             my2DArray.SetValue( "abc" + i + j, i, j );
 
       // Displays the values of the Array.
       Console.WriteLine( "The two-dimensional Array contains the following values:" );
       PrintValues( my2DArray );
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
 
 The two-dimensional Array contains the following values:
     abc00    abc01    abc02
     abc10    abc11    abc12
 */
// </Snippet1>

