// <Snippet1>
using System;
 using System.Collections;
 public class SamplesStack  {
 
    public static void Main()  {
 
       // Creates and initializes a new Stack.
       Stack myStack = new Stack();
       myStack.Push( "The" );
       myStack.Push( "quick" );
       myStack.Push( "brown" );
       myStack.Push( "fox" );
 
       // Creates a synchronized wrapper around the Stack.
       Stack mySyncdStack = Stack.Synchronized( myStack );
 
       // Displays the sychronization status of both Stacks.
       Console.WriteLine( "myStack is {0}.",
          myStack.IsSynchronized ? "synchronized" : "not synchronized" );
       Console.WriteLine( "mySyncdStack is {0}.",
          mySyncdStack.IsSynchronized ? "synchronized" : "not synchronized" );
    }
 }
 /* 
 This code produces the following output.
 
 myStack is not synchronized.
 mySyncdStack is synchronized.
 */ 
// </Snippet1>

