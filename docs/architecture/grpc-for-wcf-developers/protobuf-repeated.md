---
title: Repeated fields for lists and arrays - gRPC for WCF developers
description: Understand how Protobuf handles collections and how they relate to .NET collections.
ms.date: 09/09/2019
---

# Repeated fields for lists and arrays

[!INCLUDE [download-alert](includes/download-alert.md)]

You specify lists in Protocol Buffer (Protobuf) by using the `repeated` prefix keyword. The following example shows how to create a list:

```protobuf
message Person {
    // Other fields elided
    repeated string aliases = 8;
}
```

In the generated code, `repeated` fields are represented by read-only properties of the [`Google.Protobuf.Collections.RepeatedField<T>`][repeated-field] type rather than any of the built-in .NET collection types. This type implements all the standard .NET collection interfaces, such as <xref:System.Collections.Generic.IList%601> and <xref:System.Collections.Generic.IEnumerable%601>. So you can use LINQ queries or convert it to an array or a list easily.

The `RepeatedField<T>` type includes the code required to serialize and deserialize the list to the binary wire format.

[repeated-field]: https://developers.google.cn/protocol-buffers/docs/reference/csharp/class/google/protobuf/collections/repeated-field-t-

>[!div class="step-by-step"]
>[Previous](protobuf-nested-types.md)
>[Next](protobuf-reserved.md)
