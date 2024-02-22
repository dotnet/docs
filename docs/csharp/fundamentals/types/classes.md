---
title: "Classes"
description: Learn about the class types and how to create them
ms.date: 05/24/2023
helpviewer_keywords: 
  - "classes [C#]"
  - "C# language, classes"
---
# Introduction to classes

## Reference types

A type that is defined as a [`class`](../../language-reference/keywords/class.md) is a *reference type*. At run time, when you declare a variable of a reference type, the variable contains the value [`null`](../../language-reference/keywords/null.md) until you explicitly create an instance of the class by using the [`new`](../../language-reference/operators/new-operator.md) operator, or assign it an object of a compatible type that may have been created elsewhere, as shown in the following example:

```csharp
//Declaring an object of type MyClass.
MyClass mc = new MyClass();

//Declaring another object of the same type, assigning it the value of the first object.
MyClass mc2 = mc;
```

When the object is created, enough memory is allocated on the managed heap for that specific object, and the variable holds only a reference to the location of said object. The memory used by an object is reclaimed by the automatic memory management functionality of the CLR, which is known as *garbage collection*. For more information about garbage collection, see [Automatic memory management and garbage collection](../../../standard/garbage-collection/fundamentals.md).

## Declaring classes

Classes are declared by using the `class` keyword followed by a unique identifier, as shown in the following example:

:::code source="./snippets/classes/Program.cs" id="ClassDeclaration":::

An optional access modifier precedes the `class` keyword. Because [`public`](../../language-reference/keywords/public.md) is used in this case, anyone can create instances of this class. The name of the class follows the `class` keyword. The name of the class must be a valid C# [identifier name](../coding-style/identifier-names.md). The remainder of the definition is the class body, where the behavior and data are defined. Fields, properties, methods, and events on a class are collectively referred to as *class members*.

## Creating objects

Although they're sometimes used interchangeably, a class and an object are different things. A class defines a type of object, but it isn't an object itself. An object is a concrete entity based on a class, and is sometimes referred to as an instance of a class.

Objects can be created by using the `new` keyword followed by the name of the class, like this:

:::code source="./snippets/classes/Program.cs" id="InstantiateClass":::

When an instance of a class is created, a reference to the object is passed back to the programmer. In the previous example, `object1` is a reference to an object that is based on `Customer`. This reference refers to the new object but doesn't contain the object data itself. In fact, you can create an object reference without creating an object at all:

:::code source="./snippets/classes/Program.cs" id="DeclareVariable":::

We don't recommend creating object references that don't refer to an object because trying to access an object through such a reference fails at run time. A reference can be made to refer to an object, either by creating a new object, or by assigning it an existing object, such as this:

:::code source="./snippets/classes/Program.cs" id="AssignReference":::

This code creates two object references that both refer to the same object. Therefore, any changes to the object made through `object3` are reflected in subsequent uses of `object4`. Because objects that are based on classes are referred to by reference, classes are known as reference types.

## Constructors and initialization

The preceding sections introduced the syntax to declare a class type and create an instance of that type. When you create an instance of a type, you want to ensure that its fields and properties are initialized to useful values. There are several ways to initialize values:

- Accept default values
- Field initializers
- Constructor parameters
- Object initializers

Every .NET type has a default value. Typically, that value is 0 for number types, and `null` for all reference types. You can rely on that default value when it's reasonable in your app.

When the .NET default isn't the right value, you can set an initial value using a *field initializer*:

:::code source="./snippets/classes/Containers.cs" id="ContainerFieldInitializer":::

You can require callers to provide an initial value by defining a *constructor* that's responsible for setting that initial value:

:::code source="./snippets/classes/Containers.cs" id="ContainerConstructor":::

Beginning with C# 12, you can define a *primary constructor* as part of the class declaration:

:::code source="./snippets/classes/Containers.cs" id="ContainerPrimaryConstructor":::

Adding parameters to the class name defines the *primary constructor*. Those parameters are available in the class body, which includes its members. You can use them to initialize fields or anywhere else where they're needed.

You can also use the `required` modifier on a property and allow callers to use an *object initializer* to set the initial value of the property:

:::code source="./snippets/classes/Program.cs" id="RequiredProperties":::

The addition of the `required` keyword mandates that callers must set those properties as part of a `new` expression:

```csharp
var p1 = new Person(); // Error! Required properties not set
var p2 = new Person() { FirstName = "Grace", LastName = "Hopper" };
```

## Class inheritance

Classes fully support *inheritance*, a fundamental characteristic of object-oriented programming. When you create a class, you can inherit from any other class that isn't defined as [`sealed`](../../language-reference/keywords/sealed.md). Other classes can inherit from your class and override class virtual methods. Furthermore, you can implement one or more interfaces.

Inheritance is accomplished by using a *derivation*, which means a class is declared by using a *base class* from which it inherits data and behavior. A base class is specified by appending a colon and the name of the base class following the derived class name, like this:

:::code source="./snippets/classes/Program.cs" id="DerivedClass":::

When a class declaration includes a base class, it inherits all the members of the base class except the constructors. For more information, see [Inheritance](../object-oriented/inheritance.md).

A class in C# can only directly inherit from one base class. However, because a base class may itself inherit from another class, a class might indirectly inherit multiple base classes. Furthermore, a class can directly implement one or more interfaces. For more information, see [Interfaces](interfaces.md).

A class can be declared as [`abstract`](../../language-reference/keywords/abstract.md). An abstract class contains abstract methods that have a signature definition but no implementation. Abstract classes can't be instantiated. They can only be used through derived classes that implement the abstract methods. By contrast, a [sealed](../../language-reference/keywords/sealed.md) class doesn't allow other classes to derive from it. For more information, see [Abstract and Sealed Classes and Class Members](../../programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members.md).

Class definitions can be split between different source files. For more information, see [Partial Classes and Methods](../../programming-guide/classes-and-structs/partial-classes-and-methods.md).

## C# Language Specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]
