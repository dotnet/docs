// The following code example enumerates the elements of a HybridDictionary.

// <snippet1>
using System;
using System.Collections;
using System.Collections.Specialized;

public class SamplesHybridDictionary  {

   public static void Main()  {

      // Creates and initializes a new HybridDictionary.
      HybridDictionary myCol = new HybridDictionary();
      myCol.Add( "Braeburn Apples", "1.49" );
      myCol.Add( "Fuji Apples", "1.29" );
      myCol.Add( "Gala Apples", "1.49" );
      myCol.Add( "Golden Delicious Apples", "1.29" );
      myCol.Add( "Granny Smith Apples", "0.89" );
      myCol.Add( "Red Delicious Apples", "0.99" );
      myCol.Add( "Plantain Bananas", "1.49" );
      myCol.Add( "Yellow Bananas", "0.79" );
      myCol.Add( "Strawberries", "3.33" );
      myCol.Add( "Cranberries", "5.98" );
      myCol.Add( "Navel Oranges", "1.29" );
      myCol.Add( "Grapes", "1.99" );
      myCol.Add( "Honeydew Melon", "0.59" );
      myCol.Add( "Seedless Watermelon", "0.49" );
      myCol.Add( "Pineapple", "1.49" );
      myCol.Add( "Nectarine", "1.99" );
      myCol.Add( "Plums", "1.69" );
      myCol.Add( "Peaches", "1.99" );

      // Display the contents of the collection using foreach. This is the preferred method.
      Console.WriteLine( "Displays the elements using foreach:" );
      PrintKeysAndValues1( myCol );

      // Display the contents of the collection using the enumerator.
      Console.WriteLine( "Displays the elements using the IDictionaryEnumerator:" );
      PrintKeysAndValues2( myCol );

      // Display the contents of the collection using the Keys, Values, Count, and Item properties.
      Console.WriteLine( "Displays the elements using the Keys, Values, Count, and Item properties:" );
      PrintKeysAndValues3( myCol );

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
   public static void PrintKeysAndValues3( HybridDictionary myCol )  {
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
   Seedless Watermelon       0.49
   Nectarine                 1.99
   Cranberries               5.98
   Plantain Bananas          1.49
   Honeydew Melon            0.59
   Pineapple                 1.49
   Strawberries              3.33
   Grapes                    1.99
   Braeburn Apples           1.49
   Peaches                   1.99
   Red Delicious Apples      0.99
   Golden Delicious Apples   1.29
   Yellow Bananas            0.79
   Granny Smith Apples       0.89
   Gala Apples               1.49
   Plums                     1.69
   Navel Oranges             1.29
   Fuji Apples               1.29

Displays the elements using the IDictionaryEnumerator:
   KEY                       VALUE
   Seedless Watermelon       0.49
   Nectarine                 1.99
   Cranberries               5.98
   Plantain Bananas          1.49
   Honeydew Melon            0.59
   Pineapple                 1.49
   Strawberries              3.33
   Grapes                    1.99
   Braeburn Apples           1.49
   Peaches                   1.99
   Red Delicious Apples      0.99
   Golden Delicious Apples   1.29
   Yellow Bananas            0.79
   Granny Smith Apples       0.89
   Gala Apples               1.49
   Plums                     1.69
   Navel Oranges             1.29
   Fuji Apples               1.29

Displays the elements using the Keys, Values, Count, and Item properties:
   INDEX KEY                       VALUE
   0     Seedless Watermelon       0.49
   1     Nectarine                 1.99
   2     Cranberries               5.98
   3     Plantain Bananas          1.49
   4     Honeydew Melon            0.59
   5     Pineapple                 1.49
   6     Strawberries              3.33
   7     Grapes                    1.99
   8     Braeburn Apples           1.49
   9     Peaches                   1.99
   10    Red Delicious Apples      0.99
   11    Golden Delicious Apples   1.29
   12    Yellow Bananas            0.79
   13    Granny Smith Apples       0.89
   14    Gala Apples               1.49
   15    Plums                     1.69
   16    Navel Oranges             1.29
   17    Fuji Apples               1.29

*/
// </snippet1>
