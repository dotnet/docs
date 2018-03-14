// <Snippet1>
 using System;
 using System.Collections;
 public class SamplesArrayList  {
 
    public static void Main()  {
 
       // Creates and initializes a new ArrayList.
       ArrayList myAL = new ArrayList();
       myAL.Add("Hello");
       myAL.Add("World");
       myAL.Add("!");
 
       // Displays the properties and values of the ArrayList.
       Console.WriteLine( "myAL" );
       Console.WriteLine( "    Count:    {0}", myAL.Count );
       Console.WriteLine( "    Capacity: {0}", myAL.Capacity );
       Console.Write( "    Values:" );
       PrintValues( myAL );
    }
 
    public static void PrintValues( IEnumerable myList )  {
       foreach ( Object obj in myList )
          Console.Write( "   {0}", obj );
       Console.WriteLine();
    }

 }


 /* 
 This code produces output similar to the following:
 
 myAL
     Count:    3
     Capacity: 4
     Values:   Hello   World   !

 */
// </Snippet1>

