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

`NrbfDecoder` is part of the new [System.Formats.Nrbf](https://www.nuget.org/packages/System.Formats.Nrbf) NuGet package. It targets not only .NET 9, but also older monikers like .NET Standard 2.0 and .NET Framework. Which makes it possible for everyone who uses a supported version of .NET to migrate away from `BinaryFormatter`.

`NrbfDecoder` can read any payload that was serialized with `BinaryFormatter` using `FormatterTypeStyle.TypesAlways` (the default).
`NrbfDecoder` cannot be used for the output of BinaryFormatter for any other `FormatterTypeStyle`.

Only non-zero indexed arrays and types specific to remoting (which were never ported to .NET (Core)) are **not supported**.

`NrbfDecoder` is designed to treat all input as untrusted. As such it has these principles:

- No type loading of any kind (to avoid risks such as remote code execution).
- No recursion of any kind (to avoid unbound recursion, stack overflow and denial of service).
- No buffer pre-allocation based on size provided in the payload, if the payload is too small to contain the promised data (to avoid running out of memory and denial of service).
- Decoding every part of the input only once (to perform the same amount of work as the potential attacker who created the payload).
- Using collision-resistant randomized hashing to store records referenced by other records (to avoid running out of memory for dictionary backed by an array which size depends on the number of hash code collisions).
- Only primitive types can be instantiated in an implicit way. Arrays can be instantiated on demand. Other types are never instantiated.

### Deserializing a closed set of types

`NrbfDecoder` is mostly useful only when the list of serialized types is a known, closed set. Or put it otherwise, you need to know up front what you want to read, because at the end of the day you also need to create instances of these types and populate them with data that was read from the payload. Let's consider two opposite examples.

All `[Serializable]` types from [Quartz.NET](https://github.com/search?q=repo%3Aquartznet%2Fquartznet+%5BSerializable%5D+language%3AC%23&type=code&l=C%23) that can be persisted by the library itself are `sealed`, so there are no custom types that the users could create and the payload can contain only known types. They also provide public constructors, so it is possible to re-create these types based on the information read from payload.

`SettingsPropertyValue` type from `System.Configuration.ConfigurationManager` library exposes an `object PropertyValue` that may internally use `BinaryFormatter` to serialize and deserialize any object that was stored in the configuration file. It could be used to store an integer, a custom type, a dictionary or literally anything.  Because of that, **it is impossible to migrate this library without introducing breaking changes to the API**.

### Identifying BinaryFormatter payload

`NrbfDecoder` provides two `StartsWithPayloadHeader` methods that allow to check whether given stream or buffer starts with NRBF header.

Using these methods is recommended for the period of migrating payloads persisted with `BinaryFormatter` to a [different serializer](./choosing-a-serializer.md):

- Check if the payload read from storage is an [NRBF](/openspecs/windows_protocols/ms-nrbf/75b9fe09-be15-475f-85b8-ae7b7558cfe5) payload.
- If so, read it with `NrbfDecoder`, serialize it back with a new serializer and overwrite the data in the storage.
- If not, use the new serializer to deserialize the data.

```cs
internal static T LoadFromFile<T>(string path)
{
    bool update = false;
    T value;

    using (FileStream stream = File.OpenRead(path))
    {
        if (NrbfDecoder.StartsWithPayloadHeader(stream))
        {
            value = LoadLegacyValue<T>(stream);
            update = true;
        }
        else
        {
            value = LoadNewValue<T>(stream);
        }
    }

    if (update)
    {
        File.WriteAllBytes(path, NewSerializer(value));
    }

    return value;
}
```

### Safely reading NRBF payloads

The NRBF payload consists of serialization records that represent the serialized objects and their metadata. To read the whole payload and get the root object, the user needs to call the `Decode` method.

The `Decode` method returns a `SerializationRecord` instance. `SerializationRecord` is an abstract class that represents the serialization record and provides three self-describing properties: `Id`, `RecordType` and `TypeName`. It exposes one method: `public bool TypeNameMatches(Type type)` which compares the type name read from the payload (and exposed via `TypeName` property) against the specified type. This method ignores assembly names, so the users don't need to worry about type forwarding and assembly versioning. It also does not consider member names or their types (because getting this information would require type loading).

```cs
using System.Formats.Nrbf;

static T Pseudocode<T>(Stream payload)
{
    SerializationRecord record = NrbfDecoder.Read(payload);
    if (!record.TypeNameMatches(typeof(T))
    {
        throw new Exception($"Expected the record to match type name `{typeof(T).AssemblyQualifiedName}`, but got `{record.TypeName.AssemblyQualifiedName}`."
    }
}
```

There are more than a dozen of different serialization [record types](/openspecs/windows_protocols/ms-nrbf/954a0657-b901-4813-9398-4ec732fe8b32), but this library provides a set of abstractions, so the users need to learn only a few of them:

- `PrimitiveTypeRecord<T>`: describes all primitive types natively supported by the NRBF (`string`, `bool`, `byte`, `sbyte`, `char`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `float`, `double`, `decimal`, `TimeSpan` and `DateTime`)
  - exposes the value via the `Value` property.
  - `PrimitiveTypeRecord<T>` derives from the non-generic `PrimitiveTypeRecord` which also exposes has a `Value` property, but on the base class it is returned as `object` (which introduces boxing for value types).
- `ClassRecord`: describes all `class` and `struct` besides the aforementioned  primitive types.
- `SZArrayRecord<T>`: that describes single-dimensional, zero-indexed array records, where `T` can be either a primitive type or a `ClassRecord`.
- `ArrayRecord`: that describes all array records including jagged and multi-dimensional arrays.

```cs
SerializationRecord rootObject = NrbfDecoder.Decode(payload); // payload is a Stream

if (rootObject is PrimitiveTypeRecord primitiveRecord)
{
    Console.WriteLine($"It was a primitive value: '{primitiveRecord.Value}'");
}
else if (rootObject is ClassRecord classRecord)
{
    Console.WriteLine($"It was a class record of '{classRecord.TypeName.AssemblyQualifiedName}' type name.");
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

ClassRecord rootRecord = NrbfDecoder.DecodeClassRecord(payload);
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
- `Lengths` which get a buffer of integers that represent the number of elements in every dimension.

And one method: `GetArray`. When used for the fist time, it allocates an array and fills it with the data provided in the serialized records (in case of the natively supported primitive types like `string` or `int`) or the serialized records themselves in case of arrays of complex types.

`GetArray` requires a mandatory argument that specifies the type of the expected array. Example: if the record should be a 2D array of integers the `expectedArrayType` must be provided as `typeof(int[,])` and the returned array is also `int[,]`:

```cs
ArrayRecord arrayRecord = (ArrayRecord)NrbfDecoder.Decode(stream);
int[,] array2d = (int[,])arrayRecord.GetArray(typeof(int[,]));
```

If there is a type mismatch (example: the attacker has provided a payload with an array of two billion strings), the method throws `InvalidOperationException`.

`NrbfDecoder` does not load or instantiate any custom types, so in case of arrays of complex types, it returns an array of `ClassRecord`.

```cs
[Serializable]
public class ComplexType3D
{
    public int I, J, K;
}

ArrayRecord arrayRecord = (ArrayRecord)NrbfDecoder.Decode(payload);
ClassRecord[] records = (ClassRecord[])arrayRecord.GetArray(expectedArrayType: typeof(ComplexType3D[]));
ComplexType3D[] output = records.Select(classRecord => new ComplexType3D()
{
    I = classRecord.GetInt32(nameof(ComplexType3D.I)),
    J = classRecord.GetInt32(nameof(ComplexType3D.J)),
    K = classRecord.GetInt32(nameof(ComplexType3D.K)),
}).ToArray();

```

#### SZArrayRecord

`SZArrayRecord<T>` defines the core behavior for NRBF single dimensional, zero-indexed array records and provides a base for derived classes. The `T` can be one of the natively supported primitive types or `ClassRecord`.

It provides `Length` property and a `GetArray` overload that returns `T[]`.

```cs
[Serializable]
public class PrimitiveArrayFields
{
    public byte[]? Bytes;
    public uint[]? UnsignedIntegers;
}

ClassRecord rootRecord = NrbfDecoder.DecodeClassRecord(payload);
SZArrayRecord<byte> bytes = (SZArrayRecord<byte>)rootRecord.GetArrayRecord(nameof(PrimitiveArrayFields.Bytes));
SZArrayRecord<uint> uints = (SZArrayRecord<uint>)rootRecord.GetArrayRecord(nameof(PrimitiveArrayFields.UnsignedIntegers));
if (bytes.Length > 100_000 || uints.Length > 100_000)
{
    throw new Exception("The array exceeded our limit");
}

PrimitiveArrayFields output = new()
{
    Bytes = bytes.GetArray(),
    UnsignedIntegers = uints.GetArray()
};
```
