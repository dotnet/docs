---
title: Namespaces (F#)
description: Namespaces (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ea42156f-e1b9-4535-9383-b45f46f3f7ca
redirect_url: https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/namespaces
---

# Namespaces (F#)

A namespace lets you organize code into areas of related functionality by enabling you to attach a name to a grouping of program elements.


## Syntax

```fsharp
namespace [parent-namespaces.]identifier
```

## Remarks
If you want to put code in a namespace, the first declaration in the file must declare the namespace. The contents of the entire file then become part of the namespace.

Namespaces cannot directly contain values and functions. Instead, values and functions must be included in modules, and modules are included in namespaces. Namespaces can contain types, modules.

Namespaces can be declared explicitly with the namespace keyword, or implicitly when declaring a module. To declare a namespace explicitly, use the namespace keyword followed by the namespace name. The following example shows a code file that declares a namespace Widgets with a type and a module included in that namespace.

[!code-fsharp[Main](snippets/fslangref2/snippet6406.fs)]

If the entire contents of the file are in one module, you can also declare namespaces implicitly by using the `module` keyword and providing the new namespace name in the fully qualified module name. The following example shows a code file that declares a namespace `Widgets` and a module `WidgetsModule`, which contains a function.

[!code-fsharp[Main](snippets/fslangref2/snippet6401.fs)]

The following code is equivalent to the preceding code, but the module is a local module declaration. In that case, the namespace must appear on its own line.

[!code-fsharp[Main](snippets/fsnamespaces/snippet6402.fs)]

If more than one module is required in the same file in one or more namespaces, you must use local module declarations. When you use local module declarations, you cannot use the qualified namespace in the module declarations. The following code shows a file that has a namespace declaration and two local module declarations. In this case, the modules are contained directly in the namespace; there is no implicitly created module that has the same name as the file. Any other code in the file, such as a `do` binding, is in the namespace but not in the inner modules, so you need to qualify the module member `widgetFunction` by using the module name.

[!code-fsharp[Main](snippets/fslangref2/snippet6403.fs)]

The output of this example is as follows.

```fsharp
Module1 10 20
Module2 5 6
```

For more information, see [Modules &#40;F&#35;&#41;](Modules-%5BFSharp%5D.md).

## Nested Namespaces
When you create a nested namespace, you must fully qualify it. Otherwise, you create a new top-level namespace. Indentation is ignored in namespace declarations.

The following example shows how to declare a nested namespace.

[!code-fsharp[Main](snippets/fslangref2/snippet6404.fs)]

## Namespaces in Files and Assemblies
Namespaces can span multiple files in a single project or compilation. The term *namespace fragment* describes the part of a namespace that is included in one file. Namespaces can also span multiple assemblies. For example, the `System` namespace includes the whole .NET Framework, which spans many assemblies and contains many nested namespaces.


## Global Namespace
You use the predefined namespace `global` to put names in the .NET top-level namespace.

[!code-fsharp[Main](snippets/fslangref2/snippet6407.fs)]

You can also use global to reference the top-level .NET namespace, for example, to resolve name conflicts with other namespaces.

[!code-fsharp[Main](snippets/fslangref2/snippet6408.fs)]

## See Also
[F&#35; Language Reference](FSharp-Language-Reference.md)

[Modules &#40;F&#35;&#41;](Modules-%5BFSharp%5D.md)
