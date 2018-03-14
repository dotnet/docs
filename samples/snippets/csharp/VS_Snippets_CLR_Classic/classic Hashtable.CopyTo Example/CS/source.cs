// <Snippet1>
 using System;
 using System.Collections;
 public class SamplesHashtable  {
 
    public static void Main()  {
 
       // Creates and initializes the source Hashtable.
       Hashtable mySourceHT = new Hashtable();
       mySourceHT.Add( "A", "valueA" );
       mySourceHT.Add( "B", "valueB" );
 
       // Creates and initializes the one-dimensional target Array.
       String[] myTargetArray = new String[15];
       myTargetArray[0] = "The";
       myTargetArray[1] = "quick";
       myTargetArray[2] = "brown";
       myTargetArray[3] = "fox";
       myTargetArray[4] = "jumped";
       myTargetArray[5] = "over";
       myTargetArray[6] = "the";
       myTargetArray[7] = "lazy";
       myTargetArray[8] = "dog";
 
       // Displays the values of the target Array.
       Console.WriteLine( "The target Array contains the following before:" );
       PrintValues( myTargetArray, ' ' );
 
       // Copies the keys in the source Hashtable to the target Hashtable, starting at index 6.
       Console.WriteLine( "After copying the keys, starting at index 6:" );
       mySourceHT.Keys.CopyTo( myTargetArray, 6 );
 
       // Displays the values of the target Array.
       PrintValues( myTargetArray, ' ' );
 
       // Copies the values in the source Hashtable to the target Hashtable, starting at index 6.
       Console.WriteLine( "After copying the values, starting at index 6:" );
       mySourceHT.Values.CopyTo( myTargetArray, 6 );
 
       // Displays the values of the target Array.
       PrintValues( myTargetArray, ' ' );
    }
 
    public static void PrintValues( String[] myArr, char mySeparator )  {
       for ( int i = 0; i < myArr.Length; i++ )
          Console.Write( "{0}{1}", mySeparator, myArr[i] );
       Console.WriteLine();
    }
 }
 /* 
 This code produces the following output.
 
 The target Array contains the following before:
  The quick brown fox jumped over the lazy dog
 After copying the keys, starting at index 6:
  The quick brown fox jumped over B A dog
 After copying the values, starting at index 6:
  The quick brown fox jumped over valueB valueA dog

 */ 
// </Snippet1>

