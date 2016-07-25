---
title: Array.mapi<'T,'U> Function (F#)
description: Array.mapi<'T,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 84de1baa-d7b3-42c0-a2e1-a89abf4cdb0f 
---

# Array.mapi<'T,'U> Function (F#)

Builds a new array whose elements are the results of applying the given function to each of the elements of the array. The integer index passed to the function indicates the index of element being transformed.

**Namespace/Module Path**: Microsoft.FSharp.Collections.Array

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.mapi : (int -> 'T -> 'U) -> 'T [] -> 'U []

// Usage:
Array.mapi mapping array
```

#### Parameters
*mapping*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**-&gt; 'T -&gt; 'U**


The function to transform elements and their indices.


*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The input array.

## Return Value

The array of transformed elements.

## Remarks
This function is named `MapIndexed` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code demonstrates the use of `Array.mapi`.

[!code-fsharp[Main](snippets/fsarrays/snippet53.fs)]

**Output**

```
[|(0, 1); (1, 2); (2, 3)|]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)