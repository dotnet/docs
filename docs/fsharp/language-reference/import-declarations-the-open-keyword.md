---
title: "open Declarations"
description: Learn about F# open declarations and how they specify a module, namespace, or type whose elements you can reference without using a fully qualified name.
ms.date: 11/04/2021
---
# Import declarations: The `open` keyword

An *import declaration* specifies a module or namespace whose elements you can reference without using a fully qualified name.

## Syntax

```fsharp
open module-or-namespace-name
open type type-name
```

## Remarks

Referencing code by using the fully qualified namespace or module path every time can create code that is hard to write, read, and maintain. Instead, you can use the `open` keyword for frequently used modules and namespaces so that when you reference a member of that module or namespace, you can use the short form of the name instead of the fully qualified name. This keyword is similar to the `using` keyword in C#, `using namespace` in Visual C++, and `Imports` in Visual Basic.

The module or namespace provided must be in the same project or in a referenced project or assembly. If it is not, you can add a reference to the project, or use the `-reference` command-line option (or its abbreviation, `-r`). For more information, see [Compiler Options](compiler-options.md).

The import declaration makes the names available in the code that follows the declaration, up to the end of the enclosing namespace, module, or file.

When you use multiple import declarations, they should appear on separate lines.

The following code shows the use of the `open` keyword to simplify code.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-2/snippet6801.fs)]

The F# compiler does not emit an error or warning when ambiguities occur when the same name occurs in more than one open module or namespace. When ambiguities occur, F# gives preference to the more recently opened module or namespace. For example, in the following code, `empty` means `Seq.empty`, even though `empty` is located in both the `List` and `Seq` modules.

```fsharp
open List
open Seq
printfn %"{empty}"
```

Therefore, be careful when you open modules or namespaces such as `List` or `Seq` that contain members that have identical names; instead, consider using the qualified names. You should avoid any situation in which the code is dependent upon the order of the import declarations.

## Open type declarations

F# supports `open` on a type like so:

```fsharp
open type System.Math
PI
```

This will expose all accessible static fields and members on the type.

You can also `open` F#-defined [record](records.md) and [discriminated union](discriminated-unions.md) types to expose static members. In the case of discriminated unions, you can also expose the union cases. This can be helpful for accessing union cases in a type declared inside of a module that you may not want to open, like so:

```fsharp
module M =
    type DU = A | B | C

    let someOtherFunction x = x + 1

// Open only the type inside the module
open type M.DU

printfn "%A" A
```

## Namespaces That Are Open by Default

Some namespaces are so frequently used in F# code that they are opened implicitly without the need of an explicit import declaration. The following table shows the namespaces that are open by default.

|Namespace|Description|
|---------|-----------|
|`FSharp.Core`|Contains basic F# type definitions for built-in types such as `int` and `float`.|
|`FSharp.Core.Operators`|Contains basic arithmetic operations such as `+` and `*`.|
|`FSharp.Collections`|Contains immutable collection classes such as `List` and `Array`.|
|`FSharp.Control`|Contains types for control constructs such as lazy evaluation and async expressions.|
|`FSharp.Text`|Contains functions for formatted IO, such as the `printf` function.|

## AutoOpen Attribute

You can apply the `AutoOpen` attribute to an assembly if you want to automatically open a namespace or module when the assembly is referenced. You can also apply the `AutoOpen` attribute to a module to automatically open that module when the parent module or namespace is opened. For more information, see [AutoOpenAttribute](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-autoopenattribute.html).

## RequireQualifiedAccess Attribute

Some modules, records, or union types may specify the `RequireQualifiedAccess` attribute. When you reference elements of those modules, records, or unions, you must use a qualified name regardless of whether you include an import declaration. If you use this attribute strategically on types that define commonly used names, you help avoid name collisions and thereby make code more resilient to changes in libraries. For more information, see [RequireQualifiedAccessAttribute](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-requirequalifiedaccessattribute.html).

## See also

- [F# Language Reference](index.md)
- [Namespaces](namespaces.md)
- [Modules](modules.md)
