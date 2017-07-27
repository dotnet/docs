---
title: F# Types
description: Learn about the types that are used in F# and how F# types are named and described.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: c7272a0d-5ab6-4eae-bceb-e49af498b917 
---

# F# Types

This topic describes the types that are used in F# and how F# types are named and described.


## Summary of F# Types
Some types are considered *primitive types*, such as the Boolean type `bool` and integral and floating point types of various sizes, which include types for bytes and characters. These types are described in [Primitive Types](primitive-types.md).

Other types that are built into the language include tuples, lists, arrays, sequences, records, and discriminated unions. If you have experience with other .NET languages and are learning F#, you should read the topics for each of these types. Links to more information about these types are included in the [Related Topics](https://msdn.microsoft.com/library/#rel) section of this topic. These F#-specific types support styles of programming that are common to functional programming languages. Many of these types have associated modules in the F# library that support common operations on these types.

The type of a function includes information about the parameter types and return type.

The .NET Framework is the source of object types, interface types, delegate types, and others. You can define your own object types just as you can in any other .NET language.

Also, F# code can define aliases, which are named *type abbreviations*, that are alternative names for types. You might use type abbreviations when the type might change in the future and you want to avoid changing the code that depends on the type. Or, you might use a type abbreviation as a friendly name for a type that can make code easier to read and understand.

F# provides useful collection types that are designed with functional programming in mind. Using these collection types helps you write code that is more functional in style. For more information, see [F# Collection Types](fsharp-collection-types.md).


## Syntax for Types
In F# code, you often have to write out the names of types. Every type has a syntactic form, and you use these syntactic forms in type annotations, abstract method declarations, delegate declarations, signatures, and other constructs. Whenever you declare a new program construct in the interpreter, the interpreter prints the name of the construct and the syntax for its type. This syntax might be just an identifier for a user-defined type or a built-in identifier such as for `int` or `string`, but for more complex types, the syntax is more complex.

The following table shows aspects of the type syntax for F# types.



|Type|Type syntax|Examples|
|----|-----------|--------|
|primitive type|*type-name*|`int`<br /><br />`float`<br /><br />`string`|
|aggregate type (class, structure, union, record, enum, and so on)|*type-name*|`System.DateTime`<br /><br />`Color`|
|type abbreviation|*type-abbreviation-name*|`bigint`|
|fully qualified type|*namespaces.type-name*<br /><br />or<br /><br />*modules.type-name*<br /><br />or<br /><br />*namespaces.modules.type-name*|`System.IO.StreamWriter`|
|array|*type-name*[] or<br /><br />*type-name* array|`int[]`<br /><br />`array<int>`<br /><br />`int array`|
|two-dimensional array|*type-name*[,]|`int[,]`<br /><br />`float[,]`|
|three-dimensional array|*type-name*[,,]|`float[,,]`|
|tuple|*type-name1* &#42; *type-name2* ...|For example, `(1,'b',3)` has type `int * char * int`|
|generic type|*type-parameter* *generic-type-name*<br /><br />or<br /><br />*generic-type-name*&lt;*type-parameter-list*&gt;|`'a list`<br /><br />`list<'a>`<br /><br />`Dictionary<'key, 'value>`|
|constructed type (a generic type that has a specific type argument supplied)|*type-argument* *generic-type-name*<br /><br />or<br /><br />*generic-type-name*&lt;*type-argument-list*&gt;|`int option`<br /><br />`string list`<br /><br />`int ref`<br /><br />`option<int>`<br /><br />`list<string>`<br /><br />`ref<int>`<br /><br />`Dictionary<int, string>`|
|function type that has a single parameter|*parameter-type1* -&gt; *return-type*|A function that takes an `int` and returns a `string` has type `int -> string`|
|function type that has multiple parameters|*parameter-type1* -&gt; *parameter-type2* -&gt; ... -&gt; *return-type*|A function that takes an `int` and a `float` and returns a `string` has type `int -> float -> string`|
|higher order function as a parameter|(*function-type*)|`List.map` has type `('a -> 'b) -> 'a list -> 'b list`|
|delegate|delegate of *function-type*|`delegate of unit -> int`|
|flexible type|#*type-name*|`#System.Windows.Forms.Control`<br /><br />`#seq<int>`|

## Related Topics


|Topic|Description|
|-----|-----------|
|[Primitive Types](primitive-types.md)|Describes built-in simple types such as integral types, the Boolean type, and character types.|
|[Unit Type](unit-type.md)|Describes the `unit` type, a type that has one value and that is indicated by (); equivalent to `void` in C# and `Nothing` in Visual Basic.|
|[Tuples](tuples.md)|Describes the tuple type, a type that consists of associated values of any type grouped in pairs, triples, quadruples, and so on.|
|[Options](options.md)|Describes the option type, a type that may either have a value or be empty.|
|[Lists](lists.md)|Describes lists, which are ordered, immutable series of elements all of the same type.|
|[Arrays](arrays.md)|Describes arrays, which are ordered sets of mutable elements of the same type that occupy a contiguous block of memory and are of fixed size.|
|[Sequences](sequences.md)|Describes the sequence type, which represents a logical series of values; individual values are computed only as necessary.|
|[Records](records.md)|Describes the record type, a small aggregate of named values.|
|[Discriminated Unions](discriminated-unions.md)|Describes the discriminated union type, a type whose values can be any one of a set of possible types.|
|[Functions](functions/index.md)|Describes function values.|
|[Classes](classes.md)|Describes the class type, an object type that corresponds to a .NET reference type. Class types can contain members, properties, implemented interfaces, and a base type.|
|[Structures](structures.md)|Describes the `struct` type, an object type that corresponds to a .NET value type. The `struct` type usually represents a small aggregate of data.|
|[Interfaces](interfaces.md)|Describes interface types, which are types that represent a set of members that provide certain functionality but that contain no data. An interface type must be implemented by an object type to be useful.|
|[Delegates](delegates.md)|Describes the delegate type, which represents a function as an object.|
|[Enumerations](enumerations.md)|Describes enumeration types, whose values belong to a set of named values.|
|[Attributes](attributes.md)|Describes attributes, which are used to specify metadata for another type.|
|[Exception Types](exception-handling/exception-types.md)|Describes exceptions, which specify error information.|
