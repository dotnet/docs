---
title: "Generics (C# Programming Guide)"
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
  - "C# language, generics"
  - "generics [C#]"
ms.assetid: 75ea8509-a4ea-4e7a-a2b3-cf72482e9282
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
# Generics (C# Programming Guide)
Generics were added to version 2.0 of the C# language and the common language runtime (CLR). Generics introduce to the .NET Framework the concept of type parameters, which make it possible to design classes and methods that defer the specification of one or more types until the class or method is declared and instantiated by client code. For example, by using a generic type parameter T you can write a single class that other client code can use without incurring the cost or risk of runtime casts or boxing operations, as shown here:  
  
 [!code[csProgGuideGenerics#1](../generics/codesnippet/CSharp/generics--csharp-programming-guide-_1.cs)]  
  
## Generics Overview  
  
-   Use generic types to maximize code reuse, type safety, and performance.  
  
-   The most common use of generics is to create collection classes.  
  
-   The .NET Framework class library contains several new generic collection classes in the <xref:System.Collections.Generic> namespace. These should be used whenever possible instead of classes such as <xref:System.Collections.ArrayList> in the <xref:System.Collections> namespace.  
  
-   You can create your own generic interfaces, classes, methods, events and delegates.  
  
-   Generic classes may be constrained to enable access to methods on particular data types.  
  
-   Information on the types that are used in a generic data type may be obtained at run-time by using reflection.  
  
## Related Sections  
 For more information:  
  
-   [Introduction to Generics](../generics/introduction-to-generics--csharp-programming-guide-.md)  
  
-   [Benefits of Generics](../generics/benefits-of-generics--csharp-programming-guide-.md)  
  
-   [Generic Type Parameters](../generics/generic-type-parameters--csharp-programming-guide-.md)  
  
-   [Constraints on Type Parameters](../generics/constraints-on-type-parameters--csharp-programming-guide-.md)  
  
-   [Generic Classes](../generics/generic-classes--csharp-programming-guide-.md)  
  
-   [Generic Interfaces](../generics/generic-interfaces--csharp-programming-guide-.md)  
  
-   [Generic Methods](../generics/generic-methods--csharp-programming-guide-.md)  
  
-   [Generic Delegates](../generics/generic-delegates--csharp-programming-guide-.md)  
  
-   [default Keyword](../generics/default-keyword-in-generic-code--csharp-programming-guide-.md)  
  
-   [Differences Between C++ Templates and C# Generics](../generics/1da6beeb-d4a4-4da0-87b7-0cfbe04920b7.md)  
  
-   [Generics and Reflection](../generics/generics-and-reflection--csharp-programming-guide-.md)  
  
-   [Generics in the Run Time](../generics/generics-in-the-run-time--csharp-programming-guide-.md)  
  
-   [Generics in the .NET Framework Class Library](../generics/generics-in-the-.net-framework-class-library--csharp-programming-guide-.md)  
  
## C# Language Specification  
 For more information, see the [C# Language Specification](../language-reference/csharp-language-specification.md).  
  
## See Also  
 <xref:System.Collections.Generic>   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Types](../types/types--csharp-programming-guide-.md)   
 [\<typeparam>](../xmldoc/-typeparam---csharp-programming-guide-.md)   
 [\<typeparamref>](../xmldoc/-typeparamref---csharp-programming-guide-.md)