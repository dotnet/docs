---
title: "Constructors - C# programming guide"
description: A constructor in C# is called when a class or struct is created. Use constructors to set defaults, limit instantiation, and write flexible, easy-to-read code.
ms.date: 09/27/2021
helpviewer_keywords: 
  - "constructors [C#]"
  - "classes [C#], constructors"
  - "C# language, constructors"
ms.assetid: df2e2e9d-7998-418b-8e7d-890c17ff6c95
---
# Constructors (C# programming guide)

Whenever a [class](../../language-reference/keywords/class.md) or [struct](../../language-reference/builtin-types/struct.md) is created, its constructor is called. A class or struct may have multiple constructors that take different arguments. Constructors enable the programmer to set default values, limit instantiation, and write code that is flexible and easy to read. For more information and examples, see [Instance constructors](instance-constructors.md) and [Using constructors](using-constructors.md).

## Constructor syntax

A constructor is a method whose name is the same as the name of its type. Its method signature includes only the method name and its parameter list; it does not include a return type. The following example shows the constructor for a class named `Person`.

[!code-csharp[constructors](../../../../samples/snippets/csharp/programming-guide/classes-and-structs/constructors1.cs#1)]  

If a constructor can be implemented as a single statement, you can use an [expression body definition](../statements-expressions-operators/expression-bodied-members.md). The following example defines a `Location` class whose constructor has a single string parameter named *name*. The expression body definition assigns the argument to the `locationName` field.

[!code-csharp[expression-bodied-constructor](../../../../samples/snippets/csharp/programming-guide/classes-and-structs/expr-bodied-ctor.cs#1)]  

## Static constructors

The previous examples have all shown instance constructors, which create a new object. A class or struct can also have a static constructor, which initializes static members of the type.  Static constructors are parameterless. If you don't provide a static constructor to initialize static fields, the C# compiler initializes static fields to their default value as listed in the [Default values of C# types](../../language-reference/builtin-types/default-values.md) article.

The following example uses a static constructor to initialize a static field.

[!code-csharp[constructors](../../../../samples/snippets/csharp/programming-guide/classes-and-structs/constructors1.cs#2)]  

You can also define a static constructor with an expression body definition, as the following example shows.

[!code-csharp[constructors](../../../../samples/snippets/csharp/programming-guide/classes-and-structs/constructors1.cs#3)]  

For more information and examples, see [Static Constructors](./static-constructors.md).  
  
## In This Section  

 [Using Constructors](./using-constructors.md)  
  
 [Instance Constructors](./instance-constructors.md)  
  
 [Private Constructors](./private-constructors.md)  
  
 [Static Constructors](./static-constructors.md)  
  
 [How to write a copy constructor](./how-to-write-a-copy-constructor.md)  
  
## See also

- [C# Programming Guide](../index.md)
- [The C# type system](../../fundamentals/types/index.md)
- [Finalizers](./finalizers.md)
- [static](../../language-reference/keywords/static.md)
- [Why Do Initializers Run In The Opposite Order As Constructors? Part One](/archive/blogs/ericlippert/why-do-initializers-run-in-the-opposite-order-as-constructors-part-one)
