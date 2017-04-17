// <Snippet1>
 using System;
 using System.Collections;
 public class SamplesArrayList  {
 
    public static void Main()  {
 
       // Creates and initializes a new ArrayList.
       ArrayList myAL = new ArrayList();
       myAL.Add( "The" );
       myAL.Add( "quick" );
       myAL.Add( "brown" );
       myAL.Add( "fox" );
 
       // Creates a synchronized wrapper around the ArrayList.
       ArrayList mySyncdAL = ArrayList.Synchronized( myAL );
 
       // Displays the sychronization status of both ArrayLists.
       Console.WriteLine( "myAL is {0}.", myAL.IsSynchronized ? "synchronized" : "not synchronized" );
       Console.WriteLine( "mySyncdAL is {0}.", mySyncdAL.IsSynchronized ? "synchronized" : "not synchronized" );
    }
 }
 /* 
 This code produces the following output.
 
 myAL is not synchronized.
 mySyncdAL is synchronized.
 */ 
// </Snippet1>

