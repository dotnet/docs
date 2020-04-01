---
title: Array.Parallel Module
description: Array.Parallel Module
ms.date: 02/27/2020
---

# Array.Parallel Module

Provides parallel operations on arrays

**Namespace/Module Path**: Microsoft.FSharp.Collections.Array

## Syntax

```fsharp
module Parallel
```

## Remarks

## Values

|Value|Description|
|-----|-----------|
|[choose](parallel.choose['t,'u]-function.md)<br />`: ('T -> 'U option) -> 'T [] -> 'U []`|Apply the given function to each element of the array. Return the array comprised of the results `x` for each element where the function returns `Some(x)`.|
|[collect](parallel.collect['t,'u]-function.md)<br />`: ('T -> 'U []) -> 'T [] -> 'U []`|For each element of the array, apply the given function. Concatenate all the results and return the combined array.|
|[init](parallel.init['t]-function.md)<br />`: int -> (int -> 'T) -> 'T []`|Create an array given the dimension and a generator function to compute the elements.|
|[iter](parallel.iter['t]-function.md)<br />`: ('T -> unit) -> 'T [] -> unit`|Apply the given function to each element of the array.|
|[iteri](parallel.iteri['t]-function.md)<br />`: (int -> 'T -> unit) -> 'T [] -> unit`|Apply the given function to each element of the array. The integer passed to the function indicates the index of element.|
|[map](parallel.map['t,'u]-function.md)<br />`: ('T -> 'U) -> 'T [] -> 'U []`|Build a new array whose elements are the results of applying the given function to each of the elements of the array.|
|[mapi](parallel.mapi['t,'u]-function.md)<br />`: (int -> 'T -> 'U) -> 'T [] -> 'U []`|Build a new array whose elements are the results of applying the given function to each of the elements of the array. The integer index passed to the function indicates the index of element being transformed.|
|[partition](parallel.partition['t]-function.md)<br />`: ('T -> bool) -> 'T [] -> 'T [] * 'T []`|Split the collection into two collections, containing the elements for which the given predicate returns `true` and `false` respectively|

## See Also
[Array Module](../index.md)
