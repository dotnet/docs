---
title: "Classes and Structs (C# Programming Guide)"
description: Describes the use of classes and structures (structs) in C#.
keywords: classes (C#), structs (C#), structures (structs) (C#), reference types (C#), value types (C#)
ms.date: 01/17/2016
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "structs [C#], about structs"
  - "classes [C#], overview"
  - "C# language, structs"
  - "C# language, objects"
  - "objects [C#]"
  - "C# language, classes"
ms.assetid: cc39dbda-8754-423e-b5b1-16a1db0734c0
caps.latest.revision: 48
author: "BillWagner"
ms.author: "wiwagn"
---
# Classes and Structs (C# Programming Guide)
Classes and structs are two of the basic constructs of the common type system in the .NET Framework. Each is essentially a data structure that encapsulates a set of data and behaviors that belong together as a logical unit. The data and behaviors are the *members* of the class or struct, and they include its methods, properties, and events, and so on, as listed later in this topic.  
  
 A class or struct declaration is like a blueprint that is used to create instances or objects at run time. If you define a class or struct called `Person`, `Person` is the name of the type. If you declare and initialize a variable `p` of type `Person`, `p` is said to be an object or instance of `Person`. Multiple instances of the same `Person` type can be created, and each instance can have different values in its properties and fields.  
  
 A class is a reference type. When an object of the class is created, the variable to which the object is assigned holds only a reference to that memory. When the object reference is assigned to a new variable, the new variable refers to the original object. Changes made through one variable are reflected in the other variable because they both refer to the same data.  
  
 A struct is a value type. When a struct is created, the variable to which the struct is assigned holds the struct's actual data. When the struct is assigned to a new variable, it is copied. The new variable and the original variable therefore contain two separate copies of the same data. Changes made to one copy do not affect the other copy.  
  
 In general, classes are used to model more complex behavior, or data that is intended to be modified after a class object is created. Structs are best suited for small data structures that contain primarily data that is not intended to be modified after the struct is created.  
  
 For more information, see [Classes](../../../csharp/programming-guide/classes-and-structs/classes.md), [Objects](../../../csharp/programming-guide/classes-and-structs/objects.md), and [Structs](../../../csharp/programming-guide/classes-and-structs/structs.md).  
  
## Example  
 In the following example, `CustomClass` in the `ProgrammingGuide` namespace has three members: an instance constructor, a property named `Number`, and a method named `Multiply`. The `Main` method in the `Program` class creates an instance (object) of `CustomClass`, and the object’s method and property are accessed by using dot notation.
  
 [!code-csharp[csProgGuideObjects#1](../../../../samples/snippets/csharp/programming-guide/classes-and-structs/class1.cs#1)]  
  
## Encapsulation  
 *Encapsulation* is sometimes referred to as the first pillar or principle of object-oriented programming. According to the principle of encapsulation, a class or struct can specify how accessible each of its members is to code outside of the class or struct. Methods and variables that are not intended to be used from outside of the class or assembly can be hidden to limit the potential for coding errors or malicious exploits.  
  
 For more information about classes, see [Classes](../../../csharp/programming-guide/classes-and-structs/classes.md) and [Objects](../../../csharp/programming-guide/classes-and-structs/objects.md).  
  
### Members  
 All methods, fields, constants, properties, and events must be declared within a type; these are called the *members* of the type. In C#, there are no global variables or methods as there are in some other languages. Even a program's entry point, the `Main` method, must be declared within a class or struct. The following list includes all the various kinds of members that may be declared in a class or struct.  
  
-   [Fields](../../../csharp/programming-guide/classes-and-structs/fields.md)  
  
-   [Constants](../../../csharp/programming-guide/classes-and-structs/constants.md)  
  
-   [Properties](../../../csharp/programming-guide/classes-and-structs/properties.md)  
  
-   [Methods](../../../csharp/programming-guide/classes-and-structs/methods.md)  
  
-   [Constructors](../../../csharp/programming-guide/classes-and-structs/constructors.md)  
  
-   [Events](../../../csharp/programming-guide/events/index.md)  
  
-   [Finalizers](../../../csharp/programming-guide/classes-and-structs/destructors.md)  
  
-   [Indexers](../../../csharp/programming-guide/indexers/index.md)  
  
-   [Operators](../../../csharp/programming-guide/statements-expressions-operators/operators.md)  
  
-   [Nested Types](../../../csharp/programming-guide/classes-and-structs/nested-types.md)  
  
### Accessibility  
 Some methods and properties are meant to be called or accessed from code outside your class or struct, known as *client code*. Other methods and properties might be only for use in the class or struct itself. It is important to limit the accessibility of your code so that only the intended client code can reach it. You specify how accessible your types and their members are to client code by using the access modifiers [public](../../../csharp/language-reference/keywords/public.md), [protected](../../../csharp/language-reference/keywords/protected.md), [internal](../../../csharp/language-reference/keywords/internal.md), [protected internal](../../../csharp/language-reference/keywords/protected-internal.md), [private](../../../csharp/language-reference/keywords/private.md) and [private protected](../../../csharp/language-reference/keywords/private-protected.md). The default accessibility is `private`. For more information, see [Access Modifiers](../../../csharp/programming-guide/classes-and-structs/access-modifiers.md).  
  
### Inheritance  
 Classes (but not structs) support the concept of inheritance. A class that derives from another class (the *base class*) automatically contains all the public, protected, and internal members of the base class except its constructors and finalizers. For more information, see [Inheritance](../../../csharp/programming-guide/classes-and-structs/inheritance.md) and [Polymorphism](../../../csharp/programming-guide/classes-and-structs/polymorphism.md).  
  
 Classes may be declared as [abstract](../../../csharp/language-reference/keywords/abstract.md), which means that one or more of their methods have no implementation. Although abstract classes cannot be instantiated directly, they can serve as base classes for other classes that provide the missing implementation. Classes can also be declared as [sealed](../../../csharp/language-reference/keywords/sealed.md) to prevent other classes from inheriting from them. For more information, see [Abstract and Sealed Classes and Class Members](../../../csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members.md).  
  
### Interfaces  
 Classes and structs can inherit multiple interfaces. To inherit from an interface means that the type implements all the methods defined in the interface. For more information, see [Interfaces](../../../csharp/programming-guide/interfaces/index.md).  
  
### Generic Types  
 Classes and structs can be defined with one or more type parameters. Client code supplies the type when it creates an instance of the type. For example The <xref:System.Collections.Generic.List%601> class in the <xref:System.Collections.Generic> namespace is defined with one type parameter. Client code creates an instance of a `List<string>` or `List<int>` to specify the type that the list will hold. For more information, see [Generics](../../../csharp/programming-guide/generics/index.md).  
  
### Static Types  
 Classes (but not structs) can be declared as [static](../../../csharp/language-reference/keywords/static.md). A static class can contain only static members and cannot be instantiated with the new keyword. One copy of the class is loaded into memory when the program loads, and its members are accessed through the class name. Both classes and structs can contain static members. For more information, see [Static Classes and Static Class Members](../../../csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members.md).  
  
### Nested Types  
 A class or struct can be nested within another class or struct. For more information, see [Nested Types](../../../csharp/programming-guide/classes-and-structs/nested-types.md).  
  
### Partial Types  
 You can define part of a class, struct or method in one code file and another part in a separate code file. For more information, see [Partial Classes and Methods](../../../csharp/programming-guide/classes-and-structs/partial-classes-and-methods.md).  
  
### Object Initializers  
 You can instantiate and initialize class or struct objects, and collections of objects, without explicitly calling their constructor. For more information, see [Object and Collection Initializers](../../../csharp/programming-guide/classes-and-structs/object-and-collection-initializers.md).  
  
### Anonymous Types  
 In situations where it is not convenient or necessary to create a named class, for example when you are populating a list with data structures that you do not have to persist or pass to another method, you use anonymous types. For more information, see [Anonymous Types](../../../csharp/programming-guide/classes-and-structs/anonymous-types.md).  
  
### Extension Methods  
 You can "extend" a class without creating a derived class by creating a separate type whose methods can be called as if they belonged to the original type. For more information, see [Extension Methods](../../../csharp/programming-guide/classes-and-structs/extension-methods.md).  
  
### Implicitly Typed Local Variables  
 Within a class or struct method, you can use implicit typing to instruct the compiler to determine the correct type at compile time. For more information, see [Implicitly Typed Local Variables](../../../csharp/programming-guide/classes-and-structs/implicitly-typed-local-variables.md).  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)
