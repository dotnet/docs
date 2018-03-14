// The following code example enumerates the elements of a StringDictionary.

// <snippet2>
using System;
using System.Collections;
using System.Collections.Specialized;

public class SamplesStringDictionary
{
    public static void Main()
    {
        // Creates and initializes a new StringDictionary.
        StringDictionary myCol = new StringDictionary();
        myCol.Add( "red", "rojo" );
        myCol.Add( "green", "verde" );
        myCol.Add( "blue", "azul" );

        Console.WriteLine("VALUES");
        foreach (string val in myCol.Values)
        {
            Console.WriteLine(val);
        }
    }
}
// This code produces the following output.
// VALUE
// verde
// rojo
// azul
// </snippet2>
