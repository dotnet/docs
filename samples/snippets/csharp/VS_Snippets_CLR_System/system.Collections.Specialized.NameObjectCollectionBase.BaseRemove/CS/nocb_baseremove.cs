// The following example uses BaseRemove and BaseRemoveAt to remove elements from a NameObjectCollectionBase.
// For an expanded version of this example, see the NameObjectCollectionBase class topic.

// <snippet1>
using System;
using System.Collections;
using System.Collections.Specialized;

public class MyCollection : NameObjectCollectionBase  {

   private DictionaryEntry _de = new DictionaryEntry();

   // Gets a key-and-value pair (DictionaryEntry) using an index.
   public DictionaryEntry this[ int index ]  {
      get  {
         _de.Key = this.BaseGetKey( index );
         _de.Value = this.BaseGet( index );
         return( _de );
      }
   }

   // Adds elements from an IDictionary into the new collection.
   public MyCollection( IDictionary d )  {
      foreach ( DictionaryEntry de in d )  {
         this.BaseAdd( (String) de.Key, de.Value );
      }
   }

   // Removes an entry with the specified key from the collection.
   public void Remove( String key )  {
      this.BaseRemove( key );
   }

   // Removes an entry in the specified index from the collection.
   public void Remove( int index )  {
      this.BaseRemoveAt( index );
   }

}

public class SamplesNameObjectCollectionBase  {

   public static void Main()  {

      // Creates and initializes a new MyCollection instance.
      IDictionary d = new ListDictionary();
      d.Add( "red", "apple" );
      d.Add( "yellow", "banana" );
      d.Add( "green", "pear" );
      MyCollection myCol = new MyCollection( d );
      Console.WriteLine( "Initial state of the collection (Count = {0}):", myCol.Count );
      PrintKeysAndValues( myCol );

      // Removes an element at a specific index.
      myCol.Remove( 1 );
      Console.WriteLine( "After removing the element at index 1 (Count = {0}):", myCol.Count );
      PrintKeysAndValues( myCol );

      // Removes an element with a specific key.
      myCol.Remove( "red" );
      Console.WriteLine( "After removing the element with the key \"red\" (Count = {0}):", myCol.Count );
      PrintKeysAndValues( myCol );

   }

   public static void PrintKeysAndValues( MyCollection myCol )  {
      for ( int i = 0; i < myCol.Count; i++ )  {
         Console.WriteLine( "[{0}] : {1}, {2}", i, myCol[i].Key, myCol[i].Value );
      }
   }

}


/*
This code produces the following output.

Initial state of the collection (Count = 3):
[0] : red, apple
[1] : yellow, banana
[2] : green, pear
After removing the element at index 1 (Count = 2):
[0] : red, apple
[1] : green, pear
After removing the element with the key "red" (Count = 1):
[0] : green, pear

*/
// </snippet1>
