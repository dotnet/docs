---
title: Array.mapi2<'T1,'T2,'U> Function (F#)
description: Array.mapi2<'T1,'T2,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ec0d66da-62bf-4598-b20e-845c8197c78e 
---

# Array.mapi2<'T1,'T2,'U> Function (F#)

Builds a new collection whose elements are the results of applying the given function to the corresponding elements of the two collections pairwise, also passing the index of the elements. The two input arrays must have the same lengths, otherwise [ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx) is raised.

**Namespace/Module Path**: Microsoft.FSharp.Collections.Array

**Assembly**: FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
Array.mapi2 : (int -> 'T1 -> 'T2 -> 'U) -> 'T1 [] -> 'T2 [] -> 'U []

// Usage:
Array.mapi2 mapping array1 array2
```

#### Parameters
*mapping*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**-&gt; 'T1 -&gt; 'T2 -&gt; 'U**

The function to transform pairs of input elements and their indices.

*array1*
Type: **'T1**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The first input array.

*array2*
Type: **'T2**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The second input array.

## Return Value
Returns the array of transformed elements.

## Remarks
This function is named `MapIndexed2` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code demonstrates the use of `Array.mapi2`.

[!code-fsharp[Main](snippets/fsarrays/snippet54.fs)]

**Output**

```
[|0; 7; 18|]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)