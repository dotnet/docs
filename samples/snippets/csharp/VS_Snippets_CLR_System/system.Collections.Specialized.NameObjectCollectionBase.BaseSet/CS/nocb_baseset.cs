// The following example uses BaseSet to set the value of a specific element.
// For an expanded version of this example, see the NameObjectCollectionBase class topic.

// <snippet1>
using System;
using System.Collections;
using System.Collections.Specialized;

public class MyCollection : NameObjectCollectionBase  {

   // Gets or sets the value at the specified index.
   public Object this[ int index ]  {
      get  {
         return( this.BaseGet( index ) );
      }
      set  {
         this.BaseSet( index, value );
      }
   }

   // Gets or sets the value associated with the specified key.
   public Object this[ String key ]  {
      get  {
         return( this.BaseGet( key ) );
      }
      set  {
         this.BaseSet( key, value );
      }
   }

   // Gets a String array that contains all the keys in the collection.
   public String[] AllKeys  {
      get  {
         return( this.BaseGetAllKeys() );
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
      Console.WriteLine( "Initial state of the collection:" );
      PrintKeysAndValues2( myCol );
      Console.WriteLine();

      // Sets the value at index 1.
      myCol[1] = "sunflower";
      Console.WriteLine( "After setting the value at index 1:" );
      PrintKeysAndValues2( myCol );
      Console.WriteLine();

      // Sets the value associated with the key "red".
      myCol["red"] = "tulip";
      Console.WriteLine( "After setting the value associated with the key \"red\":" );
      PrintKeysAndValues2( myCol );

   }

   public static void PrintKeysAndValues2( MyCollection myCol )  {
      foreach ( String s in myCol.AllKeys )  {
         Console.WriteLine( "{0}, {1}", s, myCol[s] );
      }
   }

}


/*
This code produces the following output.

Initial state of the collection:
red, apple
yellow, banana
green, pear

After setting the value at index 1:
red, apple
yellow, sunflower
green, pear

After setting the value associated with the key "red":
red, tulip
yellow, sunflower
green, pear

*/
// </snippet1>
