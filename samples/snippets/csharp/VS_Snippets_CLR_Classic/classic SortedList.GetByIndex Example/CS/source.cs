// <Snippet1>
 using System;
 using System.Collections;
 public class SamplesSortedList  {
 
    public static void Main()  {
 
       // Creates and initializes a new SortedList.
       SortedList mySL = new SortedList();
       mySL.Add( 1.3, "fox" );
       mySL.Add( 1.4, "jumped" );
       mySL.Add( 1.5, "over" );
       mySL.Add( 1.2, "brown" );
       mySL.Add( 1.1, "quick" );
       mySL.Add( 1.0, "The" );
       mySL.Add( 1.6, "the" );
       mySL.Add( 1.8, "dog" );
       mySL.Add( 1.7, "lazy" );
 
       // Gets the key and the value based on the index.
       int myIndex=3;
       Console.WriteLine( "The key   at index {0} is {1}.", myIndex, mySL.GetKey( myIndex ) );
       Console.WriteLine( "The value at index {0} is {1}.", myIndex, mySL.GetByIndex( myIndex ) );
 
       // Gets the list of keys and the list of values.
       IList myKeyList = mySL.GetKeyList();
       IList myValueList = mySL.GetValueList();
 
       // Prints the keys in the first column and the values in the second column.
       Console.WriteLine( "\t-KEY-\t-VALUE-" );
       for ( int i = 0; i < mySL.Count; i++ )
          Console.WriteLine( "\t{0}\t{1}", myKeyList[i], myValueList[i] );
    }
 }
 /* 
 This code produces the following output.
 
 The key   at index 3 is 1.3.
 The value at index 3 is fox.
     -KEY-    -VALUE-
     1    The
     1.1    quick
     1.2    brown
     1.3    fox
     1.4    jumped
     1.5    over
     1.6    the
     1.7    lazy
     1.8    dog
 */ 
 // </Snippet1>

