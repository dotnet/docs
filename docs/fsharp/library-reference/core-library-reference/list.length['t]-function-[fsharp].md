---
title: List.length<'T> Function (F#)
description: List.length<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: e8e2b0ab-9089-4f76-8a0f-8f635130fbe6 
---

# List.length<'T> Function (F#)

Returns the length of the list.

**Namespace/Module Path**: Microsoft.FSharp.Collections.List

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
List.length : 'T list -> int

// Usage:
List.length list
```

#### Parameters
*list*
Type: **'T**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The input list.

## Return Value

The length of the list.

## Remarks

This function is named `Length` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fslists/snippet48.fs)]

**Output**

```
Length: 100
Length: 0
Length: 50
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)