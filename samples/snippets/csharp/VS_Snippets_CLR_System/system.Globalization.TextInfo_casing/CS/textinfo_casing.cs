// The following code example changes the casing of a string.


// <snippet1>
using System;
using System.Globalization;


public class SamplesTextInfo  {

   public static void Main()  {

      // Defines the string with mixed casing.
      string myString = "wAr aNd pEaCe";

      // Creates a TextInfo based on the "en-US" culture.
      TextInfo myTI = new CultureInfo("en-US",false).TextInfo;

      // Changes a string to lowercase.
      Console.WriteLine( "\"{0}\" to lowercase: {1}", myString, myTI.ToLower( myString ) );

      // Changes a string to uppercase.
      Console.WriteLine( "\"{0}\" to uppercase: {1}", myString, myTI.ToUpper( myString ) );

      // Changes a string to titlecase.
      Console.WriteLine( "\"{0}\" to titlecase: {1}", myString, myTI.ToTitleCase( myString ) );

   }

}

/*
This code produces the following output.

"wAr aNd pEaCe" to lowercase: war and peace
"wAr aNd pEaCe" to uppercase: WAR AND PEACE
"wAr aNd pEaCe" to titlecase: War And Peace

*/
// </snippet1>
