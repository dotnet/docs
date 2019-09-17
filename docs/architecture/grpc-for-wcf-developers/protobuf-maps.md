---
title: Protobuf maps for dictionaries - gRPC for WCF Developers
description: Understand how to use Protobuf maps to represent .NET's dictionary types.
author: markrendle
ms.date: 09/09/2019
---

# Protobuf maps for dictionaries

Protobuf's equivalent of the .NET <xref:System.Collections.Generic.IDictionary%602> type is `map<key_type, value_type>`.

```protobuf
message StockPrices {
    map<string, double> prices = 1;
}
```

In the generated code, `map` fields use the `Google.Protobuf.Collections.MapField<TKey, TValue>`. Again, this implements the standard .NET interfaces, including <xref:System.Collections.Generic.IDictionary%602>.

Map fields can't be `repeated`, but you can create a nested message containing a map and use `repeated` on the message type, like in the following example:

```protobuf
message Order {
    message Attributes {
        map<string, string> values = 1;
    }
    repeated Attributes attributes = 1;
}
```

## Further reading

For more information about Protobuf, see the official [Protobuf documentation](https://developers.google.com/protocol-buffers/docs/overview).

>[!div class="step-by-step"]
<!-->[Next](comparing-wcf-services-to-grpc.md)-->
