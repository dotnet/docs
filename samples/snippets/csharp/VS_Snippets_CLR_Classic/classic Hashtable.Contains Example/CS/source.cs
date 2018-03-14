// <Snippet1>
 using System;
 using System.Collections;
 public class SamplesHashtable  {
 
    public static void Main()  {
 
       // Creates and initializes a new Hashtable.
       Hashtable myHT = new Hashtable();
       myHT.Add( 0, "zero" );
       myHT.Add( 1, "one" );
       myHT.Add( 2, "two" );
       myHT.Add( 3, "three" );
       myHT.Add( 4, "four" );
 
       // Displays the values of the Hashtable.
       Console.WriteLine( "The Hashtable contains the following values:" );
       PrintIndexAndKeysAndValues( myHT );
 
       // Searches for a specific key.
       int myKey = 2;
       Console.WriteLine( "The key \"{0}\" is {1}.", myKey, myHT.ContainsKey( myKey ) ? "in the Hashtable" : "NOT in the Hashtable" );
       myKey = 6;
       Console.WriteLine( "The key \"{0}\" is {1}.", myKey, myHT.ContainsKey( myKey ) ? "in the Hashtable" : "NOT in the Hashtable" );
 
       // Searches for a specific value.
       String myValue = "three";
       Console.WriteLine( "The value \"{0}\" is {1}.", myValue, myHT.ContainsValue( myValue ) ? "in the Hashtable" : "NOT in the Hashtable" );
       myValue = "nine";
       Console.WriteLine( "The value \"{0}\" is {1}.", myValue, myHT.ContainsValue( myValue ) ? "in the Hashtable" : "NOT in the Hashtable" );
    }
 
 
    public static void PrintIndexAndKeysAndValues( Hashtable myHT )  {
       int i = 0;
       Console.WriteLine( "\t-INDEX-\t-KEY-\t-VALUE-" );
       foreach ( DictionaryEntry de in myHT )
          Console.WriteLine( "\t[{0}]:\t{1}\t{2}", i++, de.Key, de.Value );
       Console.WriteLine();
    }

 }


 /* 
 This code produces the following output.
 
 The Hashtable contains the following values:
         -INDEX- -KEY-   -VALUE-
         [0]:    4       four
         [1]:    3       three
         [2]:    2       two
         [3]:    1       one
         [4]:    0       zero

 The key "2" is in the Hashtable.
 The key "6" is NOT in the Hashtable.
 The value "three" is in the Hashtable.
 The value "nine" is NOT in the Hashtable.

 */ 
// </Snippet1>

