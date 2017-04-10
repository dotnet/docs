// The following code example implements the ReadOnlyCollectionBase class.

// <Snippet1>
using System;
using System.Collections;

public class ROCollection : ReadOnlyCollectionBase  {

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


public class SamplesCollectionBase  {

   public static void Main()  {

      // Create an ArrayList.
      ArrayList myAL = new ArrayList();
      myAL.Add( "red" );
      myAL.Add( "blue" );
      myAL.Add( "yellow" );
      myAL.Add( "green" );
      myAL.Add( "orange" );
      myAL.Add( "purple" );
 
      // Create a new ROCollection that contains the elements in myAL.
      ROCollection myCol = new ROCollection( myAL );

      // Display the contents of the collection using foreach. This is the preferred method.
      Console.WriteLine( "Contents of the collection (using foreach):" );
      PrintValues1( myCol );

      // Display the contents of the collection using the enumerator.
      Console.WriteLine( "Contents of the collection (using enumerator):" );
      PrintValues2( myCol );

      // Display the contents of the collection using the Count property and the Item property.
      Console.WriteLine( "Contents of the collection (using Count and Item):" );
      PrintIndexAndValues( myCol );

      // Search the collection with Contains and IndexOf.
      Console.WriteLine( "Contains yellow: {0}", myCol.Contains( "yellow" ) );
      Console.WriteLine( "orange is at index {0}.", myCol.IndexOf( "orange" ) );
      Console.WriteLine();

   }
 
   // Uses the Count property and the Item property.
   public static void PrintIndexAndValues( ROCollection myCol )  {
      for ( int i = 0; i < myCol.Count; i++ )
         Console.WriteLine( "   [{0}]:   {1}", i, myCol[i] );
      Console.WriteLine();
   }

   // Uses the foreach statement which hides the complexity of the enumerator.
   // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
   public static void PrintValues1( ROCollection myCol )  {
      foreach ( Object obj in myCol )
         Console.WriteLine( "   {0}", obj );
      Console.WriteLine();
   }

   // Uses the enumerator. 
   // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
   public static void PrintValues2( ROCollection myCol )  {
      System.Collections.IEnumerator myEnumerator = myCol.GetEnumerator();
      while ( myEnumerator.MoveNext() )
         Console.WriteLine( "   {0}", myEnumerator.Current );
      Console.WriteLine();
   }

}


/* 
This code produces the following output.

Contents of the collection (using foreach):
   red
   blue
   yellow
   green
   orange
   purple

Contents of the collection (using enumerator):
   red
   blue
   yellow
   green
   orange
   purple

Contents of the collection (using Count and Item):
   [0]:   red
   [1]:   blue
   [2]:   yellow
   [3]:   green
   [4]:   orange
   [5]:   purple

Contains yellow: True
orange is at index 4.

*/

// </Snippet1>

