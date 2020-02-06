---
title: Map.add<'Key,'T> Function (F#)
description: Map.add<'Key,'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 79958b34-af76-4dd4-941e-85ecc56c251c 
---

# Map.add<'Key,'T> Function (F#)

Returns a new map from a given map, with an additional or replaced binding.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Map

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Map.add : 'Key -> 'T -> Map<'Key,'T> -> Map<'Key,'T> (requires comparison)

// Usage:
Map.add key value table
```

#### Parameters
*key*
Type: **'Key**

The input key.


*value*
Type: **'T**

The input value.


*table*
Type: [Map](https://msdn.microsoft.com/library/975316ea-55e3-4987-9994-90897ad45664)**&lt;'Key,'T&gt;**

The input map.


## Return Value

The resulting map, in which the given key maps to the given value. If the key of the newly added key-value pair is present in *table*, the newly added pair replaces the old pair in the resulting map.


## Remarks

This function is named `Add` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.


## Example

[!code-fsharp[Main](snippets/fsmaps/snippet1.fs)]

**Output**

```
key: 0 value: zero
key: 1 value: one
key: 2 value: twice
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Map Module &#40;F&#35;&#41;](Collections.Map-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)