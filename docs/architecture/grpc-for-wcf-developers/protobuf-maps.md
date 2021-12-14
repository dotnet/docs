---
title: Protobuf maps for dictionaries - gRPC for WCF developers
description: Understand how to use Protobuf maps to represent dictionary types in .NET.
ms.date: 12/14/2021
---

# Protobuf maps for dictionaries

It's important to be able to represent arbitrary collections of named values in messages. In .NET, this activity is commonly handled through dictionary types. The equivalent of the .NET <xref:System.Collections.Generic.IDictionary%602> type in Protocol Buffer (Protobuf) is the `map<key_type, value_type>` type. This section shows how to declare a `map` type in Protobuf, and how to use the generated code.

```protobuf
message StockPrices {
    map<string, double> prices = 1;
}
```

In the generated code, `map` fields are represented by read-only properties of the [`Google.Protobuf.Collections.MapField<TKey, TValue>`][map-field] type. This type implements the standard .NET collection interfaces, including <xref:System.Collections.Generic.IDictionary%602>.

Map fields can't be directly repeated in a message definition. But you can create a nested message that contains a map and use `repeated` on the message type, as in the following example:

```protobuf
message Order {
    message Attributes {
        map<string, string> values = 1;
    }
    repeated Attributes attributes = 1;
}
```

## Using MapField properties in code

The `MapField` properties generated from `map` fields are read-only, and will never be `null`. To set a map property, use the `Add(IDictionary<TKey,TValue> values)` method on the empty `MapField` property to copy values from any .NET dictionary.

```csharp
public Order CreateOrder(Dictionary<string, string> attributes)
{
    var order = new Order();
    order.Attributes.Add(attributes);
    return order;
}
```

## Further reading

For more information about Protobuf, see the official [Protobuf documentation](https://developers.google.com/protocol-buffers/docs/overview).

[map-field]: https://developers.google.cn/protocol-buffers/docs/reference/csharp/class/google/protobuf/collections/map-field-t-key-t-value-

>[!div class="step-by-step"]
>[Previous](protobuf-enums.md)
>[Next](wcf-services-to-grpc-comparison.md)
