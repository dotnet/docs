---
title: "Generics (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "C# language, generics"
  - "generics [C#]"
ms.assetid: 75ea8509-a4ea-4e7a-a2b3-cf72482e9282
caps.latest.revision: 23
author: "BillWagner"
ms.author: "wiwagn"
---
# Generics (C# Programming Guide)
Generics were added to version 2.0 of the C# language and the common language runtime (CLR). Generics introduce to the .NET Framework the concept of type parameters, which make it possible to design classes and methods that defer the specification of one or more types until the class or method is declared and instantiated by client code. For example, by using a generic type parameter T you can write a single class that other client code can use without incurring the cost or risk of runtime casts or boxing operations, as shown here:  
  
 [!code-csharp[csProgGuideGenerics#1](../../../csharp/programming-guide/generics/codesnippet/CSharp/index_1.cs)]  
  
## Generics Overview  
  
-   Use generic types to maximize code reuse, type safety, and performance.  
  
-   The most common use of generics is to create collection classes.  
  
-   The .NET Framework class library contains several new generic collection classes in the <xref:System.Collections.Generic> namespace. These should be used whenever possible instead of classes such as <xref:System.Collections.ArrayList> in the <xref:System.Collections> namespace.  
  
-   You can create your own generic interfaces, classes, methods, events and delegates.  
  
-   Generic classes may be constrained to enable access to methods on particular data types.  
  
-   Information on the types that are used in a generic data type may be obtained at run-time by using reflection.  
  
## Related Sections  
 For more information:  
  
-   [Introduction to Generics](../../../csharp/programming-guide/generics/introduction-to-generics.md)  
  
-   [Benefits of Generics](../../../csharp/programming-guide/generics/benefits-of-generics.md)  
  
-   [Generic Type Parameters](../../../csharp/programming-guide/generics/generic-type-parameters.md)  
  
-   [Constraints on Type Parameters](../../../csharp/programming-guide/generics/constraints-on-type-parameters.md)  
  
-   [Generic Classes](../../../csharp/programming-guide/generics/generic-classes.md)  
  
-   [Generic Interfaces](../../../csharp/programming-guide/generics/generic-interfaces.md)  
  
-   [Generic Methods](../../../csharp/programming-guide/generics/generic-methods.md)  
  
-   [Generic Delegates](../../../csharp/programming-guide/generics/generic-delegates.md)  
  
-   [Differences Between C++ Templates and C# Generics](../../../csharp/programming-guide/generics/differences-between-cpp-templates-and-csharp-generics.md)  
  
-   [Generics and Reflection](../../../csharp/programming-guide/generics/generics-and-reflection.md)  
  
-   [Generics in the Run Time](../../../csharp/programming-guide/generics/generics-in-the-run-time.md)  
  
-   [Generics in the .NET Framework Class Library](../../../csharp/programming-guide/generics/generics-in-the-net-framework-class-library.md)  
  
## C# Language Specification  
 For more information, see the [C# Language Specification](../../../csharp/language-reference/language-specification/index.md).  
  
## See Also  
 <xref:System.Collections.Generic>  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Types](../../../csharp/programming-guide/types/index.md)  
 [\<typeparam>](../../../csharp/programming-guide/xmldoc/typeparam.md)  
 [\<typeparamref>](../../../csharp/programming-guide/xmldoc/typeparamref.md)
