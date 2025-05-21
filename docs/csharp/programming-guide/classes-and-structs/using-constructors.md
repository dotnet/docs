---
title: "Using Constructors"
description: This example shows how a class is instantiated by using the new operator in C#. The simple constructor is invoked after memory is allocated for the new object.
ms.date: 01/15/2025
helpviewer_keywords: 
  - "constructors [C#], about constructors"
ms.topic: how-to
---
# Use constructors (C# programming guide)

When a [class](../../language-reference/keywords/class.md) or [struct](../../language-reference/builtin-types/struct.md) is instantiated, the runtime calls its constructor. Constructors have the same name as the class or struct, and they usually initialize the data members of the new object.

In the following example, a class named `Taxi` is defined by using a simple constructor. This class is then instantiated with the [`new`](../../language-reference/operators/new-operator.md) operator. The runtime invokes the `Taxi` constructor immediately after memory is allocated for the new object.

:::code source="./snippets/using-constructors/Program.cs" id="snippet1":::

A constructor that takes no parameters is called a *parameterless constructor*. The runtime invokes the parameterless constructor when an object is instantiated using the `new` operator and no arguments are provided to `new`. C# 12 introduced *primary constructors*. A primary constructor specifies parameters that must be provided to initialize a new object. For more information, see [Instance Constructors](./instance-constructors.md).

Unless the class is [static](../../language-reference/keywords/static.md), classes without constructors are given a public parameterless constructor by the C# compiler in order to enable class instantiation. For more information, see [Static Classes and Static Class Members](./static-classes-and-static-class-members.md).

You can prevent a class from being instantiated by making the constructor private, as follows:

:::code source="./snippets/using-constructors/Program.cs" id="snippet2":::

For more information, see [Private Constructors](./private-constructors.md).

Constructors for [struct](../../language-reference/builtin-types/struct.md) types resemble class constructors. When a struct type is instantiated with `new`, the runtime invokes a constructor. When a `struct` is set to its `default` value, the runtime initializes all memory in the struct to 0. If you declare any field initializers in a `struct` type, you must supply a parameterless constructor. For more information, see the [Struct initialization and default values](../../language-reference/builtin-types/struct.md#struct-initialization-and-default-values) section of the [Structure types](../../language-reference/builtin-types/struct.md) article.

The following code uses the parameterless constructor for <xref:System.Int32>, so that you're assured that the integer is initialized:

```csharp
int i = new int();
Console.WriteLine(i);
```

The following code, however, causes a compiler error because it doesn't use `new`, and because it tries to use an object that isn't initialized:

```csharp
int i;
Console.WriteLine(i);
```

Alternatively, some `struct` types (including all built-in numeric types) can be initialized or assigned and then used as in the following example:

```csharp
int a = 44;  // Initialize the value type...
int b;
b = 33;      // Or assign it before using it.
Console.WriteLine("{0}, {1}", a, b);
```

Both classes and structs can define constructors that take parameters, including [primary constructors](./instance-constructors.md#primary-constructors). Constructors that take parameters must be called through a `new` statement or a [base](../../language-reference/keywords/base.md) statement. Classes and structs can also define multiple constructors, and neither is required to define a parameterless constructor. For example:

:::code source="./snippets/using-constructors/Program.cs" id="snippet3":::

This class can be created by using either of the following statements:

:::code source="./snippets/using-constructors/Program.cs" id="snippet4":::

A constructor can use the `base` keyword to call the constructor of a base class. For example:

:::code source="./snippets/using-constructors/Program.cs" id="snippet5":::

In this example, the constructor for the base class is called before the block for the constructor executes. The `base` keyword can be used with or without parameters. Any parameters to the constructor can be used as parameters to `base`, or as part of an expression. For more information, see [base](../../language-reference/keywords/base.md).

In a derived class, if a base-class constructor isn't called explicitly by using the `base` keyword, the parameterless constructor, if there's one, is called implicitly. The following constructor declarations are effectively the same:

:::code source="./snippets/using-constructors/Program.cs" id="snippet6":::

:::code source="./snippets/using-constructors/Program.cs" id="snippet7":::

If a base class doesn't offer a parameterless constructor, the derived class must make an explicit call to a base constructor by using `base`.

A constructor can invoke another constructor in the same object by using the [`this`](../../language-reference/keywords/this.md) keyword. Like `base`, `this` can be used with or without parameters, and any parameters in the constructor are available as parameters to `this`, or as part of an expression. For example, the second constructor in the previous example can be rewritten using `this`:

:::code source="./snippets/using-constructors/Program.cs" id="snippet8":::

The use of the `this` keyword in the previous example causes the following constructor to be called:

:::code source="./snippets/using-constructors/Program.cs" id="snippet9":::

Constructors can be marked as [`public`](../../language-reference/keywords/public.md), [`private`](../../language-reference/keywords/private.md), [`protected`](../../language-reference/keywords/protected.md), [internal](../../language-reference/keywords/internal.md), [protected internal](../../language-reference/keywords/protected-internal.md) or [`private protected`](../../language-reference/keywords/private-protected.md). These access modifiers define how users of the class can construct the class. For more information, see [Access Modifiers](./access-modifiers.md).

A constructor can be declared static by using the [`static`](../../language-reference/keywords/static.md) keyword. Static constructors are called automatically,  before any static fields are accessed, and are used to initialize static class members. For more information, see [Static Constructors](./static-constructors.md).

## C# Language Specification

For more information, see [Instance constructors](~/_csharpstandard/standard/classes.md#1511-instance-constructors) and [Static constructors](~/_csharpstandard/standard/classes.md#1512-static-constructors) in the [C# Language Specification](~/_csharpstandard/standard/README.md). The language specification is the definitive source for C# syntax and usage.

## See also

- [The C# type system](../../fundamentals/types/index.md)
- [Constructors](./constructors.md)
- [Finalizers](./finalizers.md)
