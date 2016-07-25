---
title: Collections.Array4D Module (F#)
description: Collections.Array4D Module (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 676f71e7-0ac9-41f2-9558-9d781c86cdeb 
---

# Collections.Array4D Module (F#)

Basic operations on rank 4 arrays.

**Namespace/Module Path:** Microsoft.FSharp.Collections

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
module Array4D
```

## Remarks

## Values


|Value|Description|
|-----|-----------|
|[create](https://msdn.microsoft.com/library/c146b4b0-2e63-4d00-8451-5d72833ccfdc)<br />**: int -&gt; int -&gt; int -&gt; int -&gt; 'T -&gt; 'T [,,,]**|Creates an array whose elements are all initially the given value|
|[get](https://msdn.microsoft.com/library/d268205c-d77b-4816-8360-57be8e770005)<br />**: 'T [,,,] -&gt; int -&gt; int -&gt; int -&gt; int -&gt; 'T**|Fetches an element from a 4D array.|
|[init](https://msdn.microsoft.com/library/41e8bf42-5a11-4884-8890-a1b194f5f80e)<br />**: int -&gt; int -&gt; int -&gt; int -&gt; (int -&gt; int -&gt; int -&gt; int -&gt; 'T) -&gt; 'T [,,,]**|Creates an array given the dimensions and a generator function to compute the elements.|
|[length1](https://msdn.microsoft.com/library/a864b7e6-7da5-45bf-9b54-ef0f772488f1)<br />**: 'T [,,,] -&gt; int**|Returns the length of an array in the first dimension|
|[length2](https://msdn.microsoft.com/library/2da2dd52-1348-4c70-b64c-299a3d43cda1)<br />**: 'T [,,,] -&gt; int**|Returns the length of an array in the second dimension.|
|[length3](https://msdn.microsoft.com/library/199a6b83-85df-4ed6-9ef9-faa0b4e2ae6d)<br />**: 'T [,,,] -&gt; int**|Returns the length of an array in the third dimension.|
|[length4](https://msdn.microsoft.com/library/f8e138c3-0a87-4b63-86ab-9d286c6b6cff)<br />**: 'T [,,,] -&gt; int**|Returns the length of an array in the fourth dimension.|
|[set](https://msdn.microsoft.com/library/2b72ed80-310c-4b75-9fa4-6cbb13aa7ff4)<br />**: 'T [,,,] -&gt; int -&gt; int -&gt; int -&gt; int -&gt; 'T -&gt; unit**|Sets the value of an element in an array.|
|[zeroCreate](https://msdn.microsoft.com/library/1391be77-5364-4397-a710-c1298e6397bc)<br />**: int -&gt; int -&gt; int -&gt; int -&gt; 'T [,,,]**|Creates an array where the entries are initially the default value.|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)

