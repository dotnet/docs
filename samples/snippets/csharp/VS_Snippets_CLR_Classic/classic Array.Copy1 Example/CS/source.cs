// <Snippet1>
 using System;
 public class SamplesArray  {
 
    public static void Main()  {
 
       // Creates and initializes a new Array of type Int32.
       Array myIntArray=Array.CreateInstance( typeof(System.Int32), 5 );
       for ( int i = myIntArray.GetLowerBound(0); i <= myIntArray.GetUpperBound(0); i++ )
          myIntArray.SetValue( i+1, i );
 
       // Creates and initializes a new Array of type Object.
       Array myObjArray = Array.CreateInstance( typeof(System.Object), 5 );
       for ( int i = myObjArray.GetLowerBound(0); i <= myObjArray.GetUpperBound(0); i++ )
          myObjArray.SetValue( i+26, i );
 
       // Displays the initial values of both arrays.
       Console.WriteLine( "Int32 array:" );
       PrintValues( myIntArray );
       Console.WriteLine( "Object array:" );
       PrintValues( myObjArray );
 
       // Copies the first element from the Int32 array to the Object array.
       Array.Copy( myIntArray, myIntArray.GetLowerBound(0), myObjArray, myObjArray.GetLowerBound(0), 1 );
 
       // Copies the last two elements from the Object array to the Int32 array.
       Array.Copy( myObjArray, myObjArray.GetUpperBound(0) - 1, myIntArray, myIntArray.GetUpperBound(0) - 1, 2 );
 
       // Displays the values of the modified arrays.
       Console.WriteLine( "Int32 array - Last two elements should now be the same as Object array:" );
       PrintValues( myIntArray );
       Console.WriteLine( "Object array - First element should now be the same as Int32 array:" );
       PrintValues( myObjArray );
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
 
 Int32 array:
     1    2    3    4    5
 Object array:
     26    27    28    29    30
 Int32 array - Last two elements should now be the same as Object array:
     1    2    3    29    30
 Object array - First element should now be the same as Int32 array:
     1    27    28    29    30
 */
// </Snippet1>

