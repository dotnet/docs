// The following example uses BaseGetAllKeys and BaseGetAllValues to get an array of the keys or an array of the values.
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

   // Gets a String array that contains all the keys in the collection.
   public String[] AllKeys  {
      get  {
         return( this.BaseGetAllKeys() );
      }
   }

   // Gets an Object array that contains all the values in the collection.
   public Array AllValues  {
      get  {
         return( this.BaseGetAllValues() );
      }
   }

   // Gets a String array that contains all the values in the collection.
   public String[] AllStringValues  {
      get  {
         return( (String[]) this.BaseGetAllValues( typeof(System.String) ) );
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
      Console.WriteLine( "Initial state of the collection (Count = {0}):", myCol.Count );
      PrintKeysAndValues( myCol );

      // Displays the list of keys.
      Console.WriteLine( "The list of keys:" );
      foreach ( String s in myCol.AllKeys )  {
         Console.WriteLine( "   {0}", s );
      }

      // Displays the list of values of type Object.
      Console.WriteLine( "The list of values (Object):" );
      foreach ( Object o in myCol.AllValues )  {
         Console.WriteLine( "   {0}", o.ToString() );
      }

      // Displays the list of values of type String.
      Console.WriteLine( "The list of values (String):" );
      foreach ( String s in myCol.AllValues )  {
         Console.WriteLine( "   {0}", s );
      }

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
The list of keys:
   red
   yellow
   green
The list of values (Object):
   apple
   banana
   pear
The list of values (String):
   apple
   banana
   pear

*/
// </snippet1>
