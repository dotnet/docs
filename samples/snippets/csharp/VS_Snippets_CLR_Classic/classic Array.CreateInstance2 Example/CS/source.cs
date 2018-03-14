// <Snippet1>
 using System;
 public class SamplesArray  {
 
    public static void Main()  {
 
       // Creates and initializes a three-dimensional Array of type Object.
       Array my3DArray=Array.CreateInstance( typeof(Object), 2, 3, 4 );
       for ( int i = my3DArray.GetLowerBound(0); i <= my3DArray.GetUpperBound(0); i++ )
          for ( int j = my3DArray.GetLowerBound(1); j <= my3DArray.GetUpperBound(1); j++ )
             for ( int k = my3DArray.GetLowerBound(2); k <= my3DArray.GetUpperBound(2); k++ )
                my3DArray.SetValue( "abc" + i + j + k, i, j, k );
 
       // Displays the values of the Array.
       Console.WriteLine( "The three-dimensional Array contains the following values:" );
       PrintValues( my3DArray );
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
 
 The three-dimensional Array contains the following values:
     abc000    abc001    abc002    abc003
     abc010    abc011    abc012    abc013
     abc020    abc021    abc022    abc023
     abc100    abc101    abc102    abc103
     abc110    abc111    abc112    abc113
     abc120    abc121    abc122    abc123
 */
// </Snippet1>

