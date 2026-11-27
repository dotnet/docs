---
description: "Learn about C# reference types, including class, interface, delegate, record, built-in reference types, and nullable reference types."
title: "Reference types"
ms.date: 11/01/2026
f1_keywords: 
  - "cs.referencetypes"
helpviewer_keywords: 
  - "reference types [C#]"
  - "C# language, reference types"
  - "types [C#], reference types"
---
# Reference types (C# reference)

C# has two kinds of types: reference types and value types. Variables of reference types store references to their data (objects), while variables of value types directly contain their data. With reference types, two variables can reference the same object. Therefore, operations on one variable can affect the object referenced by the other variable. With value types, each variable has its own copy of the data. Operations on one variable can't affect the other variable, except in the case of `in`, `ref`, and `out` parameter variables. For more information, see [in](method-parameters.md#in-parameter-modifier), [ref](ref.md), and [out](method-parameters.md#out-parameter-modifier) parameter modifier.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

Use the following keywords to declare reference types:

- [class](class.md)
- [interface](interface.md)
- [delegate](../builtin-types/reference-types.md#the-delegate-type)
- [record](../builtin-types/record.md)

C# also provides the following built-in reference types:

- [dynamic](../builtin-types/reference-types.md#the-dynamic-type)
- [object](../builtin-types/reference-types.md#the-object-type)
- [string](../builtin-types/reference-types.md#the-string-type)

## Nullable reference types

In a [nullable-aware context](../builtin-types/nullable-reference-types.md#nullable-context), reference types can be non-nullable or nullable:

- A *non-nullable reference type* (`T`) indicates that a variable isn't intended to hold `null`. The compiler issues warnings if a non-nullable reference might be dereferenced when it could be `null`, or if you assign `null` to it.
- A *nullable reference type* (`T?`) indicates that a variable can hold `null`. You append the `?` suffix to the type name to declare that the variable might be `null`.

Unlike [nullable value types](../builtin-types/nullable-value-types.md), which wrap an underlying value type in the <xref:System.Nullable`1> struct at run time, nullable reference types are compile-time annotations enforced by compiler static flow analysis. At run time, both `string` and `string?` are represented by the same underlying type, <xref:System.String>. For more information, see [Nullable reference types](../builtin-types/nullable-reference-types.md).

## See also

- [Nullable reference types](../builtin-types/nullable-reference-types.md)
- [Nullable value types](../builtin-types/nullable-value-types.md)
- [C# keywords](index.md)
- [Pointer types](../unsafe-code.md#pointer-types)
- [Value types](../builtin-types/value-types.md)
