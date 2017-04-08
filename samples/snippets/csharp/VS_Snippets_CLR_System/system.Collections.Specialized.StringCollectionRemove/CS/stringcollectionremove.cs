// The following code example removes elements from the StringCollection.

// <snippet1>
using System;
using System.Collections;
using System.Collections.Specialized;

public class SamplesStringCollection  {

   public static void Main()  {

      // Creates and initializes a new StringCollection.
      StringCollection myCol = new StringCollection();
      String[] myArr = new String[] { "RED", "orange", "yellow", "RED", "green", "blue", "RED", "indigo", "violet", "RED" };
      myCol.AddRange( myArr );

      Console.WriteLine( "Initial contents of the StringCollection:" );
      PrintValues( myCol );

      // Removes one element from the StringCollection.
      myCol.Remove( "yellow" );

      Console.WriteLine( "After removing \"yellow\":" );
      PrintValues( myCol );

      // Removes all occurrences of a value from the StringCollection.
      int i = myCol.IndexOf( "RED" );
      while ( i > -1 )  {
         myCol.RemoveAt( i );
         i = myCol.IndexOf( "RED" );
      }

      Console.WriteLine( "After removing all occurrences of \"RED\":" );
      PrintValues( myCol );

      // Clears the entire collection.
      myCol.Clear();

      Console.WriteLine( "After clearing the collection:" );
      PrintValues( myCol );

   }

   public static void PrintValues( IEnumerable myCol )  {
      foreach ( Object obj in myCol )
         Console.WriteLine( "   {0}", obj );
      Console.WriteLine();
   }

}

/*
This code produces the following output.

Initial contents of the StringCollection:
   RED
   orange
   yellow
   RED
   green
   blue
   RED
   indigo
   violet
   RED

After removing "yellow":
   RED
   orange
   RED
   green
   blue
   RED
   indigo
   violet
   RED

After removing all occurrences of "RED":
   orange
   green
   blue
   indigo
   violet

After clearing the collection:

*/
// </snippet1>
