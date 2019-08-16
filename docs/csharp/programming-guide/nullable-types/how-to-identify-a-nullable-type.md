---
title: "How to: Identify a nullable type - C# Programming Guide"
ms.custom: seodec18
description: "Learn how to determine whether a type is a nullable type or an instance is of a nullable type"
ms.date: 09/24/2018
helpviewer_keywords: 
  - "nullable types [C#], identifying"
ms.assetid: d4b67ee2-66e8-40c1-ae9d-545d32c71387
---
# How to: Identify a nullable type (C# Programming Guide)

The following example shows how to determine whether a <xref:System.Type?displayProperty=nameWithType> instance represents a closed generic nullable type, that is, the <xref:System.Nullable%601?displayProperty=nameWithType> type with a specified type parameter `T`:

[!code-csharp-interactive[whether Type is nullable](../../../../samples/snippets/csharp/programming-guide/nullable-types/IdentifyNullableType.cs#1)]

As the example shows, you use the [typeof](../../language-reference/operators/type-testing-and-cast.md#typeof-operator) operator to create a <xref:System.Type?displayProperty=nameWithType> object.  
  
If you want to determine whether an instance is of a nullable type, don't use the <xref:System.Object.GetType%2A?displayProperty=nameWithType> method to get a <xref:System.Type> instance to be tested with the preceding code. When you call the <xref:System.Object.GetType%2A?displayProperty=nameWithType> method on an instance of a nullable type, the instance is [boxed](using-nullable-types.md#boxing-and-unboxing) to <xref:System.Object>. As boxing of a non-null instance of a nullable type is equivalent to boxing of a value of the underlying type, <xref:System.Object.GetType%2A> returns a <xref:System.Type> object that represents the underlying type of a nullable type:

[!code-csharp-interactive[GetType example](../../../../samples/snippets/csharp/programming-guide/nullable-types/IdentifyNullableType.cs#2)]

Don't use the [is](../../language-reference/keywords/is.md) operator to determine whether an instance is of a nullable type. As the following example shows, you cannot distinguish types of instances of a nullable type and its underlying type with using the `is` operator:

[!code-csharp-interactive[is operator example](../../../../samples/snippets/csharp/programming-guide/nullable-types/IdentifyNullableType.cs#3)]

You can use the code presented in the following example to determine whether an instance is of a nullable type:

[!code-csharp-interactive[whether an instance is of a nullable type](../../../../samples/snippets/csharp/programming-guide/nullable-types/IdentifyNullableType.cs#4)]
  
## See also

- [Nullable types](index.md)
- [Using nullable types](using-nullable-types.md)
- <xref:System.Nullable.GetUnderlyingType%2A>
