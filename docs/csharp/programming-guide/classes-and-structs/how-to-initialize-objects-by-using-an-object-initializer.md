---
title: "How to initialize objects by using an object initializer - C# Programming Guide"
description: Learn how to use object initializers to initialize type objects in C# without invoking a constructor. Use an object initializer to define an anonymous type.
ms.date: 12/20/2018
helpviewer_keywords: 
  - "object initializers [C#], how to use"
  - "objects [C#], initializing"
ms.topic: how-to
ms.custom: contperf-fy21q2
ms.assetid: 4b75ebb2-2e29-43de-929c-d736a8f27ce6
---
# How to initialize objects by using an object initializer (C# Programming Guide)

You can use object initializers to initialize type objects in a declarative manner without explicitly invoking a constructor for the type.  
  
The following examples show how to use object initializers with named objects. The compiler processes object initializers by first accessing the parameterless instance constructor and then processing the member initializations. Therefore, if the parameterless constructor is declared as `private` in the class, object initializers that require public access will fail.
  
You must use an object initializer if you're defining an anonymous type. For more information, see [How to return subsets of element properties in a query](how-to-return-subsets-of-element-properties-in-a-query.md).  
  
## Example  

The following example shows how to initialize a new `StudentName` type by using object initializers. This example sets properties in the `StudentName` type:
  
[!code-csharp[InitializerObjectExample](../../../../samples/snippets/csharp/programming-guide/classes-and-structs/object-collection-initializers/HowToObjectInitializers.cs#HowToObjectInitializers)]  

Object initializers can be used to set indexers in an object. The following example defines a `BaseballTeam` class that uses an indexer to get and set players at different positions. The initializer can assign players, based on the abbreviation for the position, or the number used for each position baseball scorecards:

[!code-csharp[InitializerIndexerExample](../../../../samples/snippets/csharp/programming-guide/classes-and-structs/object-collection-initializers/HowToIndexInitializer.cs#HowToIndexInitializer)]  

## See also

- [C# Programming Guide](../index.md)
- [Object and Collection Initializers](object-and-collection-initializers.md)
