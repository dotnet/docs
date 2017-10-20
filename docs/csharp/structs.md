---
title: Structs - C# Guide
description: Learn about the struct type and how you create them
keywords: .NET, .NET Core, C#
author: BillWagner
ms.author: wiwagn
ms.date: 10/12/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: a7094b8c-7229-4b6f-82fc-824d0ea0ec40
---

# Structs
A *struct* is a value type. When a struct is created, the variable to which the struct is assigned holds the struct's actual data. When the struct is assigned to a new variable, it is copied. The new variable and the original variable therefore contain two separate copies of the same data. Changes made to one copy do not affect the other copy.

Value type variables directly contain their values, which means that the memory is allocated inline in whatever context the variable is declared. There is no separate heap allocation or garbage collection overhead for value-type variables.  
  
There are two categories of value types: [struct](./language-reference/keywords/struct.md) and [enum](./language-reference/keywords/enum.md).  
  
The built-in numeric types are structs, and they have properties and methods that you can access:  
  
[!code-csharp[Static Method](../../samples/snippets/csharp/concepts/structs/static-method.cs)]
  
But you declare and assign values to them as if they were simple non-aggregate types:  
  
[!code-csharp[Assign Values](../../samples/snippets/csharp/concepts/structs/assign-value.cs)] 
  
Value types are *sealed*, which means, for example, that you cannot derive a type from <xref:System.Int32>, and you cannot define a struct to inherit from any user-defined class or struct because a struct can only inherit from <xref:System.ValueType>. However, a struct can implement one or more interfaces. You can cast a struct type to an interface type; this causes a *boxing* operation to wrap the struct inside a reference type object on the managed heap. Boxing operations occur when you pass a value type to a method that takes an <xref:System.Object> as an input parameter. For more information, see [Boxing and Unboxing](./programming-guide/types/boxing-and-unboxing.md ).  
  
You use the [struct](./language-reference/keywords/struct.md) keyword to create your own custom value types. Typically, a struct is used as a container for a small set of related variables, as shown in the following example:  
  
[!code-csharp[Struct Keyword](../../samples/snippets/csharp/concepts/structs/struct-keyword.cs)]  
  
For more information about value types in the .NET Framework, see [Common Type System](../standard/common-type-system.md).  
    
Structs share most of the same syntax as classes, although structs are more limited than classes:  
  
-   Within a struct declaration, fields cannot be initialized unless they are declared as `const` or `static`.  
  
-   A struct cannot declare a default constructor (a constructor without parameters) or a finalizer.  
  
-   Structs are copied on assignment. When a struct is assigned to a new variable, all the data is copied, and any modification to the new copy does not change the data for the original copy. This is important to remember when working with collections of value types such as Dictionary<string, myStruct>.  
  
-   Structs are value types and classes are reference types.  
  
-   Unlike classes, structs can be instantiated without using a `new` operator.  
  
-   Structs can declare constructors that have parameters.  
  
-   A struct cannot inherit from another struct or class, and it cannot be the base of a class. All structs inherit directly from <xref:System.ValueType>, which inherits from <xref:System.Object>.  
  
-   A struct can implement interfaces.

## Literal values  
In C#, literal values receive a type from the compiler. You can specify how a numeric literal should be typed by appending a letter to the end of the number. For example, to specify that the value 4.56 should be treated as a float, append an "f" or "F" after the number: `4.56f`. If no letter is appended, the compiler will infer the `double` type for the literal. For more information about which types can be specified with letter suffixes, see the reference pages for individual types in [Value Types](./language-reference/keywords/value-types.md).  
  
Because literals are typed, and all types derive ultimately from <xref:System.Object>, you can write and compile code such as the following:  
  
[!code-csharp[Literal Values](../../samples/snippets/csharp/concepts/structs/literals.cs)]

The last two examples demonstrate language features introduced in C# 7.0. The first allows you to use an underscore character as a *digit separator* inside numeric literals. You can put them wherever you want between digits to improve readability. They have no effect on the value.

The second demonstrates *binary literals*, which allow you to specify bit patterns directly instead of using hexadecimal notation.

## Nullable types  
Ordinary value types cannot have a value of [null](./language-reference/keywords/null.md). However, you can create nullable value types by affixing a **?** after the type. For example, **int?** is an **int** type that can also have the value [null](./language-reference/keywords/null.md). In the CTS, nullable types are instances of the generic struct type <xref:System.Nullable%601>. Nullable types are especially useful when you are passing data to and from databases in which numeric values might be null. For more information, see [Nullable Types (C# Programming Guide)](./programming-guide/nullable-types/index.md).

## See also
[Classes](classes.md)

[Basic Types](basic-types.md)
