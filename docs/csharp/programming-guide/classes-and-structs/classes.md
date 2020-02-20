---
title: "Classes - C# Programming Guide"
description: Learn about the class types and how to create them
ms.date: 08/21/2018
helpviewer_keywords: 
  - "classes [C#]"
  - "C# language, classes"
ms.assetid: e8848524-7273-429f-8aba-c658d5eff5ad
---
# Classes (C# Programming Guide)

## Reference types  
A type that is defined as a [class](../../language-reference/keywords/class.md) is a *reference type*. At run time, when you declare a variable of a reference type, the variable contains the value [null](../../language-reference/keywords/null.md) until you explicitly create an instance of the class by using the [new](../../language-reference/operators/new-operator.md) operator, or assign it an object of a compatible type that may have been created elsewhere, as shown in the following example:

```csharp
//Declaring an object of type MyClass.
MyClass mc = new MyClass();

//Declaring another object of the same type, assigning it the value of the first object.
MyClass mc2 = mc;
```

When the object is created, enough memory is allocated on the managed heap for that specific object, and the variable holds only a reference to the location of said object. Types on the managed heap require overhead both when they are allocated and when they are reclaimed by the automatic memory management functionality of the CLR, which is known as *garbage collection*. However, garbage collection is also highly optimized and in most scenarios, it does not create a performance issue. For more information about garbage collection, see [Automatic memory management and garbage collection](../../../standard/garbage-collection/gc.md).  
  
## Declaring Classes

 Classes are declared by using the [class](../../language-reference/keywords/class.md) keyword followed by a unique identifier, as shown in the following example:

 ```csharp
//[access modifier] - [class] - [identifier]
 public class Customer
 {
    // Fields, properties, methods and events go here...
 }
```

 The `class` keyword is preceded by the access level. Because [public](../../language-reference/keywords/public.md) is used in this case, anyone can create instances of this class. The name of the class follows the `class` keyword. The name of the class must be a valid C# [identifier name](../inside-a-program/identifier-names.md). The remainder of the definition is the class body, where the behavior and data are defined. Fields, properties, methods, and events on a class are collectively referred to as *class members*.  
  
## Creating objects

Although they are sometimes used interchangeably, a class and an object are different things. A class defines a type of object, but it is not an object itself. An object is a concrete entity based on a class, and is sometimes referred to as an instance of a class.  
  
 Objects can be created by using the [new](../../language-reference/operators/new-operator.md) keyword followed by the name of the class that the object will be based on, like this:  

 ```csharp
 Customer object1 = new Customer();
 ```

 When an instance of a class is created, a reference to the object is passed back to the programmer. In the previous example, `object1` is a reference to an object that is based on `Customer`. This reference refers to the new object but does not contain the object data itself. In fact, you can create an object reference without creating an object at all:  
 
```csharp
 Customer object2;
```
 
 We don't recommend creating object references such as this one that don't refer to an object because trying to access an object through such a reference will fail at run time. However, such a reference can be made to refer to an object, either by creating a new object, or by assigning it to an existing object, such as this:  

 ```csharp
 Customer object3 = new Customer();
 Customer object4 = object3;
```
  
 This code creates two object references that both refer to the same object. Therefore, any changes to the object made through `object3` are reflected in subsequent uses of `object4`. Because objects that are based on classes are referred to by reference, classes are known as reference types.  
  
## Class inheritance  

Classes fully support *inheritance*, a fundamental characteristic of object-oriented programming. When you create a class, you can inherit from any other interface or class that is not defined as [sealed](../../language-reference/keywords/sealed.md), and other classes can inherit from your class and override class virtual methods.

Inheritance is accomplished by using a *derivation*, which means a class is declared by using a *base class* from which it inherits data and behavior. A base class is specified by appending a colon and the name of the base class following the derived class name, like this:  

 ```csharp
 public class Manager : Employee
 {
     // Employee fields, properties, methods and events are inherited
     // New Manager fields, properties, methods and events go here...
 }
 ```

When a class declares a base class, it inherits all the members of the base class except the constructors. For more information, see [Inheritance](inheritance.md).
  
Unlike C++, a class in C# can only directly inherit from one base class. However, because a base class may itself inherit from another class, a class may indirectly inherit multiple base classes. Furthermore, a class can directly implement more than one interface. For more information, see [Interfaces](../interfaces/index.md).  
  
A class can be declared [abstract](../../language-reference/keywords/abstract.md). An abstract class contains abstract methods that have a signature definition but no implementation. Abstract classes cannot be instantiated. They can only be used through derived classes that implement the abstract methods. By contrast, a [sealed](../../language-reference/keywords/sealed.md) class does not allow other classes to derive from it. For more information, see [Abstract and Sealed Classes and Class Members](abstract-and-sealed-classes-and-class-members.md).  
  
Class definitions can be split between different source files. For more information, see [Partial Classes and Methods](partial-classes-and-methods.md).  
  
## Example

The following example defines a public class that contains an [auto-implemented property](auto-implemented-properties.md), a method, and a special method called a constructor. For more information, see [Properties](properties.md), [Methods](methods.md), and [Constructors](constructors.md) topics. The instances of the class are then instantiated with the `new` keyword.  
  
[!code-csharp[Class Example](~/samples/snippets/csharp/programming-guide/classes-and-structs/class-example.cs)] 
  
## C# Language Specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See also

- [C# Programming Guide](../index.md)
- [Object-Oriented Programming](../concepts/object-oriented-programming.md)
- [Polymorphism](polymorphism.md)
- [Identifier names](../inside-a-program/identifier-names.md)
- [Members](members.md)
- [Methods](methods.md)
- [Constructors](constructors.md)
- [Finalizers](destructors.md)
- [Objects](objects.md)
