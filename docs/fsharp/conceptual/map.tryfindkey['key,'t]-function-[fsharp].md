---
title: Map.tryFindKey<'Key,'T> Function (F#)
description: Map.tryFindKey<'Key,'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 131dcc8e-eaec-406b-b75f-76f002b92d39
---

# Map.tryFindKey<'Key,'T> Function (F#)

Returns the key of the first mapping in the collection that satisfies the given predicate, or returns `None` if no such element exists.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Map

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Map.tryFindKey : ('Key -> 'T -> bool) -> Map<'Key,'T> -> 'Key option (requires comparison)

// Usage:
Map.tryFindKey predicate table
```

#### Parameters
*predicate*
Type: **'Key -&gt; 'T -&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


The function to test the input elements.


*table*
Type: [Map](https://msdn.microsoft.com/library/975316ea-55e3-4987-9994-90897ad45664)**&lt;'Key,'T&gt;**


The input map.

## Return Value

The first key for which the predicate returns `true` or `None` if the predicate evaluates to `false` for each key/value pair.

## Remarks
This function is named `TryFindKey` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fsmaps/snippet17.fs)]

**Output**

```
Found element with key 1.
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Map Module &#40;F&#35;&#41;](Collections.Map-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
