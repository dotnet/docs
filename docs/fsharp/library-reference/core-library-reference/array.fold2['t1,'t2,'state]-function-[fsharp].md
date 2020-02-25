---
title: Array.fold2<'T1,'T2,'State> Function (F#)
description: Array.fold2<'T1,'T2,'State> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 493ad9c8-9c14-45b4-9689-03ad9b9639b5 
---

# Array.fold2<'T1,'T2,'State> Function (F#)

Applies a function to pairs of elements drawn from the two collections, left-to-right, threading an accumulator argument through the computation. The two input arrays must have the same lengths, otherwise [ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx) is raised.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
Array.fold2 : ('State -> 'T1 -> 'T2 -> 'State) -> 'State -> 'T1 [] -> 'T2 [] -> 'State

// Usage:
Array.fold2 folder state array1 array2
```

#### Parameters
*folder*
Type: **'State -&gt; 'T1 -&gt; 'T2 -&gt; 'State**

The function to update the state given the input elements.

*state*
Type: **'State**

The initial state.

*array1*
Type: **'T1**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The first input array.

*array2*
Type: **'T2**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The second input array.

## Return Value

The final state.

## Remarks
This function is named `Fold2` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code shows how to use `Array.fold2`.

[!code-fsharp[Main](snippets/fsarrays/snippet45.fs)]

**Output**

```
The sum of the greater of each pair of elements in the two arrays is 8.
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)