---
title: Reference Cells
description: Learn how F# reference cells are storage locations that enable you to create mutable values with reference semantics.
ms.date: 05/16/2016
---
# Reference Cells

*Reference cells* are storage locations that enable you to create mutable values with reference semantics.

## Syntax

```fsharp
ref expression
```

## Remarks

You use the `ref` operator before a value to create a new reference cell that encapsulates the value. You can then change the underlying value because it is mutable.

A reference cell holds an actual value; it is not just an address. When you create a reference cell by using the `ref` operator, you create a copy of the underlying value as an encapsulated mutable value.

You can dereference a reference cell by using the `!` (bang) operator.

The following code example illustrates the declaration and use of reference cells.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet2201.fs)]

The output is `50`.

Reference cells are instances of the `Ref` generic record type, which is declared as follows.

```fsharp
type Ref<'a> =
{ mutable contents: 'a }
```

The type `'a ref` is a synonym for `Ref<'a>`. The compiler and IntelliSense in the IDE display the former for this type, but the underlying definition is the latter.

The `ref` operator creates a new reference cell. The following code is the declaration of the `ref` operator.

```fsharp
let ref x = { contents = x }
```

The following table shows the features that are available on the reference cell.

|Operator, member, or field|Description|Type|Definition|
|--------------------------|-----------|----|----------|
|`!` (dereference operator)|Returns the underlying value.|`'a ref -> 'a`|`let (!) r = r.contents`|
|`:=` (assignment operator)|Changes the underlying value.|`'a ref -> 'a -> unit`|`let (:=) r x = r.contents <- x`|
|`ref` (operator)|Encapsulates a value into a new reference cell.|`'a -> 'a ref`|`let ref x = { contents = x }`|
|`Value` (property)|Gets or sets the underlying value.|`unit -> 'a`|`member x.Value = x.contents`|
|`contents` (record field)|Gets or sets the underlying value.|`'a`|`let ref x = { contents = x }`|

There are several ways to access the underlying value. The value returned by the dereference operator (`!`) is not an assignable value. Therefore, if you are modifying the underlying value, you must use the assignment operator (`:=`) instead.

Both the `Value` property and the `contents` field are assignable values. Therefore, you can use these to either access or change the underlying value, as shown in the following code.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet2203.fs)]

The output is as follows.

```
10
10
11
12
```

The field `contents` is provided for compatibility with other versions of ML and will produce a warning during compilation. To disable the warning, use the `--mlcompatibility` compiler option. For more information, see [Compiler Options](compiler-options.md).

C# programmers should know that `ref` in C# is not the same thing as `ref` in F#. The equivalent constructs in F# are [byrefs](byrefs.md), which are a different concept from reference cells.

Values marked as `mutable`may be automatically promoted to `'a ref` if captured by a closure; see [Values](./values/index.md).

## See also

- [F# Language Reference](index.md)
- [Parameters and Arguments](parameters-and-arguments.md)
- [Symbol and Operator Reference](./symbol-and-operator-reference/index.md)
- [Values](./values/index.md)
