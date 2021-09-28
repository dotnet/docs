---
title: Structures
description: Learn about the F# structure, a compact object type often more efficient than a class for types with a small amount of data and simple behavior.
ms.date: 05/16/2016
---
# Structures

A *structure* is a compact object type that can be more efficient than a class for types that have a small amount of data and simple behavior.

## Syntax

```fsharp
[ attributes ]
type [accessibility-modifier] type-name =
    struct
        type-definition-elements-and-members
    end
// or
[ attributes ]
[<StructAttribute>]
type [accessibility-modifier] type-name =
    type-definition-elements-and-members
```

## Remarks

Structures are *value types*, which means that they are stored directly on the stack or, when they are used as fields or array elements, inline in the parent type. Unlike classes and records, structures have pass-by-value semantics. This means that they are useful primarily for small aggregates of data that are accessed and copied frequently.

In the previous syntax, two forms are shown. The first is not the lightweight syntax, but it is nevertheless frequently used because, when you use the `struct` and `end` keywords, you can omit the `StructAttribute` attribute, which appears in the second form. You can abbreviate `StructAttribute` to just `Struct`.

The *type-definition-elements-and-members* in the previous syntax represents member declarations and definitions. Structures can have constructors and mutable and immutable fields, and they can declare members and interface implementations. For more information, see [Members](./members/index.md).

Structures cannot participate in inheritance, cannot contain `let` or `do` bindings, and cannot recursively contain fields of their own type (although they can contain reference cells that reference their own type).

Because structures do not allow `let` bindings, you must declare fields in structures by using the `val` keyword. The `val` keyword defines a field and its type but does not allow initialization. Instead, `val` declarations are initialized to zero or null. For this reason, structures that have an implicit constructor (that is, parameters that are given immediately after the structure name in the declaration) require that `val` declarations be annotated with the `DefaultValue` attribute. Structures that have a defined constructor still support zero-initialization. Therefore, the `DefaultValue` attribute is a declaration that such a zero value is valid for the field. Implicit constructors for structures do not perform any actions because `let` and `do` bindings aren’t allowed on the type, but the implicit constructor parameter values passed in are available as private fields.

Explicit constructors might involve initialization of field values. When you have a structure that has an explicit constructor, it still supports zero-initialization; however, you do not use the `DefaultValue` attribute on the `val` declarations because it conflicts with the explicit constructor. For more information about `val` declarations, see [Explicit Fields: The `val` Keyword](./members/explicit-fields-the-val-keyword.md).

Attributes and accessibility modifiers are allowed on structures, and follow the same rules as those for other types. For more information, see [Attributes](attributes.md) and [Access Control](access-control.md).

The following code examples illustrate structure definitions.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet2501.fs)]

## ByRefLike structs

You can define your own structs that can adhere to `byref`-like semantics: see [Byrefs](byrefs.md) for more information. This is done with the <xref:System.Runtime.CompilerServices.IsByRefLikeAttribute> attribute:

```fsharp
open System
open System.Runtime.CompilerServices

[<IsByRefLike; Struct>]
type S(count1: Span<int>, count2: Span<int>) =
    member x.Count1 = count1
    member x.Count2 = count2
```

`IsByRefLike` does not imply `Struct`. Both must be present on the type.

A "`byref`-like" struct in F# is a stack-bound value type. It is never allocated on the managed heap. A `byref`-like struct is useful for high-performance programming, as it is enforced with set of strong checks about lifetime and non-capture. The rules are:

- They can be used as function parameters, method parameters, local variables, method returns.
- They cannot be static or instance members of a class or normal struct.
- They cannot be captured by any closure construct (`async` methods or lambda expressions).
- They cannot be used as a generic parameter.

Although these rules very strongly restrict usage, they do so to fulfill the promise of high-performance computing in a safe manner.

## ReadOnly structs

You can annotate structs with the <xref:System.Runtime.CompilerServices.IsReadOnlyAttribute> attribute. For example:

```fsharp
[<IsReadOnly; Struct>]
type S(count1: int, count2: int) =
    member x.Count1 = count1
    member x.Count2 = count2
```

`IsReadOnly` does not imply `Struct`. You must add both to have an `IsReadOnly` struct.

Use of this attribute emits metadata letting F# and C# know to treat it as `inref<'T>` and `in ref`, respectively.

Defining a mutable value inside of a readonly struct produces an error.

## Struct Records and Discriminated Unions

You can represent [Records](records.md) and [Discriminated Unions](discriminated-unions.md) as structs with the `[<Struct>]` attribute.  See each article to learn more.

## See also

- [F# Language Reference](index.md)
- [Classes](classes.md)
- [Records](records.md)
- [Members](./members/index.md)
