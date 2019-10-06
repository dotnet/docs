---
title: Type Extensions
description: Learn how F# type extensions allow you add new members to a previously defined object type.
ms.date: 02/08/2019
---
# Type extensions

Type extensions (also called _augmentations_) are a family of features that let you add new members to a previously defined object type. The three features are:

- Intrinsic type extensions
- Optional type extensions
- Extension methods

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

[<Extension>]
type Extensions() =
    [static] member self-identifier.extension-name (ty: typename, [args]) =
        body
    ...
```

## Intrinsic type extensions

An intrinsic type extension is a type extension that extends a user-defined type.

Intrinsic type extensions must be defined in the same file **and** in the same namespace or module as the type they're extending. Any other definition will result in them being [optional type extensions](type-extensions.md#optional-type-extensions).

Intrinsic type extensions are sometimes a cleaner way to separate functionality from the type declaration. The following example shows how to define an intrinsic type extension:

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

Using a type extension allows you to separate each of the following:

- The declaration of a `Variant` type
- Functionality to print the `Variant` class depending on its "shape"
- A way to access the printing functionality with object-style `.`-notation

This is an alternative to defining everything as a member on `Variant`. Although it is not an inherently better approach, it can be a cleaner representation of functionality in some situations.

Intrinsic type extensions are compiled as members of the type they augment, and appear on the type when the type is examined by reflection.

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

You can now access `RepeatElements` as if it's a member of <xref:System.Collections.Generic.IEnumerable%601> as long as the `Extensions` module is opened in the scope that you are working in.

Optional extensions do not appear on the extended type when examined by reflection. Optional extensions must be in modules, and they're only in scope when the module that contains the extension is open or is otherwise in scope.

Optional extension members are compiled to static members for which the object instance is passed implicitly as the first parameter. However, they act as if they're instance members or static members according to how they're declared.

Optional extension members are also not visible to C# or VB consumers. They can only be consumed in other F# code.

## Generic limitation of intrinsic and optional type extensions

It's possible to declare a type extension on a generic type where the type variable is constrained. The requirement is that the constraint of the extension declaration matches the constraint of the declared type.

However, even when constraints are matched between a declared type and a type extension, it's possible for a constraint to be inferred by the body of an extended member that imposes a different requirement on the type parameter than the declared type. For example:

```fsharp
open System.Collections.Generic

// NOT POSSIBLE AND FAILS TO COMPILE!
//
// The member 'Sum' has a different requirement on 'T than the type IEnumerable<'T>
type IEnumerable<'T> with
    member this.Sum() = Seq.sum this
```

There is no way to get this code to work with an optional type extension:

- As is, the `Sum` member has a different constraint on `'T` (`static member get_Zero` and `static member (+)`) than what the type extension defines.
- Modifying the type extension to have the same constraint as `Sum` will no longer match the defined constraint on `IEnumerable<'T>`.
- Changing `member this.Sum` to `member inline this.Sum` will give an error that type constraints are mismatched.

What is desired are static methods that "float in space" and can be presented as if they're extending a type. This is where extension methods become necessary.

## Extension methods

Finally, extension methods (sometimes called "C# style extension members") can be declared in F# as a static member method on a class.

Extension methods are useful for when you wish to define extensions on a generic type that will constrain the type variable. For example:

```fsharp
namespace Extensions

open System.Runtime.CompilerServices

[<Extension>]
type IEnumerableExtensions() =
    [<Extension>]
    static member inline Sum(xs: IEnumerable<'T>) = Seq.sum xs
```

When used, this code will make it appear as if `Sum` is defined on <xref:System.Collections.Generic.IEnumerable%601>, so long as `Extensions` has been opened or is in scope.

## Other remarks

Type extensions also have the following attributes:

- Any type that can be accessed can be extended.
- Intrinsic and optional type extensions can define _any_ member type, not just methods. So extension properties are also possible, for example.
- The `self-identifier` token in the [syntax](type-extensions.md#syntax) represents the instance of the type being invoked, just like ordinary members.
- Extended members can be static or instance members.
- Type variables on a type extension must match the constraints of the declared type.

The following limitations also exist for type extensions:

- Type extensions do not support virtual or abstract methods.
- Type extensions do not support override methods as augmentations.
- Type extensions do not support [Statically Resolved Type Parameters](./generics/statically-resolved-type-parameters.md).
- Optional Type extensions do not support constructors as augmentations.
- Type extensions cannot be defined on [type abbreviations](type-abbreviations.md).
- Type extensions are not valid for `byref<'T>` (though they can be declared).
- Type extensions are not valid for attributes (though they can be declared).
- You can define extensions that overload other methods of the same name, but the F# compiler gives preference to non-extension methods if there is an ambiguous call.

Finally, if multiple intrinsic type extensions exist for one type, all members must be unique. For optional type extensions, members in different type extensions to the same type can have the same names. Ambiguity errors occur only if client code opens two different scopes that define the same member names.

## See also

- [F# Language Reference](index.md)
- [Members](./members/index.md)
