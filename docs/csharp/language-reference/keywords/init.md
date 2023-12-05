---
description: "init keyword - C# Reference"
title: "init keyword - C# Reference"
ms.date: 12/06/2023
f1_keywords: 
  - "init"
  - "init_CSharpKeyword"
helpviewer_keywords: 
  - "init keyword [C#]"
---
# init (C# Reference)

The `init` keyword defines an *accessor* method in a property or indexer. An init-only setter assigns a value to the property or the indexer element **only** during object construction. An `init` enforces immutability, so  that once the object is initialized, it can't be changed again. An `init` accessor enables calling code to use an [object initializer](../../programming-guide/classes-and-structs/how-to-initialize-objects-by-using-an-object-initializer.md) to set the initial value. As a contrast, an
 [Auto-Implemented Properties](../../programming-guide/classes-and-structs/auto-implemented-properties.md) with only a `get` setter must be initialized by calling a constructor. A property with a `private set` accessor can be modified after construction, but only in the class.

The following example defines both a `get` and an `init` accessor for a property named `YearOfBirth`. It uses a private field named `_yearOfBirth` to back the property value.

:::code language="csharp" source="snippets/InitExample1.cs":::

Often, the `init` accessor consists of a single statement that assigns a value, as it did in the previous example. Because of `init`, the following **doesn't** work:

```csharp
var john = new Person_InitExample
{
    YearOfBirth = 1984
};

john.YearOfBirth = 1926; //Not allowed, as its value can only be set once in the constructor
```

An `init` accessor doesn't force callers to set the property. Instead, it allows an object initializer to set the initial value while prohibiting later modification. You can add the `required` modifier to force callers to set a property. The following example shows the same behavior:

:::code language="csharp" source="./snippets/InitNullablityExample.cs" id="Snippet4":::

The `init` accessor can be used as an expression-bodied member. Example:

:::code language="csharp" source="snippets/InitExample3.cs":::
  
The `init` accessor can also be used in autoimplemented properties as the following example code demonstrates:

:::code language="csharp" source="snippets/InitExample2.cs":::

The following example shows the distinction between a `private set`, readonly and `init` properties. Both the private set version and the readonly version require callers to use the added constructor to set the name property. The `private set` version allows a person to change their name after the instance is constructed. The `init` version doesn't require a constructor. Callers can initialize the properties using an object initializer:

:::code language="csharp" source="snippets/InitExample4.cs" id="SnippetClassDefinitions":::

:::code language="csharp" source="snippets/InitExample4.cs" id="SnippetUsage":::

  
## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [Properties](../../programming-guide/classes-and-structs/properties.md)
