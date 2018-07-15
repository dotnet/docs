---
title: Type Extensions (F#)
description: Learn how F# type extensions allow you add new members to a previously defined object type.
ms.date: 07/14/2018
---
# Type Extensions

Type extensions (also called _augmentations_) are a family of features that let you add new members to a previously defined object type. The three features are:

* Intrinsic type extensions
* Optional type extensions
* Extension methods

Each can be used in different scenarios and has different tradeoffs.

## Syntax

```fsharp
// Intrinsic and optional extensions
type typename with
    member self-identifier.member-name =
        body
    ...

// Extension methods
open System.Runtime.CompilerServices

// On a module
[<Extension>]
module TypeNameExtensions =
    let [inline] extension-name (ty: typename) [args] =
        body
    ...

// On a class
[<Extension>]
type Extensions() =
    [static] member self-identifier.extension-name (ty: typename, [args]) =
        body
    ...
```

## Intrinsic type extensions

An intrinsic type extension is an extension that appears in the same namespace or module, in the same source file, or in the same assembly (DLL or executable file) as the type being extended.

Intrinsic type extensions are sometimes a cleaner way to separate functionality from the type declaration. For example:

```fsharp
namespace Example

type Variant =
    | Num of int
    | Str of string
  
module Variant =
    let print v =
        match v with
        | Num n -> printf "Num %d" n
        | Str s -> printf "Str %s" s

// Add a member to Variant as an extension
type Variant with
    member x.Print() = Variant.print x
```

This allows you to separate the declaration of a `Variant` type, functionality to print such a class, and offer a way to access this functionality as if it were a member on the type. This is an alternative to defining everything as a member on `Variant`. This is not necessarily preferable to do, but it is an option if you prefer to cleanly separate things.

Intrinsic type extensions are compiled as members on the type they augment, and appear on the type when the type is examined by reflection.

## Optional type extensions

An optional type extension is an extension that appears outside the original module, namespace, or assembly of the type being extended.

Optional type extensions are useful for extending a type that you have not defined yourself. For example:

```fsharp
module Extensions

open System.Collections.Generic

type IEnumerable<'T> with
    /// Repeat each element of the sequence n times
    member xs.RepeatElements(n: int) =
        seq {
            for x in xs do
                for i in 1 .. n do
                    yield x
        }
```

You can now access `RepeatElements` as if it were a member on <xref:System.Collections.Generic.IEnumerable`1> so long as the `Extensions` module is opened in the scope that you are working in.

Optional extensions do not appear on the extended type when examined by reflection. Optional extensions must be in modules, and they are only in scope when the module that contains the extension is open or is otherwise in scope.

Optional extension members are compiled to static members for which the object instance is passed implicitly as the first parameter. However, they act as if they were instance members or static members according to how they are declared.

## Generic limitation of intrinsic and optional type extensions

It is possible to declare a type extension on a generic type where the type variable is constrained. The requirement is that the constraint of the extension declaration matches the constraint of the declared type.

However, even when constraints are matched between a declared type and a type extension, it is possible for a constraint to be inferred by the body of an extended member that enforces a further constraint that will lead to a type error:

```fsharp
open System.Collections.Generic

// NOT POSSIBLE AND FAILS TO COMPILE!
type IEnumerable<'T> with
    member this.Sum() = Seq.sum this
```

To get around this restriction, you can use extension methods.

## Extension methods

Finally, extension methods (sometimes called "C# style extension members") can be declared in F# as either a let-bound value value in a module or a member on a class.

Extension methods are useful for when you wish to define extensions on a generic type that will constrain the type variable. For example:

```fsharp
namespace Extensions

open System.Runtime.CompilerServices

[<Extension>]
module IEnumerableExtensions =
    [<Extension>]
    let inline Sum(xs: IEnumerable<'T>) = Seq.sum xs
```

When used, this code will make it appear as if `Sum` is defined on <xref:System.Collections.Generic.IEnumerable`1>, so long as `Extensions` has been opened or is in scope.

## Other remarks

Type extensions also have the following attributes:

* Any type that can be accessed can be extended.
* Intrinsic and optional type extensions can define _any_ member type, not just methods. So extension properties are also possible, for example.
* The `self-identifier` token in the [syntax](type-extensions.md#syntax) represents the instance of the type being invoked, just like ordinary members.
* Extended members can be static or instance members.
* Type variables on a type extension must match the constraints of the declared type.

The following limitations also exist for type extensions:

* Type extensions cannot be virtual or abstract methods.
* Type extensions cannot be defined on [type abbreviations](type-abbreviations.md).
* Type extensions do not support override methods as augmentations.
* Type extensions do not permit constructors as augmentations.
* Type extensions are not valid for `byref<'T>` (though they can be declared).
* Type extensions are not valid for attributes (though they can be declared).
* You can define extensions that overload other methods of the same name, but the F# compiler gives preference to non-extension methods in the case of an ambiguous call.

Finally, if multiple intrinsic type extensions exist for one type, all members must be unique. For optional type extensions, members in different type extensions to the same type can have the same names. Ambiguity errors occur only if client code opens two different scopes that define the same member names.

## See Also

[F# Language Reference](index.md)

[Members](members/index.md)
