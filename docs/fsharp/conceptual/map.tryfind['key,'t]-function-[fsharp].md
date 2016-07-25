---
title: Map.tryFind<'Key,'T> Function (F#)
description: Map.tryFind<'Key,'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: e4429b48-32e8-488a-bcf3-5e1e9636efb8
---

# Map.tryFind<'Key,'T> Function (F#)

Looks up an element in the map, returning a `Some` value if the element is in the domain of the map and `None` if not.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Map

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Map.tryFind : 'Key -> Map<'Key,'T> -> 'T option (requires comparison)

// Usage:
Map.tryFind key table
```

#### Parameters
*key*
Type: **'Key**


The input key.


*table*
Type: [Map](https://msdn.microsoft.com/library/975316ea-55e3-4987-9994-90897ad45664)**&lt;'Key,'T&gt;**


The input map.

## Return Value

The found `Some` value or None.

## Remarks
This function is named `TryFind` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fsmaps/snippet15.fs)]

**Output**

```
Found 2500.
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Map Module &#40;F&#35;&#41;](Collections.Map-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
