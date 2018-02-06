---
title: "sealed (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "sealed"
  - "sealed_CSharpKeyword"
helpviewer_keywords: 
  - "sealed keyword [C#]"
ms.assetid: 8e4ed5d3-10be-47db-9488-0da2008e6f3f
caps.latest.revision: 30
author: "BillWagner"
ms.author: "wiwagn"
---
# sealed (C# Reference)
When applied to a class, the `sealed` modifier prevents other classes from inheriting from it. In the following example, class `B` inherits from class `A`, but no class can inherit from class `B`.  
  
```  
class A {}      
sealed class B : A {}  
```  
  
 You can also use the `sealed` modifier on a method or property that overrides a virtual method or property in a base class. This enables you to allow classes to derive from your class and prevent them from overriding specific virtual methods or properties.  
  
## Example  
 In the following example, `Z` inherits from `Y` but `Z` cannot override the virtual function `F` that is declared in `X` and sealed in `Y`.  
  
 [!code-csharp[csrefKeywordsModifiers#16](../../../csharp/language-reference/keywords/codesnippet/CSharp/sealed_1.cs)]  
  
 When you define new methods or properties in a class, you can prevent deriving classes from overriding them by not declaring them as [virtual](../../../csharp/language-reference/keywords/virtual.md).  
  
 It is an error to use the [abstract](../../../csharp/language-reference/keywords/abstract.md) modifier with a sealed class, because an abstract class must be inherited by a class that provides an implementation of the abstract methods or properties.  
  
 When applied to a method or property, the `sealed` modifier must always be used with [override](../../../csharp/language-reference/keywords/override.md).  
  
 Because structs are implicitly sealed, they cannot be inherited.  
  
 For more information, see [Inheritance](../../../csharp/programming-guide/classes-and-structs/inheritance.md).  
  
 For more examples, see [Abstract and Sealed Classes and Class Members](../../../csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members.md).  
  
## Example  
 [!code-csharp[csrefKeywordsModifiers#17](../../../csharp/language-reference/keywords/codesnippet/CSharp/sealed_2.cs)]  
  
 In the previous example, you might try to inherit from the sealed class by using the following statement:  
  
 `class MyDerivedC: SealedClass {}   // Error`  
  
 The result is an error message:  
  
 `'MyDerivedC' cannot inherit from sealed class 'SealedClass'.`  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## Remarks  
 To determine whether to seal a class, method, or property, you should generally consider the following two points:  
  
-   The potential benefits that deriving classes might gain through the ability to customize your class.  
  
-   The potential that deriving classes could modify your classes in such a way that they would no longer work correctly or as expected.  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [Static Classes and Static Class Members](../../../csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members.md)  
 [Abstract and Sealed Classes and Class Members](../../../csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members.md)  
 [Access Modifiers](../../../csharp/programming-guide/classes-and-structs/access-modifiers.md)  
 [Modifiers](../../../csharp/language-reference/keywords/modifiers.md)  
 [override](../../../csharp/language-reference/keywords/override.md)  
 [virtual](../../../csharp/language-reference/keywords/virtual.md)
