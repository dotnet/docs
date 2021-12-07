---
title: Namespaces in F#
titleSuffix: ""
description: Learn how an F# namespace allows you to organize code into areas of related functionality by enabling you to attach a name to a grouping of program elements.
ms.date: 12/08/2018
---
# Namespaces (F#)

A namespace lets you organize code into areas of related functionality by enabling you to attach a name to a grouping of F# program elements. Namespaces are typically top-level elements in F# files.

## Syntax

```fsharp
namespace [rec] [parent-namespaces.]identifier
```

## Remarks

If you want to put code in a namespace, the first declaration in the file must declare the namespace. The contents of the entire file then become part of the namespace, provided no other namespaces declaration exists further in the file. If that is the case, then all code up until the next namespace declaration is considered to be within the first namespace.

Namespaces cannot directly contain values and functions. Instead, values and functions must be included in modules, and modules are included in namespaces. Namespaces can contain types, modules.

XML doc comments can be declared above a namespace, but they're ignored. Compiler directives can also be declared above a namespace.

Namespaces can be declared explicitly with the namespace keyword, or implicitly when declaring a module. To declare a namespace explicitly, use the namespace keyword followed by the namespace name. The following example shows a code file that declares a namespace `Widgets` with a type and a module included in that namespace.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-2/snippet6406.fs)]

If the entire contents of the file are in one module, you can also declare namespaces implicitly by using the `module` keyword and providing the new namespace name in the fully qualified module name. The following example shows a code file that declares a namespace `Widgets` and a module `WidgetsModule`, which contains a function.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-2/snippet6401.fs)]

The following code is equivalent to the preceding code, but the module is a local module declaration. In that case, the namespace must appear on its own line.

[!code-fsharp[Main](~/samples/snippets/fsharp/namespaces/snippet6402.fs)]

If more than one module is required in the same file in one or more namespaces, you must use local module declarations. When you use local module declarations, you cannot use the qualified namespace in the module declarations. The following code shows a file that has a namespace declaration and two local module declarations. In this case, the modules are contained directly in the namespace; there is no implicitly created module that has the same name as the file. Any other code in the file, such as a `do` binding, is in the namespace but not in the inner modules, so you need to qualify the module member `widgetFunction` by using the module name.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-2/snippet6403.fs)]

The output of this example is as follows.

```fsharp
Module1 10 20
Module2 5 6
```

For more information, see [Modules](modules.md).

## Nested Namespaces

When you create a nested namespace, you must fully qualify it. Otherwise, you create a new top-level namespace. Indentation is ignored in namespace declarations.

The following example shows how to declare a nested namespace.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-2/snippet6404.fs)]

## Namespaces in Files and Assemblies

Namespaces can span multiple files in a single project or compilation. The term *namespace fragment* describes the part of a namespace that is included in one file. Namespaces can also span multiple assemblies. For example, the `System` namespace includes the whole .NET Framework, which spans many assemblies and contains many nested namespaces.

## Global Namespace

You use the predefined namespace `global` to put names in the .NET top-level namespace.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-2/snippet6407.fs)]

You can also use global to reference the top-level .NET namespace, for example, to resolve name conflicts with other namespaces.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-2/snippet6408.fs)]

## Recursive namespaces

Namespaces can also be declared as recursive to allow for all contained code to be mutually recursive.  This is done via `namespace rec`. Use of `namespace rec` can alleviate some pains in not being able to write mutually referential code between types and modules. The following is an example of this:

```fsharp
namespace rec MutualReferences

type Orientation = Up | Down
type PeelState = Peeled | Unpeeled

// This exception depends on the type below.
exception DontSqueezeTheBananaException of Banana

type Banana(orientation : Orientation) =
    member val IsPeeled = false with get, set
    member val Orientation = orientation with get, set
    member val Sides: PeelState list = [ Unpeeled; Unpeeled; Unpeeled; Unpeeled] with get, set

    member self.Peel() = BananaHelpers.peel self // Note the dependency on the BananaHelpers module.
    member self.SqueezeJuiceOut() = raise (DontSqueezeTheBananaException self) // This member depends on the exception above.

module BananaHelpers =
    let peel (b: Banana) =
        let flip (banana: Banana) =
            match banana.Orientation with
            | Up ->
                banana.Orientation <- Down
                banana
            | Down -> banana

        let peelSides (banana: Banana) =
            banana.Sides
            |> List.map (function
                         | Unpeeled -> Peeled
                         | Peeled -> Peeled)

        match b.Orientation with
        | Up ->   b |> flip |> peelSides
        | Down -> b |> peelSides
```

Note that the exception `DontSqueezeTheBananaException` and the class `Banana` both refer to each other.  Additionally, the module `BananaHelpers` and the class `Banana` also refer to each other. This wouldn't be possible to express in F# if you removed the `rec` keyword from the `MutualReferences` namespace.

This feature is also available for top-level [Modules](modules.md).

## See also

- [F# Language Reference](index.md)
- [Modules](modules.md)
- [F# RFC FS-1009 - Allow mutually referential types and modules over larger scopes within files](https://github.com/fsharp/fslang-design/blob/main/FSharp-4.1/FS-1009-mutually-referential-types-and-modules-single-scope.md)
