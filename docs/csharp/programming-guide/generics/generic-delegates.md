---
title: "Generic Delegates - C# Programming Guide"
ms.custom: seodec18
ms.date: 07/20/2015
helpviewer_keywords: 
  - "generics [C#], delegates"
  - "delegates [C#], generic"
ms.assetid: bdea509c-44c1-4309-aaa9-15c7aee009df
---
# Generic Delegates (C# Programming Guide)
A [delegate](../../language-reference/keywords/delegate.md) can define its own type parameters. Code that references the generic delegate can specify the type argument to create a closed constructed type, just like when instantiating a generic class or calling a generic method, as shown in the following example:  
  
 [!code-csharp[csProgGuideGenerics#36](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideGenerics/CS/Generics.cs#36)]  
  
 C# version 2.0 has a new feature called method group conversion, which applies to concrete as well as generic delegate types, and enables you to write the previous line with this simplified syntax:  
  
 [!code-csharp[csProgGuideGenerics#37](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideGenerics/CS/Generics.cs#37)]  
  
 Delegates defined within a generic class can use the generic class type parameters in the same way that class methods do.  
  
 [!code-csharp[csProgGuideGenerics#38](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideGenerics/CS/Generics.cs#38)]  
  
 Code that references the delegate must specify the type argument of the containing class, as follows:  
  
 [!code-csharp[csProgGuideGenerics#39](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideGenerics/CS/Generics.cs#39)]  
  
 Generic delegates are especially useful in defining events based on the typical design pattern because the sender argument can be strongly typed and no longer has to be cast to and from <xref:System.Object>.  
  
 [!code-csharp[csProgGuideGenerics#40](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideGenerics/CS/Generics.cs#40)]  
  
## See also

- <xref:System.Collections.Generic>
- [C# Programming Guide](../index.md)
- [Introduction to Generics](./index.md)
- [Generic Methods](./generic-methods.md)
- [Generic Classes](./generic-classes.md)
- [Generic Interfaces](./generic-interfaces.md)
- [Delegates](../delegates/index.md)
- [Generics](../../../standard/generics/index.md)
