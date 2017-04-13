// <Snippet1>
using System;
using System.Collections.Generic;

public class Example
{
    static void Main()
    {
        Console.WriteLine("\r\nInterfaces implemented by Dictionary<int, string>:\r\n");
        
        foreach (Type tinterface in typeof(Dictionary<int, string>).GetInterfaces())
        {
            Console.WriteLine(tinterface.ToString());
        }

        //Console.ReadLine()      // Uncomment this line for Visual Studio. 
    }
}

/* This example produces output similar to the following:

Interfaces implemented by Dictionary<int, string>:

System.Collections.Generic.IDictionary`2[System.Int32,System.String]
System.Collections.Generic.ICollection`1[System.Collections.Generic.KeyValuePair`2[System.Int32,System.String]]
System.Collections.Generic.IEnumerable`1[System.Collections.Generic.KeyValuePair`2[System.Int32,System.String]]
System.Collection.IEnumerable
System.Collection.IDictionary
System.Collection.ICollection
System.Runtime.Serialization.ISerializable
System.Runtime.Serialization.IDeserializationCallback
 */
// </Snippet1>

       