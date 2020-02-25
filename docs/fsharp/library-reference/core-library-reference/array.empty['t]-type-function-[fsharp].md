---
title: Array.empty<'T> Type Function (F#)
description: Array.empty<'T> Type Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: dc605def-d750-40db-90b0-bebaf53a3bff 
---

# Array.empty<'T> Type Function (F#)

Returns an empty array of the given type.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.empty<'T> :  'T []

// Usage:
Array.empty
```

## Return Value

An empty array.

## Remarks
This function is named `Empty` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.

## Example

The following code shows how to use `Array.empty`.

[!code-fsharp[Main](snippets/fsarrays/snippet44.fs)]

**Output**

```
Length of empty array: 0
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)