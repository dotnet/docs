---
title: "How to: use DataContractJsonSerializer"
ms.date: "03/25/2019"
ms.assetid: 88abc1fb-8196-4ee3-a23b-c6934144d1dd
---
# How to use DataContractJsonSerializer

> [!NOTE]
> This article is about <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer>. For most scenarios that involve serializing and deserializing JSON, we recommend the tools in the [System.Text.Json namespace](../../../standard/serialization/system-text-json-overview.md).

JSON (JavaScript Object Notation) is an efficient data encoding format that enables fast exchanges of small amounts of data between client browsers and AJAX-enabled Web services.

This article demonstrates how to serialize .NET type objects into JSON-encoded data and then deserialize data in the JSON format back into instances of .NET types. This example uses a data contract to demonstrate serialization and deserialization of a user-defined `Person` type and uses <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer>.

Normally, JSON serialization and deserialization are handled automatically by Windows Communication Foundation (WCF) when you use data contract types in service operations that are exposed over AJAX-enabled endpoints. However, in some cases you may need to work with JSON data directly.

This article is based on the [DataContractJsonSerializer sample](../samples/json-serialization.md).

## To define the data contract for a Person type

1. Define the data contract for `Person` by attaching the <xref:System.Runtime.Serialization.DataContractAttribute> to the class and <xref:System.Runtime.Serialization.DataMemberAttribute> attribute to the members you want to serialize. For more information about data contracts, see [Designing service contracts](../designing-service-contracts.md).

    ```csharp
    [DataContract]
    internal class Person
    {
        [DataMember]
        internal string name;

        [DataMember]
        internal int age;
    }
    ```

## To serialize an instance of type Person to JSON

> [!NOTE]
> If an error occurs during serialization of an outgoing reply on the server or for some other reason, it may not get returned to the client as a fault.

1. Create an instance of the `Person` type.

    ```csharp
    var p = new Person();
    p.name = "John";
    p.age = 42;
    ```

2. Serialize the `Person` object to a memory stream by using the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer>.

    ```csharp
    var stream1 = new MemoryStream();
    var ser = new DataContractJsonSerializer(typeof(Person));
    ```

3. Use the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer.WriteObject%2A> method to write JSON data to the stream.

    ```csharp
    ser.WriteObject(stream1, p);
    ```

4. Show the JSON output.

    ```csharp
    stream1.Position = 0;
    var sr = new StreamReader(stream1);
    Console.Write("JSON form of Person object: ");
    Console.WriteLine(sr.ReadToEnd());
    ```

## To deserialize an instance of type Person from JSON

1. Deserialize the JSON-encoded data into a new instance of `Person` by using the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer.ReadObject%2A> method of the <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer>.

    ```csharp
    stream1.Position = 0;
    var p2 = (Person)ser.ReadObject(stream1);
    ```

2. Show the results.

    ```csharp
    Console.WriteLine($"Deserialized back, got name={p2.name}, age={p2.age}");
    ```

## Example

```csharp
// Create a User object and serialize it to a JSON stream.
public static string WriteFromObject()
{
    // Create User object.
    var user = new User("Bob", 42);

    // Create a stream to serialize the object to.
    var ms = new MemoryStream();

    // Serializer the User object to the stream.
    var ser = new DataContractJsonSerializer(typeof(User));
    ser.WriteObject(ms, user);
    byte[] json = ms.ToArray();
    ms.Close();
    return Encoding.UTF8.GetString(json, 0, json.Length);
}

// Deserialize a JSON stream to a User object.
public static User ReadToObject(string json)
{
    var deserializedUser = new User();
    var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
    var ser = new DataContractJsonSerializer(deserializedUser.GetType());
    deserializedUser = ser.ReadObject(ms) as User;
    ms.Close();
    return deserializedUser;
}
```

> [!NOTE]
> The JSON serializer throws a serialization exception for data contracts that have multiple members with the same name, as shown in the following sample code.

```csharp
[DataContract]
public class TestDuplicateDataBase
{
    [DataMember]
    public int field1 = 123;
}

[DataContract]
public class TestDuplicateDataDerived : TestDuplicateDataBase
{
    [DataMember]
    public new int field1 = 999;
}
```

## See also

- [JSON serialization in .NET](../../../standard/serialization/system-text-json-overview.md)
