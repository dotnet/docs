---
title: "Generic Methods (C# Programming Guide)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "generics [C#], methods"
ms.assetid: 673eeea2-4b48-4faa-9c4e-2e89449221b9
caps.latest.revision: 27
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# Generic Methods (C# Programming Guide)
A generic method is a method that is declared with type parameters, as follows:  
  
 [!code[csProgGuideGenerics#22](../generics/codesnippet/CSharp/generic-methods--csharp-programming-guide-_1.cs)]  
  
 The following code example shows one way to call the method by using `int` for the type argument:  
  
 [!code[csProgGuideGenerics#23](../generics/codesnippet/CSharp/generic-methods--csharp-programming-guide-_2.cs)]  
  
 You can also omit the type argument and the compiler will infer it. The following call to `Swap` is equivalent to the previous call:  
  
 [!code[csProgGuideGenerics#24](../generics/codesnippet/CSharp/generic-methods--csharp-programming-guide-_3.cs)]  
  
 The same rules for type inference apply to static methods and instance methods. The compiler can infer the type parameters based on the method arguments you pass in; it cannot infer the type parameters only from a constraint or return value. Therefore type inference does not work with methods that have no parameters. Type inference occurs at compile time before the compiler tries to resolve overloaded method signatures. The compiler applies type inference logic to all generic methods that share the same name. In the overload resolution step, the compiler includes only those generic methods on which type inference succeeded.  
  
 Within a generic class, non-generic methods can access the class-level type parameters, as follows:  
  
 [!code[csProgGuideGenerics#25](../generics/codesnippet/CSharp/generic-methods--csharp-programming-guide-_4.cs)]  
  
 If you define a generic method that takes the same type parameters as the containing class, the compiler generates warning CS0693 because within the method scope, the argument supplied for the inner `T` hides the argument supplied for the outer `T`. If you require the flexibility of calling a generic class method with type arguments other than the ones provided when the class was instantiated, consider providing another identifier for the type parameter of the method, as shown in `GenericList2<T>` in the following example.  
  
 [!code[csProgGuideGenerics#26](../generics/codesnippet/CSharp/generic-methods--csharp-programming-guide-_5.cs)]  
  
 Use constraints to enable more specialized operations on type parameters in methods. This version of `Swap<T>`, now named `SwapIfGreater<T>`, can only be used with type arguments that implement <xref:System.IComparable`1>.  
  
 [!code[csProgGuideGenerics#27](../generics/codesnippet/CSharp/generic-methods--csharp-programming-guide-_6.cs)]  
  
 Generic methods can be overloaded on several type parameters. For example, the following methods can all be located in the same class:  
  
 [!code[csProgGuideGenerics#28](../generics/codesnippet/CSharp/generic-methods--csharp-programming-guide-_7.cs)]  
  
## C# Language Specification  
 For more information, see the [C# Language Specification](../language-reference/csharp-language-specification.md).  
  
## See Also  
 <xref:System.Collections.Generic>   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Introduction to Generics](../generics/introduction-to-generics--csharp-programming-guide-.md)   
 [Methods](../classes-and-structs/methods--csharp-programming-guide-.md)