---
title: "Generic Type Parameters (C# Programming Guide)"
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
  - "generics [C#], type parameters"
  - "type parameters [C#]"
ms.assetid: a03b0ab2-0606-4b41-b7bf-e64d5bb4d18f
caps.latest.revision: 23
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
# Generic Type Parameters (C# Programming Guide)
In a generic type or method definition, a type parameters is a placeholder for a specific type that a client specifies when they instantiate a variable of the generic type. A generic class, such as `GenericList<T>` listed in [Introduction to Generics](../generics/introduction-to-generics--csharp-programming-guide-.md), cannot be used as-is because it is not really a type; it is more like a blueprint for a type. To use `GenericList<T>`, client code must declare and instantiate a constructed type by specifying a type argument inside the angle brackets. The type argument for this particular class can be any type recognized by the compiler. Any number of constructed type instances can be created, each one using a different type argument, as follows:  
  
 [!code[csProgGuideGenerics#7](../generics/codesnippet/CSharp/generic-type-parameters--csharp-programming-guide-_1.cs)]  
  
 In each of these instances of `GenericList<T>`, every occurrence of `T` in the class will be substituted at run time with the type argument. By means of this substitution, we have created three separate type-safe and efficient objects using a single class definition. For more information on how this substitution is performed by the CLR, see [Generics in the Run Time](../generics/generics-in-the-run-time--csharp-programming-guide-.md).  
  
## Type Parameter Naming Guidelines  
  
-   **Do** name generic type parameters with descriptive names, unless a single letter name is completely self explanatory and a descriptive name would not add value.  
  
     [!code[csProgGuideGenerics#8](../generics/codesnippet/CSharp/generic-type-parameters--csharp-programming-guide-_2.cs)]  
  
-   **Consider** using T as the type parameter name for types with one single letter type parameter.  
  
     [!code[csProgGuideGenerics#9](../generics/codesnippet/CSharp/generic-type-parameters--csharp-programming-guide-_3.cs)]  
  
-   **Do** prefix descriptive type parameter names with "T".  
  
     [!code[csProgGuideGenerics#10](../generics/codesnippet/CSharp/generic-type-parameters--csharp-programming-guide-_4.cs)]  
  
-   **Consider** indicating constraints placed on a type parameter in the name of parameter. For example, a parameter constrained to `ISession` may be called `TSession`.  
  
## See Also  
 <xref:System.Collections.Generic>   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Generics](../generics/generics--csharp-programming-guide-.md)   
 [Differences Between C++ Templates and C# Generics](../generics/1da6beeb-d4a4-4da0-87b7-0cfbe04920b7.md)