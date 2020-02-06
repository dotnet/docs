---
title: Array.map<'T,'U> Function (F#)
description: Array.map<'T,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 85203d0c-aae3-4559-8db2-9ceb7f68da4b 
---

# Array.map<'T,'U> Function (F#)

Builds a new array whose elements are the results of applying the given function to each of the elements of the array.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.map : ('T -> 'U) -> 'T [] -> 'U []

// Usage:
Array.map mapping array
```

#### Parameters
*mapping*
Type: **'T -&gt; 'U**


The function to transform elements of the array.


*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The input array.

## Return Value

The array of transformed elements.

## Remarks
This function is named `Map` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code example shows how to use `Array.map`.

[!code-fsharp[Main](snippets/fsarrays/snippet510.fs)]

**Output**
```
Adding '1' using map = [|2; 3; 4; 5|]
Converting to strings by using map = [|"1"; "2"; "3"; "4"|]
Converting to tuples by using map = [|(1, 1); (2, 2); (3, 3); (4, 4)|]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)