---
title: Protobuf maps for dictionaries - gRPC for WCF Developers
description: Understand how to use Protobuf maps to represent .NET's dictionary types.
author: markrendle
ms.date: 09/09/2019
---

# Protobuf maps for dictionaries

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

It's important to be able to represent arbitrary collections of named values in messages. In .NET this is commonly handled using dictionary types. Protobuf's equivalent of the .NET <xref:System.Collections.Generic.IDictionary%602> type is the `map<key_type, value_type>` type. This section shows how to declare a `map` in Protobuf, and how to use the generated code.

```protobuf
message StockPrices {
    map<string, double> prices = 1;
}
```

In the generated code, `map` fields use the `Google.Protobuf.Collections.MapField<TKey, TValue>` class, which implements the standard .NET collection interfaces, including <xref:System.Collections.Generic.IDictionary%602>.

Map fields can't be directly repeated in a message definition, but you can create a nested message containing a map and use `repeated` on the message type, like in the following example:

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

>[!div class="step-by-step"]
<!-->[Next](comparing-wcf-services-to-grpc.md)-->
