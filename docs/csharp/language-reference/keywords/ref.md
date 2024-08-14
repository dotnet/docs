---
description: "ref keyword - C# Reference"
title: "ref keyword"
ms.date: 09/23/2023
f1_keywords: 
  - "ref_CSharpKeyword"
helpviewer_keywords: 
  - "parameters [C#], ref"
  - "ref keyword [C#]"
---
# ref (C# reference)

You use the `ref` keyword in the following contexts:

- In a method signature and in a method call, to pass an argument to a method [by reference](./method-parameters.md#ref-parameter-modifier).

:::code language="csharp" source="./snippets/PassParameters.cs" id="PassByValueOrReference":::

- In a method signature, to return a value to the caller by reference. For more information, see [`ref return`](../statements/jump-statements.md#ref-returns).

:::code language="csharp" source="../statements/snippets/jump-statements/ReturnStatement.cs" id="RefReturn":::

- In a declaration of a local variable, to declare a [reference variable](../statements/declarations.md#reference-variables).

```csharp
ref int aliasOfvariable = ref variable;
```
  
- As the part of a [conditional ref expression](../operators/conditional-operator.md#conditional-ref-expression) or a [ref assignment operator](../operators/assignment-operator.md#ref-assignment).

:::code language="csharp" source="../operators/snippets/shared/AssignmentOperator.cs" id="SnippetRefAssignment":::

- In a `struct` declaration, to declare a `ref struct`. For more information, see the [`ref` structure types](../builtin-types/ref-struct.md) article.

:::code language="csharp" source="../builtin-types/snippets/shared/StructType.cs" id="SnippetRefStruct":::
  
- In a `ref struct` definition, to declare a `ref` field. For more information, see the [`ref` fields](../builtin-types/ref-struct.md#ref-fields) section of the [`ref` structure types](../builtin-types/ref-struct.md) article.

:::code language="csharp" source="../builtin-types/snippets/shared/StructType.cs" id="SnippetRefField":::

- In a generic type declaration to specify that a type parameter [`allows ref struct`](../../programming-guide/generics/constraints-on-type-parameters.md#allows-ref-struct) types.
