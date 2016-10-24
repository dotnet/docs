---
title: "Abstract and Sealed Classes and Class Members (C# Programming Guide)"
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
  - "abstract classes [C#]"
  - "sealed classes [C#]"
  - "C# language, abstract classes"
  - "C# language, sealed"
ms.assetid: 99aa52f7-b435-43f9-936e-2470af734c4e
caps.latest.revision: 14
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
# Abstract and Sealed Classes and Class Members (C# Programming Guide)
The [abstract](../keywords/abstract--csharp-reference-.md) keyword enables you to create classes and [class](../keywords/class--csharp-reference-.md) members that are incomplete and must be implemented in a derived class.  
  
 The [sealed](../keywords/sealed--csharp-reference-.md) keyword enables you to prevent the inheritance of a class or certain class members that were previously marked [virtual](../keywords/virtual--csharp-reference-.md).  
  
## Abstract Classes and Class Members  
 Classes can be declared as abstract by putting the keyword `abstract` before the class definition. For example:  
  
 [!code[csProgGuideInheritance#13](../classes-and-structs/codesnippet/CSharp/abstract-and-sealed-classes-and-class-members--csharp-programming-guide-_1.cs)]  
  
 An abstract class cannot be instantiated. The purpose of an abstract class is to provide a common definition of a base class that multiple derived classes can share. For example, a class library may define an abstract class that is used as a parameter to many of its functions, and require programmers using that library to provide their own implementation of the class by creating a derived class.  
  
 Abstract classes may also define abstract methods. This is accomplished by adding the keyword `abstract` before the return type of the method. For example:  
  
 [!code[csProgGuideInheritance#14](../classes-and-structs/codesnippet/CSharp/abstract-and-sealed-classes-and-class-members--csharp-programming-guide-_2.cs)]  
  
 Abstract methods have no implementation, so the method definition is followed by a semicolon instead of a normal method block. Derived classes of the abstract class must implement all abstract methods. When an abstract class inherits a virtual method from a base class, the abstract class can override the virtual method with an abstract method. For example:  
  
 [!code[csProgGuideInheritance#15](../classes-and-structs/codesnippet/CSharp/abstract-and-sealed-classes-and-class-members--csharp-programming-guide-_3.cs)]  
  
 If a `virtual` method is declared `abstract`, it is still virtual to any class inheriting from the abstract class. A class inheriting an abstract method cannot access the original implementation of the method—in the previous example, `DoWork` on class F cannot call `DoWork` on class D. In this way, an abstract class can force derived classes to provide new method implementations for virtual methods.  
  
## Sealed Classes and Class Members  
 Classes can be declared as [sealed](../keywords/sealed--csharp-reference-.md) by putting the keyword `sealed` before the class definition. For example:  
  
 [!code[csProgGuideInheritance#16](../classes-and-structs/codesnippet/CSharp/abstract-and-sealed-classes-and-class-members--csharp-programming-guide-_4.cs)]  
  
 A sealed class cannot be used as a base class. For this reason, it cannot also be an abstract class. Sealed classes prevent derivation. Because they can never be used as a base class, some run-time optimizations can make calling sealed class members slightly faster.  
  
 A method, indexer, property, or event, on a derived class that is overriding a virtual member of the base class can declare that member as sealed. This negates the virtual aspect of the member for any further derived class. This is accomplished by putting the `sealed` keyword before the [override](../keywords/override--csharp-reference-.md) keyword in the class member declaration. For example:  
  
 [!code[csProgGuideInheritance#17](../classes-and-structs/codesnippet/CSharp/abstract-and-sealed-classes-and-class-members--csharp-programming-guide-_5.cs)]  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Classes and Structs](../classes-and-structs/classes-and-structs--csharp-programming-guide-.md)   
 [Inheritance](../classes-and-structs/inheritance--csharp-programming-guide-.md)   
 [Methods](../classes-and-structs/methods--csharp-programming-guide-.md)   
 [Fields](../classes-and-structs/fields--csharp-programming-guide-.md)   
 [How to: Define Abstract Properties](../classes-and-structs/how-to--define-abstract-properties--csharp-programming-guide-.md)