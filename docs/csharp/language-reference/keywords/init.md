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

The `init` keyword defines an *accessor* method in a property or indexer. An init-only setter assigns a value to the property or the indexer element **only** during object construction. An `init` enforces immutability, so  that once the object is initialized, it can't be changed. An `init` accessor enables calling code to use an [object initializer](../../programming-guide/classes-and-structs/how-to-initialize-objects-by-using-an-object-initializer.md) to set the initial value. As a contrast, an
 [auto-implemented property](../../programming-guide/classes-and-structs/auto-implemented-properties.md) with only a `get` setter must be initialized by calling a constructor. A property with a `private set` accessor can be modified after construction, but only in the class.

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

An `init` accessor doesn't force callers to set the property. Instead, it allows callers to use an object initializer while prohibiting later modification. You can add the [`required`](required.md) modifier to force callers to set a property. The following example shows an `init` only property with a nullable value type as its backing field. If a caller doesn't initialize the `YearOfBirth` property, that property will have the default `null` value:

:::code language="csharp" source="./snippets/InitNullablityExample.cs" id="Snippet4":::

To force callers to set an initial non-null value, you add the `required` modifier, as shown in the following example:

:::code language="csharp" source="./snippets/InitNullablityExample.cs" id="SnippetNonNullable":::

The `init` accessor can be used as an expression-bodied member. Example:

:::code language="csharp" source="snippets/InitExample3.cs":::
  
The `init` accessor can also be used in autoimplemented properties, as the following example code demonstrates:

:::code language="csharp" source="snippets/InitExample2.cs":::

The following example shows the distinction between a `private set`, read only, and `init` property. Both the private set version and the read only version require callers to use the added constructor to set the name property. The `private set` version allows a person to change their name after the instance is constructed. The `init` version doesn't require a constructor. Callers can initialize the properties using an object initializer:

:::code language="csharp" source="snippets/InitExample4.cs" id="SnippetClassDefinitions":::

:::code language="csharp" source="snippets/InitExample4.cs" id="SnippetUsage":::

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Keywords](index.md)
- [Properties](../../programming-guide/classes-and-structs/properties.md)
