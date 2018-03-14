// The following code example demonstrates several of the properties and methods of ListDictionary.

// <snippet1>
using System;
using System.Collections;
using System.Collections.Specialized;

public class SamplesListDictionary  {

   public static void Main()  {

      // Creates and initializes a new ListDictionary.
      ListDictionary myCol = new ListDictionary();
      myCol.Add( "Braeburn Apples", "1.49" );
      myCol.Add( "Fuji Apples", "1.29" );
      myCol.Add( "Gala Apples", "1.49" );
      myCol.Add( "Golden Delicious Apples", "1.29" );
      myCol.Add( "Granny Smith Apples", "0.89" );
      myCol.Add( "Red Delicious Apples", "0.99" );

      // Display the contents of the collection using foreach. This is the preferred method.
      Console.WriteLine( "Displays the elements using foreach:" );
      PrintKeysAndValues1( myCol );

      // Display the contents of the collection using the enumerator.
      Console.WriteLine( "Displays the elements using the IDictionaryEnumerator:" );
      PrintKeysAndValues2( myCol );

      // Display the contents of the collection using the Keys, Values, Count, and Item properties.
      Console.WriteLine( "Displays the elements using the Keys, Values, Count, and Item properties:" );
      PrintKeysAndValues3( myCol );

      // Copies the ListDictionary to an array with DictionaryEntry elements.
      DictionaryEntry[] myArr = new DictionaryEntry[myCol.Count];
      myCol.CopyTo( myArr, 0 );

      // Displays the values in the array.
      Console.WriteLine( "Displays the elements in the array:" );
      Console.WriteLine( "   KEY                       VALUE" );
      for ( int i = 0; i < myArr.Length; i++ )
         Console.WriteLine( "   {0,-25} {1}", myArr[i].Key, myArr[i].Value );
      Console.WriteLine();

      // Searches for a key.
      if ( myCol.Contains( "Kiwis" ) )
         Console.WriteLine( "The collection contains the key \"Kiwis\"." );
      else
         Console.WriteLine( "The collection does not contain the key \"Kiwis\"." );
      Console.WriteLine();

      // Deletes a key.
      myCol.Remove( "Plums" );
      Console.WriteLine( "The collection contains the following elements after removing \"Plums\":" );
      PrintKeysAndValues1( myCol );

      // Clears the entire collection.
      myCol.Clear();
      Console.WriteLine( "The collection contains the following elements after it is cleared:" );
      PrintKeysAndValues1( myCol );

   }

   // Uses the foreach statement which hides the complexity of the enumerator.
   // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
   public static void PrintKeysAndValues1( IDictionary myCol )  {
      Console.WriteLine( "   KEY                       VALUE" );
      foreach ( DictionaryEntry de in myCol )
         Console.WriteLine( "   {0,-25} {1}", de.Key, de.Value );
      Console.WriteLine();
   }

   // Uses the enumerator. 
   // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
   public static void PrintKeysAndValues2( IDictionary myCol )  {
      IDictionaryEnumerator myEnumerator = myCol.GetEnumerator();
      Console.WriteLine( "   KEY                       VALUE" );
      while ( myEnumerator.MoveNext() )
         Console.WriteLine( "   {0,-25} {1}", myEnumerator.Key, myEnumerator.Value );
      Console.WriteLine();
   }

   // Uses the Keys, Values, Count, and Item properties.
   public static void PrintKeysAndValues3( ListDictionary myCol )  {
      String[] myKeys = new String[myCol.Count];
      myCol.Keys.CopyTo( myKeys, 0 );

      Console.WriteLine( "   INDEX KEY                       VALUE" );
      for ( int i = 0; i < myCol.Count; i++ )
         Console.WriteLine( "   {0,-5} {1,-25} {2}", i, myKeys[i], myCol[myKeys[i]] );
      Console.WriteLine();
   }

}

/*
This code produces output similar to the following.
Note that because a dictionary is implemented for fast keyed access the order
of the items in the dictionary are not gauranteed and, as a result, should not
be depended on.

Displays the elements using foreach:
   KEY                       VALUE
   Braeburn Apples           1.49
   Fuji Apples               1.29
   Gala Apples               1.49
   Golden Delicious Apples   1.29
   Granny Smith Apples       0.89
   Red Delicious Apples      0.99

Displays the elements using the IDictionaryEnumerator:
   KEY                       VALUE
   Braeburn Apples           1.49
   Fuji Apples               1.29
   Gala Apples               1.49
   Golden Delicious Apples   1.29
   Granny Smith Apples       0.89
   Red Delicious Apples      0.99

Displays the elements using the Keys, Values, Count, and Item properties:
   INDEX KEY                       VALUE
   0     Braeburn Apples           1.49
   1     Fuji Apples               1.29
   2     Gala Apples               1.49
   3     Golden Delicious Apples   1.29
   4     Granny Smith Apples       0.89
   5     Red Delicious Apples      0.99

Displays the elements in the array:
   KEY                       VALUE
   Braeburn Apples           1.49
   Fuji Apples               1.29
   Gala Apples               1.49
   Golden Delicious Apples   1.29
   Granny Smith Apples       0.89
   Red Delicious Apples      0.99

The collection does not contain the key "Kiwis".

The collection contains the following elements after removing "Plums":
   KEY                       VALUE
   Braeburn Apples           1.49
   Fuji Apples               1.29
   Gala Apples               1.49
   Golden Delicious Apples   1.29
   Granny Smith Apples       0.89
   Red Delicious Apples      0.99

The collection contains the following elements after it is cleared:
   KEY                       VALUE


*/
// </snippet1>
