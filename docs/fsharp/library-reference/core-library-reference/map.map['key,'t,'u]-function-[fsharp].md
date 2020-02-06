---
title: Map.map<'Key,'T,'U> Function (F#)
description: Map.map<'Key,'T,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 306e8312-a8ab-4cc3-8101-8a860f025345
---

# Map.map<'Key,'T,'U> Function (F#)

Creates a new collection whose elements are the results of applying the given function to each of the elements of the collection. The key passed to the function indicates the key of element being transformed.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Map

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Map.map : ('Key -> 'T -> 'U) -> Map<'Key,'T> -> Map<'Key,'U> (requires comparison)

// Usage:
Map.map mapping table
```

#### Parameters
*mapping*
Type: **'Key -&gt; 'T -&gt; 'U**


The function to transform the key/value pairs.


*table*
Type: [Map](https://msdn.microsoft.com/library/975316ea-55e3-4987-9994-90897ad45664)**&lt;'Key,'T&gt;**


The input map.

## Return Value

The resulting map of keys and transformed values.

## Remarks
This function is named `Map` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fsmaps/snippet12.fs)]

**Output**

```
map [(1, "One"); (2, "Two"); (3, "Three")]
map [(1, "ONE"); (2, "TWO"); (3, "THREE")]
map [(1, "one"); (2, "two"); (3, "three")]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Map Module &#40;F&#35;&#41;](Collections.Map-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
