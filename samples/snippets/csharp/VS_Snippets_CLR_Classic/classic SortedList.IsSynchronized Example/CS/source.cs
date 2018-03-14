// <Snippet1>
 using System;
 using System.Collections;
 public class SamplesSortedList  {
 
    public static void Main()  {
 
       // Creates and initializes a new SortedList.
       SortedList mySL = new SortedList();
       mySL.Add( 2, "two" );
       mySL.Add( 3, "three" );
       mySL.Add( 1, "one" );
       mySL.Add( 0, "zero" );
       mySL.Add( 4, "four" );
 
       // Creates a synchronized wrapper around the SortedList.
       SortedList mySyncdSL = SortedList.Synchronized( mySL );
 
       // Displays the sychronization status of both SortedLists.
       Console.WriteLine( "mySL is {0}.", mySL.IsSynchronized ? "synchronized" : "not synchronized" );
       Console.WriteLine( "mySyncdSL is {0}.", mySyncdSL.IsSynchronized ? "synchronized" : "not synchronized" );
    }
 }
 /* 
 This code produces the following output.
 
 mySL is not synchronized.
 mySyncdSL is synchronized.
 */ 
 // </Snippet1>

