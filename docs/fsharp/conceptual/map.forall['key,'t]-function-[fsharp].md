---
title: Map.forall<'Key,'T> Function (F#)
description: Map.forall<'Key,'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 211b6e5d-cb8f-46a7-a0e6-5c5ad982b953
---

# Map.forall<'Key,'T> Function (F#)

Returns `true` if the given predicate returns `true` for all of the bindings in the map.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Map

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Map.forall : ('Key -> 'T -> bool) -> Map<'Key,'T> -> bool (requires comparison)

// Usage:
Map.forall predicate table
```

#### Parameters
*predicate*
Type: **'Key -&gt; 'T -&gt;**[bool](https://msdn.microsoft.com/library/89c0cf9c-49ce-4207-a3be-555851a67dd5)


The function to test the input elements.


*table*
Type: [Map](https://msdn.microsoft.com/library/975316ea-55e3-4987-9994-90897ad45664)**&lt;'Key,'T&gt;**


The input map.

## Return Value

`true` if the predicate evaluates to true for all of the bindings in the map.

## Remarks
This function is named `ForAll` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fsmaps/snippet11.fs)]

**Output**

```
true false
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Map Module &#40;F&#35;&#41;](Collections.Map-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
