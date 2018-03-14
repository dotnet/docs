// <Snippet1>
using namespace System;
using namespace System::Collections::Generic;

void main()
{
    Console::WriteLine("\r\nInterfaces implemented by Dictionary<int, String^>:\r\n");
     
    for each (Type^ tinterface in Dictionary<int, String^>::typeid->GetInterfaces())
    {
        Console::WriteLine(tinterface->ToString());
    }

    //Console::ReadLine()      // Uncomment this line for Visual Studio. 
}

/* This example produces output similar to the following:

Interfaces implemented by Dictionary<int, String^>:

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
