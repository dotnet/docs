// <Snippet1>
 using System;
 using System.Collections;
 public class SamplesStack  {
 
    public static void Main()  {
 
       // Creates and initializes a new Stack.
       Stack myStack = new Stack();
       myStack.Push("Hello");
       myStack.Push("World");
       myStack.Push("!");
 
       // Displays the properties and values of the Stack.
       Console.WriteLine( "myStack" );
       Console.WriteLine( "\tCount:    {0}", myStack.Count );
       Console.Write( "\tValues:" );
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
 
 myStack
     Count:    3
     Values:    !    World    Hello
 */ 

// </Snippet1>

