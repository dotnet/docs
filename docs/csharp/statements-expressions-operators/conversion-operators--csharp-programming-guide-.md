---
title: "Conversion Operators (C# Programming Guide)"
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
  - "C# language, conversion operators"
  - "conversion operators [C#]"
  - "operators [C#], conversion"
  - "user-defined conversions [C#]"
ms.assetid: c5ad73a3-d57b-4d2b-b4c9-24e3c2856efc
caps.latest.revision: 22
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "ru-ru"
  - "zh-cn"
  - "zh-tw"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# Conversion Operators (C# Programming Guide)
C# enables programmers to declare conversions on classes or structs so that classes or structs can be converted to and/or from other classes or structs, or basic types. Conversions are defined like operators and are named for the type to which they convert. Either the type of the argument to be converted, or the type of the result of the conversion, but not both, must be the containing type.  
  
 [!code[csProgGuideStatements#10](../classes-and-structs/codesnippet/CSharp/conversion-operators--csharp-programming-guide-_1.cs)]  
  
## Conversion Operators Overview  
 Conversion operators have the following properties:  
  
-   Conversions declared as `implicit` occur automatically when it is required.  
  
-   Conversions declared as `explicit` require a cast to be called.  
  
-   All conversions must be declared as `static`.  
  
## Related Sections  
 For more information:  
  
-   [Using Conversion Operators](../statements-expressions-operators/using-conversion-operators--csharp-programming-guide-.md)  
  
-   [Casting and Type Conversions](../types/casting-and-type-conversions--csharp-programming-guide-.md)  
  
-   [How to: Implement User-Defined Conversions Between Structs](../statements-expressions-operators/97839aef-8fbc-40d5-9769-6b569bc2710b.md)  
  
-   [explicit](../keywords/explicit--csharp-reference-.md)  
  
-   [implicit](../keywords/implicit--csharp-reference-.md)  
  
-   [static](../keywords/static--csharp-reference-.md)  
  
## See Also  
 <xref:System.Convert>   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Chained user-defined explicit conversions in C#](http://go.microsoft.com/fwlink/?LinkId=112384)