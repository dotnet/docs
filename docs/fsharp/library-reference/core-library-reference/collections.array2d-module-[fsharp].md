---
title: Collections.Array2D Module (F#)
description: Collections.Array2D Module (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: d8ece5ed-4d80-47e5-a68a-ca330b262141 
---

# Collections.Array2D Module (F#)

Basic operations on 2-dimensional arrays.

**Namespace/Module Path:** Microsoft.FSharp.Collections

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
module Array2D
```

## Remarks
F# and CLI multi-dimensional arrays are typically zero-based. However, CLI multi-dimensional arrays used in conjunction with external libraries (for examples, libraries associated with Visual Basic) be non-zero based, using a potentially different base for each dimension. The operations in this module will accept such arrays, and the basing on an input array will be propagated to a matching output array on the [`Array2D.map`](https://msdn.microsoft.com/library/9e0c7271-62af-4eb4-a146-1c6a1bb56294) and [Array2D.mapi](https://msdn.microsoft.com/library/a16e3775-2ebb-41bb-9fa0-212bcd7830ac) operations. Non-zero-based arrays can also be created using [`Array2D.zeroCreateBased`](https://msdn.microsoft.com/library/5b67f6b5-1dc4-4952-a8cf-241f3cc95124), [`Array2D.createBased`](https://msdn.microsoft.com/library/673f61c6-3b1c-425a-b847-7e236a03651f) and [Array2D.initBased](https://msdn.microsoft.com/library/546194f1-965f-47b9-afd8-77422e4e2d5d).


## Values


|Value|Description|
|-----|-----------|
|[base1](https://msdn.microsoft.com/library/e485c1ca-f1aa-490c-95ed-b7cac0597878)<br />**: 'T [,] -&gt; int**|Fetches the base-index for the first dimension of the array.|
|[base2](https://msdn.microsoft.com/library/4640beaa-a189-44a8-9d43-461916418bf8)<br />**: 'T [,] -&gt; int**|Fetches the base-index for the second dimension of the array.|
|[blit](https://msdn.microsoft.com/library/c1f7709d-3276-4e5f-b1b1-8dfc7de8c5f5)<br />**: 'T [,] -&gt; int -&gt; int -&gt; 'T[,] -&gt; int -&gt; int -&gt; int -&gt; int -&gt; unit**|Reads a range of elements from the first array and writes them into the second.|
|[copy](https://msdn.microsoft.com/library/369872d9-90ef-4a18-b389-ceda283e07ae)<br />**: 'T [,] -&gt; 'T [,]**|Creates a new array whose elements are the same as the input array.|
|[create](https://msdn.microsoft.com/library/36c9d980-b241-4a20-bc64-bcfa0205d804)<br />**: int -&gt; int -&gt; 'T -&gt; 'T [,]**|Creates an array whose elements are all initially the given value.|
|[createBased](https://msdn.microsoft.com/library/673f61c6-3b1c-425a-b847-7e236a03651f)<br />**: int -&gt; int -&gt; int -&gt; int -&gt; 'T -&gt; 'T [,]**|Creates a based array whose elements are all initially the given value.|
|[get](https://msdn.microsoft.com/library/fa3adca1-4a34-4873-912b-28858042780b)<br />**: 'T [,] -&gt; int -&gt; int -&gt; 'T**|Fetches an element from a 2D array. You can also use the syntax **array.[index1,index2]**.|
|[init](https://msdn.microsoft.com/library/9de07e95-bc21-4927-b5b4-08fdec882c7b)<br />**: int -&gt; int -&gt; (int -&gt; int -&gt; 'T) -&gt; 'T [,]**|Creates an array given the dimensions and a generator function to compute the elements.|
|[initBased](https://msdn.microsoft.com/library/546194f1-965f-47b9-afd8-77422e4e2d5d)<br />**: int -&gt; int -&gt; int -&gt; int -&gt; (int -&gt; int -&gt; 'T) -&gt; 'T [,]**|Creates a based array given the dimensions and a generator function to compute the elements.|
|[iter](https://msdn.microsoft.com/library/212385f9-a8f2-4301-ae64-a8f312be12ee)<br />**: ('T -&gt; unit) -&gt; 'T [,] -&gt; unit**|Applies the given function to each element of the array.|
|[iteri](https://msdn.microsoft.com/library/69cd5883-f551-4afd-9a67-63ee13b3d24d)<br />**: int -&gt; int -&gt; 'T -&gt; unit**|Applies the given function to each element of the array. The integer indices passed to the function indicate the index of element.|
|[length1](https://msdn.microsoft.com/library/f381c958-fc7d-4a5c-9f1b-d1223ee79346)<br />**: 'T [,] -&gt; int**|Returns the length of an array in the first dimension.|
|[length2](https://msdn.microsoft.com/library/95260501-3e51-41e2-903f-4b892a682b55)<br />**: 'T [,] -&gt; int**|Returns the length of an array in the second dimension.|
|[map](https://msdn.microsoft.com/library/9e0c7271-62af-4eb4-a146-1c6a1bb56294)<br />**: ('T -&gt; 'U) -&gt; 'T [,] -&gt; 'U [,]**|Creates a new array whose elements are the results of applying the given function to each of the elements of the array.|
|[mapi](https://msdn.microsoft.com/library/a16e3775-2ebb-41bb-9fa0-212bcd7830ac)<br />**: (int -&gt; int -&gt; 'T -&gt; 'U) -&gt; 'T [,] -&gt; 'U [,]**|Creates a new array whose elements are the results of applying the given function to each of the elements of the array. The integer indices passed to the function indicate the element being transformed.|
|[rebase](https://msdn.microsoft.com/library/5fc9b6f1-ef54-49bc-aa70-17624490a53d)<br />**: 'T [,] -&gt; 'T [,]**|Creates a new array whose elements are the same as the input array but where a non-zero-based input array generates a corresponding zero-based output array.|
|[set](https://msdn.microsoft.com/library/c1378409-b257-4833-9a1b-322b618912f1)<br />**: 'T [,] -&gt; int -&gt; int -&gt; 'T -&gt; unit**|Sets the value of an element in an array. You can also use the syntax **array.[index1,index2] &lt;- value**.|
|[zeroCreate](https://msdn.microsoft.com/library/70384332-e76f-416f-9631-e0c1676528de)<br />**: int -&gt; int -&gt; 'T [,]**|Creates an array where the entries are initially [Unchecked.defaultof&lt;'T&gt;](https://msdn.microsoft.com/library/9ff97f2a-1bd4-4f4c-afbe-5886a74ab977).|
|[zeroCreateBased](https://msdn.microsoft.com/library/5b67f6b5-1dc4-4952-a8cf-241f3cc95124)<br />**: int -&gt; int -&gt; int -&gt; int -&gt; 'T [,]**|Creates a based array where the entries are initially [Unchecked.defaultof&lt;'T&gt;](https://msdn.microsoft.com/library/9ff97f2a-1bd4-4f4c-afbe-5886a74ab977).|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)

