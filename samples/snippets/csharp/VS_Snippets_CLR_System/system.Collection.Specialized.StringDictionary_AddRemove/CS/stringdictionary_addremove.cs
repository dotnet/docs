// The following code example demonstrates how to add and remove elements from a StringDictionary.

// <snippet1>
using System;
using System.Collections;
using System.Collections.Specialized;

public class SamplesStringDictionary  {

   public static void Main()  {

      // Creates and initializes a new StringDictionary.
      StringDictionary myCol = new StringDictionary();
      myCol.Add( "red", "rojo" );
      myCol.Add( "green", "verde" );
      myCol.Add( "blue", "azul" );

      // Displays the values in the StringDictionary.
      Console.WriteLine( "Initial contents of the StringDictionary:" );
      PrintKeysAndValues( myCol );

      // Deletes an element.
      myCol.Remove( "green" );
      Console.WriteLine( "The collection contains the following elements after removing \"green\":" );
      PrintKeysAndValues( myCol );

      // Clears the entire collection.
      myCol.Clear();
      Console.WriteLine( "The collection contains the following elements after it is cleared:" );
      PrintKeysAndValues( myCol );

   }

   public static void PrintKeysAndValues( StringDictionary myCol )  {
      Console.WriteLine( "   KEY        VALUE" );
      foreach ( DictionaryEntry de in myCol )
         Console.WriteLine( "   {0,-10} {1}", de.Key, de.Value );
      Console.WriteLine();
   }

}

/*
This code produces the following output.

Initial contents of the StringDictionary:
   KEY        VALUE
   green      verde
   red        rojo
   blue       azul

The collection contains the following elements after removing "green":
   KEY        VALUE
   red        rojo
   blue       azul

The collection contains the following elements after it is cleared:
   KEY        VALUE

*/
// </snippet1>
