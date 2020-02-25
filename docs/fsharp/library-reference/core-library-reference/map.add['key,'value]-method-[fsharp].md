---
title: Map.Add<'Key,'Value> Method (F#)
description: Map.Add<'Key,'Value> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: f85baaff-bcd7-464b-959f-f5b502e9cebb 
---

# Map.Add<'Key,'Value> Method (F#)

Returns a new map from a given map, with an additional or replaced binding.

**Namespace/Module Path:** Microsoft.FSharp.Collections

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.Add : 'Key * 'Value -> Map<'Key, 'Value> (requires comparison)

// Usage:
map.Add (key, value)
```

#### Parameters
*key*
Type: **'Key**

The input key.


*value*
Type: **'Value**

The input value.


## Return Value

The resulting map, in which the given key maps to the given value. If the key of the newly added key-value pair is present in the map this method was called on, the newly added pair replaces the old pair in the resulting map.


## Example

[!code-fsharp[Main](snippets/fsmaps/snippet2.fs)]

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
[Collections.Map&#60;'Key,'Value&#62; Class &#40;F&#35;&#41;](Collections.Map%5B%27Key%2C%27Value%5D-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)