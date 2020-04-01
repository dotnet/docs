title: "Nullable reference types - C# reference"
description: Learn about C# nullable reference types and how to use them
ms.date: 04/01/2020
---
# Nullable reference types (C# reference)

> [!NOTE]
> This article covers nullable reference types. You can also declare [nullable value types](nullable-value-types.md).

Nullable reference types are available beginning with C# 8.0, in code that has opted in to a *nullable aware context*. Nullable reference types, the null static analysis warnings and the null forgiveness operator are optional language features turned off by default. A *nullable context* is controlled at the project level using build settings, or in code using pragmas.

 In a nullable aware context:

- A reference type `T` must be initialized to non-null, and may never be assigned a value that may be `null`.
- A reference type `T?` may be initialized or assigned to `null`, but is required to be checked against `null` before de-referencing.
- A variable `m` of type `T?` is considered to be non-null if the *null forgiveness operator* is appended to the variable name, as in `m!`.

The distinctions between a non-nullable reference type `T` and a nullable reference type `T?` are all in the compiler interpretation of the preceding rules. A variable of type `T` and a variable of type `T?` are represented by the same type.

The following example declares a non-nullable string, a nullable string, and the null forgiveness operator to assign a value to a non-nullable string:

```csharp
string notNull = "Hello";
string? nullable = default;
notNull = nullable!; // null forgiveness
```

## Using nullable reference types

## static analysis and storage

## context and warnings



