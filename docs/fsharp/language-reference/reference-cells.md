---
title: Reference Cells (F#)
description: Learn how F# reference cells are storage locations that enable you to create mutable values with reference semantics.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: 09a0b221-ea21-45c4-bae8-5e4a339750c4
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

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet2201.fs)]

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

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet2203.fs)]

The output is as follows.

```
10
10
11
12
```

The field `contents` is provided for compatibility with other versions of ML and will produce a warning during compilation. To disable the warning, use the `--mlcompatibility` compiler option. For more information, see [Compiler Options](compiler-options.md).

The following code illustrates the use of reference cells in parameter passing. The Incrementor type has a method Increment that takes a parameter that includes byref in the parameter type. The byref in the parameter type indicates that callers must pass a reference cell or the address of a typical variable of the specified type, in this case int. The remaining code illustrates how to call Increment with both of these types of arguments, and shows the use of the ref operator on a variable to create a reference cell (ref myDelta1). It then shows the use of the address-of operator (&amp;) to generate an appropriate argument. Finally, the Increment method is called again by using a reference cell that is declared by using a let binding. The final line of code demonstrates the use of the ! operator to dereference the reference cell for printing.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet2204.fs)]

For more information about how to pass by reference, see [Parameters and Arguments](parameters-and-arguments.md).

>[!NOTE]
C# programmers should know that ref works differently in F# than it does in C#. For example, the use of ref when you pass an argument does not have the same effect in F# as it does in C#.

## Consuming C# `ref` returns

Starting with F# 4.1, you can consume `ref` returns generated in C#.  The result of such a call is a `byref<_>` pointer.

The following C# method:

```csharp
namespace RefReturns
{
    public static class RefClass
    {
        public static ref int Find(int val, int[] vals)
        {
            for (int i = 0; i < vals.Length; i++)
            {
                if (vals[i] == val)
                {
                    return ref numbers[i]; // Returns the location, not the value
                }
            }

            throw new IndexOutOfRangeException($"{nameof(number)} not found");
        }
    }
}
```

Can be transparently called by F# with no special syntax:

```fsharp
open RefReturns

let consumeRefReturn() =
    let result = RefClass.Find(3, [| 1; 2; 3; 4; 5 |]) // 'result' is of type 'byref<int>'.
    ()
```

You can also declare functions which could take a `ref` return as input, for example:

```fsharp
let f (x: byref<int>) = &x
```

There is currently no way to generate a `ref` return in F# which could be consumed in C#.

## See Also
[F# Language Reference](index.md)

[Parameters and Arguments](parameters-and-arguments.md)

[Symbol and Operator Reference](symbol-and-operator-reference/index.md)
