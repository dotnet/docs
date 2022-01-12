---
title: "Using Constructors - C# Programming Guide"
description: This example shows how a class is instantiated by using the new operator in C#. The simple constructor is invoked after memory is allocated for the new object.
ms.date: 07/20/2015
helpviewer_keywords: 
  - "constructors [C#], about constructors"
ms.assetid: 464253b2-fd5d-469a-836d-df0fdf2a43f7
---
# Using Constructors (C# Programming Guide)

When a [class](../../language-reference/keywords/class.md) or [struct](../../language-reference/builtin-types/struct.md) is created, its constructor is called. Constructors have the same name as the class or struct, and they usually initialize the data members of the new object.  
  
 In the following example, a class named `Taxi` is defined by using a simple constructor. This class is then instantiated with the [new](../../language-reference/operators/new-operator.md) operator. The `Taxi` constructor is invoked by the `new` operator immediately after memory is allocated for the new object.  
  
 [!code-csharp[TaxiExample#1](snippets/using-constructors/Program.cs#1)]
  
 A constructor that takes no parameters is called a *parameterless constructor*. Parameterless constructors are invoked whenever an object is instantiated by using the `new` operator and no arguments are provided to `new`. For more information, see [Instance Constructors](./instance-constructors.md).  
  
 Unless the class is [static](../../language-reference/keywords/static.md), classes without constructors are given a public parameterless constructor by the C# compiler in order to enable class instantiation. For more information, see [Static Classes and Static Class Members](./static-classes-and-static-class-members.md).  
  
 You can prevent a class from being instantiated by making the constructor private, as follows:  
  
 [!code-csharp[PrivateConstructor#2](snippets/using-constructors/Program.cs#2)]
  
 For more information, see [Private Constructors](./private-constructors.md).  

Constructors for [struct](../../language-reference/builtin-types/struct.md) types resemble class constructors, but `structs` cannot contain an explicit parameterless constructor because one is provided automatically by the compiler. This constructor initializes each field in the `struct` to the [default value](../../language-reference/builtin-types/default-values.md). However, this parameterless constructor is only invoked if the `struct` is instantiated with `new`. For example, this code uses the parameterless constructor for <xref:System.Int32>, so that you are assured that the integer is initialized:  
  
```csharp  
int i = new int();  
Console.WriteLine(i);  
```  

> [!NOTE]
> Beginning with C# 10, a structure type can contain an explicit parameterless constructor. For more information, see the [Parameterless constructors and field initializers](../../language-reference/builtin-types/struct.md#parameterless-constructors-and-field-initializers) section of the [Structure types](../../language-reference/builtin-types/struct.md) article.

The following code, however, causes a compiler error because it does not use `new`, and because it tries to use an object that has not been initialized:  
  
```csharp  
int i;  
Console.WriteLine(i);  
```  
  
 Alternatively, objects based on `structs` (including all built-in numeric types) can be initialized or assigned and then used as in the following example:  
  
```csharp  
int a = 44;  // Initialize the value type...  
int b;  
b = 33;      // Or assign it before using it.  
Console.WriteLine("{0}, {1}", a, b);  
```  
  
 So calling the parameterless constructor for a value type is not required.  
  
 Both classes and `structs` can define constructors that take parameters. Constructors that take parameters must be called through a `new` statement or a [base](../../language-reference/keywords/base.md) statement. Classes and `structs` can also define multiple constructors, and neither is required to define a parameterless constructor. For example:  
  
 [!code-csharp[EmployeeExample#3](snippets/using-constructors/Program.cs#3)]
  
 This class can be created by using either of the following statements:  
  
 [!code-csharp[InstantiatingEmployeeConstructors#4](snippets/using-constructors/Program.cs#4)]
  
 A constructor can use the `base` keyword to call the constructor of a base class. For example:  
  
 [!code-csharp[ManagerInheritingEmployee#5](snippets/using-constructors/Program.cs#5)]
  
 In this example, the constructor for the base class is called before the block for the constructor is executed. The `base` keyword can be used with or without parameters. Any parameters to the constructor can be used as parameters to `base`, or as part of an expression. For more information, see [base](../../language-reference/keywords/base.md).  
  
 In a derived class, if a base-class constructor is not called explicitly by using the `base` keyword, the parameterless constructor, if there is one, is called implicitly. This means that the following constructor declarations are effectively the same:  
  
 [!code-csharp[ManagerImplicitlyCallingParameterlessBaseConstructor#6](snippets/using-constructors/Program.cs#6)]
  
 [!code-csharp[ManagerExplicitlyCallingParameterlessBaseConstructor#7](snippets/using-constructors/Program.cs#7)]
  
 If a base class does not offer a parameterless constructor, the derived class must make an explicit call to a base constructor by using `base`.  
  
 A constructor can invoke another constructor in the same object by using the [this](../../language-reference/keywords/this.md) keyword. Like `base`, `this` can be used with or without parameters, and any parameters in the constructor are available as parameters to `this`, or as part of an expression. For example, the second constructor in the previous example can be rewritten using `this`:  
  
 [!code-csharp[EmployeeCallingConstructorInSameClass#8](snippets/using-constructors/Program.cs#8)]
  
 The use of the `this` keyword in the previous example causes this constructor to be called:  
  
 [!code-csharp[ConstructorBeingCalledByThisKeyword#9](snippets/using-constructors/Program.cs#9)]
  
 Constructors can be marked as [public](../../language-reference/keywords/public.md), [private](../../language-reference/keywords/private.md), [protected](../../language-reference/keywords/protected.md), [internal](../../language-reference/keywords/internal.md), [protected internal](../../language-reference/keywords/protected-internal.md) or [private protected](../../language-reference/keywords/private-protected.md). These access modifiers define how users of the class can construct the class. For more information, see [Access Modifiers](./access-modifiers.md).  
  
 A constructor can be declared static by using the [static](../../language-reference/keywords/static.md) keyword. Static constructors are called automatically, immediately before any static fields are accessed, and are generally used to initialize static class members. For more information, see [Static Constructors](./static-constructors.md).  
  
## C# Language Specification  

For more information, see [Instance constructors](~/_csharpstandard/standard/classes.md#1511-instance-constructors) and [Static constructors](~/_csharpstandard/standard/classes.md#1512-static-constructors) in the [C# Language Specification](~/_csharpstandard/standard/README.md). The language specification is the definitive source for C# syntax and usage.
  
## See also

- [C# Programming Guide](../index.md)
- [The C# type system](../../fundamentals/types/index.md)
- [Constructors](./constructors.md)
- [Finalizers](./finalizers.md)
