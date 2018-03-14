// The following code example shows that CultureInfo.ReadOnly also protects the DateTimeFormatInfo and NumberFormatInfo instances associated with the CultureInfo.


// <snippet1>
using System;
using System.Globalization;


public class SamplesCultureInfo  {

   public static void Main()  {

      // Creates a CultureInfo.
      CultureInfo myCI = new CultureInfo( "en-US" );

      // Creates a read-only CultureInfo based on myCI.
      CultureInfo myReadOnlyCI = CultureInfo.ReadOnly( myCI );

      // Display the read-only status of each CultureInfo and their DateTimeFormat and NumberFormat properties.
      Console.WriteLine( "myCI is {0}.", myCI.IsReadOnly ? "read only" : "writable" );
      Console.WriteLine( "myCI.DateTimeFormat is {0}.", myCI.DateTimeFormat.IsReadOnly ? "read only" : "writable" );
      Console.WriteLine( "myCI.NumberFormat is {0}.", myCI.NumberFormat.IsReadOnly ? "read only" : "writable" );
      Console.WriteLine( "myReadOnlyCI is {0}.", myReadOnlyCI.IsReadOnly ? "read only" : "writable" );
      Console.WriteLine( "myReadOnlyCI.DateTimeFormat is {0}.", myReadOnlyCI.DateTimeFormat.IsReadOnly ? "read only" : "writable" );
      Console.WriteLine( "myReadOnlyCI.NumberFormat is {0}.", myReadOnlyCI.NumberFormat.IsReadOnly ? "read only" : "writable" );

   }

}

/*
This code produces the following output.

myCI is writable.
myCI.DateTimeFormat is writable.
myCI.NumberFormat is writable.
myReadOnlyCI is read only.
myReadOnlyCI.DateTimeFormat is read only.
myReadOnlyCI.NumberFormat is read only.

*/
// </snippet1>
