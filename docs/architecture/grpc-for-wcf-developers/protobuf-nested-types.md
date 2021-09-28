---
title: Protobuf nested types - gRPC for WCF developers
description: Learn about nested message types in Protobuf and gRPC and how they're generated in C#.
ms.date: 09/09/2019
---

# Protobuf nested types

Just as C# allows you to declare classes inside other classes, Protocol Buffer (Protobuf) allows you to nest message definitions within other messages. The following example shows how to create nested message types:

```protobuf
message Outer {
    message Inner {
        string text = 1;
    }
    Inner inner = 1;
}
```

In the generated C# code, the `Inner` type will be declared in a nested static `Types` class within the `HelloRequest` class:

```csharp
var inner = new Outer.Types.Inner { Text = "Hello" };
```

>[!div class="step-by-step"]
>[Previous](protobuf-data-types.md)
>[Next](protobuf-repeated.md)
