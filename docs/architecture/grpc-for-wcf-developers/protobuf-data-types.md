---
title: Data Types
description: gRPC for WCF Developers | Data Types
ms.date: 08/31/2019
---

# Scalar Data Types

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

## Notes

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

The `Guid` type, known as `UUID` on other platforms, is not directly supported by Protobuf and there is no well-known type for it. The best approach is to handle `Guid` values as `string` fields, using the standard `8-4-4-4-12` hexadecimal format (e.g. `45a9fda3-bd01-47a9-8460-c1cd7484b0b3`) which can be parsed by all languages and platforms. You should not use a `bytes` field for `Guid` values, as problems with endian-ness can result in erratic behavior when interacting with other platforms, such as Java.

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

## ??? Decimals

??? Protobuf doesn't natively support the `decimal` type, just `double` and `float`. Given the target audience, is a discussion of how to create a custom `Decimal` message worthwhile?

>[!div class="step-by-step"]
<!-->[Next](protobuf-nested-types.md)-->
