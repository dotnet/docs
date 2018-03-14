// The following example uses BaseHasKeys to determine if the collection contains keys that are not a null reference.
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

   // Creates an empty collection.
   public MyCollection()  {
   }

   // Adds an entry to the collection.
   public void Add( String key, Object value )  {
      this.BaseAdd( key, value );
   }

   // Gets a value indicating whether the collection contains keys that are not a null reference.
   public Boolean HasKeys  {
      get  {
         return( this.BaseHasKeys() );
      }
   }

}

public class SamplesNameObjectCollectionBase  {

   public static void Main()  {

      // Creates an empty MyCollection instance.
      MyCollection myCol = new MyCollection();
      Console.WriteLine( "Initial state of the collection (Count = {0}):", myCol.Count );
      PrintKeysAndValues( myCol );
      Console.WriteLine( "HasKeys? {0}", myCol.HasKeys );

      Console.WriteLine();

      // Adds an item to the collection.
      myCol.Add( "blue", "sky" );
      Console.WriteLine( "Initial state of the collection (Count = {0}):", myCol.Count );
      PrintKeysAndValues( myCol );
      Console.WriteLine( "HasKeys? {0}", myCol.HasKeys );

   }

   public static void PrintKeysAndValues( MyCollection myCol )  {
      for ( int i = 0; i < myCol.Count; i++ )  {
         Console.WriteLine( "[{0}] : {1}, {2}", i, myCol[i].Key, myCol[i].Value );
      }
   }

}


/*
This code produces the following output.

Initial state of the collection (Count = 0):
HasKeys? False

Initial state of the collection (Count = 1):
[0] : blue, sky
HasKeys? True

*/
// </snippet1>
