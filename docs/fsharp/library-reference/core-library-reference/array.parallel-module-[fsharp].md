---
title: Array.Parallel Module (F#)
description: Array.Parallel Module (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: f79592a6-b5f9-4972-a700-51ed689495fb 
---

# Array.Parallel Module (F#)

Provides parallel operations on arrays

**Namespace/Module Path**: Microsoft.FSharp.Collections.Array

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
module Parallel
```

## Remarks

## Values


|Value|Description|
|-----|-----------|
|[choose](https://msdn.microsoft.com/library/2deed2b4-eb4c-4d03-9931-0f5bbb47f1f1)<br />`: ('T -> 'U option) -> 'T [] -> 'U []`|Apply the given function to each element of the array. Return the array comprised of the results `x` for each element where the function returns `Some(x)`.|
|[collect](https://msdn.microsoft.com/library/3787e401-d84e-4521-9d7f-87303753dc7b)<br />`: ('T -> 'U []) -> 'T [] -> 'U []`|For each element of the array, apply the given function. Concatenate all the results and return the combined array.|
|[init](https://msdn.microsoft.com/library/96c71191-2fa4-42fc-9418-80e1a1906fef)<br />`: int -> (int -> 'T) -> 'T []`|Create an array given the dimension and a generator function to compute the elements.|
|[iter](https://msdn.microsoft.com/library/2484b54a-41b7-482e-8931-b528b32ba93e)<br />`: ('T -> unit) -> 'T [] -> unit`|Apply the given function to each element of the array.|
|[iteri](https://msdn.microsoft.com/library/5e777c6f-9b12-4a63-8168-9d7a66205482)<br />`: (int -> 'T -> unit) -> 'T [] -> unit`|Apply the given function to each element of the array. The integer passed to the function indicates the index of element.|
|[map](https://msdn.microsoft.com/library/0485547d-15e9-41ed-a3a6-fb5816413fed)<br />`: ('T -> 'U) -> 'T [] -> 'U []`|Build a new array whose elements are the results of applying the given function to each of the elements of the array.|
|[mapi](https://msdn.microsoft.com/library/994595e4-6886-467e-a6c3-cebc4e621052)<br />`: (int -> 'T -> 'U) -> 'T [] -> 'U []`|Build a new array whose elements are the results of applying the given function to each of the elements of the array. The integer index passed to the function indicates the index of element being transformed.|
|[partition](https://msdn.microsoft.com/library/1981a0bd-8d44-46a2-a3f3-3e5cc7b78fce)<br />`: ('T -> bool) -> 'T [] -> 'T [] * 'T []`|Split the collection into two collections, containing the elements for which the given predicate returns `true` and `false` respectively|

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 4.0

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)