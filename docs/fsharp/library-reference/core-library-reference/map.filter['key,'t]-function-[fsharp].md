---
title: Map.filter<'Key,'T> Function (F#)
description: Map.filter<'Key,'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: d78c4426-6423-4275-9136-2cfa96770bee
---

# Map.filter<'Key,'T> Function (F#)

Creates a new map containing only the bindings for which the given predicate returns `true`.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Map

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Map.filter : ('Key -> 'T -> bool) -> Map<'Key,'T> -> Map<'Key,'T> (requires comparison)

// Usage:
Map.filter predicate table
```

#### Parameters
*predicate*
Type: **'Key -&gt; 'T -&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


The function to test the key/value pairs.


*table*
Type: [Map](https://msdn.microsoft.com/library/975316ea-55e3-4987-9994-90897ad45664)**&lt;'Key,'T&gt;**


The input map.

## Return Value

The filtered map.

## Remarks
This function is named `Filter` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fsmaps/snippet5.fs)]

**Output**

```
Even numbers and their squares.
(2, 4) (4, 16) (6, 36) (8, 64) (10, 100)
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Map Module &#40;F&#35;&#41;](Collections.Map-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
