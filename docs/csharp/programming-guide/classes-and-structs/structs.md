---
title: "Structs (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "C# language, structs"
  - "structs [C#]"
ms.assetid: b7cf4ff2-0eb7-4e5c-93d5-b2196b4f5d89
caps.latest.revision: 31
author: "BillWagner"
ms.author: "wiwagn"
---
# Structs (C# Programming Guide)
Structs are defined by using the [struct](../../../csharp/language-reference/keywords/struct.md) keyword, for example:  
  
 [!code-csharp[csProgGuideObjects#39](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/structs_1.cs)]  
  
 Structs share most of the same syntax as classes, although structs are more limited than classes:  
  
-   Within a struct declaration, fields cannot be initialized unless they are declared as const or static.  
  
-   A struct cannot declare a default constructor (a constructor without parameters) or a finalizer.  
  
-   Structs are copied on assignment. When a struct is assigned to a new variable, all the data is copied, and any modification to the new copy does not change the data for the original copy. This is important to remember when working with collections of value types such as Dictionary\<string, myStruct>.  
  
-   Structs are value types and classes are reference types.  
  
-   Unlike classes, structs can be instantiated without using a `new` operator.  
  
-   Structs can declare constructors that have parameters.  
  
-   A struct cannot inherit from another struct or class, and it cannot be the base of a class. All structs inherit directly from `System.ValueType`, which inherits from `System.Object`.  
  
-   A struct can implement interfaces.  
  
-   A struct can be used as a nullable type and can be assigned a null value.  
  
## Related Sections  
 For more information:  
  
-   [Using Structs](../../../csharp/programming-guide/classes-and-structs/using-structs.md)  
  
-   [Constructors](../../../csharp/programming-guide/classes-and-structs/constructors.md)  
  
-   [Nullable Types](../../../csharp/programming-guide/nullable-types/index.md)  
  
-   [How to: Know the Difference Between Passing a Struct and Passing a Class Reference to a Method](../../../csharp/programming-guide/classes-and-structs/how-to-know-the-difference-passing-a-struct-and-passing-a-class-to-a-method.md)  
  
-   [How to: Implement User-Defined Conversions Between Structs](../../../csharp/programming-guide/statements-expressions-operators/how-to-implement-user-defined-conversions-between-structs.md)  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Classes and Structs](../../../csharp/programming-guide/classes-and-structs/index.md)  
 [Classes](../../../csharp/programming-guide/classes-and-structs/classes.md)
