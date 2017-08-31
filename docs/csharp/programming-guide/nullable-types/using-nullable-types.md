---
title: "Using Nullable Types (C# Programming Guide) | Microsoft Docs"
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
---
# Using Nullable Types (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

Nullable types can represent all the values of an underlying type, and an additional [null](../../../csharp/language-reference/keywords/null.md) value. Nullable types are declared in one of two ways:  
  
 `System.Nullable<T> variable`  
  
 -or-  
  
 `T? variable`  
  
 `T` is the underlying type of the nullable type. `T` can be any value type including `struct`; it cannot be a reference type.  
  
 For an example of when you might use a nullable type, consider how an ordinary Boolean variable can have two values: true and false. There is no value that signifies "undefined". In many programming applications, most notably database interactions, variables can occur in an undefined state. For example, a field in a database may contain the values true or false, but it may also contain no value at all. Similarly, reference types can be set to `null` to indicate that they are not initialized.  
  
 This disparity can create extra programming work, with additional variables used to store state information, the use of special values, and so on. The nullable type modifier enables C# to create value-type variables that indicate an undefined value.  
  
## Examples of Nullable Types  
 Any value type may be used as the basis for a nullable type. For example:  
  
 [!code-csharp[csProgGuideTypes#4](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/CsProgGuideTypes/CS/Class1.cs#4)]  
  
## The Members of Nullable Types  
 Each instance of a nullable type has two public read-only properties:  
  
-   `HasValue`  
  
     `HasValue` is of type `bool`. It is set to `true` when the variable contains a non-null value.  
  
-   `Value`  
  
     `Value` is of the same type as the underlying type. If `HasValue` is `true`, `Value` contains a meaningful value. If `HasValue` is `false`, accessing `Value` will throw a <xref:System.InvalidOperationException>.  
  
 In this example, the `HasValue` member is used to test whether the variable contains a value before it tries to display it.  
  
 [!code-csharp[csProgGuideTypes#5](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/CsProgGuideTypes/CS/Class1.cs#5)]  
  
 Testing for a value can also be done as in the following example:  
  
 [!code-csharp[csProgGuideTypes#6](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/CsProgGuideTypes/CS/Class1.cs#6)]  
  
## Explicit Conversions  
 A nullable type can be cast to a regular type, either explicitly with a cast, or by using the `Value` property. For example:  
  
 [!code-csharp[csProgGuideTypes#7](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/CsProgGuideTypes/CS/Class1.cs#7)]  
  
 If a user-defined conversion is defined between two data types, the same conversion can also be used with the nullable versions of these data types.  
  
## Implicit Conversions  
 A variable of nullable type can be set to null with the `null` keyword, as shown in the following example:  
  
 [!code-csharp[csProgGuideTypes#8](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/CsProgGuideTypes/CS/Class1.cs#8)]  
  
 The conversion from an ordinary type to a nullable type, is implicit.  
  
 [!code-csharp[csProgGuideTypes#9](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/CsProgGuideTypes/CS/Class1.cs#9)]  
  
## Operators  
 The predefined unary and binary operators and any user-defined operators that exist for value types may also be used by nullable types. These operators produce a null value if the operands are null; otherwise, the operator uses the contained value to calculate the result. For example:  
  
 [!code-csharp[csProgGuideTypes#10](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/CsProgGuideTypes/CS/Class1.cs#10)]  
  
 When you perform comparisons with nullable types, if the value of one of the nullable types is null and the other is not, all comparisons evaluate to `false` except for `!=` (not equal). It is important not to assume that because a particular comparison returns `false`, the opposite case returns `true`. In the following example, 10 is not greater than, less than, nor equal to null. Only `num1 != num2` evaluates to `true`.  
  
 [!code-csharp[csProgGuideTypes#11](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/CsProgGuideTypes/CS/Class1.cs#11)]  
  
 An equality comparison of two nullable types that are both null evaluates to `true`.  
  
## The ?? Operator  
 The `??` operator defines a default value that is returned when a nullable type is assigned to a non-nullable type.  
  
 [!code-csharp[csProgGuideTypes#12](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/CsProgGuideTypes/CS/Class1.cs#12)]  
  
 This operator can also be used with multiple nullable types. For example:  
  
 [!code-csharp[csProgGuideTypes#13](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/CsProgGuideTypes/CS/Class1.cs#13)]  
  
## The bool? type  
 The `bool?` nullable type can contain three different values: [true](../../../csharp/language-reference/keywords/true.md), [false](../../../csharp/language-reference/keywords/false.md) and [null](../../../csharp/language-reference/keywords/null.md). For information about how to cast from a bool? to a bool, see [How to: Safely Cast from bool? to bool](../../../csharp/programming-guide/nullable-types/how-to-safely-cast-from-bool-to-bool.md).  
  
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
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Nullable Types](../../../csharp/programming-guide/nullable-types/index.md)   
 [Boxing Nullable Types](../../../csharp/programming-guide/nullable-types/boxing-nullable-types.md)   
 [Nullable Value Types](../../../visual-basic/programming-guide/language-features/data-types/nullable-value-types.md)