---
title: Indexed Properties
description: Learn about indexed properties in F#, which allow for array-like access to ordered data.
ms.date: 10/17/2018
---
# Indexed Properties

When defining a class that abstracts over ordered data, it can sometimes be helpful to provide indexed access to that data without exposing the underlying implementation. This is done with the `Index` member.

## Syntax

```fsharp
// Indexed property that has both get and set defined.
member self-identifier.Index
    with get(index-values) =
        get-member-body
    and set index-values values-to-set =
        set-member-body

// Indexed property with get only
member self-identifier.Index
    with get(index-values) =
        get-member-body

// Indexed property that has set only.
member self-identifier.Index
    with set index-values values-to-set =
        set-member-body
```

## Remarks

The forms of the previous syntax show how to define indexed properties that have both a `get` and a `set` method, have a `get` method only, or have a `set` method only. You can also combine both the syntax shown for get only and the syntax shown for set only, and produce a property that has both get and set. This latter form allows you to put different accessibility modifiers and attributes on the get and set methods.

By using the name `Item`, the compiler treats the property as a default indexed property. A *default indexed property* is a property that you can access by using array-like syntax on the object instance. For example, if `o` is an object of the type that defines this property, the syntax `o.[index]` is used to access the property.

The syntax for accessing a non-default indexed property is to provide the name of the property and the index in parentheses, just like a regular member. For example, if the property on `o` is called `Ordinal`, you write `o.Ordinal(index)` to access it.

Regardless of which form you use, you should always use the curried form for the set method on an indexed property. For information about curried functions, see [Functions](../functions/index.md).

## Example

The following code example illustrates the definition and use of default and non-default indexed properties that have get and set methods.

[!code-fsharp[Main](../../../../samples/snippets/fsharp/lang-ref-1/snippet3301.fs)]

## Output

```console
ONE two three four five six seven eight nine ten
ONE first two second three third four fourth five fifth six 6th
seven seventh eight eighth nine ninth ten tenth
```

## Indexed Properties with multiple index values

Indexed properties can have more than one index value. In that case, the values are separated by commas when the property is used. The set method in such a property must have two curried arguments, the first of which is a tuple containing the keys, and the second of which is the value to set.

The following code demonstrates the use of an indexed property with multiple index values.

```fsharp
open System.Collections.Generic

/// Basic implementation of a sparse matrix basedon a dictionary
type SparseMatrix() =
    let table = new Dictionary<(int * int), float>()
    member __.Item
        // Because the key is comprised of two values, 'get' has two index values
        with get(key1, key2) = table.[(key1, key2)]

        // 'set' has two index values and a new value to place in the key's position
        and set (key1, key2) value = table.[(key1, key2)] <- value

let sm = new SparseMatrix()
for i in 1..1000 do
    sm.[i, i] <- float i * float i
```

## See also

- [Members](index.md)
