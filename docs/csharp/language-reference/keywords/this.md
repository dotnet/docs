---
title: "The this keyword"
description: The `this` keyword clarifies access to the current instance of a type, or declares an indexer on the type.
ms.date: 04/08/2025
f1_keywords: 
  - "this"
  - "this_CSharpKeyword"
helpviewer_keywords: 
  - "this keyword [C#]"
---
# The this keyword

The `this` keyword refers to the current instance of the class and is also used as a modifier of the first parameter of an extension method.

> [!NOTE]
> This article discusses the use of `this` with class instances. For more information about its use in extension methods, see the [`extension`](./extension.md) keyword.

The following are common uses of `this`:

- To qualify members hidden by similar names, for example:

  :::code language="csharp" source="./snippets/csrefKeywordsAccess.cs" id="snippet4":::

- To pass an object as a parameter to other methods, for example:

  ```csharp
  CalcTax(this);
  ```

- To declare [indexers](../../programming-guide/indexers/index.md), for example:

  :::code language="csharp" source="./snippets/csrefKeywordsAccess.cs" id="snippet5":::

Static member functions, because they exist at the class level and not as part of an object, don't have a `this` pointer. It's an error to refer to `this` in a static method.

In this example, the parameters `name`, and `alias` hide fields with the same names. The `this` keyword qualifies those variables as `Employee` class members. The `this` keyword also specifies the object for the method `CalcTax`, which belongs to another class.

:::code language="csharp" source="./snippets/csrefKeywordsAccess.cs" id="snippet3":::

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [`this` code-style preferences (IDE0003 and IDE0009)](../../../fundamentals/code-analysis/style-rules/ide0003-ide0009.md)
- [C# Keywords](index.md)
- [base](base.md)
- [Methods](../../programming-guide/classes-and-structs/methods.md)
