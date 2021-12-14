---
title: Protobuf scalar data types - gRPC for WCF developers
description: Learn about the basic and well-known data types that Protobuf and gRPC support in .NET Core.
ms.date: 09/09/2019
---

# Protobuf scalar data types

Protocol Buffer (Protobuf) supports a range of native scalar value types. The following table lists them all with their equivalent C# type:

| Protobuf type | C# type      | Notes |
| ------------- | ------------ | ----- |
| `double`      | `double`     |       |
| `float`       | `float`      |       |
| `int32`       | `int`        | 1     |
| `int64`       | `long`       | 1     |
| `uint32`      | `uint`       |       |
| `uint64`      | `ulong`      |       |
| `sint32`      | `int`        | 1     |
| `sint64`      | `long`       | 1     |
| `fixed32`     | `uint`       | 2     |
| `fixed64`     | `ulong`      | 2     |
| `sfixed32`    | `int`        | 2     |
| `sfixed64`    | `long`       | 2     |
| `bool`        | `bool`       |       |
| `string`      | `string`     | 3     |
| `bytes`       | `ByteString` | 4     |

Notes:

1. The standard encoding for `int32` and `int64` is inefficient when you're working with signed values. If your field is likely to contain negative numbers, use `sint32` or `sint64` instead. These types map to the C# `int` and `long` types, respectively.
2. The `fixed` fields always use the same number of bytes no matter what the value is. This behavior makes serialization and deserialization faster for larger values.
3. Protobuf strings are UTF-8 (or 7-bit ASCII) encoded. The encoded length can't be greater than 2<sup>32</sup>.
4. The Protobuf runtime provides a `ByteString` type that maps easily to and from C# `byte[]` arrays.

## Other .NET primitive types

### Dates and times

The native scalar types don't provide for date and time values, equivalent to C#'s <xref:System.DateTimeOffset>, <xref:System.DateTime>, and <xref:System.TimeSpan>. You can specify these types by using some of Google's "Well Known Types" extensions. These extensions provide code generation and runtime support for complex field types across the supported platforms.

The following table shows the date and time types:

| C# type | Protobuf well-known type |
| ------- | ------------------------ |
| `DateTimeOffset` | `google.protobuf.Timestamp` |
| `DateTime` | `google.protobuf.Timestamp` |
| `TimeSpan` | `google.protobuf.Duration` |

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

The generated properties in the C# class aren't the .NET date and time types. The properties use the `Timestamp` and `Duration` classes in the `Google.Protobuf.WellKnownTypes` namespace. These classes provide methods for converting to and from `DateTimeOffset`, `DateTime`, and `TimeSpan`.

```csharp
// Create Timestamp and Duration from .NET DateTimeOffset and TimeSpan
var meeting = new Meeting
{
    Time = Timestamp.FromDateTimeOffset(meetingTime), // also FromDateTime()
    Duration = Duration.FromTimeSpan(meetingLength)
};

// Convert Timestamp and Duration to .NET DateTimeOffset and TimeSpan
DateTimeOffset time = meeting.Time.ToDateTimeOffset();
TimeSpan? duration = meeting.Duration?.ToTimeSpan();
```

> [!NOTE]
> The `Timestamp` type works with UTC times. `DateTimeOffset` values always have an offset of zero, and the `DateTime.Kind` property is always `DateTimeKind.Utc`.

### System.Guid

Protobuf doesn't directly support the <xref:System.Guid> type, known as `UUID` on other platforms. There's no well-known type for it.

The best approach is to handle `Guid` values as a `string` field, by using the standard `8-4-4-4-12` hexadecimal format (for example, `45a9fda3-bd01-47a9-8460-c1cd7484b0b3`). All languages and platforms can parse that format.

Don't use a `bytes` field for `Guid` values. Problems with *endianness* ([Wikipedia definition](https://en.wikipedia.org/wiki/Endianness)) can result in erratic behavior when Protobuf is interacting with other platforms, such as Java.

### Nullable types

The Protobuf code generation for C# uses the native types, such as `int` for `int32`. So the values are always included and can't be null.

For values that require explicit null, such as using `int?` in your C# code, Protobuf's "Well Known Types" include wrappers that are compiled to nullable C# types. To use them, import `wrappers.proto` into your `.proto` file, like this:

```protobuf  
syntax = "proto3"

import "google/protobuf/wrappers.proto"

message Person {

    ...
    google.protobuf.Int32Value age = 5;

}
```

Protobuf will use the simple `T?` (for example, `int?`) for the generated message property.

The following table shows the complete list of wrapper types with their equivalent C# type:

| C# type   | Well Known Type wrapper       |
| --------- | ----------------------------- |
| `double?` | `google.protobuf.DoubleValue` |
| `float?`  | `google.protobuf.FloatValue`  |
| `int?`    | `google.protobuf.Int32Value`  |
| `long?`   | `google.protobuf.Int64Value`  |
| `uint?`   | `google.protobuf.UInt32Value` |
| `ulong?`  | `google.protobuf.UInt64Value` |

The well-known types `Timestamp` and `Duration` are represented in .NET as classes. In C# 8 and beyond, you can use nullable reference types. But it's important to check for null on properties of those types when you're converting to `DateTimeOffset` or `TimeSpan`.

## Decimals

Protobuf doesn't natively support the .NET `decimal` type, just `double` and `float`. There's an ongoing discussion in the Protobuf project about the possibility of adding a standard `Decimal` type to the well-known types, with platform support for languages and frameworks that support it. Nothing has been implemented yet.

It's possible to create a message definition to represent the `decimal` type that would work for safe serialization between .NET clients and servers. But developers on other platforms would have to understand the format being used and implement their own handling for it.

### Creating a custom decimal type for Protobuf

A simple implementation might be similar to the nonstandard `Money` type that some Google APIs use, without the `currency` field.

```protobuf
package CustomTypes;

// Example: 12345.6789 -> { units = 12345, nanos = 678900000 }
message DecimalValue {

    // Whole units part of the amount
    int64 units = 1;

    // Nano units of the amount (10^-9)
    // Must be same sign as units
    sfixed32 nanos = 2;
}
```

The `nanos` field represents values from `0.999_999_999` to `-0.999_999_999`. For example, the `decimal` value `1.5m` would be represented as `{ units = 1, nanos = 500_000_000 }`. This is why the `nanos` field in this example uses the `sfixed32` type, which encodes more efficiently than `int32` for larger values. If the `units` field is negative, the `nanos` field should also be negative.

> [!NOTE]
> There are multiple other algorithms for encoding `decimal` values as byte strings, but this message is easier to understand than any of them. The values are not affected by endianness on different platforms.

Conversion between this type and the BCL `decimal` type might be implemented in C# like this:

```csharp
namespace CustomTypes;
public partial class DecimalValue
{
    private const decimal NanoFactor = 1_000_000_000;
    public DecimalValue(long units, int nanos)
    {
        Units = units;
        Nanos = nanos;
    }

    public static implicit operator decimal(CustomTypes.DecimalValue grpcDecimal)
    {
        return grpcDecimal.Units + grpcDecimal.Nanos / NanoFactor;
    }

    public static implicit operator CustomTypes.DecimalValue(decimal value)
    {
        var units = decimal.ToInt64(value);
        var nanos = decimal.ToInt32((value - units) * NanoFactor);
        return new CustomTypes.DecimalValue(units, nanos);
    }
}
```

> [!IMPORTANT]
> Whenever you use custom message types like this, you *must* document them with comments in `.proto`. Other developers can then implement conversion to and from the equivalent type in their own language or framework.

>[!div class="step-by-step"]
>[Previous](protobuf-messages.md)
>[Next](protobuf-nested-types.md)
