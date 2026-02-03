---
title: "The this keyword"
description: The `this` keyword clarifies access to the current instance of a type, or declares an indexer on the type.
ms.date: 01/22/2026
f1_keywords: 
  - "this"
  - "this_CSharpKeyword"
helpviewer_keywords: 
  - "this keyword [C#]"
---
# The this keyword

The `this` keyword refers to the current instance of the class. It also serves as a modifier for the first parameter of an extension method.

> [!NOTE]
> This article discusses the use of `this` to refer to the receiver instance in the current member. For more information about its use in extension methods, see the [`extension`](./extension.md) keyword.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

Common uses of `this` include:

- Qualifying members hidden by similar names, such as:
  :::code language="csharp" source="./snippets/csrefKeywordsAccess.cs" id="snippet4":::
- Passing an object as a parameter to other methods.

  ```csharp
  CalcTax(this);
  ```

- Declaring [indexers](../../programming-guide/indexers/index.md), such as:
  :::code language="csharp" source="./snippets/csrefKeywordsAccess.cs" id="snippet5":::

Static member functions exist at the class level and not as part of an object. They don't have a `this` pointer. Referring to `this` in a static method is an error.

In the following example, the parameters `name` and `alias` hide fields with the same names. The `this` keyword qualifies those variables as `Employee` class members. The `this` keyword also specifies the object for the method `CalcTax`, which belongs to another class.

:::code language="csharp" source="./snippets/csrefKeywordsAccess.cs" id="snippet3":::

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [`this` code-style preferences (IDE0003 and IDE0009)](../../../fundamentals/code-analysis/style-rules/ide0003-ide0009.md)
- [C# Keywords](index.md)
- [base](base.md)
- [Methods](../../programming-guide/classes-and-structs/methods.md)
