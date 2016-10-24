---
title: "Using Nullable Types (C# Programming Guide)"
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
  - "nullable types [C#], about nullable types"
ms.assetid: 0bacbe72-ce15-4b14-83e1-9c14e6380c28
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
# Using Nullable Types (C# Programming Guide)
Nullable types can represent all the values of an underlying type, and an additional [null](../keywords/null--csharp-reference-.md) value. Nullable types are declared in one of two ways:  
  
 `System.Nullable<T> variable`  
  
 -or-  
  
 `T? variable`  
  
 `T` is the underlying type of the nullable type. `T` can be any value type including `struct`; it cannot be a reference type.  
  
 For an example of when you might use a nullable type, consider how an ordinary Boolean variable can have two values: true and false. There is no value that signifies "undefined". In many programming applications, most notably database interactions, variables can occur in an undefined state. For example, a field in a database may contain the values true or false, but it may also contain no value at all. Similarly, reference types can be set to `null` to indicate that they are not initialized.  
  
 This disparity can create extra programming work, with additional variables used to store state information, the use of special values, and so on. The nullable type modifier enables C# to create value-type variables that indicate an undefined value.  
  
## Examples of Nullable Types  
 Any value type may be used as the basis for a nullable type. For example:  
  
 [!code[csProgGuideTypes#4](../nullable-types/codesnippet/CSharp/using-nullable-types--csharp-programming-guide-_1.cs)]  
  
## The Members of Nullable Types  
 Each instance of a nullable type has two public read-only properties:  
  
-   `HasValue`  
  
     `HasValue` is of type `bool`. It is set to `true` when the variable contains a non-null value.  
  
-   `Value`  
  
     `Value` is of the same type as the underlying type. If `HasValue` is `true`, `Value` contains a meaningful value. If `HasValue` is `false`, accessing `Value` will throw a <xref:System.InvalidOperationException>.  
  
 In this example, the `HasValue` member is used to test whether the variable contains a value before it tries to display it.  
  
 [!code[csProgGuideTypes#5](../nullable-types/codesnippet/CSharp/using-nullable-types--csharp-programming-guide-_2.cs)]  
  
 Testing for a value can also be done as in the following example:  
  
 [!code[csProgGuideTypes#6](../nullable-types/codesnippet/CSharp/using-nullable-types--csharp-programming-guide-_3.cs)]  
  
## Explicit Conversions  
 A nullable type can be cast to a regular type, either explicitly with a cast, or by using the `Value` property. For example:  
  
 [!code[csProgGuideTypes#7](../nullable-types/codesnippet/CSharp/using-nullable-types--csharp-programming-guide-_4.cs)]  
  
 If a user-defined conversion is defined between two data types, the same conversion can also be used with the nullable versions of these data types.  
  
## Implicit Conversions  
 A variable of nullable type can be set to null with the `null` keyword, as shown in the following example:  
  
 [!code[csProgGuideTypes#8](../nullable-types/codesnippet/CSharp/using-nullable-types--csharp-programming-guide-_5.cs)]  
  
 The conversion from an ordinary type to a nullable type, is implicit.  
  
 [!code[csProgGuideTypes#9](../nullable-types/codesnippet/CSharp/using-nullable-types--csharp-programming-guide-_6.cs)]  
  
## Operators  
 The predefined unary and binary operators and any user-defined operators that exist for value types may also be used by nullable types. These operators produce a null value if the operands are null; otherwise, the operator uses the contained value to calculate the result. For example:  
  
 [!code[csProgGuideTypes#10](../nullable-types/codesnippet/CSharp/using-nullable-types--csharp-programming-guide-_7.cs)]  
  
 When you perform comparisons with nullable types, if the value of one of the nullable types is null and the other is not, all comparisons evaluate to `false` except for `!=` (not equal). It is important not to assume that because a particular comparison returns `false`, the opposite case returns `true`. In the following example, 10 is not greater than, less than, nor equal to null. Only `num1 != num2` evaluates to `true`.  
  
 [!code[csProgGuideTypes#11](../nullable-types/codesnippet/CSharp/using-nullable-types--csharp-programming-guide-_8.cs)]  
  
 An equality comparison of two nullable types that are both null evaluates to `true`.  
  
## The ?? Operator  
 The `??` operator defines a default value that is returned when a nullable type is assigned to a non-nullable type.  
  
 [!code[csProgGuideTypes#12](../nullable-types/codesnippet/CSharp/using-nullable-types--csharp-programming-guide-_9.cs)]  
  
 This operator can also be used with multiple nullable types. For example:  
  
 [!code[csProgGuideTypes#13](../nullable-types/codesnippet/CSharp/using-nullable-types--csharp-programming-guide-_10.cs)]  
  
## The bool? type  
 The `bool?` nullable type can contain three different values: [true](../keywords/true--csharp-reference-.md), [false](../keywords/false--csharp-reference-.md) and [null](../keywords/null--csharp-reference-.md). For information about how to cast from a bool? to a bool, see [How to: Safely Cast from bool? to bool](../nullable-types/how-to--safely-cast-from-bool--to-bool--csharp-programming-guide-.md).  
  
 Nullable Booleans are like the Boolean variable type that is used in SQL. To ensure that the results produced by the `&` and `|` operators are consistent with the three-valued Boolean type in SQL, the following predefined operators are provided:  
  
 `bool? operator &(bool? x, bool? y)`  
  
 `bool? operator |(bool? x, bool? y)`  
  
 The results of these operators are listed in the following table:  
  
|X|y|x&y|x&#124;y|  
|-------|-------|---------|--------------|  
|true|true|true|true|  
|true|false|false|true|  
|true|null|null|true|  
|false|true|false|true|  
|false|false|false|false|  
|false|null|false|null|  
|null|true|null|true|  
|null|false|false|null|  
|null|null|null|null|  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Nullable Types](../nullable-types/nullable-types--csharp-programming-guide-.md)   
 [Boxing Nullable Types](../nullable-types/boxing-nullable-types--csharp-programming-guide-.md)   
 [Nullable Value Types](../Topic/Nullable%20Value%20Types%20\(Visual%20Basic\).md)