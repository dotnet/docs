// <Snippet1>
 using System;
 using System.Collections;
 public class SamplesHashtable  {
 
    public static void Main()  {
 
       // Creates and initializes a new Hashtable.
       Hashtable myHT = new Hashtable();
       myHT.Add( "one", "The" );
       myHT.Add( "two", "quick" );
       myHT.Add( "three", "brown" );
       myHT.Add( "four", "fox" );
 
       // Displays the Hashtable.
       Console.WriteLine( "The Hashtable contains the following:" );
       PrintKeysAndValues( myHT );
    }
 
 
    public static void PrintKeysAndValues( Hashtable myHT )  {
       Console.WriteLine( "\t-KEY-\t-VALUE-" );
       foreach ( DictionaryEntry de in myHT )
          Console.WriteLine( "\t{0}:\t{1}", de.Key, de.Value );
       Console.WriteLine();
    }
 }
 /* 
 This code produces the following output.
 
 The Hashtable contains the following:
         -KEY-   -VALUE-
         two:    quick
         three:  brown
         four:   fox
         one:    The
 */ 
// </Snippet1>

