---
title: Map.partition<'Key,'T> Function (F#)
description: Map.partition<'Key,'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 434e9468-4884-4041-bf97-f23682041cae
---

# Map.partition<'Key,'T> Function (F#)

Creates two new maps, one containing the bindings for which the given predicate returns `true`, and the other the remaining bindings.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Map

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Map.partition : ('Key -> 'T -> bool) -> Map<'Key,'T> -> Map<'Key,'T> * Map<'Key,'T> (requires comparison)

// Usage:
Map.partition predicate table
```

#### Parameters
*predicate*
Type: **'Key -&gt; 'T -&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


The function to test the input elements.


*table*
Type: [Map](https://msdn.microsoft.com/library/975316ea-55e3-4987-9994-90897ad45664)**&lt;'Key,'T&gt;**


The input map.

## Return Value

A pair of maps in which the first contains the elements for which the predicate returned `true` and the second containing the elements for which the predicated returned `false`.

## Remarks
This function is named `Partition` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fsmaps/snippet13.fs)]

**Output**

```
Evens: map [(2, 4); (4, 16); (6, 36); (8, 64); (10, 100)]
Odds: map [(1, 1); (3, 9); (5, 25); (7, 49); (9, 81)]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Map Module &#40;F&#35;&#41;](Collections.Map-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
