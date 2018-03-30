---
title: Casting and Conversions (F#)
description: Learn how the F# programming language provides conversion operators for arithmetic conversions between various primitive types.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: db30db67-da21-4206-bf0c-9211bd3cb22f 
---

# Casting and Conversions (F#)

This topic describes support for type conversions in F#.

## Arithmetic Types
F# provides conversion operators for arithmetic conversions between various primitive types, such as between integer and floating point types. The integral and char conversion operators have checked and unchecked forms; the floating point operators and the `enum` conversion operator do not. The unchecked forms are defined in `Microsoft.FSharp.Core.Operators` and the checked forms are defined in `Microsoft.FSharp.Core.Operators.Checked`. The checked forms check for overflow and generate a runtime exception if the resulting value exceeds the limits of the target type.

Each of these operators has the same name as the name of the destination type. For example, in the following code, in which the types are explicitly annotated, `byte` appears with two different meanings. The first occurrence is the type and the second is the conversion operator.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-2/snippet4401.fs)]

The following table shows conversion operators defined in F#.

|Operator|Description|
|--------|-----------|
|`byte`|Convert to byte, an 8-bit unsigned type.|
|`sbyte`|Convert to signed byte.|
|`int16`|Convert to a 16-bit signed integer.|
|`uint16`|Convert to a 16-bit unsigned integer.|
|`int32, int`|Convert to a 32-bit signed integer.|
|`uint32`|Convert to a 32-bit unsigned integer.|
|`int64`|Convert to a 64-bit signed integer.|
|`uint64`|Convert to a 64-bit unsigned integer.|
|`nativeint`|Convert to a native integer.|
|`unativeint`|Convert to an unsigned native integer.|
|`float, double`|Convert to a 64-bit double-precision IEEE floating point number.|
|`float32, single`|Convert to a 32-bit single-precision IEEE floating point number.|
|`decimal`|Convert to `System.Decimal`.|
|`char`|Convert to `System.Char`, a Unicode character.|
|`enum`|Convert to an enumerated type.|
In addition to built-in primitive types, you can use these operators with types that implement `op_Explicit` or `op_Implicit` methods with appropriate signatures. For example, the `int` conversion operator works with any type that provides a static method `op_Explicit` that takes the type as a parameter and returns `int`. As a special exception to the general rule that methods cannot be overloaded by return type, you can do this for `op_Explicit` and `op_Implicit`.

## Enumerated Types
The `enum` operator is a generic operator that takes one type parameter that represents the type of the `enum` to convert to. When it converts to an enumerated type, type inference attempts to determine the type of the `enum` that you want to convert to. In the following example, the variable `col1` is not explicitly annotated, but its type is inferred from the later equality test. Therefore, the compiler can deduce that you are converting to a `Color` enumeration. Alternatively, you can supply a type annotation, as with `col2` in the following example.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-2/snippet4402.fs)]
    
You can also specify the target enumeration type explicitly as a type parameter, as in the following code:

```fsharp
let col3 = enum<Color> 3
```

Note that the enumeration casts work only if the underlying type of the enumeration is compatible with the type being converted. In the following code, the conversion fails to compile because of the mismatch between `int32` and `uint32`.

```fsharp
// Error: types are incompatible
let col4 : Color = enum 2u
```

For more information, see [Enumerations](enumerations.md).

## Casting Object Types
Conversion between types in an object hierarchy is fundamental to object-oriented programming. There are two basic types of conversions: casting up (upcasting) and casting down (downcasting). Casting up a hierarchy means casting from a derived object reference to a base object reference. Such a cast is guaranteed to work as long as the base class is in the inheritance hierarchy of the derived class. Casting down a hierarchy, from a base object reference to a derived object reference, succeeds only if the object actually is an instance of the correct destination (derived) type or a type derived from the destination type.

F# provides operators for these types of conversions. The `:>` operator casts up the hierarchy, and the `:?>` operator casts down the hierarchy.

### Upcasting
In many object-oriented languages, upcasting is implicit; in F#, the rules are slightly different. Upcasting is applied automatically when you pass arguments to methods on an object type. However, for let-bound functions in a module, upcasting is not automatic, unless the parameter type is declared as a flexible type. For more information, see [Flexible Types](flexible-Types.md).

The `:>` operator performs a static cast, which means that the success of the cast is determined at compile time. If a cast that uses `:>` compiles successfully, it is a valid cast and has no chance of failure at run time.

You can also use the `upcast` operator to perform such a conversion. The following expression specifies a conversion up the hierarchy:

```fsharp
upcast expression
```

When you use the upcast operator, the compiler attempts to infer the type you are converting to from the context. If the compiler is unable to determine the target type, the compiler reports an error.

### Downcasting
The `:?>` operator performs a dynamic cast, which means that the success of the cast is determined at run time. A cast that uses the `:?>` operator is not checked at compile time; but at run time, an attempt is made to cast to the specified type. If the object is compatible with the target type, the cast succeeds. If the object is not compatible with the target type, the runtime raises an `InvalidCastException`.

You can also use the `downcast` operator to perform a dynamic type conversion. The following expression specifies a conversion down the hierarchy to a type that is inferred from program context:

```fsharp
downcast expression
```

As for the `upcast` operator, if the compiler cannot infer a specific target type from the context, it reports an error.

The following code illustrates the use of the `:>` and `:?>` operators. The code illustrates that the `:?>` operator is best used when you know that conversion will succeed, because it throws `InvalidCastException` if the conversion fails. If you do not know that a conversion will succeed, a type test that uses a `match` expression is better because it avoids the overhead of generating an exception.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-2/snippet4403.fs)]

Because generic operators `downcast` and `upcast` rely on type inference to determine the argument and return type, in the above code, you can replace

```fsharp
let base1 = d1 :> Base1
```

with

```fsharp
let base1 = upcast d1
```

In the previous code, the argument type and return types are `Derived1` and `Base1`, respectively.

For more information about type tests, see [Match Expressions](match-Expressions.md).

## See Also
[F# Language Reference](index.md)
