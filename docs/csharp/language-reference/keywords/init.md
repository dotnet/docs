---
description: "init keyword - C# Reference"
title: "init keyword - C# Reference"
ms.date: 03/03/2021
f1_keywords: 
  - "init"
  - "init_CSharpKeyword"
helpviewer_keywords: 
  - "init keyword [C#]"
---
# init (C# Reference)

In C# 9 and later, the `init` keyword defines an *accessor* method in a property or indexer. An init-only setter assigns a value to the property or the indexer element only during object construction. For more information and examples, see [Properties](../../programming-guide/classes-and-structs/properties.md), [Auto-Implemented Properties](../../programming-guide/classes-and-structs/auto-implemented-properties.md), and [Indexers](../../programming-guide/indexers/index.md).

The following example defines both a `get` and an `init` accessor for a property named `Seconds`. It uses a private field named `_seconds` to back the property value.

[!code-csharp[init#1](snippets/InitExample1.cs)]

Often, the `init` accessor consists of a single statement that assigns a value, as it did in the previous example. You can implement the `init` accessor as an expression-bodied member. The following example implements both the `get` and the `init` accessors as expression-bodied members.

[!code-csharp[init#3](snippets/InitExample3.cs)]
  
For simple cases in which a property's `get` and `init` accessors perform no other operation than setting or retrieving a value in a private backing field, you can take advantage of the C# compiler's support for auto-implemented properties. The following example implements `Hours` as an auto-implemented property.

[!code-csharp[init#2](snippets/InitExample2.cs)]
  
## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [Properties](../../programming-guide/classes-and-structs/properties.md)
