---
title: "BinaryFormatter migration guide: Read BinaryFormatter (NRBF) payloads"
description: "Safely read payloads created by BinaryFormatter in '.NET Remoting: Binary Format (NRBF).'"
ms.date: 5/31/2024
no-loc: [BinaryFormatter, Serialization]
dev_langs:
  - CSharp
helpviewer_keywords:
  - "BinaryFormatter"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
---

# Read BinaryFormatter (NRBF) payloads

[BinaryFormatter] used the [.NET Remoting: Binary Format](/openspecs/windows_protocols/ms-nrbf/) for serialization. This format is known by its abbreviation of MS-NRBF or just NRBF. A common challenge involved in migrating from [BinaryFormatter] is dealing with payloads persisted to storage as reading these payloads previously required [BinaryFormatter]. Some systems need to retain the ability to read these payloads for gradual migrations to new serializers while avoiding a reference to [BinaryFormatter] itself.

As part of .NET 9, a new [NrbfDecoder] class was introduced to decode NRBF payloads without performing _deserialization_ of the payload. This API can safely be used to decode trusted or untrusted payloads without any of the risks that [BinaryFormatter] deserialization carries. However, [NrbfDecoder] merely decodes the data into structures an application can further process. Care must be taken when using [NrbfDecoder] to safely load the data into the appropriate instances.

> [!CAUTION]
> [NrbfDecoder] is _an_ implementation of an NRBF reader, but its behaviors don't strictly follow [BinaryFormatter]'s implementation. Thus you shouldn't use the output of [NrbfDecoder] to determine whether a call to [BinaryFormatter] would be safe.

You can think of <xref:System.Formats.Nrbf.NrbfDecoder> as being the equivalent of using a JSON/XML reader without the deserializer.

## NrbfDecoder

[NrbfDecoder] is part of the new [System.Formats.Nrbf](https://www.nuget.org/packages/System.Formats.Nrbf) NuGet package. It targets not only .NET 9, but also older monikers like .NET Standard 2.0 and .NET Framework. That multi-targeting makes it possible for everyone who uses a supported version of .NET to migrate away from [BinaryFormatter]. [NrbfDecoder] can read payloads that were serialized with [BinaryFormatter] using <xref:System.Runtime.Serialization.Formatters.FormatterTypeStyle.TypesAlways?displayProperty=nameWithType> (the default).

[NrbfDecoder] is designed to treat all input as untrusted. As such it has these principles:

- No type loading of any kind (to avoid risks such as remote code execution).
- No recursion of any kind (to avoid unbound recursion, stack overflow, and denial of service).
- No buffer pre-allocation based on size provided in the payload, if the payload is too small to contain the promised data (to avoid running out of memory and denial of service).
- Decode every part of the input only once (to perform the same amount of work as the potential attacker who created the payload).
- Use collision-resistant randomized hashing to store records referenced by other records (to avoid running out of memory for dictionary backed by an array whose size depends on the number of hash-code collisions).
- Only primitive types can be instantiated in an implicit way. Arrays can be instantiated on demand. Other types are never instantiated.

> [!CAUTION]
> When using [NrbfDecoder], it's important not to reintroduce those capabilities in general-purpose code, as doing so would negate these safeguards.

### Deserialize a closed set of types

[NrbfDecoder] is useful only when the list of serialized types is a known, closed set. To put it another way, you need to know up front what you want to read, because you also need to create instances of those types and populate them with data that was read from the payload. Consider two opposite examples:

- All `[Serializable]` types from [Quartz.NET](https://github.com/search?q=repo%3Aquartznet%2Fquartznet+%5BSerializable%5D+language%3AC%23&type=code&l=C%23) that can be persisted by the library itself are `sealed`. So there are no custom types that users could create, and the payload can contain only known types. The types also provide public constructors, so it's possible to recreate these types based on the information read from the payload.
- The <xref:System.Configuration.SettingsPropertyValue> type exposes the property <xref:System.Configuration.SettingsPropertyValue.PropertyValue> of type `object` that might internally use [BinaryFormatter] to serialize and deserialize any object that was stored in the configuration file. It could be used to store an integer, a custom type, a dictionary, or literally anything.  Because of that, **it's impossible to migrate this library without introducing breaking changes to the API**.

### Identify NRBF payloads

[NrbfDecoder] provides two <xref:System.Formats.Nrbf.NrbfDecoder.StartsWithPayloadHeader*> methods that let you check whether a given stream or buffer starts with the NRBF header. It's recommended to use these methods when you're migrating payloads persisted with [BinaryFormatter] to a [different serializer](./choose-a-serializer.md):

- Check if the payload read from storage is an [NRBF](/openspecs/windows_protocols/ms-nrbf/) payload with <xref:System.Formats.Nrbf.NrbfDecoder.StartsWithPayloadHeader*?displayProperty=nameWithType>.
- If so, read it with <xref:System.Formats.Nrbf.NrbfDecoder.Decode*?displayProperty=nameWithType>, serialize it back with a new serializer, and overwrite the data in the storage.
- If not, use the new serializer to deserialize the data.

```csharp
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

### Safely read NRBF payloads

The NRBF payload consists of serialization records that represent the serialized objects and their metadata. To read the whole payload and get the root object, you need to call the <xref:System.Formats.Nrbf.NrbfDecoder.Decode*> method.

The <xref:System.Formats.Nrbf.NrbfDecoder.Decode*> method returns a <xref:System.Formats.Nrbf.SerializationRecord> instance. <xref:System.Formats.Nrbf.SerializationRecord> is an abstract class that represents the serialization record and provides three self-describing properties: <xref:System.Formats.Nrbf.SerializationRecord.Id>, <xref:System.Formats.Nrbf.SerializationRecord.RecordType>, and <xref:System.Formats.Nrbf.SerializationRecord.TypeName>.

> [!NOTE]
> An attacker could create a payload with cycles (example: class or an array of objects with a reference to itself). The <xref:System.Formats.Nrbf.SerializationRecord.Id> returns an instance of <xref:System.Formats.Nrbf.SerializationRecordId> which implements <xref:System.IEquatable%601> and amongst other things, it can be used to detect cycles in decoded records.

<xref:System.Formats.Nrbf.SerializationRecord> exposes one method, <xref:System.Formats.Nrbf.SerializationRecord.TypeNameMatches*>, which compares the type name read from the payload (and exposed via <xref:System.Formats.Nrbf.SerializationRecord.TypeName> property) against the specified type. This method ignores assembly names, so users don't need to worry about type forwarding and assembly versioning. It also does not consider member names or their types (because getting this information would require type loading).

```csharp
using System.Formats.Nrbf;

static Animal Pseudocode(Stream payload)
{
    SerializationRecord record = NrbfDecoder.Read(payload);
    if (record.TypeNameMatches(typeof(Cat)) && record is ClassRecord catRecord)
    {
        return new Cat()
        {
            Name = catRecord.GetString("Name"),
            WorshippersCount = catRecord.GetInt32("WorshippersCount")
        };
    }
    else if (record.TypeNameMatches(typeof(Dog)) && record is ClassRecord dogRecord)
    {
        return new Dog()
        {
            Name = dogRecord.GetString("Name"),
            FriendsCount = dogRecord.GetInt32("FriendsCount")
        };
    }
    else
    {
        throw new Exception($"Unexpected record: `{record.TypeName.AssemblyQualifiedName}`.");
    }
}
```

There are more than a dozen different serialization [record types](/openspecs/windows_protocols/ms-nrbf/). This library provides a set of abstractions, so you only need to learn a few of them:

- <xref:System.Formats.Nrbf.PrimitiveTypeRecord%601>: describes all primitive types natively supported by the NRBF (`string`, `bool`, `byte`, `sbyte`, `char`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `float`, `double`, `decimal`, `TimeSpan`, and `DateTime`).
  - Exposes the value via the `Value` property.
  - <xref:System.Formats.Nrbf.PrimitiveTypeRecord%601> derives from the non-generic <xref:System.Formats.Nrbf.PrimitiveTypeRecord>, which also exposes a <xref:System.Formats.Nrbf.PrimitiveTypeRecord.Value> property. But on the base class, the value is returned as `object` (which introduces boxing for value types).
- <xref:System.Formats.Nrbf.ClassRecord>: describes all `class` and `struct` besides the aforementioned  primitive types.
- <xref:System.Formats.Nrbf.ArrayRecord>: describes all array records, including jagged and multi-dimensional arrays.
- <xref:System.Formats.Nrbf.SZArrayRecord%601>: describes single-dimensional, zero-indexed array records, where `T` can be either a primitive type or a <xref:System.Formats.Nrbf.SerializationRecord>.

```csharp
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

Beside <xref:System.Formats.Nrbf.NrbfDecoder.Decode*>, the [NrbfDecoder] exposes a <xref:System.Formats.Nrbf.NrbfDecoder.DecodeClassRecord*> method that returns <xref:System.Formats.Nrbf.ClassRecord> (or throws).

#### ClassRecord

The most important type that derives from <xref:System.Formats.Nrbf.SerializationRecord> is <xref:System.Formats.Nrbf.ClassRecord>, which represents **all `class` and `struct` instances beside arrays and natively supported primitive types**. It allows you to read all member names and values. To understand what *member* is, see the [BinaryFormatter functionality reference](./functionality-reference.md).

The API it provides:

- <xref:System.Formats.Nrbf.ClassRecord.MemberNames> property that gets the names of serialized members.
- <xref:System.Formats.Nrbf.ClassRecord.HasMember*> method that checks if member of given name was present in the payload. It was designed for handling versioning scenarios where given member could have been renamed.
- A set of dedicated methods for retrieving primitive values of the provided member name: <xref:System.Formats.Nrbf.ClassRecord.GetString*>, <xref:System.Formats.Nrbf.ClassRecord.GetBoolean*>, <xref:System.Formats.Nrbf.ClassRecord.GetByte*>, <xref:System.Formats.Nrbf.ClassRecord.GetSByte*>, <xref:System.Formats.Nrbf.ClassRecord.GetChar*>, <xref:System.Formats.Nrbf.ClassRecord.GetInt16*>, <xref:System.Formats.Nrbf.ClassRecord.GetUInt16*>, <xref:System.Formats.Nrbf.ClassRecord.GetInt32*>, <xref:System.Formats.Nrbf.ClassRecord.GetUInt32*>, <xref:System.Formats.Nrbf.ClassRecord.GetInt64*>, <xref:System.Formats.Nrbf.ClassRecord.GetUInt64*>, <xref:System.Formats.Nrbf.ClassRecord.GetSingle*>, <xref:System.Formats.Nrbf.ClassRecord.GetDouble*>, <xref:System.Formats.Nrbf.ClassRecord.GetDecimal*>, <xref:System.Formats.Nrbf.ClassRecord.GetTimeSpan*>, and <xref:System.Formats.Nrbf.ClassRecord.GetDateTime*>.
- <xref:System.Formats.Nrbf.ClassRecord.GetClassRecord*> retrieves an instance of [ClassRecord]. In case of a cycle, it's the same instance of the current [ClassRecord] with the same <xref:System.Formats.Nrbf.SerializationRecord.Id>.
- <xref:System.Formats.Nrbf.ClassRecord.GetArrayRecord*> retrieves an instance of [ArrayRecord].
- <xref:System.Formats.Nrbf.ClassRecord.GetSerializationRecord*> to retrieve any serialization record and <xref:System.Formats.Nrbf.ClassRecord.GetRawValue*> to retrieve any serialization record or a raw primitive value.

The following code snippet shows <xref:System.Formats.Nrbf.ClassRecord> in action:

```csharp
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
};

// using GetClassRecord to read a class record
ClassRecord? referenced = rootRecord.GetClassRecord(nameof(Sample.ClassInstance));
if (referenced is not null)
{
    if (referenced.Id.Equals(rootRecord.Id))
    {
        throw new Exception("Unexpected cycle detected!");
    }

    output.ClassInstance = new()
    {
        Text = referenced.GetString(nameof(Sample.Text))
    };
}
```

#### ArrayRecord

<xref:System.Formats.Nrbf.ArrayRecord> defines the core behavior for NRBF array records and provides a base for derived classes. It provides two properties:

- <xref:System.Formats.Nrbf.ArrayRecord.Rank>, which gets the rank of the array.
- <xref:System.Formats.Nrbf.ArrayRecord.Lengths>, which gets a buffer of integers that represent the number of elements in every dimension. It's recommended to **check the total length of the provided array record** before calling <xref:System.Formats.Nrbf.ArrayRecord.GetArray*>.

It also provides one method: <xref:System.Formats.Nrbf.ArrayRecord.GetArray*>. When used for the first time, it allocates an array and fills it with the data provided in the serialized records (in case of the natively supported primitive types like `string` or `int`) or the serialized records themselves (in case of arrays of complex types).

<xref:System.Formats.Nrbf.ArrayRecord.GetArray*> requires a mandatory argument that specifies the type of the expected array. For example, if the record should be a 2D array of integers, the `expectedArrayType` must be provided as `typeof(int[,])` and the returned array is also `int[,]`:

```csharp
ArrayRecord arrayRecord = (ArrayRecord)NrbfDecoder.Decode(stream);
if (arrayRecord.Rank != 2 || arrayRecord.Lengths[0] * arrayRecord.Lengths[1] > 10_000)
{
    throw new Exception("The array had unexpected rank or length!");
}
int[,] array2d = (int[,])arrayRecord.GetArray(typeof(int[,]));
```

If there is a type mismatch (example: the attacker has provided a payload with an array of two billion strings), the method throws <xref:System.InvalidOperationException>.

> [!CAUTION]
> Unfortunately, the NRBF format makes it easy for an attacker to compress a large number of null array items. That's why it's recommended to always check the total length of the array before calling <xref:System.Formats.Nrbf.ArrayRecord.GetArray*>. Moreover, <xref:System.Formats.Nrbf.ArrayRecord.GetArray*> accepts an optional `allowNulls` Boolean argument, which, when set to `false`, will throw for nulls.

[NrbfDecoder] does not load or instantiate any custom types, so in case of arrays of complex types, it returns an array of <xref:System.Formats.Nrbf.SerializationRecord>.

```csharp
[Serializable]
public class ComplexType3D
{
    public int I, J, K;
}

ArrayRecord arrayRecord = (ArrayRecord)NrbfDecoder.Decode(payload);
if (arrayRecord.Rank != 1 || arrayRecord.Lengths[0] > 10_000)
{
    throw new Exception("The array had unexpected rank or length!");
}

SerializationRecord[] records = (SerializationRecord[])arrayRecord.GetArray(expectedArrayType: typeof(ComplexType3D[]), allowNulls: false);
ComplexType3D[] output = records.OfType<ClassRecord>().Select(classRecord => new ComplexType3D()
{
    I = classRecord.GetInt32(nameof(ComplexType3D.I)),
    J = classRecord.GetInt32(nameof(ComplexType3D.J)),
    K = classRecord.GetInt32(nameof(ComplexType3D.K)),
}).ToArray();
```

.NET Framework supported non-zero indexed arrays within NRBF payloads, but this support was never ported to .NET (Core). [NrbfDecoder] therefore does not support decoding non-zero indexed arrays.

#### SZArrayRecord

`SZArrayRecord<T>` defines the core behavior for NRBF single dimensional, zero-indexed array records and provides a base for derived classes. The `T` can be one of the natively supported primitive types or <xref:System.Formats.Nrbf.SerializationRecord>.

It provides a <xref:System.Formats.Nrbf.SZArrayRecord%601.Length> property and a <xref:System.Formats.Nrbf.SZArrayRecord%601.GetArray*> overload that returns `T[]`.

```csharp
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

[BinaryFormatter]: xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
[NrbfDecoder]: xref:System.Formats.Nrbf.NrbfDecoder
