---
title: "protected (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "protected"
  - "protected_CSharpKeyword"
helpviewer_keywords: 
  - "protected keyword [C#]"
ms.assetid: 05ce3794-6675-4025-bddb-eaaa0ec22892
caps.latest.revision: 20
author: "BillWagner"
ms.author: "wiwagn"
---
# protected (C# Reference)
The `protected` keyword is a member access modifier. 

 > This page covers `protected` access. The `protected` keyword is also part of the [`protected internal`](./protected-internal.md) and [`private protected`](./private-protected.md) access modifiers. 

A protected member is accessible within its class and by derived class instances. 

For a comparison of `protected` with the other access modifiers, see [Accessibility Levels](../../../csharp/language-reference/keywords/accessibility-levels.md). 
  
## Example  
 A protected member of a base class is accessible in a derived class only if the access occurs through the derived class type. For example, consider the following code segment:  
  
 [!code-csharp[csrefKeywordsModifiers#11](../../../csharp/language-reference/keywords/codesnippet/CSharp/protected_1.cs)]  
  
 The statement `a.x = 10` generates an error because it is made within the static method Main, and not an instance of class B.  
  
 Struct members cannot be protected because the struct cannot be inherited.  
  
## Example  
 In this example, the class `DerivedPoint` is derived from `Point`. Therefore, you can access the protected members of the base class directly from the derived class.  
  
 [!code-csharp[csrefKeywordsModifiers#12](../../../csharp/language-reference/keywords/codesnippet/CSharp/protected_2.cs)]  
  
 If you change the access levels of `x` and `y` to [private](../../../csharp/language-reference/keywords/private.md), the compiler will issue the error messages:  
  
 `'Point.y' is inaccessible due to its protection level.`  
  
 `'Point.x' is inaccessible due to its protection level.`  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [Access Modifiers](../../../csharp/language-reference/keywords/access-modifiers.md)  
 [Accessibility Levels](../../../csharp/language-reference/keywords/accessibility-levels.md)  
 [Modifiers](../../../csharp/language-reference/keywords/modifiers.md)  
 [public](../../../csharp/language-reference/keywords/public.md)  
 [private](../../../csharp/language-reference/keywords/private.md)  
 [internal](../../../csharp/language-reference/keywords/internal.md)  
 [Security concerns for internal virtual keywords](https://msdn.microsoft.com/library/heyd8kky(v=vs.110))