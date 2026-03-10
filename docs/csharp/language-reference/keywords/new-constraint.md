---
description: "new constraint - C# Reference"
title: "new constraint"
ms.date: 01/22/2026
helpviewer_keywords: 
  - "new constraint keyword [C#]"
---
# new constraint (C# Reference)

The `new` constraint specifies that a type argument in a generic class or method declaration must have a public parameterless constructor. To use the `new` constraint, the type can't be abstract.

Apply the `new` constraint to a type parameter when a generic class creates new instances of the type, as shown in the following example:

:::code language="csharp" source="./snippets/csrefKeywordsOperators.cs" id="5":::

When you use the `new()` constraint with other constraints, you must specify it last:

:::code language="csharp" source="./snippets/csrefKeywordsOperators.cs" id="6":::

For more information, see [Constraints on Type Parameters](../../programming-guide/generics/constraints-on-type-parameters.md).

You can also use the `new` keyword to [create an instance of a type](../operators/new-operator.md) or as a [member declaration modifier](new-modifier.md).

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

## C# language specification

For more information, see the [Type parameter constraints](~/_csharpstandard/standard/classes.md#1525-type-parameter-constraints) section of the [C# language specification](~/_csharpstandard/standard/README.md).

## See also

- [C# Keywords](index.md)
- [Generics](../../fundamentals/types/generics.md)
