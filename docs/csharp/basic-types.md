---
title: Basic Types | C# Guide
description: Learn about the core types (numerics, strings, and object) in all C# programs 
keywords: .NET, .NET Core, C#
author: BillWagner
ms.author: wiwagn
ms.date: 10/10/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: 95c686ba-ae4f-440e-8e94-0dbd6e04d11f
---

# Types, variables, and values  
C# is a strongly-typed language. Every variable and constant has a type, as does every expression that evaluates to a value. Every method signature specifies a type for each input parameter and for the return value. The .NET Framework class library defines a set of built-in numeric types as well as more complex types that represent a wide variety of logical constructs, such as the file system, network connections, collections and arrays of objects, and dates. A typical C# program uses types from the class library as well as user-defined types that model the concepts that are specific to the program's problem domain.  
  
The information stored in a type can include the following:  
  
-   The storage space that a variable of the type requires.  
  
-   The maximum and minimum values that it can represent.  
  
-   The members (methods, fields, events, and so on) that it contains.  
  
-   The base type it inherits from.  
  
-   The location where the memory for variables will be allocated at run time.  
  
-   The kinds of operations that are permitted.  
  
The compiler uses type information to make sure that all operations that are performed in your code are *type safe*. For example, if you declare a variable of type [int](https://msdn.microsoft.com/library/5kzh1b5w.aspx), the compiler allows you to use the variable in addition and subtraction operations. If you try to perform those same operations on a variable of type [bool](https://msdn.microsoft.com/library/c8f5xwh7.aspx), the compiler generates an error, as shown in the following example:  
  
[!code-csharp[Type Safety](../../samples/snippets/csharp/concepts/basic-types/type-safety.cs)]  
  
> [!NOTE]  
>  C and C++ developers, notice that in C#, [bool](https://msdn.microsoft.com/library/c8f5xwh7.aspx) is not convertible to [int](https://msdn.microsoft.com/library/5kzh1b5w.aspx).  
  
The compiler embeds the type information into the executable file as metadata. The common language runtime (CLR) uses that metadata at run time to further guarantee type safety when it allocates and reclaims memory.  

## Specifying types in variable declarations  
When you declare a variable or constant in a program, you must either specify its type or use the [var](https://msdn.microsoft.com/library/bb383973.aspx) keyword to let the compiler infer the type. The following example shows some variable declarations that use both built-in numeric types and complex user-defined types:  
  
[!code-csharp[Variable Declaration](../../samples/snippets/csharp/concepts/basic-types/variable-declaration.cs)]  
  
The types of method parameters and return values are specified in the method signature. The following signature shows a method that requires an [int](https://msdn.microsoft.com/library/5kzh1b5w.aspx) as an input argument and returns a string:  
  
[!code-csharp[Method Signature](../../samples/snippets/csharp/concepts/basic-types/method-signature.cs)]  
  
After a variable is declared, it cannot be re-declared with a new type, and it cannot be assigned a value that is not compatible with its declared type. For example, you cannot declare an [int](https://msdn.microsoft.com/library/5kzh1b5w.aspx) and then assign it a Boolean value of [true](https://msdn.microsoft.com/library/06d3w013.aspx). However, values can be converted to other types, for example when they are assigned to new variables or passed as method arguments. A *type conversion* that does not cause data loss is performed automatically by the compiler. A conversion that might cause data loss requires a *cast* in the source code. 

For more information, see [Casting and type conversions](https://msdn.microsoft.com/library/ms173105.aspx).
 
## Built-in types
C# provides a standard set of built-in numeric types to represent integers, floating point values, Boolean expressions, text characters, decimal values, and other types of data. There are also built-in **string** and **object** types. These are available for you to use in any C# program. For a more information about the built-in types, see [Types reference tables](https://msdn.microsoft.com/library/1dhd7f2x.aspx).  
  
## Custom types  
You use the [struct](https://msdn.microsoft.com/library/ah19swz4.aspx), [class](https://msdn.microsoft.com/library/0b0thckt.aspx), [interface](https://msdn.microsoft.com/library/87d83y5b.aspx), and [enum](https://msdn.microsoft.com/library/sbbt4032.aspx) constructs to create your own custom types. The .NET Framework class library itself is a collection of custom types provided by Microsoft that you can use in your own applications. By default, the most frequently used types in the class library are available in any C# program. Others become available only when you explicitly add a project reference to the assembly in which they are defined. After the compiler has a reference to the assembly, you can declare variables (and constants) of the types declared in that assembly in source code. For more information, see [.NET Framework class library](https://msdn.microsoft.com/library/gg145045(v=vs.110).aspx).  
  
## Generic types  
A type can be declared with one or more *type parameters* that serve as a placeholder for the actual type (the *concrete type*) that client code will provide when it creates an instance of the type. Such types are called *generic types*. For example, the .NET Framework type @System.Collections.Generic.List%601 has one type parameter that by convention is given the name *T*. When you create an instance of the type, you specify the type of the objects that the list will contain, for example, string:  
  
[!code-csharp[Generic types](../../samples/snippets/csharp/concepts/basic-types/generic-type.cs)] 
  
The use of the type parameter makes it possible to reuse the same class to hold any type of element, without having to convert each element to [object](https://msdn.microsoft.com/library/9kkx3h3c.aspx). Generic collection classes are called *strongly-typed collections* because the compiler knows the specific type of the collection's elements and can raise an error at compile-time if, for example, you try to add an integer to the `strings` object in the previous example. For more information, see [Generics](programming-guide/generics/index.md). 

## Implicit types, anonymous types, and tuple types  
As stated previously, you can implicitly type a local variable (but not class members) by using the [var](https://msdn.microsoft.com/library/bb383973.aspx) keyword. The variable still receives a type at compile time, but the type is provided by the compiler. For more information, see [Implicitly typed local variables](https://msdn.microsoft.com/library/bb384061.aspx).  
  
In some cases, it is inconvenient to create a named type for simple sets of related values that you do not intend to store or pass outside method boundaries. You can create *anonymous types* for this purpose. For more information, see [Anonymous types](https://msdn.microsoft.com/library/bb397696.aspx).

It's common to want to return more than one value from a method. You can create *tuple types* that return multiple values in a single method call. For more information, see [Tuples](tuples.md)

## The Common type system  
It is important to understand two fundamental points about the type system in the .NET Framework:  
  
-   It supports the principle of inheritance. Types can derive from other types, called *base types*. The derived type inherits (with some restrictions) the methods, properties, and other members of the base type. The base type can in turn derive from some other type, in which case the derived type inherits the members of both base types in its inheritance hierarchy. All types, including built-in numeric types such as @System.Int32 (C# keyword: `int`), derive ultimately from a single base type, which is @System.Object (C# keyword: `object`). This unified type hierarchy is called the [Common type system](../standard/common-type-system.md) (CTS). For more information about inheritance in C#, see [Inheritance](https://msdn.microsoft.com/library/ms173149.aspx).  
  
-   Each type in the CTS is defined as either a *value type* or a *reference type*. This includes all custom types in the .NET Framework class library and also your own user-defined types. Types that you define by using the [struct](https://msdn.microsoft.com/library/ah19swz4.aspx) keyword are value types; all the built-in numeric types are **structs**. For more information about value types, see [Structs](structs.md). Types that you define by using the [class](https://msdn.microsoft.com/library/0b0thckt.aspx) keyword are reference types. For more information about reference types, see [Classes](classes.md). Reference types and value types have different compile-time rules, and different run-time behavior.
 
  
## See also
[Structs](structs.md)

[Classes](classes.md)
