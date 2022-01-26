---
title: Protobuf reserved fields - gRPC for WCF developers
description: Learn about reserved fields for cross-version compatibility.
ms.date: 12/14/2021
---

# Protobuf reserved fields

The backward-compatibility guarantees in Protocol Buffer (Protobuf) rely on field numbers always representing the same data item. If a field is removed from a message in a new version of the service, that field number should never be reused. You can enforce this behavior by using the `reserved` keyword.

If the `displayName` and `marketId` fields were removed from the `Stock` message defined earlier, their field numbers should be reserved as in the following example.

```protobuf
syntax "proto3";

message Stock {

    reserved 3, 4;
    int32 id = 1;
    string symbol = 2;

}
```

You can also use the `reserved` keyword as a placeholder for fields that might be added in the future. You can express contiguous field numbers as a range by using the `to` keyword.

```protobuf
syntax "proto3";

message Info {

    reserved 2, 9 to 11, 15;
    // ...
}
```

>[!div class="step-by-step"]
>[Previous](protobuf-repeated.md)
>[Next](protobuf-any-oneof.md)
