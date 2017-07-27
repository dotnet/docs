---
title: Constraints (F#)
description: Learn about F# constraints that apply to generic type parameters to specify the requirements for a type argument in a generic type or function.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: 2f232a3a-9486-48fb-9759-f23404ed4b52 
---

# Constraints

This topic describes constraints that you can apply to generic type parameters to specify the requirements for a type argument in a generic type or function.


## Syntax

```fsharp
type-parameter-list when constraint1 [ and constraint2]
```

## Remarks
There are several different constraints you can apply to limit the types that can be used in a generic type. The following table lists and describes these constraints.

|Constraint|Syntax|Description|
|----------|------|-----------|
|Type Constraint|*type-parameter* :&gt; *type*|The provided type must be equal to or derived from the type specified, or, if the type is an interface, the provided type must implement the interface.|
|Null Constraint|*type-parameter* : null|The provided type must support the null literal. This includes all .NET object types but not F# list, tuple, function, class, record, or union types.|
|Explicit Member Constraint|[(]*type-parameter* [or ... or *type-parameter*)] : (*member-signature *)|At least one of the type arguments provided must have a member that has the specified signature; not intended for common use. Members must be either explicitly defined on the type or part of an implicit type extension to be valid targets for an Explicit Member Constraint.|
|Constructor Constraint|*type-parameter* : ( new : unit -&gt; 'a )|The provided type must have a default constructor.|
|Value Type Constraint|: struct|The provided type must be a .NET value type.|
|Reference Type Constraint|: not struct|The provided type must be a .NET reference type.|
|Enumeration Type Constraint|: enum&lt;*underlying-type*&gt;|The provided type must be an enumerated type that has the specified underlying type; not intended for common use.|
|Delegate Constraint|: delegate&lt;*tuple-parameter-type*, *return-type*&gt;|The provided type must be a delegate type that has the specified arguments and return value; not intended for common use.|
|Comparison Constraint|: comparison|The provided type must support comparison.|
|Equality Constraint|: equality|The provided type must support equality.|
|Unmanaged Constraint|: unmanaged|The provided type must be an unmanaged type. Unmanaged types are either certain primitive types (`sbyte`, `byte`, `char`, `nativeint`, `unativeint`, `float32`, `float`, `int16`, `uint16`, `int32`, `uint32`, `int64`, `uint64`, or `decimal`), enumeration types, `nativeptr&lt;_&gt;`, or a non-generic structure whose fields are all unmanaged types.|
You have to add a constraint when your code has to use a feature that is available on the constraint type but not on types in general. For example, if you use the type constraint to specify a class type, you can use any one of the methods of that class in the generic function or type.

Specifying constraints is sometimes required when writing type parameters explicitly, because without a constraint, the compiler has no way of verifying that the features that you are using will be available on any type that might be supplied at run time for the type parameter.

The most common constraints you use in F# code are type constraints that specify base classes or interfaces. The other constraints are either used by the F# library to implement certain functionality, such as the explicit member constraint, which is used to implement operator overloading for arithmetic operators, or are provided mainly because F# supports the complete set of constraints that is supported by the common language runtime.

During the type inference process, some constraints are inferred automatically by the compiler. For example, if you use the `+` operator in a function, the compiler infers an explicit member constraint on variable types that are used in the expression.

The following code illustrates some constraint declarations.

```fsharp
// Base Type Constraint
type Class1<'T when 'T :> System.Exception> =
class end

// Interface Type Constraint
type Class2<'T when 'T :> System.IComparable> = 
class end

// Null constraint
type Class3<'T when 'T : null> =
class end

// Member constraint with static member
type Class4<'T when 'T : (static member staticMethod1 : unit -> 'T) > =
class end

// Member constraint with instance member
type Class5<'T when 'T : (member Method1 : 'T -> int)> =
class end

// Member constraint with property
type Class6<'T when 'T : (member Property1 : int)> =
class end

// Constructor constraint
type Class7<'T when 'T : (new : unit -> 'T)>() =
member val Field = new 'T()

// Reference type constraint
type Class8<'T when 'T : not struct> =
class end

// Enumeration constraint with underlying value specified
type Class9<'T when 'T : enum<uint32>> =
class end

// 'T must implement IComparable, or be an array type with comparable
// elements, or be System.IntPtr or System.UIntPtr. Also, 'T must not have
// the NoComparison attribute.
type Class10<'T when 'T : comparison> =
class end

// 'T must support equality. This is true for any type that does not
// have the NoEquality attribute.
type Class11<'T when 'T : equality> =
class end

type Class12<'T when 'T : delegate<obj * System.EventArgs, unit>> =
class end

type Class13<'T when 'T : unmanaged> =
class end

// Member constraints with two type parameters
// Most often used with static type parameters in inline functions
let inline add(value1 : ^T when ^T : (static member (+) : ^T * ^T -> ^T), value2: ^T) =
value1 + value2

// ^T and ^U must support operator +
let inline heterogenousAdd(value1 : ^T when (^T or ^U) : (static member (+) : ^T * ^U -> ^T), value2 : ^U) =
value1 + value2

// If there are multiple constraints, use the and keyword to separate them.
type Class14<'T,'U when 'T : equality and 'U : equality> =
class end
```

## See Also
[Generics](index.md)

[Constraints](constraints.md)
