---
title: Protobuf enumerations - gRPC for WCF Developers
description: Declaring and using enumerations in Protobuf
author: markrendle
ms.date: 09/09/2019
---

# Protobuf enumerations

Protobuf supports enumerations and compiles them to C# `enum` types. Because Protobuf is designed for use with a variety of languages, the naming conventions for enumerations are different from what you might be used to with C#, but the code generator is clever and converts the names to traditional C# case: if the Pascal-case equivalent of the field name starts with the enumeration name, then it is removed.

For example, in this Protobuf enumeration the fields are prefixed with `ACCOUNT_STATUS`, which is equivalent to the Pascal case enum name: `AccountStatus`.

```protobuf
enum AccountStatus {
  ACCOUNT_STATUS_UNKNOWN = 0;
  ACCOUNT_STATUS_PENDING = 1;
  ACCOUNT_STATUS_ACTIVE = 2;
  ACCOUNT_STATUS_SUSPENDED = 3;
  ACCOUNT_STATUS_CLOSED = 4;
}
```

So the generator creates a C# `enum` equivalent to the following code.

```csharp
public enum AccountStatus
{
    Unknown = 0,
    Pending = 1,
    Active = 2,
    Suspended = 3,
    Closed = 4
}
```

Protobuf enumeration definitions **must** have a zero constant as their first field. As in C#, you can declare multiple fields with the same value, but you have to explicitly enable this option using the `allow_alias` option in the enum:

```protobuf
enum AccountStatus {
  option allow_alias = true;
  ACCOUNT_STATUS_UNKNOWN = 0;
  ACCOUNT_STATUS_PENDING = 1;
  ACCOUNT_STATUS_ACTIVE = 2;
  ACCOUNT_STATUS_SUSPENDED = 3;
  ACCOUNT_STATUS_CLOSED = 4;
  ACCOUNT_STATUS_CANCELLED = 4;
}
```

You can declare enumerations at the top level in a `.proto` file, or nested within a message definition. Nested enumerations&mdash;like nested messages&mdash;will be declared within the `.Types` static class in the generated message class.

>[!div class="step-by-step"]
<!-->[Next](protobuf-maps.md)-->
