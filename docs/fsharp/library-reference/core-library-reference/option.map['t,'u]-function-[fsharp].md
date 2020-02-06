---
title: Option.map<'T,'U> Function (F#)
description: Option.map<'T,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 8feaeb72-55d1-4584-8dd6-285f7b207b7b
---

# Option.map<'T,'U> Function (F#)

Transforms an option value by using a specified mapping function.

**Namespace/Module Path**: Microsoft.FSharp.Core.Option

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
map : ('T -> 'U) -> 'T option -> 'U option

// Usage:
map mapping option
```

#### Parameters
*mapping*
Type: **'T -&gt; 'U**


A function to apply to the option value.


*option*
Type: **'T**[option](https://msdn.microsoft.com/library/b08add48-34bf-4410-80a1-ef6a8daddc58)


The input option.

## Return Value

An option of the result of applying the mapping function, or `None` if the input is `None`.

## Remarks
The expression `map f inp` evaluates to `match inp with None -> None | Some x -> Some (f x)`.

This function is named `Map` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable, Portable

## See Also
[Core.Option Module &#40;F&#35;&#41;](Core.Option-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
