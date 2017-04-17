// The following code example implements the ReadOnlyCollectionBase class.

using System;
using System.Collections;

public class ROCollection : ReadOnlyCollectionBase
{

   public ROCollection( IList sourceList )  {
      InnerList.AddRange( sourceList );
   }

   public Object this[ int index ]  {
      get  {
         return( InnerList[index] );
      }
   }

   public int IndexOf( Object value )  {
      return( InnerList.IndexOf( value ) );
   }

   public bool Contains( Object value )  {
      return( InnerList.Contains( value ) );
   }

}


public class SamplesCollectionBase
{
    public static void Main()
    {
        // Create an ArrayList.
        ArrayList myAL = new ArrayList();
        myAL.Add( "red" );
        myAL.Add( "blue" );
        myAL.Add( "yellow" );
        myAL.Add( "green" );
        myAL.Add( "orange" );
        myAL.Add( "purple" );

        // Create a new ROCollection that contains the elements in myAL.
        ROCollection myReadOnlyCollection = new ROCollection( myAL );

        // <Snippet2>
        // Get the ICollection interface from the ReadOnlyCollectionBase
        // derived class.
        ICollection myCollection = myReadOnlyCollection;
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



