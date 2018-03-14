// The following code example creates a case-sensitive hashtable and a case-insensitive hashtable
// and demonstrates the difference in their behavior, even if both contain the same elements.

// <Snippet1>
using System;
using System.Collections;
using System.Globalization;

public class SamplesHashtable  {

   public static void Main()  {

      // Create a Hashtable using the default hash code provider and the default comparer.
      Hashtable myHT1 = new Hashtable();
      myHT1.Add("FIRST", "Hello");
      myHT1.Add("SECOND", "World");
      myHT1.Add("THIRD", "!");

      // Create a Hashtable using a case-insensitive code provider and a case-insensitive comparer,
      // based on the culture of the current thread.
      Hashtable myHT2 = new Hashtable( new CaseInsensitiveHashCodeProvider(), new CaseInsensitiveComparer() );
      myHT2.Add("FIRST", "Hello");
      myHT2.Add("SECOND", "World");
      myHT2.Add("THIRD", "!");

      // Create a Hashtable using a case-insensitive code provider and a case-insensitive comparer,
      // based on the InvariantCulture.
      Hashtable myHT3 = new Hashtable( CaseInsensitiveHashCodeProvider.DefaultInvariant, CaseInsensitiveComparer.DefaultInvariant );
      myHT3.Add("FIRST", "Hello");
      myHT3.Add("SECOND", "World");
      myHT3.Add("THIRD", "!");

      // Create a Hashtable using a case-insensitive code provider and a case-insensitive comparer,
      // based on the Turkish culture (tr-TR), where "I" is not the uppercase version of "i".
      CultureInfo myCul = new CultureInfo( "tr-TR" );
      Hashtable myHT4 = new Hashtable( new CaseInsensitiveHashCodeProvider( myCul ), new CaseInsensitiveComparer( myCul ) );
      myHT4.Add("FIRST", "Hello");
      myHT4.Add("SECOND", "World");
      myHT4.Add("THIRD", "!");

      // Search for a key in each hashtable.
      Console.WriteLine( "first is in myHT1: {0}", myHT1.ContainsKey( "first" ) );
      Console.WriteLine( "first is in myHT2: {0}", myHT2.ContainsKey( "first" ) );
      Console.WriteLine( "first is in myHT3: {0}", myHT3.ContainsKey( "first" ) );
      Console.WriteLine( "first is in myHT4: {0}", myHT4.ContainsKey( "first" ) );

   }

}


/* 
This code produces the following output.  Results vary depending on the system's culture settings.

first is in myHT1: False
first is in myHT2: True
first is in myHT3: True
first is in myHT4: False

*/

// </Snippet1>

