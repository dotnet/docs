---
title: Casting and conversions
description: Learn how the F# programming language provides operators for arithmetic conversions between various primitive types.
ms.date: 02/20/2020
---
# Casting and conversions (F#)

This article describes support for type conversions in F#.

## Arithmetic Types

F# provides conversion operators for arithmetic conversions between various primitive types, such as between integer and floating point types. The integral and char conversion operators have checked and unchecked forms; the floating point operators and the `enum` conversion operator do not. The unchecked forms are defined in `FSharp.Core.Operators` and the checked forms are defined in `FSharp.Core.Operators.Checked`. The checked forms check for overflow and generate a runtime exception if the resulting value exceeds the limits of the target type.

Each of these operators has the same name as the name of the destination type. For example, in the following code, in which the types are explicitly annotated, `byte` appears with two different meanings. The first occurrence is the type and the second is the conversion operator.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-2/snippet4401.fs)]

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

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-2/snippet4402.fs)]

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

In many object-oriented languages, upcasting is implicit; in F#, the rules are slightly different. Upcasting is applied automatically when you pass arguments to methods on an object type. However, for let-bound functions in a module, upcasting is not automatic, unless the parameter type is declared as a flexible type. For more information, see [Flexible Types](flexible-types.md).

The `:>` operator performs a static cast, which means that the success of the cast is determined at compile time. If a cast that uses `:>` compiles successfully, it is a valid cast and has no chance of failure at run time.

You can also use the `upcast` operator to perform such a conversion. The following expression specifies a conversion up the hierarchy:

```fsharp
upcast expression
```

When you use the upcast operator, the compiler attempts to infer the type you are converting to from the context. If the compiler is unable to determine the target type, the compiler reports an error. A type annotation may be required.

### Downcasting

The `:?>` operator performs a dynamic cast, which means that the success of the cast is determined at run time. A cast that uses the `:?>` operator is not checked at compile time; but at run time, an attempt is made to cast to the specified type. If the object is compatible with the target type, the cast succeeds. If the object is not compatible with the target type, the runtime raises an `InvalidCastException`.

You can also use the `downcast` operator to perform a dynamic type conversion. The following expression specifies a conversion down the hierarchy to a type that is inferred from program context:

```fsharp
downcast expression
```

As for the `upcast` operator, if the compiler cannot infer a specific target type from the context, it reports an error. A type annotation may be required.

The following code illustrates the use of the `:>` and `:?>` operators. The code illustrates that the `:?>` operator is best used when you know that conversion will succeed, because it throws `InvalidCastException` if the conversion fails. If you do not know that a conversion will succeed, a type test that uses a `match` expression is better because it avoids the overhead of generating an exception.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-2/snippet4403.fs)]

Because the generic operators `downcast` and `upcast` rely on type inference to determine the argument and return type, you can replace `let base1 = d1 :> Base1` in the previous code example with `let base1: Base1 = upcast d1`.

A type annotation is required, because `upcast` by itself could not determine the base class.

## Implicit upcast conversions

Implicit upcasts are inserted in the following situations:

* When providing a parameter to a function or method with a known named type. This includes when a construct such as computation expressions or slicing becomes a method call.

* When assigning to or mutating a record field or property that has a known named type.

* When a branch of an `if/then/else` or `match` expression has a known target type arising from another branch or overall known type.

* When an element of a list, array, or sequence expression has a known target type.

For example, consider the following code:

```fsharp
open System
open System.IO

let findInputSource () : TextReader =
    if DateTime.Now.DayOfWeek = DayOfWeek.Monday then
        // On Monday a TextReader
        Console.In
    else
        // On other days a StreamReader
        File.OpenText("path.txt")
```

Here the branches of the conditional compute a `TextReader` and `StreamReader` respectively. On the second branch, the known target type is `TextReader` from the type annotation on the method, and from the first branch. This means no upcast is needed on the second branch.

To show a warning at every point an additional implicit upcast is used, you can enable warning 3388 (`/warnon:3388` or property `<WarnOn>3388</WarnOn>`).

### Implicit numeric conversions

F# uses explicit widening of numeric types in most cases via conversion operators. For example, explicit widening is needed for most numeric types, such as `int8` or `int16`, or from `float32` to `float64`, or when either source or destination type is unknown.

However, implicit widening is allowed for 32-bit integers widened to 64-bit integers, in the same situations as implicit upcasts. For example, consider a typical API shape:

```fsharp
type Tensor(…) =
    static member Create(sizes: seq<int64>) = Tensor(…)
```

Integer literals for int64 may be used:

```fsharp
Tensor.Create([100L; 10L; 10L])
```

Or integer literals for int32:

```fsharp
Tensor.Create([int64 100; int64 10; int64 10])
```

Widening happens automatically for `int32` to `int64`, `int32` to `nativeint`, and `int32` to `double`, when both source and destination type are known during type inference. So in cases such as the previous examples, `int32` literals can be used:

```fsharp
Tensor.Create([100; 10; 10])
```

You can also optionally enable the warning 3389 (`/warnon:3389` or property `<WarnOn>3389</WarnOn>`) to show a warning at every point implicit numeric widening is used.

### .NET-style implicit conversions

.NET APIs allow the definition of `op_Implicit` static methods to provide implicit conversions between types. These are applied automatically in F# code when passing arguments to methods. For example, consider the following code making explicit calls to `op_Implicit` methods:

```fsharp
open System.Xml.Linq

let purchaseOrder = XElement.Load("PurchaseOrder.xml")
let partNos = purchaseOrder.Descendants(XName.op_Implicit "Item")
```

.NET-style `op_Implicit` conversions are applied automatically for argument expressions when types are available for source expression and target type:

```fsharp
open System.Xml.Linq

let purchaseOrder = XElement.Load("PurchaseOrder.xml")
let partNos = purchaseOrder.Descendants("Item")
```

You can also optionally enable the warning 3395 (`/warnon:3395` or property `<WarnOn>3395</WarnOn>`) to show a warning at every point a .NET-style implicit conversion is used.

.NET-style `op_Implicit` conversions are also applied automatically for non-method-argument expressions in the same situations as implicit upcasts. However, when used widely or inappropriately, implicit conversions can interact poorly with type inference and lead to code that's harder to understand. For this reason, these always generate warnings when used in non-argument positions.

To show a warning at every point that a .NET-style implicit conversion is used for a non-method argument, you can enable warning 3391 (`/warnon:3391` or property `<WarnOn>3391</WarnOn>`).

### Summary of warnings related to conversions

The following optional warnings are provided for uses of implicit conversions:

* `/warnon:3388` (additional implicit upcast)
* `/warnon:3389` (implicit numeric widening)
* `/warnon:3391` (`op_Implicit` at non-method arguments, on by default)
* `/warnon:3395` (`op_Implicit` at method arguments)

## See also

- [F# Language Reference](index.md)
