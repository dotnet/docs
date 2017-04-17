// The following code example adds new elements to the StringCollection.

// <snippet1>
using System;
using System.Collections;
using System.Collections.Specialized;

public class SamplesStringCollection  {

   public static void Main()  {

      // Creates and initializes a new StringCollection.
      StringCollection myCol = new StringCollection();

      Console.WriteLine( "Initial contents of the StringCollection:" );
      PrintValues( myCol );

      // Adds a range of elements from an array to the end of the StringCollection.
      String[] myArr = new String[] { "RED", "orange", "yellow", "RED", "green", "blue", "RED", "indigo", "violet", "RED" };
      myCol.AddRange( myArr );

      Console.WriteLine( "After adding a range of elements:" );
      PrintValues( myCol );

      // Adds one element to the end of the StringCollection and inserts another at index 3.
      myCol.Add( "* white" );
      myCol.Insert( 3, "* gray" );

      Console.WriteLine( "After adding \"* white\" to the end and inserting \"* gray\" at index 3:" );
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

After adding a range of elements:
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

After adding "* white" to the end and inserting "* gray" at index 3:
   RED
   orange
   yellow
   * gray
   RED
   green
   blue
   RED
   indigo
   violet
   RED
   * white

*/
// </snippet1>
