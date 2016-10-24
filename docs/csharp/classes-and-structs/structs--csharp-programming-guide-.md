---
title: "Structs (C# Programming Guide)"
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
  - "C# language, structs"
  - "structs [C#]"
ms.assetid: b7cf4ff2-0eb7-4e5c-93d5-b2196b4f5d89
caps.latest.revision: 31
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
# Structs (C# Programming Guide)
Structs are defined by using the [struct](../keywords/struct--csharp-reference-.md) keyword, for example:  
  
 [!code[csProgGuideObjects#39](../classes-and-structs/codesnippet/CSharp/structs--csharp-programming-guide-_1.cs)]  
  
 Structs share most of the same syntax as classes, although structs are more limited than classes:  
  
-   Within a struct declaration, fields cannot be initialized unless they are declared as const or static.  
  
-   A struct cannot declare a default constructor (a constructor without parameters) or a destructor.  
  
-   Structs are copied on assignment. When a struct is assigned to a new variable, all the data is copied, and any modification to the new copy does not change the data for the original copy. This is important to remember when working with collections of value types such as Dictionary\<string, myStruct>.  
  
-   Structs are value types and classes are reference types.  
  
-   Unlike classes, structs can be instantiated without using a `new` operator.  
  
-   Structs can declare constructors that have parameters.  
  
-   A struct cannot inherit from another struct or class, and it cannot be the base of a class. All structs inherit directly from `System.ValueType`, which inherits from `System.Object`.  
  
-   A struct can implement interfaces.  
  
-   A struct can be used as a nullable type and can be assigned a null value.  
  
## Related Sections  
 For more information:  
  
-   [Using Structs](../classes-and-structs/using-structs--csharp-programming-guide-.md)  
  
-   [Constructors](../classes-and-structs/constructors--csharp-programming-guide-.md)  
  
-   [Nullable Types](../nullable-types/nullable-types--csharp-programming-guide-.md)  
  
-   [How to: Know the Difference Between Passing a Struct and Passing a Class Reference to a Method](../classes-and-structs/9c1313a6-32a8-4ea7-a59f-450f66af628b.md)  
  
-   [How to: Implement User-Defined Conversions Between Structs](../statements-expressions-operators/97839aef-8fbc-40d5-9769-6b569bc2710b.md)  
  
-   [More About Variables](http://go.microsoft.com/fwlink/?LinkId=221230) in [Beginning Visual C# 2010](http://go.microsoft.com/fwlink/?LinkId=221214)  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Classes and Structs](../classes-and-structs/classes-and-structs--csharp-programming-guide-.md)   
 [Classes](../classes-and-structs/classes--csharp-programming-guide-.md)