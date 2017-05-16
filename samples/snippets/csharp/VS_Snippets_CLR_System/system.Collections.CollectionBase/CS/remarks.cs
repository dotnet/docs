// The following code example implements the CollectionBase class and uses that implementation to create a collection of Int16 objects.

using System;
using System.Collections;

public class Int16Collection : CollectionBase  {

   public Int16 this[ int index ]  {
      get  {
         return( (Int16) List[index] );
      }
      set  {
         List[index] = value;
      }
   }

   public int Add( Int16 value )  {
      return( List.Add( value ) );
   }

   public int IndexOf( Int16 value )  {
      return( List.IndexOf( value ) );
   }

   public void Insert( int index, Int16 value )  {
      List.Insert( index, value );
   }

   public void Remove( Int16 value )  {
      List.Remove( value );
   }

   public bool Contains( Int16 value )  {
      // If value is not of type Int16, this will return false.
      return( List.Contains( value ) );
   }

   protected override void OnInsert( int index, Object value )  {
      // Insert additional code to be run only when inserting values.
   }

   protected override void OnRemove( int index, Object value )  {
      // Insert additional code to be run only when removing values.
   }

   protected override void OnSet( int index, Object oldValue, Object newValue )  {
      // Insert additional code to be run only when setting values.
   }

   protected override void OnValidate( Object value )  {
      if ( value.GetType() != typeof(System.Int16) )
         throw new ArgumentException( "value must be of type Int16.", "value" );
   }

}


public class SamplesCollectionBase
{
    public static void Main()
    {
        // Create and initialize a new CollectionBase.
        Int16Collection myCollectionBase = new Int16Collection();

        // Add elements to the collection.
        myCollectionBase.Add( (Int16) 1 );
        myCollectionBase.Add( (Int16) 2 );
        myCollectionBase.Add( (Int16) 3 );
        myCollectionBase.Add( (Int16) 5 );
        myCollectionBase.Add( (Int16) 7 );

        // <Snippet2>
        // Get the ICollection interface from the CollectionBase
        // derived class.
        ICollection myCollection = myCollectionBase;
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