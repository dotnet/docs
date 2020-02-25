---
title: Option.count<'T> Function (F#)
description: Option.count<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: c1692b01-d335-4e0d-bb4c-773fd975c7a9
---

# Option.count<'T> Function (F#)

Evaluates the equivalent of [Set.count](https://msdn.microsoft.com/library/54acc46d-af76-474e-9ff7-bd4bd6b7b4c4) for an option.

**Namespace/Module Path:** Microsoft.FSharp.Core.Option

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
count : 'T option -> int

// Usage:
count option
```

#### Parameters
*option*
Type: **'T**[option](https://msdn.microsoft.com/library/b08add48-34bf-4410-80a1-ef6a8daddc58)


The input option.

## Return Value

A zero if the option is `None`, a one otherwise.

## Remarks

The expression `count inp` evaluates to `match inp with None -> 0 | Some _ -> 1`.

This function is named `Count` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fsoptions/snippet2.fs)]

**Output**

```
1 035
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Core.Option Module &#40;F&#35;&#41;](Core.Option-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Core Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core-Namespace-%5BFSharp%5D.md)
