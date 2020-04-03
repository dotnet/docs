---
title: Collections.Array4D Module (F#)
description: Collections.Array4D Module (F#)
ms.date: 4/3/2020
---

# Collections.Array4D Module (F#)

Basic operations on rank 4 arrays.

## Syntax

```fsharp
module Array4D
```

## Values

|Value|Signature|Description|
|-----|---------|-----------|
|[create](array4d.create['t]-function.md)|`int -> int -> int -> int -> 'T -> 'T [,,,]`|Creates an array whose elements are all initially the given value|
|[get](array4d.get['t]-function.md)|`'T [,,,] -> int -> int -> int -> int -> 'T`|Fetches an element from a 4D array.|
|[init](array4d.init['t]-function.md)|`int -> int -> int -> int -> (int -> int -> int -> int -> 'T) -> 'T [,,,]`|Creates an array given the dimensions and a generator function to compute the elements.|
|[length1](array4d.length1['t]-function.md)|`'T [,,,] -> int`|Returns the length of an array in the first dimension|
|[length2](array4d.length2['t]-function.md)|`'T [,,,] -> int`|Returns the length of an array in the second dimension.|
|[length3](array4d.length3['t]-function.md)|`'T [,,,] -> int`|Returns the length of an array in the third dimension.|
|[length4](array4d.length4['t]-function.md)|`'T [,,,] -> int`|Returns the length of an array in the fourth dimension.|
|[set](array4d.set['t]-function.md)|`'T [,,,] -> int -> int -> int -> int -> 'T -> unit`|Sets the value of an element in an array.|
|[zeroCreate](array4d.zerocreate['t]-function.md)|`int -> int -> int -> int -> 'T [,,,]`|Creates an array where the entries are initially the default value.|

## See Also
[Microsoft.FSharp.Collections Namespace](Microsoft.FSharp.Collections-Namespace.md)

