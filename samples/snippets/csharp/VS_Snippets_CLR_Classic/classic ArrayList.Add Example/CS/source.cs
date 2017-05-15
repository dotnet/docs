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
 
       // Creates and initializes a new Queue.
       Queue myQueue = new Queue();
       myQueue.Enqueue( "jumped" );
       myQueue.Enqueue( "over" );
       myQueue.Enqueue( "the" );
       myQueue.Enqueue( "lazy" );
       myQueue.Enqueue( "dog" );
 
       // Displays the ArrayList and the Queue.
       Console.WriteLine( "The ArrayList initially contains the following:" );
       PrintValues( myAL, '\t' );
       Console.WriteLine( "The Queue initially contains the following:" );
       PrintValues( myQueue, '\t' );
 
       // Copies the Queue elements to the end of the ArrayList.
       myAL.AddRange( myQueue );
 
       // Displays the ArrayList.
       Console.WriteLine( "The ArrayList now contains the following:" );
       PrintValues( myAL, '\t' );
    }
 
    public static void PrintValues( IEnumerable myList, char mySeparator )  {
       foreach ( Object obj in myList )
          Console.Write( "{0}{1}", mySeparator, obj );
       Console.WriteLine();
    }

 }


 /* 
 This code produces the following output.
 
 The ArrayList initially contains the following:
     The    quick    brown    fox
 The Queue initially contains the following:
     jumped    over    the    lazy    dog
 The ArrayList now contains the following:
     The    quick    brown    fox    jumped    over    the    lazy    dog
 */ 
// </Snippet1>

