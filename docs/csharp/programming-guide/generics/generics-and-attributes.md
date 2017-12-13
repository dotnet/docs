---
title: "Generics and Attributes (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "generics [C#], attributes"
  - "attributes [C#], with generics"
ms.assetid: da9fc326-4648-454a-8e13-3911a2edefd7
caps.latest.revision: 13
author: "BillWagner"
ms.author: "wiwagn"
---
# Generics and Attributes (C# Programming Guide)
Attributes can be applied to generic types in the same way as non-generic types. For more information on applying attributes, see [Attributes](../../../csharp/programming-guide/concepts/attributes/index.md).  
  
 Custom attributes are only permitted to reference open generic types, which are generic types for which no type arguments are supplied, and closed constructed generic types, which supply arguments for all type parameters.  
  
 The following examples use this custom attribute:  
  
 [!code-csharp[csProgGuideGenerics#48](../../../csharp/programming-guide/generics/codesnippet/CSharp/generics-and-attributes_1.cs)]  
  
 An attribute can reference an open generic type:  
  
 [!code-csharp[csProgGuideGenerics#49](../../../csharp/programming-guide/generics/codesnippet/CSharp/generics-and-attributes_2.cs)]  
  
 Specify multiple type parameters using the appropriate number of commas. In this example, `GenericClass2` has two type parameters:  
  
 [!code-csharp[csProgGuideGenerics#50](../../../csharp/programming-guide/generics/codesnippet/CSharp/generics-and-attributes_3.cs)]  
  
 An attribute can reference a closed constructed generic type:  
  
 [!code-csharp[csProgGuideGenerics#51](../../../csharp/programming-guide/generics/codesnippet/CSharp/generics-and-attributes_4.cs)]  
  
 An attribute that references a generic type parameter will cause a compile-time error:  
  
 [!code-csharp[csProgGuideGenerics#52](../../../csharp/programming-guide/generics/codesnippet/CSharp/generics-and-attributes_5.cs)]  
  
 A generic type cannot inherit from <xref:System.Attribute>:  
  
 [!code-csharp[csProgGuideGenerics#53](../../../csharp/programming-guide/generics/codesnippet/CSharp/generics-and-attributes_6.cs)]  
  
 To obtain information about a generic type or type parameter at run time, you can use the methods of <xref:System.Reflection>. For more information, see [Generics and Reflection](../../../csharp/programming-guide/generics/generics-and-reflection.md)  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Generics](../../../csharp/programming-guide/generics/index.md)  
 [Attributes](../../../../docs/standard/attributes/index.md)
