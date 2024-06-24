---
title: "BinaryFormatter Migration Guide: Reading NRBF Payloads"
description: "Reading the payloads that were created using BinaryFormatter."
ms.date: 5/31/2024
no-loc: [BinaryFormatter, Serialization]
dev_langs:
  - CSharp
  - VB
helpviewer_keywords:
  - "BinaryFormatter"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
---

# Reading NRBF payloads

## NrbfDecoder

`NrbfDecoder` is part of the new [System.Formats.Nrbf](https://www.nuget.org/packages/System.Formats.Nrbf) NuGet package. It targets not only .NET 9, but also older monikers like .NET Standard 2.0 and .NET Framework. Which **makes it possible for everyone who uses a supported version of .NET to migrate away from `BinaryFormatter`**.

`NrbfDecoder` can read any payload that was serialized with `BinaryFormatter` and `FormatterTypeStyle.TypesAlways`. `FormatterTypeStyle.TypesAlways` is the default setting that forces BF to emit full type information and does not require any type loading when reading the payload. Which means that `FormatterTypeStyle.TypesWhenNeeded` is not supported.

Only non-zero indexed arrays and types specific to remoting (which were never ported to .NET (Core)) are **not supported**. 

`NrbfDecoder` is following these principles to read from **untrusted input**:
- Treating every input as potentially hostile.
- No type loading of any kind (to avoid remote code execution).
- No recursion of any kind (to avoid unbound recursion, stack overflow and denial of service).
- No buffer pre-allocation based on size provided in the payload, if the payload is too small to contain the promised data (to avoid running out of memory and denial of service).
- Decoding every part of the input only once (to perform the same amout of work as the potential attacker who created the payload).
- Using collision-resistant randomized hashing to store records referenced by other records (to avoid running out of memory for dictionary backed by an array which size depends on the number of hash code collisions).
- Only primitive types can be instantiated in implicit way. Arrays can be instantiated on demand. Other types are never instantiated.

### Identifying BinaryFormatter payload

`NrbfDecoder` provides two `StartsWithPayloadHeader` methods that allow to **check whether given stream or buffer starts with NRBF header**. 

Using these methods is recommeded for the period of migrating payloads persisted with `BinaryFormatter` to a [different serializer](./choosing-a-serializer.md):
- Check if the payload read from storage is an [NRBF](https://learn.microsoft.com/openspecs/windows_protocols/ms-nrbf/75b9fe09-be15-475f-85b8-ae7b7558cfe5) payload.
- If so, read it with `NrbfDecoder`, serialize back with a new serializer and overwrite the data in the storage.
- If not, use the new serializer to deserialize the data.

### Safely reading NRBF payloads

The NRBF payload consists of serialization records that represent the serialized objects and their metadata. To read the whole payload and get the root object, the user needs to call the `Decode` method.

The `Decode` method returns an `SerializationRecord` instance. `SerializationRecord` is an abstract class that represents the serialization record and provides three self-describing properties: `Id`, `RecordType` and `TypeName`. It exposes one method: `public bool TypeNameMatches(Type type)` which compares the type name read from the payload (and exposed via `TypeName` property) against the specified type. This method ignores assembly names so the users don't need to worry about type forwarding and assembly versioning. It also does not take into account member names or their types (because getting this information would require type loading).

```cs
using System.Formats.Nrbf;

static T Pseudocode<T>(Stream payload)
{
    SerializationRecord record = NrbfDecoder.Read(payload);
    if (!record.TypeNameMatches(typeof(T))
    {
        throw new Exception($"Expected the record to represent type `{typeof(T).AssemblyQualifiedName}`, but got `{record.TypeName.AssemblyQualifiedName}`."
    }
}
```


There is more than a dozen of different serialization [record types](https://learn.microsoft.com/openspecs/windows_protocols/ms-nrbf/954a0657-b901-4813-9398-4ec732fe8b32), but this library provides a set of abstractions, so the users need to learn only a few of them:
- `PrimitiveTypeRecord<T>` that describes all primitive types natively supported by the NRBF (`string`, `bool`, `byte`, `sbyte`, `char`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `float`, `double`, `decimal`, `TimeSpan` and `DateTime`) and exposes the value `Value` getter. `PrimitiveTypeRecord<T>` derives from non-generic `PrimitiveTypeRecord` which also exposes the raw value via `Value` property, but it's returned as `object` (which introduces boxing for value types).
- `ClassRecord` that describes all `class` and `struct`  beside the formentioned primitive types.
- `SZArrayRecord<T>` that describes single-dimension, zero-indexed array records, where `T` can be either a primitive type or a `ClassRecord`.
- `ArrayRecord` that describes all array records including jagged and multi-dimensional arrays.

```cs
SerializationRecord rootObject = NrbfDecoder.Decode(payload); // payload is a Stream

if (rootObject is PrimitiveTypeRecord primitiveRecord)
{
    Console.WriteLine($"It was a primitive value: '{primitiveRecord.Value}'");
}
else if (rootObject is ClassRecord classRecord)
{
    Console.WriteLine($"It was a class record of '{classRecord.TypeName}' type.");
}
else if (rootObject is SZArrayRecord<byte> arrayOfBytes)
{
    Console.WriteLine($"It was an array of `{arrayOfBytes.Length}`-many bytes.");
}
```

Beside `Decode`, the `NrbfDecoder` exposes a `DecodeClassRecord` method that returns `ClassRecord` (or throws).

#### ClassRecord

The most important type that derives from `SerializationRecord` is `ClassRecord` which represents **all `class` and `struct` instances beside arrays and natively supported primitive types**. It allows to read all member names and values. It's recommended to read the [BinaryFormatter functionality reference](./functionality-reference.md) to understand what *member* is.

The API it provides:
- `MemberNames` property that gets the names of serialized members.
- `HasMember` method that checks if member of given name was present in the payload. It was designed for handling versioning scenarios where given member could have been renamed.
- A set of dedicated methods for retrieving primitive values of the provided member name: `GetString`, `GetBoolean`, `GetByte`, `GetSByte`, `GetChar`, `GetInt16`, `GetUInt16`, `GetInt32`, `GetUInt32`, `GetInt64`, `GetUInt64`, `GetSingle`, `GetDouble`, `GetDecimal`, `GetTimeSpan` and `GetDateTime`.
- `GetClassRecord` and `GetArrayRecord` methods to retrieve instance of given record types.
- `GetSerializationRecord` to retrieve any serialization record and `GetRawValue` to retrieve any serialization record or a raw primitive value.

Let's see it in action:

```cs
[Serializable]
public class Sample
{
    public int Integer;
    public string? Text;
    public byte[]? ArrayOfBytes;
    public Sample? ClassInstance;
}

ClassRecord rootRecord = NrbfDecoder.ReadClassRecord(payload);
Sample output = new()
{
    // using the dedicated methods to read primitive values
    Integer = rootRecord.GetInt32(nameof(Sample.Integer)),
    Text = rootRecord.GetString(nameof(Sample.Text)),
    // using dedicated method to read an array of bytes
    ArrayOfBytes = ((SZArrayRecord<byte>)rootRecord.GetArrayRecord(nameof(Sample.ArrayOfBytes))).GetArray(),
    // using GetClassRecord to read a class record
    ClassInstance = new()
    {
        Text = rootRecord
            .GetClassRecord(nameof(Sample.ClassInstance))!
            .GetString(nameof(Sample.Text))
    }  
};
```

#### ArrayRecord

`ArrayRecord` defines the core behavior for NRBF array records and provides a base for derived classes. It provides two properties:
- `Rank` which gets the rank of the array.
- `Lengths` which gets a buffer of integers that represent the number of elements in every dimension.

TODO: GetArray and SZArrayRecord.


### Deserializing a closed set of types

`PayloadReader` is mostly useful only when the list of serialized types is a known, closed set. Or put it otherwise, you need to know up front what you want to read, because at the end of the day you also need to create instances of these types and populate them with data that was read from the payload. Let's consider two opposite examples.

All `[Serializable]` types from [Quartz.NET](https://github.com/search?q=repo%3Aquartznet%2Fquartznet+%5BSerializable%5D+language%3AC%23&type=code&l=C%23) that can be persisted by the library itself are `sealed`, so there are no custom types that the users could create and the payload can contain only known types. They also provide public constructors, so it is possible to re-create these types based on the information read from payload.

`SettingsPropertyValue` type from `System.Configuration.ConfigurationManager` library exposes an `object PropertyValue` that may internally use `BinaryFormatter` to serialize and deserialize any object that was stored in the configuration file. It could be used to store an integer, a custom type, a dictionary or literally anything.  Because of that, **it is impossible to migrate this library without introducing breaking changes to the API, as the payload can contain anything**.

```cs
[Serializable]
public sealed class TimeOfDay
{
    public readonly int Hour, Minute, Second;

    public TimeOfDay(int hour, int minute, int second);
}

[Serializable]
public sealed class CronExpression : ISerializable
{
    private readonly string cronExpression;

    public CronExpression(string cronExpression);
}

private static T Deserialize<T>(Stream payload)
{
    ClassRecord rootRecord = PayloadReader.ReadClassRecord(payload);
    if (rootRecord.IsTypeNameMatching(typeof(T)))
    {
        throw new InvalidOperationException("Payload contained unexpected data");
    }

    if (rootRecord.IsTypeNameMatching(typeof(TimeOfDay)))
    {
        return (T)(object)new TimeOfDay(
            rootRecord.GetInt32("Hour"),
            rootRecord.GetInt32("Minut"),
            rootRecord.GetInt32("Second")
        );
    }
    else if (rootRecord.IsTypeNameMatching(typeof(CronExpression)))
    {
        return (T)(object)new CronExpression(rootRecord.GetString("cronExpression")!);
    }
    else
    {
        throw new NotSupportedException();
    }    
}
```
