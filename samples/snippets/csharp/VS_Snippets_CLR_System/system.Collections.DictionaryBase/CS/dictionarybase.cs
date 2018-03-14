// The following code example implements the DictionaryBase class and uses that implementation to create a dictionary of String keys and values that have a Length of 5 or less.

// <Snippet1>
using System;
using System.Collections;

public class ShortStringDictionary : DictionaryBase  {

   public String this[ String key ]  {
      get  {
         return( (String) Dictionary[key] );
      }
      set  {
         Dictionary[key] = value;
      }
   }

   public ICollection Keys  {
      get  {
         return( Dictionary.Keys );
      }
   }

   public ICollection Values  {
      get  {
         return( Dictionary.Values );
      }
   }

   public void Add( String key, String value )  {
      Dictionary.Add( key, value );
   }

   public bool Contains( String key )  {
      return( Dictionary.Contains( key ) );
   }

   public void Remove( String key )  {
      Dictionary.Remove( key );
   }

   protected override void OnInsert( Object key, Object value )  {
      if ( key.GetType() != typeof(System.String) )
         throw new ArgumentException( "key must be of type String.", "key" );
      else  {
         String strKey = (String) key;
         if ( strKey.Length > 5 )
            throw new ArgumentException( "key must be no more than 5 characters in length.", "key" );
      }

      if ( value.GetType() != typeof(System.String) )
         throw new ArgumentException( "value must be of type String.", "value" );
      else  {
         String strValue = (String) value;
         if ( strValue.Length > 5 )
            throw new ArgumentException( "value must be no more than 5 characters in length.", "value" );
      }
   }

   protected override void OnRemove( Object key, Object value )  {
      if ( key.GetType() != typeof(System.String) )
         throw new ArgumentException( "key must be of type String.", "key" );
      else  {
         String strKey = (String) key;
         if ( strKey.Length > 5 )
            throw new ArgumentException( "key must be no more than 5 characters in length.", "key" );
      }
   }

   protected override void OnSet( Object key, Object oldValue, Object newValue )  {
      if ( key.GetType() != typeof(System.String) )
         throw new ArgumentException( "key must be of type String.", "key" );
      else  {
         String strKey = (String) key;
         if ( strKey.Length > 5 )
            throw new ArgumentException( "key must be no more than 5 characters in length.", "key" );
      }

      if ( newValue.GetType() != typeof(System.String) )
         throw new ArgumentException( "newValue must be of type String.", "newValue" );
      else  {
         String strValue = (String) newValue;
         if ( strValue.Length > 5 )
            throw new ArgumentException( "newValue must be no more than 5 characters in length.", "newValue" );
      }
   }

   protected override void OnValidate( Object key, Object value )  {
      if ( key.GetType() != typeof(System.String) )
         throw new ArgumentException( "key must be of type String.", "key" );
      else  {
         String strKey = (String) key;
         if ( strKey.Length > 5 )
            throw new ArgumentException( "key must be no more than 5 characters in length.", "key" );
      }

      if ( value.GetType() != typeof(System.String) )
         throw new ArgumentException( "value must be of type String.", "value" );
      else  {
         String strValue = (String) value;
         if ( strValue.Length > 5 )
            throw new ArgumentException( "value must be no more than 5 characters in length.", "value" );
      }
   }

}


public class SamplesDictionaryBase  {

   public static void Main()  {
 
      // Creates and initializes a new DictionaryBase.
      ShortStringDictionary mySSC = new ShortStringDictionary();

      // Adds elements to the collection.
      mySSC.Add( "One", "a" );
      mySSC.Add( "Two", "ab" );
      mySSC.Add( "Three", "abc" );
      mySSC.Add( "Four", "abcd" );
      mySSC.Add( "Five", "abcde" );

      // Display the contents of the collection using foreach. This is the preferred method.
      Console.WriteLine( "Contents of the collection (using foreach):" );
      PrintKeysAndValues1( mySSC );

      // Display the contents of the collection using the enumerator.
      Console.WriteLine( "Contents of the collection (using enumerator):" );
      PrintKeysAndValues2( mySSC );

      // Display the contents of the collection using the Keys property and the Item property.
      Console.WriteLine( "Initial contents of the collection (using Keys and Item):" );
      PrintKeysAndValues3( mySSC );

      // Tries to add a value that is too long.
      try  {
         mySSC.Add( "Ten", "abcdefghij" );
      }
      catch ( ArgumentException e )  {
         Console.WriteLine( e.ToString() );
      }

      // Tries to add a key that is too long.
      try  {
         mySSC.Add( "Eleven", "ijk" );
      }
      catch ( ArgumentException e )  {
         Console.WriteLine( e.ToString() );
      }

      Console.WriteLine();

      // Searches the collection with Contains.
      Console.WriteLine( "Contains \"Three\": {0}", mySSC.Contains( "Three" ) );
      Console.WriteLine( "Contains \"Twelve\": {0}", mySSC.Contains( "Twelve" ) );
      Console.WriteLine();

      // Removes an element from the collection.
      mySSC.Remove( "Two" );

      // Displays the contents of the collection.
      Console.WriteLine( "After removing \"Two\":" );
      PrintKeysAndValues1( mySSC );

   }

   // Uses the foreach statement which hides the complexity of the enumerator.
   // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
   public static void PrintKeysAndValues1( ShortStringDictionary myCol )  {
      foreach ( DictionaryEntry myDE in myCol )
         Console.WriteLine( "   {0,-5} : {1}", myDE.Key, myDE.Value );
      Console.WriteLine();
   }

   // Uses the enumerator. 
   // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
   public static void PrintKeysAndValues2( ShortStringDictionary myCol )  {
      DictionaryEntry myDE;
      System.Collections.IEnumerator myEnumerator = myCol.GetEnumerator();
      while ( myEnumerator.MoveNext() )
         if ( myEnumerator.Current != null )  {
            myDE = (DictionaryEntry) myEnumerator.Current;
            Console.WriteLine( "   {0,-5} : {1}", myDE.Key, myDE.Value );
         }
      Console.WriteLine();
   }

   // Uses the Keys property and the Item property.
   public static void PrintKeysAndValues3( ShortStringDictionary myCol )  {
      ICollection myKeys = myCol.Keys;
      foreach ( String k in myKeys )
         Console.WriteLine( "   {0,-5} : {1}", k, myCol[k] );
      Console.WriteLine();
   }

}


/* 
This code produces the following output.

Contents of the collection (using foreach):
   Three : abc
   Five  : abcde
   Two   : ab
   One   : a
   Four  : abcd

Contents of the collection (using enumerator):
   Three : abc
   Five  : abcde
   Two   : ab
   One   : a
   Four  : abcd

Initial contents of the collection (using Keys and Item):
   Three : abc
   Five  : abcde
   Two   : ab
   One   : a
   Four  : abcd

System.ArgumentException: value must be no more than 5 characters in length.
Parameter name: value
   at ShortStringDictionary.OnValidate(Object key, Object value)
   at System.Collections.DictionaryBase.System.Collections.IDictionary.Add(Object key, Object value)
   at SamplesDictionaryBase.Main()
System.ArgumentException: key must be no more than 5 characters in length.
Parameter name: key
   at ShortStringDictionary.OnValidate(Object key, Object value)
   at System.Collections.DictionaryBase.System.Collections.IDictionary.Add(Object key, Object value)
   at SamplesDictionaryBase.Main()

Contains "Three": True
Contains "Twelve": False

After removing "Two":
   Three : abc
   Five  : abcde
   One   : a
   Four  : abcd

*/

// </Snippet1>

