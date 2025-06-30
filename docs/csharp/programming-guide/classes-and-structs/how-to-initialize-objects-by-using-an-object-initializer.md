---
title: "How to initialize objects by using an object initializer"
description: Learn how to use object initializers to initialize type objects in C# without invoking a constructor. Use an object initializer to define an anonymous type.
ms.date: 12/20/2018
helpviewer_keywords: 
  - "object initializers [C#], how to use"
  - "objects [C#], initializing"
ms.topic: how-to
ms.assetid: 4b75ebb2-2e29-43de-929c-d736a8f27ce6
---
# How to initialize objects by using an object initializer (C# Programming Guide)

You can use object initializers to initialize type objects in a declarative manner without explicitly invoking a constructor for the type.  
  
The following examples show how to use object initializers with named objects. The compiler processes object initializers by first accessing the parameterless instance constructor and then processing the member initializations. Therefore, if the parameterless constructor is declared as `private` in the class, object initializers that require public access will fail.
  
You must use an object initializer if you're defining an anonymous type. For more information, see [How to return subsets of element properties in a query](how-to-return-subsets-of-element-properties-in-a-query.md).  
  
## Example  

The following example shows how to initialize a new `StudentName` type by using object initializers. This example sets properties in the `StudentName` type:
  
:::code language="csharp" source="snippets/object-collection-initializers/HowToObjectInitializers.cs" id="SnippetHowToObjectInitializers":::

Object initializers can be used to set indexers in an object. The following example defines a `BaseballTeam` class that uses an indexer to get and set players at different positions. The initializer can assign players, based on the abbreviation for the position, or the number used for each position baseball scorecards:

:::code language="csharp" source="snippets/object-collection-initializers/HowToIndexInitializer.cs" id="SnippetHowToIndexInitializer":::

The next example shows the order of execution of constructor and member initializations using constructor with and without parameter:

:::code language="csharp" source="snippets/object-collection-initializers/ObjectInitializersExecutionOrder.cs" id="ObjectInitializersExecutionOrder":::

## Object initializers without the `new` keyword

You can also use object initializer syntax without the `new` keyword to initialize properties of nested objects. This syntax is particularly useful with read-only properties:

```csharp
var person = new Person
{
    Name = "Alice",
    Address = { Street = "123 Main St", City = "Anytown" }  // No 'new' keyword needed
};
```

This approach modifies the existing instance of the nested object rather than creating a new one. For more details and examples, see [Object Initializers with class-typed properties](object-and-collection-initializers.md#object-initializers-with-class-typed-properties).

## See also

- [Object and Collection Initializers](object-and-collection-initializers.md)
