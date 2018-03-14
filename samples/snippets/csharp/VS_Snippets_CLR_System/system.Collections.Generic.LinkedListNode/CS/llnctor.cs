// The following code example creates a LinkedList node, adds it to a LinkedList, and tracks the values of its properties as the LinkedList changes.


// <snippet1>
using System;
using System.Collections.Generic;

public class GenericCollection  {

   public static void Main()  {

      // Create a new LinkedListNode of type String and displays its properties.
      LinkedListNode<String> lln = new LinkedListNode<String>( "orange" );
      Console.WriteLine( "After creating the node ...." );
      DisplayProperties( lln );

      // Create a new LinkedList.
      LinkedList<String> ll = new LinkedList<String>();

      // Add the "orange" node and display its properties.
      ll.AddLast( lln );
      Console.WriteLine( "After adding the node to the empty LinkedList ...." );
      DisplayProperties( lln );

      // Add nodes before and after the "orange" node and display the "orange" node's properties.
      ll.AddFirst( "red" );
      ll.AddLast( "yellow" );
      Console.WriteLine( "After adding red and yellow ...." );
      DisplayProperties( lln );

   }

   public static void DisplayProperties( LinkedListNode<String> lln )  {
      if ( lln.List == null )
         Console.WriteLine( "   Node is not linked." );
      else
         Console.WriteLine( "   Node belongs to a linked list with {0} elements.", lln.List.Count );

      if ( lln.Previous == null )
         Console.WriteLine( "   Previous node is null." );
      else
         Console.WriteLine( "   Value of previous node: {0}", lln.Previous.Value );

      Console.WriteLine( "   Value of current node:  {0}", lln.Value );

      if ( lln.Next == null )
         Console.WriteLine( "   Next node is null." );
      else
         Console.WriteLine( "   Value of next node:     {0}", lln.Next.Value );

      Console.WriteLine();
   }

}


/*

This code produces the following output.

After creating the node ....
   Node is not linked.
   Previous node is null.
   Value of current node:  orange
   Next node is null.

After adding the node to the empty LinkedList ....
   Node belongs to a linked list with 1 elements.
   Previous node is null.
   Value of current node:  orange
   Next node is null.

After adding red and yellow ....
   Node belongs to a linked list with 3 elements.
   Value of previous node: red
   Value of current node:  orange
   Value of next node:     yellow

*/
// </snippet1>
