---
title: Protobuf reserved fields - gRPC for WCF Developers
description: Reserved fields for cross-version compatibility
author: markrendle
ms.date: 09/02/2019
---

# Protobuf reserved fields

Protobuf's backward-compatibility guarantees rest on field numbers always representing the same data item. If a field is removed from a message in a new version of the service, that field number should never be reused. This can be enforced using the `reserved` keyword.

```protobuf
syntax "proto3";

message Stock {

    reserved 3, 4;
    int32 id = 1;
    string symbol = 2;

}
```

The `reserved` keyword can also be used as a placeholder for fields that might be added in the future.

>[!div class="step-by-step"]
<!-->[Next](protobuf-any-oneof.md)-->
