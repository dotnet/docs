---
title: "BinaryFormatter Migration Guide: Migrating Persisted Payloads"
description: "Managing the migration of payloads that were persisted using BinaryFormatter."
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

# Migrating payloads persisted using BinaryFormatter

**Do you own any data that was serialized with `BinaryFormatter` and persisted**? Sample scenarios that typically don't include persisting the payload:
- Deep object cloning (allocate a stream, serialize to it, seek to the beginning of the stream, deserialize from it and return deserialized instance).
- Testing whether given type is serializable.

A scenario where it depends, is inter-process communication. If you own all the processes and can migrate them at the same time, you don't need to read the binary format payload. However, if you own only one side (example: you expose a backend that accepts requests from 3rd party clients), or you can not shut down all the processes to perform the migration, you need to read it.

**If you don't need to read the payload, you can skip this paragraph**.

### Identifying if a payload was created using BinaryFormatter

For now, we can simplify the process and assume that for the time of migration from `BinaryFormatter`, the app should do the following:

- Check if the payload read from storage is a binary formatter payload.
- If so, read it with `PayloadReader`, serialize back with a new serializer and overwrite the data in the storage.
- If not, use the new serializer to deserialize the data.

`PayloadReader` provides two `ContainsBinaryFormatterPayload` methods that allow to **check whether given stream or buffer contains binary formatter payload**. The `Stream` overload resets the stream position to the initial value, but both more or less check the first and last bytes.

```cs
static T Pseudocode<T>(Stream payload, NewSerializer newSerializer)
{
    if (PayloadReader.ContainsBinaryFormatterPayload(payload))
    {
        T fromPayload = UseThePayloadReaderToReadTheData<T>(payload);

        payload.Seek(0, SeekOrigin.Begin);
        newSerializer.Serialize(payload, fromPayload);
        payload.Flush();
    }
    else
    {
        return newSerializer.Deserialize<T>(payload)
    }
}
```

### Safely reading persisted BinaryFormatter payloads

`PayloadReader` can read any payload that was serialized with `BinaryFormatter` (except of types specific to **remoting** which were never ported to .NET (Core)). 

`PayloadReader` is following these principles to read from **untrusted input**:
- Treating every input as potentially hostile.
- No type loading of any kind (to avoid remote code execution).
- No recursion of any kind (to avoid unbound recursion, stack overflow and denial of service).
- No buffer pre-allocation based on size provided in payload (to avoid running out of memory and denial of service).
- Using collision-resistant dictionary to store records referenced by other records.
- Only primitive types can be instantiated in implicit way. Arrays can be instantiated on demand (with a default max size limit). Other types are never instantiated.

The Binary Formatter payload consists of serialization records that represent the serialized objects and their metadata. To read the whole payload and get the root object, the user need to call `static SerializationRecord Read(Stream payload, bool leaveOpen = false)` method (TODO: add option bag when we have it). There is more than a dozen of different serialization [record types](https://learn.microsoft.com/openspecs/windows_protocols/ms-nrbf/954a0657-b901-4813-9398-4ec732fe8b32), but this library provides a set of abstractions, so the users need to learn only a few of them:
- `PrimitiveTypeRecord<T>` that describes all primitive types natively supported by the Binary Format (`string`, `bool`, `char`, `byte`, `sbyte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `float`, `double`, `decimal`, `TimeSpan`, `DateTime`)
- `ClassRecord` that describes all `class` and `struct`  beside the formentioned primitive types.
- `ArrayRecord<T>` that describes single-dimension array records, where `T` can be either a primitive type or `ClassRecord`.
- `ArrayRecord` that describes all array records including jagged and multi-dimensional arrays.

```cs
SerializationRecord rootObject = PayloadReader.Read(payload); // payload is a Stream

if (rootObject is PrimitiveTypeRecord<string> stringRecord)
{
    Console.WriteLine($"It was a string: '{stringRecord.Value}'");
}
else if (rootObject is ClassRecord classRecord)
{
    Console.WriteLine($"It was a class record of '{classRecord.TypeName}' type.");
}
else if (rootObject is ArrayRecord<byte> arrayOfBytes)
{
    Console.WriteLine($"It was an array of bytes: '{string.Join(",", arrayOfBytes.ToArray())}'");
}
```

Beside `Read`, the `PayloadReader` exposes a `ReadClassRecord` method that returns `ClassRecord` (or throws).

The most important type that derives from `SerializationRecord` is `ClassRecord` which represents **all `class` and `struct` instances beside arrays and selected primitive types**.

```cs
public class ClassRecord : SerializationRecord
{
    public string TypeName { get; }
    public string LibraryName { get; }
    public IEnumerable<string> MemberNames { get; }

    // Checks if member of given name was present in the payload (useful for versioning scenarios)
    public bool HasMember(string memberName);
    
    // Retrieves the value of the provided memberName
    public string? GetString(string memberName);
    public bool GetBoolean(string memberName);
    public byte GetByte(string memberName);
    public sbyte GetSByte(string memberName);
    public short GetInt16(string memberName);
    public ushort GetUInt16(string memberName);
    public char GetChar(string memberName);
    public int GetInt32(string memberName);
    public uint GetUInt32(string memberName);
    public float GetSingle(string memberName);
    public long GetInt64(string memberName);
    public ulong GetUInt64(string memberName);
    public double GetDouble(string memberName);
    public decimal GetDecimal(string memberName);
    public TimeSpan GetTimeSpan(string memberName);
    public DateTime GetDateTime(string memberName);
    public object? GetObject(string memberName);

    // Retrieves an array for the provided memberName, with default max length
    public T[]? GetArrayOfPrimitiveType<T>(string memberName, int maxLength = 64000) where T : unmanaged;

    // Retrieves an instance of ClassRecord that describes non-primitive type for the provided memberName
    public ClassRecord? GetClassRecord(string memberName);
    // Retrieves any other serialization record like jagged array or array of complex types
    public SerializationRecord? GetSerializationRecord(string memberName);
}
```

`Get$PrimitiveType` methods read a value of given primitive type.
`GetArrayOfPrimitiveType<T>` methods read arrays of values of given primitive type.
`GetClassRecord` method reads an instance of `ClassRecord` that describes non-primitive type like a custom `class` or `struct`.

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
