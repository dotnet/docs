---
title: "Generics and Attributes - C# Programming Guide"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "generics [C#], attributes"
  - "attributes [C#], with generics"
ms.assetid: da9fc326-4648-454a-8e13-3911a2edefd7
---
# Generics and Attributes (C# Programming Guide)
Attributes can be applied to generic types in the same way as non-generic types. For more information on applying attributes, see [Attributes](../concepts/attributes/index.md).  
  
 Custom attributes are only permitted to reference open generic types, which are generic types for which no type arguments are supplied, and closed constructed generic types, which supply arguments for all type parameters.  
  
 The following examples use this custom attribute:  
  
 [!code-csharp[csProgGuideGenerics#48](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideGenerics/CS/Generics.cs#48)]  
  
 An attribute can reference an open generic type:  
  
 [!code-csharp[csProgGuideGenerics#49](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideGenerics/CS/Generics.cs#49)]  
  
 Specify multiple type parameters using the appropriate number of commas. In this example, `GenericClass2` has two type parameters:  
  
 [!code-csharp[csProgGuideGenerics#50](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideGenerics/CS/Generics.cs#50)]  
  
 An attribute can reference a closed constructed generic type:  
  
 [!code-csharp[csProgGuideGenerics#51](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideGenerics/CS/Generics.cs#51)]  
  
 An attribute that references a generic type parameter will cause a compile-time error:  
  
 [!code-csharp[csProgGuideGenerics#52](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideGenerics/CS/Generics.cs#52)]  
  
 A generic type cannot inherit from <xref:System.Attribute>:  
  
 [!code-csharp[csProgGuideGenerics#53](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideGenerics/CS/Generics.cs#53)]  
  
 To obtain information about a generic type or type parameter at run time, you can use the methods of <xref:System.Reflection>. For more information, see [Generics and Reflection](./generics-and-reflection.md)  
  
## See also

- [C# Programming Guide](../index.md)
- [Generics](./index.md)
- [Attributes](../../../standard/attributes/index.md)
