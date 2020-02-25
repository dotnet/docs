---
title: Array.tryPick<'T,'U> Function (F#)
description: Array.tryPick<'T,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: b4ae71a0-232e-43eb-a23d-87f6fbc33a03 
---

# Array.tryPick<'T,'U> Function (F#)

Applies the given function to successive elements, returning the first result where function returns `Some`. If the function does not return `Some` for any element, then `None` is returned.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.tryPick : ('T -> 'U option) -> 'T [] -> 'U option

// Usage:
Array.tryPick chooser array
```

#### Parameters
*chooser*
Type: **'T -&gt; 'U option**


The function to transform the array elements into options.


*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The input array.


## Return Value

The first transformed element that has an option value of `Some`, or `None` if the function does not return `Some` for any element.

## Remarks
This function is named `TryPick` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following example demonstrates the use of `Array.tryPick` to attempt to locate an element that satisfies a condition, and also return some additional data about the element, in this case the square root and the cube root.

[!code-fsharp[Main](snippets/fsarrays/snippet27.fs)]

```
Found an element 1 with square root 1 and cube root 1.
Found an element 64 with square root 8 and cube root 4.
Found an element 729 with square root 27 and cube root 9.
Found an element 4096 with square root 64 and cube root 16.
Did not find an element that is both a perfect square and a perfect cube.
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)