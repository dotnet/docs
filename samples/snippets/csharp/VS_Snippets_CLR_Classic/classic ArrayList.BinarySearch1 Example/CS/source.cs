// <Snippet1>
 using System;
 using System.Collections;
 public class SamplesArrayList  {
 
    public static void Main()  {
 
       // Creates and initializes a new ArrayList. BinarySearch requires
       // a sorted ArrayList.
       ArrayList myAL = new ArrayList();
       for ( int i = 0; i <= 4; i++ )
          myAL.Add( i*2 );

       // Displays the ArrayList.
       Console.WriteLine( "The Int32 ArrayList contains the following:" );
       PrintValues( myAL );
 
       // Locates a specific object that does not exist in the ArrayList.
       Object myObjectOdd = 3;
       FindMyObject( myAL, myObjectOdd );
 
       // Locates an object that exists in the ArrayList.
       Object myObjectEven = 6;
       FindMyObject( myAL, myObjectEven );
    }
 
    public static void FindMyObject( ArrayList myList, Object myObject )  {
       int myIndex=myList.BinarySearch( myObject );
       if ( myIndex < 0 )
          Console.WriteLine( "The object to search for ({0}) is not found. The next larger object is at index {1}.", myObject, ~myIndex );
       else
          Console.WriteLine( "The object to search for ({0}) is at index {1}.", myObject, myIndex );
    }
 
    public static void PrintValues( IEnumerable myList )  {
       foreach ( Object obj in myList )
          Console.Write( "   {0}", obj );
       Console.WriteLine();
    }

 }
 /* 
 This code produces the following output.
 
 The Int32 ArrayList contains the following:
    0   2   4   6   8
 The object to search for (3) is not found. The next larger object is at index 2.
 The object to search for (6) is at index 3.
 */ 
// </Snippet1>

