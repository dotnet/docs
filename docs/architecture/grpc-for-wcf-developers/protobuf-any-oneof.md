---
title: Protobuf Any and Oneof fields for variant types - gRPC for WCF Developers
description: Learn how to use the Any type and the Oneof keyword to represent variant object types in messages.
author: markrendle
ms.date: 09/09/2019
---

# Protobuf Any and Oneof fields for variant types

Handling dynamic property types (that is, properties of type `object`) in WCF is complicated. Serializers must be specified, [KnownType](xref:System.Runtime.Serialization.KnownTypeAttribute) attributes must be provided, and so on.

Protobuf provides two simpler options for dealing with values that may be of more than one type. The `Any` type can represent any known Protobuf message type, while the `oneOf` keyword allows you to specify that only one of a range of fields can be set in any given message.

## Any

To use the `Any` type, you must import `google/protobuf/any.proto`.

```protobuf
syntax "proto3"

import "google/protobuf/any.proto"

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

In the C# code, the `Any` type provides methods for setting the field, extracting the message, and checking the type.

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

The `Descriptor` static field on each generated type is used by Protobuf's internal reflection code to resolve `Any` field types. There's also a `TryUnpack<T>` method, but that creates an uninitialized instance of `T` even when it fails, so it's better to use the `Is` method as shown above.

## Oneof

Whereas `Any` is a well-known type, `oneof` is a Protobuf language keyword. Using `oneof` to specify the `ChangeNotification` message might look like this:

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

When you use `oneof`, the generated C# code includes an enum that specifies which of the fields has been set. You can use test the enum to find which field is set. Fields that aren't set return `null` or the default value, rather than throwing an exception.

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

Setting any field that is part of a `oneof` set will automatically clear any other fields in the set. You can't use `repeated` with `oneof`. Instead, you can create a nested message with either the repeated field or the `oneof` set to work around this limitation.

>[!div class="step-by-step"]
<!-->[Next](protobuf-enums.md)-->
