---
title: Collections.Array3D Module (F#)
description: Collections.Array3D Module (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 728734c4-45c6-487c-ae15-9cdf60e1257e 
---

# Collections.Array3D Module (F#)

Basic operations on rank 3 arrays.

**Namespace/Module Path:** Microsoft.FSharp.Collections

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
module Array3D
```

## Values


|Value|Description|
|-----|-----------|
|[create](https://msdn.microsoft.com/library/ca930a5a-bf9d-4819-ba23-cc6bfb9c4233)<br />**: int -&gt; int -&gt; int -&gt; int -&gt; 'T -&gt; 'T [,,]**|Creates an array whose elements are all initially the given value.|
|[get](https://msdn.microsoft.com/library/c4f024ba-4bb6-492a-aa7d-bfb02576ac6b)<br />**: 'T [,,] -&gt; int -&gt; int -&gt; int -&gt; 'T**|Fetches an element from a 3D array. You can also use the syntax **array.[index1,index2,index3]**.|
|[init](https://msdn.microsoft.com/library/fcd89119-995c-4f28-9e79-7e8b14ca6f08)<br />**: int -&gt; int -&gt; int -&gt; (int -&gt; int -&gt; int -&gt; 'T) -&gt; 'T [,,]**|Creates an array given the dimensions and a generator function to compute the elements.|
|[iter](https://msdn.microsoft.com/library/99b0ab25-8fe7-47a8-a193-6d0dd9b0b630)<br />**: ('T -&gt; unit) -&gt; 'T [,,] -&gt; unit**|Applies the given function to each element of the array.|
|[iteri](https://msdn.microsoft.com/library/c4e1d5ec-7b6e-4aa3-9fab-d1ff443ee867)<br />**: (int -&gt; int -&gt; int -&gt; 'T -&gt; unit) -&gt; 'T [,,] -&gt; unit**|Applies the given function to each element of the array. The integer indices passed to the function indicate the index of element.|
|[length1](https://msdn.microsoft.com/library/6d655ea9-e1d5-49a4-96e7-30c4bb077bc5)<br />**: 'T [,,] -&gt; int**|Returns the length of an array in the first dimension|
|[length2](https://msdn.microsoft.com/library/367b5647-745f-4db8-b586-064622e04d98)<br />**: 'T [,,] -&gt; int**|Returns the length of an array in the second dimension.|
|[length3](https://msdn.microsoft.com/library/4995858d-ba53-4d61-81e0-1f8a553e4ac8)<br />**: 'T [,,] -&gt; int**|Returns the length of an array in the third dimension.|
|[map](https://msdn.microsoft.com/library/01f91430-9fb0-4fa3-bc7f-dbfd004487af)<br />**: ('T -&gt; 'U) -&gt; 'T [,,] -&gt; 'U [,,]**|Builds a new array whose elements are the results of applying the given function to each of the elements of the array.|
|[mapi](https://msdn.microsoft.com/library/99a1673b-524b-408d-ad6d-9179535f2ac6)<br />**: (int -&gt; int -&gt; int -&gt; 'T -&gt; 'U) -&gt; 'T [,,] -&gt; 'U [,,]**|Builds a new array whose elements are the results of applying the given function to each of the elements of the array. The integer indices passed to the function indicate the element being transformed.|
|[set](https://msdn.microsoft.com/library/825c1e6d-b9e0-4b45-8adf-c8fe46fe1d4b)<br />**: 'T [,,] -&gt; int -&gt; int -&gt; int -&gt; 'T -&gt; unit**|Sets the value of an element in an array. You can also use the syntax **array.[index1,index2,index3] &lt;- value**.|
|[zeroCreate](https://msdn.microsoft.com/library/a56ae875-8805-4527-b459-a7a97756ce84)<br />**: int -&gt; int -&gt; int -&gt; 'T [,,]**|Creates an array where the entries are initially the default value.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)

