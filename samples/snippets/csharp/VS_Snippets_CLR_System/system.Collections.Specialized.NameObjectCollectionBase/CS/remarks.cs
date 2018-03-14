using System;
using System.Collections;
using System.Collections.Specialized;

public class DerivedCollection : NameObjectCollectionBase
{
   // Creates an empty collection.
   public DerivedCollection()  {
   }

   // Adds elements from an IDictionary into the new collection.
   public DerivedCollection( IDictionary d, Boolean bReadOnly )  {
      foreach ( DictionaryEntry de in d )  {
         this.BaseAdd( (String) de.Key, de.Value );
      }
      this.IsReadOnly = bReadOnly;
   }

   // Gets a key-and-value pair (DictionaryEntry) using an index.
   public DictionaryEntry this[ int index ]  {
      get  {
          return ( new DictionaryEntry( 
              this.BaseGetKey(index), this.BaseGet(index) ) );
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

   // Gets an Object array that contains all the values in the collection.
   public Array AllValues  {
      get  {
         return( this.BaseGetAllValues() );
      }
   }

   // Gets a String array that contains all the values in the collection.
   public String[] AllStringValues  {
      get  {
         return( (String[]) this.BaseGetAllValues( typeof( string ) ));
      }
   }

   // Gets a value indicating if the collection contains keys that are not null.
   public Boolean HasKeys  {
      get  {
         return( this.BaseHasKeys() );
      }
   }

   // Adds an entry to the collection.
   public void Add( String key, Object value )  {
      this.BaseAdd( key, value );
   }

   // Removes an entry with the specified key from the collection.
   public void Remove( String key )  {
      this.BaseRemove( key );
   }

   // Removes an entry in the specified index from the collection.
   public void Remove( int index )  {
      this.BaseRemoveAt( index );
   }

   // Clears all the elements in the collection.
   public void Clear()  {
      this.BaseClear();
   }

}

public class SamplesNameObjectCollectionBase
{
    public static void Main()
    {
        // <Snippet2>
        // Create a collection derived from NameObjectCollectionBase
        ICollection myCollection = new DerivedCollection();
        lock(myCollection.SyncRoot)
        {
            foreach (object item in myCollection)
            {
                // Insert your code here.
            }
        }
        // </Snippet2>
    }
}

