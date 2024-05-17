---
description: "Reference types - C# Reference"
title: "Reference types"
ms.date: 07/20/2015
f1_keywords: 
  - "cs.referencetypes"
helpviewer_keywords: 
  - "reference types [C#]"
  - "C# language, reference types"
  - "types [C#], reference types"
ms.assetid: 801cf030-6e2d-4a0d-9daf-1431b0c31f47
---
# Reference types (C# reference)

There are two kinds of types in C#: reference types and value types. Variables of reference types store references to their data (objects), while variables of value types directly contain their data. With reference types, two variables can reference the same object; therefore, operations on one variable can affect the object referenced by the other variable. With value types, each variable has its own copy of the data, and it's not possible for operations on one variable to affect the other (except in the case of `in`, `ref`, and `out` parameter variables; see [in](method-parameters.md#in-parameter-modifier), [ref](ref.md), and [out](method-parameters.md#out-parameter-modifier) parameter modifier).

 The following keywords are used to declare reference types:

- [class](class.md)
- [interface](interface.md)
- [delegate](../builtin-types/reference-types.md#the-delegate-type)
- [record](../builtin-types/record.md)

 C# also provides the following built-in reference types:

- [dynamic](../builtin-types/reference-types.md#the-dynamic-type)
- [object](../builtin-types/reference-types.md#the-object-type)
- [string](../builtin-types/reference-types.md#the-string-type)

## See also

- [C# keywords](index.md)
- [Pointer types](../unsafe-code.md#pointer-types)
- [Value types](../builtin-types/value-types.md)
