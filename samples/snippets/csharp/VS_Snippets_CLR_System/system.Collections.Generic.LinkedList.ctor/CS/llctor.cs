// The following code example creates and initializes a LinkedList of type String and then displays its contents.


// <snippet1>
using System;
using System.Collections;
using System.Collections.Generic;

public class GenericCollection  
{
   public static void Main()  
   {
      // Create and initialize a new LinkedList.
      LinkedList<String> ll = new LinkedList<String>();
      ll.AddLast( "red" );
      ll.AddLast( "orange" );
      ll.AddLast( "yellow" );
      ll.AddLast( "orange" );

      // Display the contents of the LinkedList.
      if ( ll.Count > 0 )  
      {
         Console.WriteLine( "The item in the list is {0}.", ll.First.Value );
         Console.WriteLine( "The item in the list is {0}.", ll.Last.Value );

         Console.WriteLine( "The LinkedList contains:" );
         foreach ( String s in ll )
            Console.WriteLine( "   {0}", s);
      }
      else  
      {
         Console.WriteLine("The LinkedList is empty.");
      }
   }
}

/* This code produces the following output.

The first item in the list is red.
The last item in the list is orange.
The LinkedList contains:
   red
   orange
   yellow
   orange
*/
// </snippet1>
