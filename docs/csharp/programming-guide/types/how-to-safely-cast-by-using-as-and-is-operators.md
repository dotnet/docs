---
title: "How to: Safely Cast by Using as and is Operators (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "cast operators [C#], as and is operators"
  - "as operator [C#]"
  - "is operator [C#]"
ms.assetid: c1176cea-1426-4a44-8570-3eadafa58863
caps.latest.revision: 10
author: "BillWagner"
ms.author: "wiwagn"
---
# How to: Safely Cast by Using as and is Operators (C# Programming Guide)
Because objects are polymorphic, it is possible for a variable of a base class type to hold a derived type. To access the derived type's method, it is necessary to cast the value back to the derived type. However, to attempt a simple cast in these cases creates the risk of throwing an <xref:System.InvalidCastException>. That is why C# provides the [is](../../../csharp/language-reference/keywords/is.md) and [as](../../../csharp/language-reference/keywords/as.md) operators. You can use these operators to test whether a cast will succeed without causing an exception to be thrown. In general, the `as` operator is more efficient because it actually returns the cast value if the cast can be made successfully. The `is` operator returns only a Boolean value. It can therefore be used when you just want to determine an object's type but do not have to actually cast it.  
  
## Example  
 The following examples show how to use the `is` and `as` operators to cast from one reference type to another without the risk of throwing an exception. The example also shows how to use the `as` operator with nullable value types.  
  
 [!code-csharp[csProgGuideTypes#40](../../../csharp/programming-guide/nullable-types/codesnippet/CSharp/how-to-safely-cast-by-using-as-and-is-operators_1.cs)]  
  
## See Also  
 [Types](../../../csharp/programming-guide/types/index.md)  
 [Casting and Type Conversions](../../../csharp/programming-guide/types/casting-and-type-conversions.md)  
 [Nullable Types](../../../csharp/programming-guide/nullable-types/index.md)
