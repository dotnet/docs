---
title: Option.bind<'T,'U> Function (F#)
description: Option.bind<'T,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 370ec852-332c-4a8d-8d85-aa0d83f58e08
---

# Option.bind<'T,'U> Function (F#)

Invokes a function on an optional value that itself yields an option.

**Namespace/Module Path**: Microsoft.FSharp.Core.Option

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
bind : ('T -> 'U option) -> 'T option -> 'U option

// Usage:
bind binder option
```

#### Parameters
*binder*
Type: **'T -&gt; 'U**[option](https://msdn.microsoft.com/library/b08add48-34bf-4410-80a1-ef6a8daddc58)


A function that takes the value of type T from an option and transforms it into an option containing a value of type U.


*option*
Type: **'T**[option](https://msdn.microsoft.com/library/b08add48-34bf-4410-80a1-ef6a8daddc58)


The input option.

## Return Value

An option of the output type of the binder.

## Remarks
The expression `Option.bind f inp` evaluates to `match inp with None -> None | Some x -> f x.`

This function is named `Bind` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fsoptions/snippet1.fs)]

**Output**

```
Some "egamI rorriM"<null>
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Option Module &#40;F&#35;&#41;](Core.Option-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
