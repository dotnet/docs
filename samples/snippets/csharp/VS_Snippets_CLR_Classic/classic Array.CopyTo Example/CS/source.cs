// <Snippet1>
 using System;
 public class SamplesArray  {
 
    public static void Main()  {
 
       // Creates and initializes two new Arrays.
       Array mySourceArray=Array.CreateInstance( typeof(String), 6 );
       mySourceArray.SetValue( "three", 0 );
       mySourceArray.SetValue( "napping", 1 );
       mySourceArray.SetValue( "cats", 2 );
       mySourceArray.SetValue( "in", 3 );
       mySourceArray.SetValue( "the", 4 );
       mySourceArray.SetValue( "barn", 5 );
       Array myTargetArray=Array.CreateInstance( typeof(String), 15 );
       myTargetArray.SetValue( "The", 0 );
       myTargetArray.SetValue( "quick", 1 );
       myTargetArray.SetValue( "brown", 2 );
       myTargetArray.SetValue( "fox", 3 );
       myTargetArray.SetValue( "jumps", 4 );
       myTargetArray.SetValue( "over", 5 );
       myTargetArray.SetValue( "the", 6 );
       myTargetArray.SetValue( "lazy", 7 );
       myTargetArray.SetValue( "dog", 8 );
 
       // Displays the values of the Array.
       Console.WriteLine( "The target Array contains the following (before and after copying):" );
       PrintValues( myTargetArray, ' ' );
 
       // Copies the source Array to the target Array, starting at index 6.
       mySourceArray.CopyTo( myTargetArray, 6 );
 
       // Displays the values of the Array.
       PrintValues( myTargetArray, ' ' );
    }
 
 
    public static void PrintValues( Array myArr, char mySeparator )  {
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
          Console.Write( "{0}{1}", mySeparator, myEnumerator.Current );
       }
       Console.WriteLine();
    }
 }
 /*
 This code produces the following output.
 
  The target Array contains the following (before and after copying):
  The quick brown fox jumps over the lazy dog      
  The quick brown fox jumps over three napping cats in the barn
 */
// </Snippet1>
// <Snippet2>
 public class SamplesArray2{
 
    public static void Main()  {
       // Creates and initializes the source Array.
       Array myArrayZero=Array.CreateInstance( typeof(String), 3 );
       myArrayZero.SetValue( "zero", 0 );
       myArrayZero.SetValue( "one", 1 );
 
       // Displays the source Array.
       Console.WriteLine( "The array with lower bound=0 contains:" );
       PrintIndexAndValues( myArrayZero );
 
       // Creates and initializes the target Array.
       int[] myArrLen = { 4 };
       int[] myArrLow = { 2 };
       Array myArrayTwo=Array.CreateInstance( typeof(String), myArrLen, myArrLow );
       myArrayTwo.SetValue( "two", 2 );
       myArrayTwo.SetValue( "three", 3 );
       myArrayTwo.SetValue( "four", 4 );
       myArrayTwo.SetValue( "five", 5 );
 
       // Displays the target Array.
       Console.WriteLine( "The array with lower bound=2 contains:" );
       PrintIndexAndValues( myArrayTwo );
 
       // Copies from the array with lower bound=0 to the array with lower bound=2.
       myArrayZero.CopyTo( myArrayTwo, 3 );
 
       // Displays the modified target Array.
       Console.WriteLine( "\nAfter copying to the target array from index 3:" );
       PrintIndexAndValues( myArrayTwo );
    }
 
 
    public static void PrintIndexAndValues( Array myArray )  {
       for ( int i = myArray.GetLowerBound(0); i <= myArray.GetUpperBound(0); i++ )
          Console.WriteLine( "\t[{0}]:\t{1}", i, myArray.GetValue( i ) );
    }
 }
 /* 
 This code produces the following output.
 
 The array with lower bound=0 contains:
     [0]:    zero
     [1]:    one
     [2]:    
 The array with lower bound=2 contains:
     [2]:    two
     [3]:    three
     [4]:    four
     [5]:    five
 
 After copying to the target array from index 3:
     [2]:    two
     [3]:    zero
     [4]:    one
     [5]:
 */
// </Snippet2>

