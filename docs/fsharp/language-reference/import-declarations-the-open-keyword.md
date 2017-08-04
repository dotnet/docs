---
title: "Import Declarations: The open Keyword (F#)"
description: Learn about F# import declarations and how they specify a module or namespace whose elements you can reference without using a fully qualified name.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: 1e98e48c-52e9-4314-8954-85d5583125f0 
---

# Import Declarations: The `open` Keyword

> [!NOTE]
The API reference links in this article will take you to MSDN.  The docs.microsoft.com API reference is not complete.

An *import declaration* specifies a module or namespace whose elements you can reference without using a fully qualified name.


## Syntax

```fsharp
open module-or-namespace-name
```

## Remarks
Referencing code by using the fully qualified namespace or module path every time can create code that is hard to write, read, and maintain. Instead, you can use the `open` keyword for frequently used modules and namespaces so that when you reference a member of that module or namespace, you can use the short form of the name instead of the fully qualified name. This keyword is similar to the `using` keyword in C#, `using namespace` in Visual C++, and `Imports` in Visual Basic.

The module or namespace provided must be in the same project or in a referenced project or assembly. If it is not, you can add a reference to the project, or use the `-reference` command`-`line option (or its abbreviation, `-r`). For more information, see [Compiler Options](compiler-options.md).

The import declaration makes the names available in the code that follows the declaration, up to the end of the enclosing namespace, module, or file.

When you use multiple import declarations, they should appear on separate lines.

The following code shows the use of the `open` keyword to simplify code.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-2/snippet6801.fs)]

The F# compiler does not emit an error or warning when ambiguities occur when the same name occurs in more than one open module or namespace. When ambiguities occur, F# gives preference to the more recently opened module or namespace. For example, in the following code, `empty` means `Seq.empty`, even though `empty` is located in both the `List` and `Seq` modules.

```fsharp
open List
open Seq
printfn "%A" empty
```

Therefore, be careful when you open modules or namespaces such as `List` or `Seq` that contain members that have identical names; instead, consider using the qualified names. You should avoid any situation in which the code is dependent upon the order of the import declarations.


## Namespaces That Are Open by Default
Some namespaces are so frequently used in F# code that they are opened implicitly without the need of an explicit import declaration. The following table shows the namespaces that are open by default.

|Namespace|Description|
|---------|-----------|
|`Microsoft.FSharp.Core`|Contains basic F# type definitions for built-in types such as `int` and `float`.|
|`Microsoft.FSharp.Core.Operators`|Contains basic arithmetic operations such as `+` and `*`.|
|`Microsoft.FSharp.Collections`|Contains immutable collection classes such as `List` and `Array`.|
|`Microsoft.FSharp.Control`|Contains types for control constructs such as lazy evaluation and asynchronous workflows.|
|`Microsoft.FSharp.Text`|Contains functions for formatted IO, such as the `printf` function.|

## AutoOpen Attribute
You can apply the `AutoOpen` attribute to an assembly if you want to automatically open a namespace or module when the assembly is referenced. You can also apply the `AutoOpen` attribute to a module to automatically open that module when the parent module or namespace is opened. For more information, see [Core.AutoOpenAttribute Class](https://msdn.microsoft.com/visualfsharpdocs/conceptual/core.autoopenattribute-class-%5bfsharp%5d).


## RequireQualifiedAccess Attribute
Some modules, records, or union types may specify the `RequireQualifiedAccess` attribute. When you reference elements of those modules, records, or unions, you must use a qualified name regardless of whether you include an import declaration. If you use this attribute strategically on types that define commonly used names, you help avoid name collisions and thereby make code more resilient to changes in libraries. For more information, see [Core.RequireQualifiedAccessAttribute Class](https://msdn.microsoft.com/visualfsharpdocs/conceptual/core.requirequalifiedaccessattribute-class-%5Bfsharp%5D).


## See Also
[# Language Reference](index.md)

[Namespaces](namespaces.md)

[Modules](modules.md)

