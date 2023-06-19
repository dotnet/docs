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

In C# 9 and later, the `init` keyword defines an *accessor* method in a property or indexer. An init-only setter assigns a value to the property or the indexer element **only** during object construction. This enforces immutability, so  that once the object is initialized, it can't be changed again.

For more information and examples, see [Properties](../../programming-guide/classes-and-structs/properties.md), [Auto-Implemented Properties](../../programming-guide/classes-and-structs/auto-implemented-properties.md), and [Indexers](../../programming-guide/indexers/index.md).

The following example defines both a `get` and an `init` accessor for a property named `YearOfBirth`. It uses a private field named `_yearOfBirth` to back the property value.

[!code-csharp[init#1](snippets/InitExample1.cs)]

Often, the `init` accessor consists of a single statement that assigns a value, as it did in the previous example. Note that, because of `init`, the following will **not** work:

```csharp
var john = new Person_InitExample
{
    YearOfBirth = 1984
};

john.YearOfBirth = 1926; //Not allowed, as its value can only be set once in the constructor
```
Do note, that this behavior does not change when nullablity is used. `init` properties do not force the values to be initialized. What `init` does is that, if the property is to be initialized, it must be done at construction time in an object initializer (or in the constructor if you have one). So the behavior is the same for this example:

[!code-csharp[init#4](snippets/InitNullablityExample.cs)]

The `init` accessor can be used as an expression-bodied member. Example:

[!code-csharp[init#3](snippets/InitExample3.cs)]
  
The `init` accessor can also be used in auto-implemented properties as the following example code demonstrates:

[!code-csharp[init#2](snippets/InitExample2.cs)]
  
## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [Properties](../../programming-guide/classes-and-structs/properties.md)
