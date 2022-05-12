---
title: Protobuf Any and Oneof fields for variant types - gRPC for WCF developers
description: Learn how to use the Any type and the Oneof keyword to represent variant object types in messages.
ms.date: 09/09/2019
---

# Protobuf Any and Oneof fields for variant types

[!INCLUDE [download-alert](includes/download-alert.md)]

Handling dynamic property types (that is, properties of type `object`) in Windows Communication Foundation (WCF) is complicated. For example, you must specify serializers and provide [KnownType](xref:System.Runtime.Serialization.KnownTypeAttribute) attributes.

Protocol Buffer (Protobuf) provides two simpler options for dealing with values that might be of more than one type. The `Any` type can represent any known Protobuf message type. And you can use the `oneof` keyword to specify that only one of a range of fields can be set in any message.

## Any

`Any` is one of Protobuf's "well-known types": a collection of useful, reusable message types with implementations in all supported languages. To use the `Any` type, you must import the `google/protobuf/any.proto` definition.

```protobuf
syntax = "proto3";

import "google/protobuf/any.proto";

message Stock {
    // Stock-specific data
}

message Currency {
    // Currency-specific data
}

message ChangeNotification {
    int32 id = 1;
    google.protobuf.Any instrument = 2;
}
```

In the C# code, the `Any` class provides methods for setting the field, extracting the message, and checking the type.

```csharp
public void FormatChangeNotification(ChangeNotification change)
{
    if (change.Instrument.Is(Stock.Descriptor))
    {
        FormatStock(change.Instrument.Unpack<Stock>());
    }
    else if (change.Instrument.Is(Currency.Descriptor))
    {
        FormatCurrency(change.Instrument.Unpack<Currency>());
    }
    else
    {
        throw new ArgumentException("Unknown instrument type");
    }
}
```

Protobuf's internal reflection code uses the `Descriptor` static field on each generated type to resolve `Any` field types. There's also a `TryUnpack<T>` method, but that creates an uninitialized instance of `T` even when it fails. It's better to use the `Is` method as shown earlier.

## Oneof

Oneof fields are a language feature: the compiler handles the `oneof` keyword when it generates the message class. Using `oneof` to specify the `ChangeNotification` message might look like this:

```protobuf
message Stock {
    // Stock-specific data
}

message Currency {
    // Currency-specific data
}

message ChangeNotification {
  int32 id = 1;
  oneof instrument {
    Stock stock = 2;
    Currency currency = 3;
  }
}
```

Fields within the `oneof` set must have unique field numbers in the overall message declaration.

When you use `oneof`, the generated C# code includes an enum that specifies which of the fields has been set. You can test the enum to find which field is set. Fields that aren't set return `null` or the default value, rather than throwing an exception.

```csharp
public void FormatChangeNotification(ChangeNotification change)
{
    switch (change.InstrumentCase)
    {
        case ChangeNotification.InstrumentOneofCase.None:
            return;
        case ChangeNotification.InstrumentOneofCase.Stock:
            FormatStock(change.Stock);
            break;
        case ChangeNotification.InstrumentOneofCase.Currency:
            FormatCurrency(change.Currency);
            break;
        default:
            throw new ArgumentException("Unknown instrument type");
    }
}
```

Setting any field that's part of a `oneof` set will automatically clear any other fields in the set. You can't use `repeated` with `oneof`. Instead, you can create a nested message with either the repeated field or the `oneof` set to work around this limitation.

>[!div class="step-by-step"]
>[Previous](protobuf-reserved.md)
>[Next](protobuf-enums.md)
