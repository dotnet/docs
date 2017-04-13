// <Snippet1>
 using System;
 using System.Collections;
 public class SamplesHashtable  {
 
    public static void Main()  {
 
       // Creates and initializes a new Hashtable.
       Hashtable myHT = new Hashtable();
       myHT.Add( "1a", "The" );
       myHT.Add( "1b", "quick" );
       myHT.Add( "1c", "brown" );
       myHT.Add( "2a", "fox" );
       myHT.Add( "2b", "jumped" );
       myHT.Add( "2c", "over" );
       myHT.Add( "3a", "the" );
       myHT.Add( "3b", "lazy" );
       myHT.Add( "3c", "dog" );
 
       // Displays the Hashtable.
       Console.WriteLine( "The Hashtable initially contains the following:" );
       PrintKeysAndValues( myHT );
 
       // Removes the element with the key "3b".
       myHT.Remove( "3b" );
 
       // Displays the current state of the Hashtable.
       Console.WriteLine( "After removing \"lazy\":" );
       PrintKeysAndValues( myHT );
    }
 
 
    public static void PrintKeysAndValues( Hashtable myHT )  {
       foreach ( DictionaryEntry de in myHT )
          Console.WriteLine( "    {0}:    {1}", de.Key, de.Value );
       Console.WriteLine();
    }

 }


 /*
 This code produces the following output.
 
 The Hashtable initially contains the following:
     2c:    over
     3a:    the
     2b:    jumped
     3b:    lazy
     1b:    quick
     3c:    dog
     2a:    fox
     1c:    brown
     1a:    The

 After removing "lazy":
     2c:    over
     3a:    the
     2b:    jumped
     1b:    quick
     3c:    dog
     2a:    fox
     1c:    brown
     1a:    The

 */
// </Snippet1>

