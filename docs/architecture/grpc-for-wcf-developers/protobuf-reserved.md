---
title: Protobuf reserved fields - gRPC for WCF Developers
description: Learn about reserved fields for cross-version compatibility.
author: markrendle
ms.date: 09/09/2019
---

# Protobuf reserved fields

Protobuf's backward-compatibility guarantees rely on field numbers always representing the same data item. If a field is removed from a message in a new version of the service, that field number should never be reused. This can be enforced using the `reserved` keyword. If the `displayName` and `marketId` fields were removed from the `Stock` message defined earlier, their field numbers should be reserved as in the following example.

```protobuf
syntax "proto3";

message Stock {

    reserved 3, 4;
    int32 id = 1;
    string symbol = 2;

}
```

The `reserved` keyword can also be used as a placeholder for fields that might be added in the future. Contiguous field numbers can be expressed as a range using the `to` keyword.

```protobuf
syntax "proto3";

message Info {

    reserved 2, 9 to 11, 15;
    // ...
}
```

>[!div class="step-by-step"]
<!-->[Next](protobuf-any-oneof.md)-->
