// The following code example searches the StringCollection for an element.

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

      // Checks whether the collection contains "orange" and, if so, displays its index.
      if ( myCol.Contains( "orange" ) )
         Console.WriteLine( "The collection contains \"orange\" at index {0}.", myCol.IndexOf( "orange" ) );
      else
         Console.WriteLine( "The collection does not contain \"orange\"." );

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

The collection contains "orange" at index 1.

*/
// </snippet1>
