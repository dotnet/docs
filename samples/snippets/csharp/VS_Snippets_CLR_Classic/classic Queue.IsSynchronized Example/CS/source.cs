// <Snippet1>
 using System;
 using System.Collections;
 public class SamplesQueue  {
 
    public static void Main()  {
 
       // Creates and initializes a new Queue.
       Queue myQ = new Queue();
       myQ.Enqueue( "The" );
       myQ.Enqueue( "quick" );
       myQ.Enqueue( "brown" );
       myQ.Enqueue( "fox" );
 
       // Creates a synchronized wrapper around the Queue.
       Queue mySyncdQ = Queue.Synchronized( myQ );
 
       // Displays the sychronization status of both Queues.
       Console.WriteLine( "myQ is {0}.", myQ.IsSynchronized ? "synchronized" : "not synchronized" );
       Console.WriteLine( "mySyncdQ is {0}.", mySyncdQ.IsSynchronized ? "synchronized" : "not synchronized" );
    }
 }
 /* 
 This code produces the following output.
 
 myQ is not synchronized.
 mySyncdQ is synchronized.
 */ 
// </Snippet1>

