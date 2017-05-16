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
 
       // Displays the Stack.
       Console.Write( "Stack values:" );
       PrintValues( myStack, '\t' );
 
       // Removes an element from the Stack.
       Console.WriteLine( "(Pop)\t\t{0}", myStack.Pop() );
 
       // Displays the Stack.
       Console.Write( "Stack values:" );
       PrintValues( myStack, '\t' );
 
       // Removes another element from the Stack.
       Console.WriteLine( "(Pop)\t\t{0}", myStack.Pop() );
 
       // Displays the Stack.
       Console.Write( "Stack values:" );
       PrintValues( myStack, '\t' );
 
       // Views the first element in the Stack but does not remove it.
       Console.WriteLine( "(Peek)\t\t{0}", myStack.Peek() );
 
       // Displays the Stack.
       Console.Write( "Stack values:" );
       PrintValues( myStack, '\t' );
    }


    public static void PrintValues( IEnumerable myCollection, char mySeparator )  {
       foreach ( Object obj in myCollection )
          Console.Write( "{0}{1}", mySeparator, obj );
       Console.WriteLine();
    }

 }


 /* 
 This code produces the following output.
 
 Stack values:    fox    brown    quick    The
 (Pop)        fox
 Stack values:    brown    quick    The
 (Pop)        brown
 Stack values:    quick    The
 (Peek)        quick
 Stack values:    quick    The
 */ 

 // </Snippet1>

