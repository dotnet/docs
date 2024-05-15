---
title: "Generic Type Parameters"
description: Learn about generic type definition in C#, where a type parameter is a placeholder for a type that a client specifies for an instance of the generic type.
ms.date: 07/20/2015
helpviewer_keywords:
  - "generics [C#], type parameters"
  - "type parameters [C#]"
ms.assetid: a03b0ab2-0606-4b41-b7bf-e64d5bb4d18f
---
# Generic type parameters (C# Programming Guide)

In a generic type or method definition, a type parameter is a placeholder for a specific type that a client specifies when they create an instance of the generic type. A generic class, such as `GenericList<T>` listed in [Introduction to Generics](../../fundamentals/types/generics.md), cannot be used as-is because it is not really a type; it is more like a blueprint for a type. To use `GenericList<T>`, client code must declare and instantiate a constructed type by specifying a type argument inside the angle brackets. The type argument for this particular class can be any type recognized by the compiler. Any number of constructed type instances can be created, each one using a different type argument, as follows:

[!code-csharp[csProgGuideGenerics#7](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideGenerics/CS/Generics.cs#7)]

In each of these instances of `GenericList<T>`, every occurrence of `T` in the class is substituted at run time with the type argument. By means of this substitution, we have created three separate type-safe and efficient objects using a single class definition. For more information on how this substitution is performed by the CLR, see [Generics in the Runtime](./generics-in-the-run-time.md).

You can learn the naming conventions for generic type parameters in the article on [naming conventions](../../fundamentals/coding-style/identifier-names.md#type-parameter-naming-guidelines).

## See also

- <xref:System.Collections.Generic>
- [Generics](../../fundamentals/types/generics.md)
- [Differences Between C++ Templates and C# Generics](./differences-between-cpp-templates-and-csharp-generics.md)
