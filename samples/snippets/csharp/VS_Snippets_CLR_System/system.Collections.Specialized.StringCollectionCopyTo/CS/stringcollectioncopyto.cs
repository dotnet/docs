// The following code example copies a StringCollection to an array.

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

      // Copies the collection to a new array starting at index 0.
      String[] myArr2 = new String[myCol.Count];
      myCol.CopyTo( myArr2, 0 );

      Console.WriteLine( "The new array contains:" );
      for ( int i = 0; i < myArr2.Length; i++ )  {
         Console.WriteLine( "   [{0}] {1}", i, myArr2[i] );
      }
      Console.WriteLine();

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

The new array contains:
   [0] RED
   [1] orange
   [2] yellow
   [3] RED
   [4] green
   [5] blue
   [6] RED
   [7] indigo
   [8] violet
   [9] RED

*/
// </snippet1>
