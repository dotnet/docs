---
title: Protobuf messages - gRPC for WCF developers
description: Learn how Protobuf messages are defined in the IDL and generated in C#.
ms.date: 12/14/2021
---

# Protobuf messages

This section covers how to declare Protocol Buffer (Protobuf) messages in `.proto` files. It explains the fundamental concepts of field numbers and types, and it looks at the C# code that the `protoc` compiler generates.

The rest of the chapter will look in more detail at how different types of data are represented in Protobuf.

## Declaring a message

In Windows Communication Foundation (WCF), a `Stock` class for a stock market trading application might be defined like the following example:

```csharp
namespace TraderSys;

[DataContract]
public class Stock
{
    [DataMember]
    public int Id { get; set; }
    [DataMember]
    public string Symbol { get; set; }
    [DataMember]
    public string DisplayName { get; set; }
    [DataMember]
    public int MarketId { get; set; }
}
```

To implement the equivalent class in Protobuf, you must declare it in the `.proto` file. The `protoc` compiler will then generate the .NET class as part of the build process.

```protobuf
syntax = "proto3";

option csharp_namespace = "TraderSys";

message Stock {

    int32 id = 1;
    string symbol = 2;
    string display_name = 3;
    int32 market_id = 4;

}  
```

The first line declares the syntax version being used. Version 3 of the language was released in 2016. It's the version that we recommend for gRPC services.

The `option csharp_namespace` line specifies the namespace to be used for the generated C# types. This option will be ignored when the `.proto` file is compiled for other languages. Protobuf files often contain language-specific options for several languages.

The `Stock` message definition specifies four fields. Each has a type, a name, and a field number.

## Field numbers

Field numbers are an important part of Protobuf. They're used to identify fields in the binary encoded data, which means they can't change from version to version of your service. The advantage is that backward compatibility and forward compatibility are possible. Clients and services will ignore field numbers that they don't know about, as long as the possibility of missing values is handled.

In the binary format, the field number is combined with a type identifier. Field numbers from 1 to 15 can be encoded with their type as a single byte. Numbers from 16 to 2,047 take 2 bytes. You can go higher if you need more than 2,047 fields on a message for any reason. The single-byte identifiers for field numbers 1 to 15 offer better performance, so you should use them for the most basic, frequently used fields.

## Types

The type declarations are using Protobuf's native scalar data types, which are discussed in more detail in [the next section](protobuf-data-types.md). The rest of this chapter will cover Protobuf's built-in types and show how they relate to common .NET types.

> [!NOTE]
> Protobuf doesn't natively support a `decimal` type, so `double` is used instead. For applications that require full decimal precision, refer to the [section on decimals](protobuf-data-types.md#decimals) in the next part of this chapter.

## The generated code

When you build your application, Protobuf creates classes for each of your messages, mapping its native types to C# types. The generated `Stock` type would have the following signature:

```csharp
public class Stock
{
    public int Id { get; set; }
    public string Symbol { get; set; }
    public string DisplayName { get; set; }
    public int MarketId { get; set; }
}
```

The actual code that's generated is far more complicated than this. The reason is that each class contains all the code necessary to serialize and deserialize itself to the binary wire format.

### Property names

Note that the Protobuf compiler applied `PascalCase` to the property names, although they were `snake_case` in the `.proto` file. The [Protobuf style guide](https://developers.google.com/protocol-buffers/docs/style) recommends using `snake_case` in your message definitions so that the code generation for other platforms produces the expected case for their conventions.

>[!div class="step-by-step"]
>[Previous](protocol-buffers.md)
>[Next](protobuf-data-types.md)
