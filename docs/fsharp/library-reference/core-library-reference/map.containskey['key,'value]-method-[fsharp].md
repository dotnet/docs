---
title: Map.ContainsKey<'Key,'Value> Method (F#)
description: Map.ContainsKey<'Key,'Value> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 035571ba-5194-4463-b91e-724cf67bdcf9
---

# Map.ContainsKey<'Key,'Value> Method (F#)

Tests if an element is in the domain of the map.

**Namespace/Module Path:** Microsoft.FSharp.Collections

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
member this.ContainsKey : 'Key -> bool (requires comparison)

// Usage:
map.ContainsKey (key)
```

#### Parameters
*key*
Type: **'Key**


The input key.

## Return Value

`true` if the map contains the given key.

## Example

[!code-fsharp[Main](snippets/fsmaps/snippet4.fs)]

**Output**

```
The specified map contains the key 1.
The specified map does not contain the key 0.
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Map&#60;'Key,'Value&#62; Class &#40;F&#35;&#41;](Collections.Map%5B%27Key%2C%27Value%5D-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
