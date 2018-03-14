// The following code example demonstrates several of the properties and methods of StringCollection.

// <snippet1>
using System;
using System.Collections;
using System.Collections.Specialized;

public class SamplesStringCollection  {

   public static void Main()  {

      // Create and initializes a new StringCollection.
      StringCollection myCol = new StringCollection();

      // Add a range of elements from an array to the end of the StringCollection.
      String[] myArr = new String[] { "RED", "orange", "yellow", "RED", "green", "blue", "RED", "indigo", "violet", "RED" };
      myCol.AddRange( myArr );

      // Display the contents of the collection using foreach. This is the preferred method.
      Console.WriteLine( "Displays the elements using foreach:" );
      PrintValues1( myCol );

      // Display the contents of the collection using the enumerator.
      Console.WriteLine( "Displays the elements using the IEnumerator:" );
      PrintValues2( myCol );

      // Display the contents of the collection using the Count and Item properties.
      Console.WriteLine( "Displays the elements using the Count and Item properties:" );
      PrintValues3( myCol );

      // Add one element to the end of the StringCollection and insert another at index 3.
      myCol.Add( "* white" );
      myCol.Insert( 3, "* gray" );

      Console.WriteLine( "After adding \"* white\" to the end and inserting \"* gray\" at index 3:" );
      PrintValues1( myCol );

      // Remove one element from the StringCollection.
      myCol.Remove( "yellow" );

      Console.WriteLine( "After removing \"yellow\":" );
      PrintValues1( myCol );

      // Remove all occurrences of a value from the StringCollection.
      int i = myCol.IndexOf( "RED" );
      while ( i > -1 )  {
         myCol.RemoveAt( i );
         i = myCol.IndexOf( "RED" );
      }

      // Verify that all occurrences of "RED" are gone.
      if ( myCol.Contains( "RED" ) )
         Console.WriteLine( "*** The collection still contains \"RED\"." );

      Console.WriteLine( "After removing all occurrences of \"RED\":" );
      PrintValues1( myCol );

      // Copy the collection to a new array starting at index 0.
      String[] myArr2 = new String[myCol.Count];
      myCol.CopyTo( myArr2, 0 );

      Console.WriteLine( "The new array contains:" );
      for ( i = 0; i < myArr2.Length; i++ )  {
         Console.WriteLine( "   [{0}] {1}", i, myArr2[i] );
      }
      Console.WriteLine();

      // Clears the entire collection.
      myCol.Clear();

      Console.WriteLine( "After clearing the collection:" );
      PrintValues1( myCol );

   }

   // Uses the foreach statement which hides the complexity of the enumerator.
   // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
   public static void PrintValues1( StringCollection myCol )  {
      foreach ( Object obj in myCol )
         Console.WriteLine( "   {0}", obj );
      Console.WriteLine();
   }

   // Uses the enumerator. 
   // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
   public static void PrintValues2( StringCollection myCol )  {
      StringEnumerator myEnumerator = myCol.GetEnumerator();
      while ( myEnumerator.MoveNext() )
         Console.WriteLine( "   {0}", myEnumerator.Current );
      Console.WriteLine();
   }

   // Uses the Count and Item properties.
   public static void PrintValues3( StringCollection myCol )  {
      for ( int i = 0; i < myCol.Count; i++ )
         Console.WriteLine( "   {0}", myCol[i] );
      Console.WriteLine();
   }

}

/*
This code produces the following output.

Displays the elements using foreach:
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

Displays the elements using the IEnumerator:
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

Displays the elements using the Count and Item properties:
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

After removing "yellow":
   RED
   orange
   * gray
   RED
   green
   blue
   RED
   indigo
   violet
   RED
   * white

After removing all occurrences of "RED":
   orange
   * gray
   green
   blue
   indigo
   violet
   * white

The new array contains:
   [0] orange
   [1] * gray
   [2] green
   [3] blue
   [4] indigo
   [5] violet
   [6] * white

After clearing the collection:

*/
// </snippet1>
