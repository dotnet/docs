---
title: Array.reduce<'T> Function (F#)
description: Array.reduce<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 3be190a5-251c-4286-bd19-c6af6c5171e4 
---

# Array.reduce<'T> Function (F#)

Applies a function to each element of the array, threading an accumulator argument through the computation. If the input function is **f** and the elements are **i0...iN**, then computes **f (... (f i0 i1)...) iN**. Raises **System.ArgumentException** if the array has size zero.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
Array.reduce : ('T -> 'T -> 'T) -> 'T [] -> 'T

// Usage:
Array.reduce reduction array
```

#### Parameters
*reduction*
Type: **'T -&gt; 'T -&gt; 'T**

The function to reduce a pair of elements to a single element.

*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The input array.

## Return Value

Returns the final result of the reductions.

## Remarks
This function is named `Reduce` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following example demonstrates the use of `Array.reduce`.

[!code-fsharp[Main](snippets/fssamples101/snippet1006.fs)]

**Output**

```
sentence = A man landed on the moon
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)