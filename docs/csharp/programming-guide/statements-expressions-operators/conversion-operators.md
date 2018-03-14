---
title: "Conversion Operators (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "C# language, conversion operators"
  - "conversion operators [C#]"
  - "operators [C#], conversion"
  - "user-defined conversions [C#]"
ms.assetid: c5ad73a3-d57b-4d2b-b4c9-24e3c2856efc
caps.latest.revision: 22
author: "BillWagner"
ms.author: "wiwagn"
---
# Conversion Operators (C# Programming Guide)
C# enables programmers to declare conversions on classes or structs so that classes or structs can be converted to and/or from other classes or structs, or basic types. Conversions are defined like operators and are named for the type to which they convert. Either the type of the argument to be converted, or the type of the result of the conversion, but not both, must be the containing type.  
  
 [!code-csharp[csProgGuideStatements#10](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/conversion-operators_1.cs)]  
  
## Conversion Operators Overview  
 Conversion operators have the following properties:  
  
-   Conversions declared as `implicit` occur automatically when it is required.  
  
-   Conversions declared as `explicit` require a cast to be called.  
  
-   All conversions must be declared as `static`.  
  
## Related Sections  
 For more information:  
  
-   [Using Conversion Operators](../../../csharp/programming-guide/statements-expressions-operators/using-conversion-operators.md)  
  
-   [Casting and Type Conversions](../../../csharp/programming-guide/types/casting-and-type-conversions.md)  
  
-   [How to: Implement User-Defined Conversions Between Structs](../../../csharp/programming-guide/statements-expressions-operators/how-to-implement-user-defined-conversions-between-structs.md)  
  
-   [explicit](../../../csharp/language-reference/keywords/explicit.md)  
  
-   [implicit](../../../csharp/language-reference/keywords/implicit.md)  
  
-   [static](../../../csharp/language-reference/keywords/static.md)  
  
## See Also  
 <xref:System.Convert>  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Chained user-defined explicit conversions in C#](https://blogs.msdn.microsoft.com/ericlippert/2007/04/16/chained-user-defined-explicit-conversions-in-c/)
