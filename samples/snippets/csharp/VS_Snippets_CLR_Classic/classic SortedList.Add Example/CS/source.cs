// <Snippet1>
 using System;
 using System.Collections;
 public class SamplesSortedList  {
 
    public static void Main()  {
 
       // Creates and initializes a new SortedList.
       SortedList mySL = new SortedList();
       mySL.Add( "one", "The" );
       mySL.Add( "two", "quick" );
       mySL.Add( "three", "brown" );
       mySL.Add( "four", "fox" );
 
       // Displays the SortedList.
       Console.WriteLine( "The SortedList contains the following:" );
       PrintKeysAndValues( mySL );
    }
 
 
    public static void PrintKeysAndValues( SortedList myList )  {
       Console.WriteLine( "\t-KEY-\t-VALUE-" );
       for ( int i = 0; i < myList.Count; i++ )  {
          Console.WriteLine( "\t{0}:\t{1}", myList.GetKey(i), myList.GetByIndex(i) );
       }
       Console.WriteLine();
    }
 }
 /* 
 This code produces the following output.
 
 The SortedList contains the following:
     -KEY-    -VALUE-
     four:    fox
     one:    The
     three:    brown
     two:    quick
 */
 // </Snippet1>

