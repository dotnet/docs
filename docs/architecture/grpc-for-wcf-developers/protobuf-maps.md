---
title: Maps for dictionaries - gRPC for WCF Developers
description: TO BE WRITTEN
author: markrendle
ms.date: 09/02/2019
---

# Maps for dictionaries

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

>[!div class="step-by-step"]
<!-->[Next](comparing-wcf-services-to-grpc.md)-->
