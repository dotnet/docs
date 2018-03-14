// The following code example enumerates the elements of a StringDictionary.

// <snippet1>
using System;
using System.Collections;
using System.Collections.Specialized;

public class SamplesStringDictionary  {

   public static void Main()  {

      // Creates and initializes a new StringDictionary.
      StringDictionary myCol = new StringDictionary();
      myCol.Add( "red", "rojo" );
      myCol.Add( "green", "verde" );
      myCol.Add( "blue", "azul" );

      // Display the contents of the collection using foreach. This is the preferred method.
      Console.WriteLine( "Displays the elements using foreach:" );
      PrintKeysAndValues1( myCol );

      // Display the contents of the collection using the enumerator.
      Console.WriteLine( "Displays the elements using the IEnumerator:" );
      PrintKeysAndValues2( myCol );

      // Display the contents of the collection using the Keys, Values, Count, and Item properties.
      Console.WriteLine( "Displays the elements using the Keys, Values, Count, and Item properties:" );
      PrintKeysAndValues3( myCol );

   }

   // Uses the foreach statement which hides the complexity of the enumerator.
   // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
   public static void PrintKeysAndValues1( StringDictionary myCol )  {
      Console.WriteLine( "   KEY                       VALUE" );
      foreach ( DictionaryEntry de in myCol )
         Console.WriteLine( "   {0,-25} {1}", de.Key, de.Value );
      Console.WriteLine();
   }

   // Uses the enumerator. 
   // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
   public static void PrintKeysAndValues2( StringDictionary myCol )  {
      IEnumerator myEnumerator = myCol.GetEnumerator();
      DictionaryEntry de;
      Console.WriteLine( "   KEY                       VALUE" );
      while ( myEnumerator.MoveNext() )  {
         de = (DictionaryEntry) myEnumerator.Current;
         Console.WriteLine( "   {0,-25} {1}", de.Key, de.Value );
      }
      Console.WriteLine();
   }

   // Uses the Keys, Values, Count, and Item properties.
   public static void PrintKeysAndValues3( StringDictionary myCol )  {
      String[] myKeys = new String[myCol.Count];
      myCol.Keys.CopyTo( myKeys, 0 );

      Console.WriteLine( "   INDEX KEY                       VALUE" );
      for ( int i = 0; i < myCol.Count; i++ )
         Console.WriteLine( "   {0,-5} {1,-25} {2}", i, myKeys[i], myCol[myKeys[i]] );
      Console.WriteLine();
   }

}

/*
This code produces the following output.

Displays the elements using foreach:
   KEY                       VALUE
   red                       rojo
   blue                      azul
   green                     verde

Displays the elements using the IEnumerator:
   KEY                       VALUE
   red                       rojo
   blue                      azul
   green                     verde

Displays the elements using the Keys, Values, Count, and Item properties:
   INDEX KEY                       VALUE
   0     red                       rojo
   1     blue                      azul
   2     green                     verde

*/
// </snippet1>
