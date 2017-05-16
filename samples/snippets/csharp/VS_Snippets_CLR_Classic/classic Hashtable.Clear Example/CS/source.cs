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
       myHT.Add( "five", "jumped" );
 
       // Displays the count and values of the Hashtable.
       Console.WriteLine( "Initially," );
       Console.WriteLine( "   Count    : {0}", myHT.Count );
       Console.WriteLine( "   Values:" );
       PrintKeysAndValues( myHT );
 
       // Clears the Hashtable.
       myHT.Clear();
 
       // Displays the count and values of the Hashtable.
       Console.WriteLine( "After Clear," );
       Console.WriteLine( "   Count    : {0}", myHT.Count );
       Console.WriteLine( "   Values:" );
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
 
 Initially,
    Count    : 5
    Values:
         -KEY-   -VALUE-
         two:    quick
         three:  brown
         four:   fox
         five:   jumped
         one:    The

 After Clear,
    Count    : 0
    Values:
         -KEY-   -VALUE-

 */ 

// </Snippet1>

