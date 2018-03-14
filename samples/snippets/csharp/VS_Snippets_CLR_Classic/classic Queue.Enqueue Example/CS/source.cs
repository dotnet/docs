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
 
       // Displays the Queue.
       Console.Write( "Queue values:" );
       PrintValues( myQ );
 
       // Removes an element from the Queue.
       Console.WriteLine( "(Dequeue)\t{0}", myQ.Dequeue() );
 
       // Displays the Queue.
       Console.Write( "Queue values:" );
       PrintValues( myQ );
 
       // Removes another element from the Queue.
       Console.WriteLine( "(Dequeue)\t{0}", myQ.Dequeue() );
 
       // Displays the Queue.
       Console.Write( "Queue values:" );
       PrintValues( myQ );
 
       // Views the first element in the Queue but does not remove it.
       Console.WriteLine( "(Peek)   \t{0}", myQ.Peek() );
 
       // Displays the Queue.
       Console.Write( "Queue values:" );
       PrintValues( myQ );
    }
 
    public static void PrintValues( IEnumerable myCollection )  {
       foreach ( Object obj in myCollection )
          Console.Write( "    {0}", obj );
       Console.WriteLine();
    }
 }
 /* 
 This code produces the following output.
 
 Queue values:    The    quick    brown    fox
 (Dequeue)       The
 Queue values:    quick    brown    fox
 (Dequeue)       quick
 Queue values:    brown    fox
 (Peek)          brown
 Queue values:    brown    fox

 */ 
// </Snippet1>

