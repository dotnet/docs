---
title: Null Values
description: Learn how the null value is used in the F# programming language.
ms.date: 08/15/2020
---
# Null Values

This topic describes how the null value is used in F#.

## Null Values Prior To F# 9

The null value is not normally used in F# for values or variables. However, null appears as an abnormal value in certain situations. If a type is defined in F#, null is not permitted as a regular value unless the [AllowNullLiteral](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-allownullliteralattribute.html#Value) attribute is applied to the type. If a type is defined in some other .NET language, null is a possible value, and when you are interoperating with such types, your F# code might encounter null values.

For a type defined in F# and used strictly from F#, the only way to create a null value using the F# library directly is to use [Unchecked.defaultof](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-operators-unchecked.html#defaultof) or [Array.zeroCreate](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule.html#zeroCreate). However, for an F# type that is used from other .NET languages, or if you are using that type with an API that is not written in F#, such as the .NET Framework, null values can occur.

You can use the `option` type in F# when you might use a reference variable with a possible null value in another .NET language. Instead of null, with an F# `option` type, you use the option value `None` if there is no object. You use the option value `Some(obj)` with an object `obj` when there is an object. For more information, see [Options](../options.md). Note that you can still pack a `null` value into an Option if, for `Some x`, `x` happens to be `null`. Because of this, it is important you use `None` when a value is `null`.

The `null` keyword is a valid keyword in F#, and you have to use it when you are working with .NET Framework APIs or other APIs that are written in another .NET language. The two situations in which you might need a null value are when you call a .NET API and pass a null value as an argument, and when you interpret the return value or an output parameter from a .NET method call.

To pass a null value to a .NET method, just use the `null` keyword in the calling code. The following code example illustrates this.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet701.fs)]

To interpret a null value that is obtained from a .NET method, use pattern matching if you can. The following code example shows how to use pattern matching to interpret the null value that is returned from `ReadLine` when it tries to read past the end of an input stream.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet702.fs)]

Null values for F# types can also be generated in other ways, such as when you use `Array.zeroCreate`, which calls `Unchecked.defaultof`. You must be careful with such code to keep the null values encapsulated. In a library intended only for F#, you do not have to check for null values in every function. If you are writing a library for interoperation with other .NET languages, you might have to add checks for null input parameters and throw an `ArgumentNullException`, just as you do in C# or Visual Basic code.

You can use the following code to check if an arbitrary value is null.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet703.fs)]

## Null Values starting with F# 9

In F# 9, extra capabilities are added to the language to deal with reference types which can have `null` as a value. Those are off by default - to turn them on, the following property must be put in your project file:

```xml
<Nullable>enable</Nullable>
```

This passes the `--checknulls+` [flag](../compiler-options.md) to the F# compiler and sets a `NULLABLE` [preprocessor directive](../compiler-directives.md#nullable-directive) for the build.

To explicitly opt-in into nullability, a type declaration has to be suffixed with the new syntax:

```fsharp
type | null
```

The bar symbol `|` has the meaning of a logical OR in the syntax, building a union of two disjoint sets of types: the underlying type, and the nullable reference. This is the same syntactical symbol which is used for declaring multiple cases of an F# discriminated union: `type AB = A | B` carries the meaning of either `A`, or `B`.

The nullable annotation `| null` can be used at all places where a reference type would be normally used:

- Fields of union types, record types and custom types.
- Type aliases to existing types.
- Type applications of a generic type.
- Explicit type annotations to let bindings, parameters or return types.
- Type annotations to object-programming constructs like members, properties or fields.

```fsharp
type AB = A | B
type AbNull = AB | null

type RecordField = { X: string | null }
type TupleField = string * string | null

type NestedGenerics = { Z : List<List<string | null> | null> | null }
```

The bar symbol `|` does have other usages in F# which might lead to syntactical ambiguities. In such cases, parentheses are needed around the null-annotated type:

```fsharp
// Unexpected symbol '|' (directly before 'null') in member definition
type DUField = N of string | null
```

Wrapping the same type into a pair of `( )` parentheses fixes the issue:

```fsharp
type DUField = N of (string | null)
```

When used in pattern matching, `|` is used to separate different pattern matching clauses.

```fsharp
match x with
| ?: string | null -> ...
```

This snippet is actually equivalent to code first doing a type test against the `string` type, and then having a separate clause for handling null:

```fsharp
match x with
| ?: string 
| null -> ...
```

> [!IMPORTANT]
> The extra null related capabilities were added to the language for the interoperability purposes. Using `| null` in F# type modeling is not considered idiomatic for denoting missing information - for that purpose, use options (as described above). Read more about null-related [conventions](../../style-guide/conventions.md#nulls-and-default-values) in the style guide.

## See also

- [Values](index.md)
- [Match Expressions](../match-expressions.md)
