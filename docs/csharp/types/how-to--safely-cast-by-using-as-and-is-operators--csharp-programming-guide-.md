---
title: "How to: Safely Cast by Using as and is Operators (C# Programming Guide)"
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
  - "cast operators [C#], as and is operators"
  - "as operator [C#]"
  - "is operator [C#]"
ms.assetid: c1176cea-1426-4a44-8570-3eadafa58863
caps.latest.revision: 10
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
# How to: Safely Cast by Using as and is Operators (C# Programming Guide)
Because objects are polymorphic, it is possible for a variable of a base class type to hold a derived type. To access the derived type's method, it is necessary to cast the value back to the derived type. However, to attempt a simple cast in these cases creates the risk of throwing an <xref:System.InvalidCastException>. That is why C# provides the [is](../keywords/is--csharp-reference-.md) and [as](../keywords/as--csharp-reference-.md) operators. You can use these operators to test whether a cast will succeed without causing an exception to be thrown. In general, the `as` operator is more efficient because it actually returns the cast value if the cast can be made successfully. The `is` operator returns only a Boolean value. It can therefore be used when you just want to determine an object's type but do not have to actually cast it.  
  
## Example  
 The following examples show how to use the `is` and `as` operators to cast from one reference type to another without the risk of throwing an exception. The example also shows how to use the `as` operator with nullable value types.  
  
 [!code[csProgGuideTypes#40](../nullable-types/codesnippet/CSharp/how-to--safely-cast-by-using-as-and-is-operators--csharp-programming-guide-_1.cs)]  
  
## See Also  
 [Types](../types/types--csharp-programming-guide-.md)   
 [Casting and Type Conversions](../types/casting-and-type-conversions--csharp-programming-guide-.md)   
 [Nullable Types](../nullable-types/nullable-types--csharp-programming-guide-.md)