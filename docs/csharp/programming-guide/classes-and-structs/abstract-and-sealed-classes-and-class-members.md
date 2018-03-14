---
title: "Abstract and Sealed Classes and Class Members (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "abstract classes [C#]"
  - "sealed classes [C#]"
  - "C# language, abstract classes"
  - "C# language, sealed"
ms.assetid: 99aa52f7-b435-43f9-936e-2470af734c4e
caps.latest.revision: 14
author: "BillWagner"
ms.author: "wiwagn"
---
# Abstract and Sealed Classes and Class Members (C# Programming Guide)
The [abstract](../../../csharp/language-reference/keywords/abstract.md) keyword enables you to create classes and [class](../../../csharp/language-reference/keywords/class.md) members that are incomplete and must be implemented in a derived class.  
  
 The [sealed](../../../csharp/language-reference/keywords/sealed.md) keyword enables you to prevent the inheritance of a class or certain class members that were previously marked [virtual](../../../csharp/language-reference/keywords/virtual.md).  
  
## Abstract Classes and Class Members  
 Classes can be declared as abstract by putting the keyword `abstract` before the class definition. For example:  
  
 [!code-csharp[csProgGuideInheritance#13](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/abstract-and-sealed-classes-and-class-members_1.cs)]  
  
 An abstract class cannot be instantiated. The purpose of an abstract class is to provide a common definition of a base class that multiple derived classes can share. For example, a class library may define an abstract class that is used as a parameter to many of its functions, and require programmers using that library to provide their own implementation of the class by creating a derived class.  
  
 Abstract classes may also define abstract methods. This is accomplished by adding the keyword `abstract` before the return type of the method. For example:  
  
 [!code-csharp[csProgGuideInheritance#14](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/abstract-and-sealed-classes-and-class-members_2.cs)]  
  
 Abstract methods have no implementation, so the method definition is followed by a semicolon instead of a normal method block. Derived classes of the abstract class must implement all abstract methods. When an abstract class inherits a virtual method from a base class, the abstract class can override the virtual method with an abstract method. For example:  
  
 [!code-csharp[csProgGuideInheritance#15](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/abstract-and-sealed-classes-and-class-members_3.cs)]  
  
 If a `virtual` method is declared `abstract`, it is still virtual to any class inheriting from the abstract class. A class inheriting an abstract method cannot access the original implementation of the method—in the previous example, `DoWork` on class F cannot call `DoWork` on class D. In this way, an abstract class can force derived classes to provide new method implementations for virtual methods.  
  
## Sealed Classes and Class Members  
 Classes can be declared as [sealed](../../../csharp/language-reference/keywords/sealed.md) by putting the keyword `sealed` before the class definition. For example:  
  
 [!code-csharp[csProgGuideInheritance#16](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/abstract-and-sealed-classes-and-class-members_4.cs)]  
  
 A sealed class cannot be used as a base class. For this reason, it cannot also be an abstract class. Sealed classes prevent derivation. Because they can never be used as a base class, some run-time optimizations can make calling sealed class members slightly faster.  
  
 A method, indexer, property, or event, on a derived class that is overriding a virtual member of the base class can declare that member as sealed. This negates the virtual aspect of the member for any further derived class. This is accomplished by putting the `sealed` keyword before the [override](../../../csharp/language-reference/keywords/override.md) keyword in the class member declaration. For example:  
  
 [!code-csharp[csProgGuideInheritance#17](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/abstract-and-sealed-classes-and-class-members_5.cs)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Classes and Structs](../../../csharp/programming-guide/classes-and-structs/index.md)  
 [Inheritance](../../../csharp/programming-guide/classes-and-structs/inheritance.md)  
 [Methods](../../../csharp/programming-guide/classes-and-structs/methods.md)  
 [Fields](../../../csharp/programming-guide/classes-and-structs/fields.md)  
 [How to: Define Abstract Properties](../../../csharp/programming-guide/classes-and-structs/how-to-define-abstract-properties.md)
