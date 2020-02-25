---
title: Array.iteri<'T> Function (F#)
description: Array.iteri<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: cc1636c6-296e-492c-a497-8d4439c32107 
---

# Array.iteri<'T> Function (F#)

Applies the given function to each element of the array. The integer passed to the function indicates the index of element.

**Namespace/Module Path**: Microsoft.FSharp.Collections.Array

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.iteri : (int -> 'T -> unit) -> 'T [] -> unit

// Usage:
Array.iteri action array
```

#### Parameters
*action*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**-&gt; 'T -&gt;**[unit](https://msdn.microsoft.com/library/00b837c2-6c8a-483a-87d3-0479c64037a7)

The function to apply to each index and element.

*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The input array.

## Remarks
This function is named `IterateIndexed` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example
The following code examples shows the differences between [`Array.iter`](https://msdn.microsoft.com/library/94eba0f1-ecd7-459f-b89f-ed2a2923e516), [`Array.iter2`](https://msdn.microsoft.com/library/018aa9b9-f186-4142-be8a-a62462794fdc), `Array.iteri`, and [`Array.iteri2`](https://msdn.microsoft.com/library/c041b91f-6080-45b7-867b-2ed983a90405).

[!code-fsharp[Main](snippets/fsarrays/snippet49.fs)]

**Output**

```
Array.iter: element is 1
Array.iter: element is 2
Array.iter: element is 3
Array.iteri: element 0 is 1
Array.iteri: element 1 is 2
Array.iteri: element 2 is 3
Array.iter2: elements are 1 4
Array.iter2: elements are 2 5
Array.iter2: elements are 3 6
Array.iteri2: element 0 of array1 is 1 element 0 of array2 is 4
Array.iteri2: element 1 of array1 is 2 element 1 of array2 is 5
Array.iteri2: element 2 of array1 is 3 element 2 of array2 is 6
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)