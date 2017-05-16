// <Snippet1>
 using System;
 using System.Collections;
 public class SamplesSortedList  {
 
    public static void Main()  {
 
       // Creates and initializes a new SortedList.
       SortedList mySL = new SortedList();
       mySL.Add( "one", "The" );
       mySL.Add( "two", "quick" );
       mySL.Add( "three", "brown" );
       mySL.Add( "four", "fox" );
       mySL.Add( "five", "jumped" );
 
       // Displays the count, capacity and values of the SortedList.
       Console.WriteLine( "Initially," );
       Console.WriteLine( "   Count    : {0}", mySL.Count );
       Console.WriteLine( "   Capacity : {0}", mySL.Capacity );
       Console.WriteLine( "   Values:" );
       PrintKeysAndValues( mySL );
 
       // Trims the SortedList.
       mySL.TrimToSize();
 
       // Displays the count, capacity and values of the SortedList.
       Console.WriteLine( "After TrimToSize," );
       Console.WriteLine( "   Count    : {0}", mySL.Count );
       Console.WriteLine( "   Capacity : {0}", mySL.Capacity );
       Console.WriteLine( "   Values:" );
       PrintKeysAndValues( mySL );
 
       // Clears the SortedList.
       mySL.Clear();
 
       // Displays the count, capacity and values of the SortedList.
       Console.WriteLine( "After Clear," );
       Console.WriteLine( "   Count    : {0}", mySL.Count );
       Console.WriteLine( "   Capacity : {0}", mySL.Capacity );
       Console.WriteLine( "   Values:" );
       PrintKeysAndValues( mySL );
 
       // Trims the SortedList again.
       mySL.TrimToSize();
 
       // Displays the count, capacity and values of the SortedList.
       Console.WriteLine( "After the second TrimToSize," );
       Console.WriteLine( "   Count    : {0}", mySL.Count );
       Console.WriteLine( "   Capacity : {0}", mySL.Capacity );
       Console.WriteLine( "   Values:" );
       PrintKeysAndValues( mySL );
    }
 
 
    public static void PrintKeysAndValues( SortedList myList )  {
       Console.WriteLine( "\t-KEY-\t-VALUE-" );
       for ( int i = 0; i < myList.Count; i++ )  {
          Console.WriteLine( "\t{0}:\t{1}", myList.GetKey(i), myList.GetByIndex(i) );
       }
       Console.WriteLine();
    }
 }
 /* 
 This code produces the following output.
 
 Initially,
    Count    : 5
    Capacity : 16
    Values:
     -KEY-    -VALUE-
     five:    jumped
     four:    fox
     one:    The
     three:    brown
     two:    quick
 
 After TrimToSize,
    Count    : 5
    Capacity : 5
    Values:
     -KEY-    -VALUE-
     five:    jumped
     four:    fox
     one:    The
     three:    brown
     two:    quick
 
 After Clear,
    Count    : 0
    Capacity : 16
    Values:
     -KEY-    -VALUE-
 
 After the second TrimToSize,
    Count    : 0
    Capacity : 16
    Values:
     -KEY-    -VALUE-
 */ 
 // </Snippet1>

