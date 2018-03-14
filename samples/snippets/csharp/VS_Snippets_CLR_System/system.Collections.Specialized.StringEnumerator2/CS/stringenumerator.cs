// The following code example demonstrates several of the properties and methods of StringEnumerator.

// <snippet1>
using System;
using System.Collections.Specialized;

public class SamplesStringEnumerator  {

   public static void Main()  {

      // Creates and initializes a StringCollection.
      StringCollection myCol = new StringCollection();
      String[] myArr = new String[] { "red", "orange", "yellow", "green", "blue", "indigo", "violet" };
      myCol.AddRange( myArr );

      // Enumerates the elements in the StringCollection.
      StringEnumerator myEnumerator = myCol.GetEnumerator();
      while ( myEnumerator.MoveNext() )
         Console.WriteLine( "{0}", myEnumerator.Current );
      Console.WriteLine();

      // Resets the enumerator and displays the first element again.
      myEnumerator.Reset();
      if ( myEnumerator.MoveNext() )
         Console.WriteLine( "The first element is {0}.", myEnumerator.Current );

   }

}

/*
This code produces the following output.

red
orange
yellow
green
blue
indigo
violet

The first element is red.

*/
// </snippet1>
