# Protocol Buffers
gRPC services send and receive data as *Protocol Buffer (Protobuf)  messages*, similar to WCF's Data Contracts. Protobuf is a very efficient way of serializing structured data for machines to read and write, without the overhead that human-readable formats like XML or JSON incur.

This chapter provides an overview of Protobuf, how it enables cross-platform message passing, and how to define your own Protobuf messages.

## How Protobuf works
Unlike most other .NET object serialization techniques, which work by using reflection to analyze the object structure at run-time, Protobuf requires you to define the structure up front using a dedicated language (*Protocol Buffer Language*) in a `.proto` file. This is then used to generate code for any of the supported platforms, including .NET, Java, C/C++, JavaScript and many more. The Protobuf compiler, `protoc`, is maintained by Google, although alternative implementations are available. The generated code is very efficient and optimized for fast serialization/deserialization of data.

The Protobuf wire format itself is a binary encoding, which uses some clever tricks to minimize the number of bytes used to represent messages. Knowledge of the binary encoding format is not necessary to use Protobuf, but if you are interested you can learn more about it on [the Protocol Buffers web site](https://developers.google.com/protocol-buffers/docs/encoding).

## Our first Protobuf message

Let's look at a simple example of a Protobuf message, defining a `Stock` message.

```protobuf
[]
syntax "proto3";

message Stock {

    int32 id = 1;
    string symbol = 2;
    double price = 3;
    string displayName = 4;

}  
```

We start by declaring the syntax version that we are using. Version 3 of the language was released in 2016 and is the recommended version for gRPC services, so we use that.

Next we write the `Person` message definition, specifying three fields, each with a type, a name and a field number.

### Field numbers

Field numbers are a very important part of Protobuf. They are used to identify fields in the binary encoded data, which means they can't change from version to version of your service. The advantage is that backward and forward compatibility is possible. Clients and services will simply ignore field numbers they don't know about, as long as the possibility of missing values is handled.

In the binary format, the field number is combined with a type identifier. Field numbers from 1 to 15 can be encoded with their type as a single byte; numbers from 16 to 2047 take two bytes. You can go higher if you need more than 2047 fields on a message for any reason. The single byte identifiers for field numbers 1 to 15 offer better performance, so you should use them for the most basic, frequently-used fields.

If you delete a field from your message definition in a future update, and then another developer uses that same field number for a different field, it will break backward compatibility. You can avoid this by marking deleted field numbers as `reserved` in your message. Here is the `Stock` message with the `price` and `name` fields removed:

```protobuf
syntax "proto3";

message Stock {

    reserved 3, 4;
    int32 id = 1;
    string symbol = 2;

}
```

### The generated code

When you build your application, Protobuf will create classes for each of your messages, mapping its native types to C# types. The generated `Stock` type would have this signature:

```c#
public class Stock
{
    public int Id { get; set; }
    public string Symbol { get; set; }
    public double Price { get; set; }
    public string DisplayName { get; set; }
}
```

(The actual code generated is far more complicated than this, because each class contains all the code necessary to serialize and deserialize itself to the binary wire format.)

Note that the Protobuf compiler applied `PascalCase` to the property names although they were `camelCase` in the `.proto` file.

## Scalar Data Types

Protobuf supports a range of native scalar value types. This table lists them all with their equivalent C# type.

| Protobuf Type | C# Type    | Notes |
| ------------- | ---------- | ----- |
| double        | double     |       |
| float         | float      |       |
| int32         | int        |       |
| int64         | long       |       |
| uint32        | uint       |       |
| uint64        | ulong      |       |
| sint32        | int        | 1     |
| sint64        | long       | 1     |
| fixed32       | uint       | 2     |
| fixed64       | ulong      | 2     |
| sfixed32      | int        | 2     |
| sfixed64      | long       | 2     |
| bool          | bool       |       |
| string        | string     | 3     |
| bytes         | ByteString | 4     |

### Notes

1. The standard encoding for `int32` and `int64` is inefficient when working with signed values. If your field is likely to contain negative numbers, use `sint32` or `sint64` instead. Both types map to the C# `int` and `long` types respectively.
2. The `fixed` fields always use the same number of bytes regardless of the value. This makes serialization/deserialization faster for larger values.
3. Protobuf strings are UTF-8 (or 7-bit ASCII) encoded, and the encoded length cannot be greater than 2<sup>32</sup>.
4. The Protobuf runtime provides a `ByteString` type that maps easily to and from C# `byte[]` arrays.

## Other .NET primitive types

### Dates and Times

The native scalar types do not provide for date and time values, equivalent to C#'s `DateTimeOffset`, `DateTime` and `TimeSpan`. These types can be specified using some of Google's "Well Known Types" extensions, which provide code generation and runtime support for more complex field types across the supported platforms. To use them, you need to import them in your `.proto` file, like this:

```protobuf  
syntax = "proto3"

import "google/protobuf/duration.proto";  
import "google/protobuf/timestamp.proto";

message Meeting {

    string subject = 1;
    google.protobuf.Timestamp time = 2;
    google.protobuf.Duration duration = 3;

}  
```

### System.Guid

The `Guid` type, known as `UUID` on other platforms, is not directly supported by Protobuf and there is no well-known type for it. The best approach is to handle `Guid` values as `string` fields, using the standard `8-4-4-4-12` hexadecimal format (e.g. `45a9fda3-bd01-47a9-8460-c1cd7484b0b3`) which can be parsed by all languages and platforms. You should not use a `bytes` field for `Guid` values, as problems with endianness can result in erratic behavior when interacting with other platforms, such as Java.

### Nullable Types

The Protobuf code generation for C# will use the native types, such as `int` for `int32`. This means that the values are always included and can't be null. For values that require explicit null, where you would use e.g. `int?` in your C# code, Protobuf's "Well Known Types" include wrappers that are compiled to nullable C# types. To use them, import `wrappers.proto` into your `.proto` file, like this:

```protobuf  
syntax = "proto3"

import "google/protobuf/wrappers.proto"

message Person {

    ...
    google.protobuf.Int32Value age = 5;

}
```

Protobuf will use the simple `T?` (e.g. `int?`) for the generated message property.

Here is the complete list of wrapper types with their equivalent C# type:

| C# Type | Well Known Type wrapper     |
| ------- | --------------------------- |
| double? | google.protobuf.DoubleValue |
| float?  | google.protobuf.FloatValue  |
| int?    | google.protobuf.Int32Value  |
| long?   | google.protobuf.Int64Value  |
| uint?   | google.protobuf.UInt32Value |
| ulong?  | google.protobuf.UInt64Value |

## ??? Decimals ???

> Protobuf doesn't natively support the `decimal` type, just `double` and `float`. Given the target audience, is a discusson of how to create a custom `Decimal` message worthwhile?

## Nested types

You can nest message definitions within other messages:

```protobuf
message Outer {
    message Inner {
        string text = 1;
    }
    Inner inner = 1;
}
```

In the generated C# code, the `Inner` type will be declared in a nested static `Types` class within the `HelloRequest` class.

```c#
var inner = new Outer.Types.Inner { Text = "Hello" };
```

## Lists

Lists are specified in Protobuf using the `repeated` prefix keyword.

```protobuf
message Person {
    // Other fields elided
    repeated string aliases = 8;
}
```

In the generated code, `repeated` fields are represented by the `Google.Protobuf.Collections.RepeatedField<T>` generic type rather than any of the built-in .NET collection types. The `RepeatedField<T>` type includes the code required to serialize and deserialize the list to the binary wire format. It implements all the standard .NET collection interfaces such as `IList<T>` and `IEnumerable<T>`, so you can use LINQ queries or convert it to an array or a list easily.

## Dictionaries

Protobuf's equivalent of the .NET `Dictionary<TKey, TValue>` type is `map<key_type, value_type>`.

```protobuf
message StockPrices {
    map<string, double> prices = 1;
}
```

In the generated code, `map` fields use the `Google.Protobuf.Collections.MapField<TKey, TValue>`. Again, this implements the standard .NET interfaces, including `IDictionary<TKey, TValue>`.

Map fields cannot be `repeated`, but you can create a nested message containing a map and use `repeated` on the message type.

```protobuf
message Order {
    message Attributes {
        map<string, string> values = 1;
    }
    repeated Attributes attributes = 1;
}
```

## Variant Types

Protobuf provides two options for dealing with values that may be of more than one type. The `Any` type can represent any known Protobuf message type, while the `oneOf` keyword allows you to specify that only one of a range of fields can be set in any given message.

### Any

To use the any type, you must import `google/protobuf/any.proto`.

```protobuf
syntax "proto3"

import "google/protobuf/any.proto"

message Car {
    // Car-specific data
}

message Motorcycle {
    // Bike-specific data
}

message Incident {
    int32 id = 1;
    google.protobuf.Any vehicle = 2;
}
```

In the C# code, the `Any` type provides methods for setting the field, extracting the message and checking the type.

```C#
public void FormatVehicleData(Incident incident)
{
    if (incident.Vehicle.Is(Car.Descriptor))
    {
        FormatCarData(incident.Vehicle.Unpack<Car>());
    }
    else if (incident.Vehicle.Is(Motorcycle.Descriptor))
    {
        FormatMotorcycleData(incident.Vehicle.Unpack<Motorcycle>());
    }
    else
    {
        throw new ArgumentException("Unknown vehicle type");
    }
}
```

The `Descriptor` static field on each generated type is used by Protobuf's internal reflection code to resolve `Any` field types. There is also a `TryUnpack<T>` method, but that creates an uninitialized instance of `T` even when it fails, so it's better to use the `Is` method as shown above.

### OneOf

Whereas `Any` is a well-known type, `oneof` is a Protobuf language keyword. Using `oneof` to specify the `Incident` message might look like this:

```protobuf
message Car {
    // Car-specific data
}

message Motorcycle {
    // Bike-specific data
}

message Incident {
  int32 id = 1;
  oneof vehicle {
    Car car = 2;
    Motorcycle motorcycle = 3;
  }
}
```

When you use `oneof`, the generated C# includes an `enum` that specifies which of the fields has been set. You can use test the `enum` to find which field is set. Fields that are not set will return `null` or the default value, rather than throwing an exception.

```C#
public void FormatVehicleData(Incident incident)
{
    switch (incident.VehicleCase)
    {
        case Incident.VehicleOneofCase.None:
            return;
        case Incident.VehicleOneofCase.Car:
            FormatCarData(incident.Car);
            break;
        case Incident.VehicleOneofCase.Motorcycle:
            FormatMotorcycleData(incident.Motorcycle);
            break;
        default:
            throw new ArgumentException("Unknown vehicle type");
    }
}
```

Setting any field that is part of a `oneof` set will automatically clear any other fields in the set. You cannot use `repeated` with `oneof`; again, you can create a nested message with either the repeated field or the `oneof` set to work around this.

## Enumerations

Protobuf supports enumerations and compiles them to C# `enum` types. Because Protobuf is designed for use with a variety of languages, the naming conventions for enumerations are different from what you might be used to with C#, but the code generator is clever and converts the names to traditional C# case: if the Pascal-case equivalent of the field name starts with the enumeration name, then it is removed.

For example, in this Protobuf enumeration the fields are prefixed with `ACCOUNT_STATUS`, which is equivalent to the Pascal case enum name: `AccountStatus`.

```protobuf
enum AccountStatus {
  ACCOUNT_STATUS_UNKNOWN = 0;
  ACCOUNT_STATUS_PENDING = 1;
  ACCOUNT_STATUS_ACTIVE = 2;
  ACCOUNT_STATUS_SUSPENDED = 3;
  ACCOUNT_STATUS_CLOSED = 4;
}
```

So the generator creates a C# `enum` equivalent to the following code.

```C#
public enum AccountStatus
{
    Unknown = 0,
    Pending = 1,
    Active = 2,
    Suspended = 3,
    Closed = 4
}
```

Protobuf enumeration definitions **must** have a zero constant as their first field. As in C#, you can declare multiple fields with the same value, but you have to explicitly enable this option using the `allow_alias` option in the enum:

```protobuf
enum PhotoType {
    option allow_alias = true;
    COLOR = 0;
    MONOCHROME = 1;
    BLACK_AND_WHITE = 1;
}
```

You can declare enumerations at the top level in a `.proto` file, or nested within a message definition. Nested enumerations&mdash;like nested messages&mdash;will be declared within the `.Types` static class in the generated message class.
