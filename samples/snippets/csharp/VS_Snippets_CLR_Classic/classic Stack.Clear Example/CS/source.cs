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
       myStack.Push( "jumped" );
 
       // Displays the count and values of the Stack.
       Console.WriteLine( "Initially," );
       Console.WriteLine( "   Count    : {0}", myStack.Count );
       Console.Write( "   Values:" );
       PrintValues( myStack );
 
       // Clears the Stack.
       myStack.Clear();
 
       // Displays the count and values of the Stack.
       Console.WriteLine( "After Clear," );
       Console.WriteLine( "   Count    : {0}", myStack.Count );
       Console.Write( "   Values:" );
       PrintValues( myStack );

    }

    public static void PrintValues( IEnumerable myCollection )  {
       foreach ( Object obj in myCollection )
          Console.Write( "    {0}", obj );
       Console.WriteLine();
    }

 }


 /* 
 This code produces the following output.
 
 Initially,
    Count    : 5
    Values:    jumped    fox    brown    quick    The
 After Clear,
    Count    : 0
    Values:
 */ 

 // </Snippet1>
