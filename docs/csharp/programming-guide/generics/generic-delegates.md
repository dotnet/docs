---
title: "Generic Delegates (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "generics [C#], delegates"
  - "delegates [C#], generic"
ms.assetid: bdea509c-44c1-4309-aaa9-15c7aee009df
caps.latest.revision: 16
author: "BillWagner"
ms.author: "wiwagn"
---
# Generic Delegates (C# Programming Guide)
A [delegate](../../../csharp/language-reference/keywords/delegate.md) can define its own type parameters. Code that references the generic delegate can specify the type argument to create a closed constructed type, just like when instantiating a generic class or calling a generic method, as shown in the following example:  
  
 [!code-csharp[csProgGuideGenerics#36](../../../csharp/programming-guide/generics/codesnippet/CSharp/generic-delegates_1.cs)]  
  
 C# version 2.0 has a new feature called method group conversion, which applies to concrete as well as generic delegate types, and enables you to write the previous line with this simplified syntax:  
  
 [!code-csharp[csProgGuideGenerics#37](../../../csharp/programming-guide/generics/codesnippet/CSharp/generic-delegates_2.cs)]  
  
 Delegates defined within a generic class can use the generic class type parameters in the same way that class methods do.  
  
 [!code-csharp[csProgGuideGenerics#38](../../../csharp/programming-guide/generics/codesnippet/CSharp/generic-delegates_3.cs)]  
  
 Code that references the delegate must specify the type argument of the containing class, as follows:  
  
 [!code-csharp[csProgGuideGenerics#39](../../../csharp/programming-guide/generics/codesnippet/CSharp/generic-delegates_4.cs)]  
  
 Generic delegates are especially useful in defining events based on the typical design pattern because the sender argument can be strongly typed and no longer has to be cast to and from <xref:System.Object>.  
  
 [!code-csharp[csProgGuideGenerics#40](../../../csharp/programming-guide/generics/codesnippet/CSharp/generic-delegates_5.cs)]  
  
## See Also  
 <xref:System.Collections.Generic>  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Introduction to Generics](../../../csharp/programming-guide/generics/introduction-to-generics.md)  
 [Generic Methods](../../../csharp/programming-guide/generics/generic-methods.md)  
 [Generic Classes](../../../csharp/programming-guide/generics/generic-classes.md)  
 [Generic Interfaces](../../../csharp/programming-guide/generics/generic-interfaces.md)  
 [Delegates](../../../csharp/programming-guide/delegates/index.md)  
 [Generics](~/docs/standard/generics/index.md)
