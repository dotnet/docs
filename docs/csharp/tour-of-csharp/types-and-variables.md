---
title: C# Types and Variables - A tour of the C# language
description: Learn about defining types and declaring variables in C#
keywords: .NET, csharp, type, reference type, value type
author: BillWagner
ms.author: wiwagn
ms.date: 08/10/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: f8a8051e-0049-43f1-b594-9c84cc7b1224
---

# Types and variables

There are two kinds of types in C#: *value types* and *reference types*. Variables of value types directly contain their data whereas variables of reference types store references to their data, the latter being known as objects. With reference types, it is possible for two variables to reference the same object and thus possible for operations on one variable to affect the object referenced by the other variable. With value types, the variables each have their own copy of the data, and it is not possible for operations on one to affect the other (except in the case of `ref` and `out` parameter variables).

C#’s value types are further divided into *simple types*, *enum types*, *struct types*, and *nullable value types*. C#’s reference types are further divided into *class types*, *interface types*, *array types*, and *delegate types*.

The following provides an overview of C#’s type system.

* Value types
    - Simple Types
        * Signed integral: `sbyte`, `short`, `int`, `long`
        * Unsigned integral: `byte`, `ushort`, `uint`, `ulong`
		* Unicode characters: `char`
        * IEEE floating point: `float`, `double`
        * High-precision decimal: `decimal`
		* Boolean: `bool`
    - Enum types
        * User-defined types of the form `enum E {...}`
    - Struct types
        * User-defined types of the form `struct S {...}`
    - Nullable value types
        * Extensions of all other value types with a `null` value
* Reference types
    - Class types
        * Ultimate base class of all other types: `object`
		* Unicode strings: `string`
        * User-defined types of the form `class C {...}`
    - Interface types
        * User-defined types of the form `interface I {...}`
	- Array types
    	* Single- and multi-dimensional, for example, `int[]` and `int[,]`
	- Delegate types
        * User-defined types of the form `delegate int D(...)`

The eight integral types provide support for 8-bit, 16-bit, 32-bit, and 64-bit values in signed or unsigned form.

The two floating-point types, `float` and `double`, are represented using the 32-bit single-precision and 64-bit double-precision IEC-60559 formats, respectively.

The `decimal` type is a 128-bit data type suitable for financial and monetary calculations.

C#’s `bool` type is used to represent Boolean values—values that are either `true` or `false`.

Character and string processing in C# uses Unicode encoding. The `char` type represents a UTF-16 code unit, and the `string` type represents a sequence of UTF-16 code units.

This summarizes C#’s numeric types.

* Signed Integral
    - `sbyte`:  8 bits, range from -128 - 127
    - `short`: 16 bits, range from -32,768 - 32,767
    - `int`  : 32 bits, range from -2,147,483,648 - 2,147,483,647
    - `long` : 64 bits, range from –9,223,372,036,854,775,808 to 9,223,372,036,854,775,807
* Unsigned integral
    - `byte`   :  8 bits, range from 0 - 255
    - `ushort` : 16 bits, range from 0 - 65,535
    - `uint`   : 32 bits, range from 0 - 4,294,967,295
    - `ulong`  : 64 bits, range from 0 - 18,446,744,073,709,551,615
* Floating point
    - `float`  : 32 bits, range from 1.5 × 10<sup>−45</sup> - 3.4 × 10<sup>38</sup>,    7-digit precision
	- `double` : 64 bits, range from 5.0 × 10<sup>−324</sup> - 1.7 × 10<sup>308</sup>, 15-digit precision
* Decimal
    - `decimal` : 128 bits, range is at least –7.9 × 10<sup>−28</sup> -  7.9 × 10<sup>28</sup>, with at least 28-digit precision
    
C# programs use *type declarations* to create new types. A type declaration specifies the name and the members of the new type. Five of C#’s categories of types are user-definable: class types, struct types, interface types, enum types, and delegate types.

A `class` type defines a data structure that contains data members (fields) and function members (methods, properties, and others). Class types support single inheritance and polymorphism, mechanisms whereby derived classes can extend and specialize base classes.

A `struct` type is similar to a class type in that it represents a structure with data members and function members. However, unlike classes, structs are value types and do not typically require heap allocation. Struct types do not support user-specified inheritance, and all struct types implicitly inherit from type `object`.

An `interface` type defines a contract as a named set of public function members. A `class` or `struct` that implements an `interface` must provide implementations of the interface’s function members. An `interface` may inherit from multiple base interfaces, and a `class` or `struct` may implement multiple interfaces.

A `delegate` type represents references to methods with a particular parameter list and return type. Delegates make it possible to treat methods as entities that can be assigned to variables and passed as parameters. Delegates are analogous to function types provided by functional languages. They are also similar to the concept of function pointers found in some other languages, but unlike function pointers, delegates are object-oriented and type-safe.

The `class`, `struct`, `interface` and `delegate` types all support generics, whereby they can be parameterized with other types.

An `enum` type is a distinct type with named constants. Every `enum` type has an underlying type, which must be one of the eight integral types. The set of values of an `enum` type is the same as the set of values of the underlying type.

C# supports single- and multi-dimensional arrays of any type. Unlike the types listed above, array types do not have to be declared before they can be used. Instead, array types are constructed by following a type name with square brackets. For example, `int[]` is a single-dimensional array of `int`, `int[,]` is a two-dimensional array of `int`, and `int[][]` is a single-dimensional array of single-dimensional array of `int`.

Nullable value types also do not have to be declared before they can be used. For each non-nullable value type `T` there is a corresponding nullable value type `T?`, which can hold an additional value, `null`. For instance, `int?` is a type that can hold any 32-bit integer or the value `null`.

C#’s type system is unified such that a value of any type can be treated as an `object`. Every type in C# directly or indirectly derives from the `object` class type, and `object` is the ultimate base class of all types. Values of reference types are treated as objects simply by viewing the values as type `object`. Values of value types are treated as objects by performing *boxing* and *unboxing operations*. In the following example, an `int` value is converted to `object` and back again to `int`.

[!code-csharp[Boxing](../../../samples/snippets/csharp/tour/types-and-variables/Program.cs#L1-L10)]

When a value of a value type is converted to type `object`, an `object` instance, also called a "box", is allocated to hold the value, and the value is copied into that box. Conversely, when an `object` reference is cast to a value type, a check is made that the referenced `object` is a box of the correct value type, and, if the check succeeds, the value in the box is copied out.

C#’s unified type system effectively means that value types can become objects "on demand." Because of the unification, general-purpose libraries that use type `object` can be used with both reference types and value types.

There are several kinds of *variables* in C#, including fields, array elements, local variables, and parameters. Variables represent storage locations, and every variable has a type that determines what values can be stored in the variable, as shown below.

* Non-nullable value type
    - A value of that exact type
* Nullable value type
    - A `null` value or a value of that exact type
* object
    - A `null` reference, a reference to an object of any reference type, or a reference to a boxed value of any value type
* Class type
    - A `null` reference, a reference to an instance of that class type, or a reference to an instance of a class derived from that class type
* Interface type
    - A `null` reference, a reference to an instance of a class type that implements that interface type, or a reference to a boxed value of a value type that implements that interface type
* Array type
    - A `null` reference, a reference to an instance of that array type, or a reference to an instance of a compatible array type
* Delegate type
    - A `null` reference or a reference to an instance of a compatible delegate type

>[!div class="step-by-step"]
[Previous](program-structure.md)
[Next](expressions.md)
