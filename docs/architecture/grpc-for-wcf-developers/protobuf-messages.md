---
title: Protobuf messages - gRPC for WCF Developers
description: TO BE WRITTEN
author: markrendle
ms.date: 09/02/2019
---

# Protobuf messages

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

The first line declares the syntax version being used. Version 3 of the language was released in 2016 and is the recommended version for gRPC services.

The `Stock` message definition specifies four fields, each with a type, a name and a field number.

## Field numbers

Field numbers are a very important part of Protobuf. They are used to identify fields in the binary encoded data, which means they can't change from version to version of your service. The advantage is that backward and forward compatibility is possible. Clients and services will simply ignore field numbers they don't know about, as long as the possibility of missing values is handled.

In the binary format, the field number is combined with a type identifier. Field numbers from 1 to 15 can be encoded with their type as a single byte; numbers from 16 to 2047 take two bytes. You can go higher if you need more than 2047 fields on a message for any reason. The single byte identifiers for field numbers 1 to 15 offer better performance, so you should use them for the most basic, frequently-used fields.

## The generated code

When you build your application, Protobuf will create classes for each of your messages, mapping its native types to C# types. The generated `Stock` type would have this signature:

```csharp
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

>[!div class="step-by-step"]
<!-->[Next](protobuf-data-types.md)-->
