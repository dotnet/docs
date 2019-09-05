---
title: Protobuf nested types - gRPC for WCF Developers
description: TO BE WRITTEN
author: markrendle
ms.date: 09/02/2019
---

# Protobuf nested types

You can nest message definitions within other messages:

```protobuf
message Outer {
    message Inner {
        string text = 1;
    }
    Inner inner = 1;
}
```

In the generated C# code, the `Inner` type will be declared in a nested static `Types` class within the `HelloRequest` class.

```csharp
var inner = new Outer.Types.Inner { Text = "Hello" };
```

>[!div class="step-by-step"]
<!-->[Next](protobuf-repeated.md)-->
