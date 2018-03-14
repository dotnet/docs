// <Snippet1>
 using System;
 using System.Collections;
 
 public class SamplesSortedList  {
 
    public static void Main()  {
 
       // Creates and initializes a new SortedList.
       SortedList mySL = new SortedList();
       mySL.Add( 2, "two" );
       mySL.Add( 4, "four" );
       mySL.Add( 1, "one" );
       mySL.Add( 3, "three" );
       mySL.Add( 0, "zero" );
 
       // Displays the values of the SortedList.
       Console.WriteLine( "The SortedList contains the following values:" );
       PrintIndexAndKeysAndValues( mySL );
 
       // Searches for a specific key.
       int myKey = 2;
       Console.WriteLine( "The key \"{0}\" is {1}.", myKey, mySL.ContainsKey( myKey ) ? "in the SortedList" : "NOT in the SortedList" );
       myKey = 6;
       Console.WriteLine( "The key \"{0}\" is {1}.", myKey, mySL.ContainsKey( myKey ) ? "in the SortedList" : "NOT in the SortedList" );
 
       // Searches for a specific value.
       String myValue = "three";
       Console.WriteLine( "The value \"{0}\" is {1}.", myValue, mySL.ContainsValue( myValue ) ? "in the SortedList" : "NOT in the SortedList" );
       myValue = "nine";
       Console.WriteLine( "The value \"{0}\" is {1}.", myValue, mySL.ContainsValue( myValue ) ? "in the SortedList" : "NOT in the SortedList" );
    }
 
 
    public static void PrintIndexAndKeysAndValues( SortedList myList )  {
       Console.WriteLine( "\t-INDEX-\t-KEY-\t-VALUE-" );
       for ( int i = 0; i < myList.Count; i++ )  {
          Console.WriteLine( "\t[{0}]:\t{1}\t{2}", i, myList.GetKey(i), myList.GetByIndex(i) );
       }
       Console.WriteLine();
    }
 }
 /* 
 This code produces the following output.
 
 The SortedList contains the following values:
     -INDEX-    -KEY-    -VALUE-
     [0]:    0    zero
     [1]:    1    one
     [2]:    2    two
     [3]:    3    three
     [4]:    4    four
 
 The key "2" is in the SortedList.
 The key "6" is NOT in the SortedList.
 The value "three" is in the SortedList.
 The value "nine" is NOT in the SortedList.
 */ 
 // </Snippet1>

