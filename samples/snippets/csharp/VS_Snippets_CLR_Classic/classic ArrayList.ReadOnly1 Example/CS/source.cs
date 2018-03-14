// <Snippet1>
 using System;
 using System.Collections;
 public class SamplesArrayList  {
 
    public static void Main()  {
 
       // Creates and initializes a new ArrayList.
       ArrayList myAL = new ArrayList();
       myAL.Add( "red" );
       myAL.Add( "orange" );
       myAL.Add( "yellow" );
 
       // Creates a read-only copy of the ArrayList.
       ArrayList myReadOnlyAL = ArrayList.ReadOnly( myAL );
 
       // Displays whether the ArrayList is read-only or writable.
       Console.WriteLine( "myAL is {0}.", myAL.IsReadOnly ? "read-only" : "writable" );
       Console.WriteLine( "myReadOnlyAL is {0}.", myReadOnlyAL.IsReadOnly ? "read-only" : "writable" );
 
       // Displays the contents of both collections.
       Console.WriteLine( "\nInitially," );
       Console.WriteLine( "The original ArrayList myAL contains:" );
       foreach ( String myStr in myAL )
          Console.WriteLine( "   {0}", myStr );
       Console.WriteLine( "The read-only ArrayList myReadOnlyAL contains:" );
       foreach ( String myStr in myReadOnlyAL )
          Console.WriteLine( "   {0}", myStr );

       // Adding an element to a read-only ArrayList throws an exception.
       Console.WriteLine( "\nTrying to add a new element to the read-only ArrayList:" );
       try  {
          myReadOnlyAL.Add("green");
       } catch ( Exception myException )  {
          Console.WriteLine("Exception: " + myException.ToString());
       }

       // Adding an element to the original ArrayList affects the read-only ArrayList.
       myAL.Add( "blue" );

       // Displays the contents of both collections again.
       Console.WriteLine( "\nAfter adding a new element to the original ArrayList," );
       Console.WriteLine( "The original ArrayList myAL contains:" );
       foreach ( String myStr in myAL )
          Console.WriteLine( "   {0}", myStr );
       Console.WriteLine( "The read-only ArrayList myReadOnlyAL contains:" );
       foreach ( String myStr in myReadOnlyAL )
          Console.WriteLine( "   {0}", myStr );

    }

 }


/* 
This code produces the following output.

myAL is writable.
myReadOnlyAL is read-only.

Initially,
The original ArrayList myAL contains:
   red
   orange
   yellow
The read-only ArrayList myReadOnlyAL contains:
   red
   orange
   yellow

Trying to add a new element to the read-only ArrayList:
Exception: System.NotSupportedException: Collection is read-only.
   at System.Collections.ReadOnlyArrayList.Add(Object obj)
   at SamplesArrayList.Main()

After adding a new element to the original ArrayList,
The original ArrayList myAL contains:
   red
   orange
   yellow
   blue
The read-only ArrayList myReadOnlyAL contains:
   red
   orange
   yellow
   blue

*/

// </Snippet1>

