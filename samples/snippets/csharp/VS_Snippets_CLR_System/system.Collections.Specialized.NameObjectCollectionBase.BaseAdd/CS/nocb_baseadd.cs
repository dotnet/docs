// The following example uses BaseAdd to create a new NameObjectCollectionBase with elements from another dictionary.
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

}

public class SamplesNameObjectCollectionBase  {

   public static void Main()  {

      // Creates and initializes a new MyCollection instance.
      IDictionary d = new ListDictionary();
      d.Add( "red", "apple" );
      d.Add( "yellow", "banana" );
      d.Add( "green", "pear" );
      MyCollection myCol = new MyCollection( d );

      // Displays the keys and values of the MyCollection instance.
      for ( int i = 0; i < myCol.Count; i++ )  {
         Console.WriteLine( "[{0}] : {1}, {2}", i, myCol[i].Key, myCol[i].Value );
      }

   }

}


/*
This code produces the following output.

[0] : red, apple
[1] : yellow, banana
[2] : green, pear

*/
// </snippet1>
