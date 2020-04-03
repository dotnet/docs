---
title: Collections.Array3D Module (F#)
description: Collections.Array3D Module (F#)index.md
ms.assetid: 728734c4-45c6-487c-ae15-9cdf60e1257e 
---

# Collections.Array3D Module (F#)

Basic operations on rank 3 arrays.

## Syntax

```fsharp
module Array3D
```

## Values

|Value|signature|Description|
|-----|---------|-----------|
|[create](array3d.create['t]-function.md)|`int -> int -> int -> int -> 'T -> 'T [,,]`|Creates an array whose elements are all initially the given value.|
|[get](array3d.get['t]-function.md)|`'T [,,] -> int -> int -> int -> 'T`|Fetches an element from a 3D array. You can also use the syntax `array.[index1,index2,index3]`.|
|[init](array3d.init['t]-function.md)|`int -> int -> int -> (int -> int -> int -> 'T) -> 'T [,,]`|Creates an array given the dimensions and a generator function to compute the elements.|
|[iter](array3d.iter['t]-function.md)|`('T -> unit) -> 'T [,,] -> unit`|Applies the given function to each element of the array.|
|[iteri](array3d.iteri['t]-function.md)|`(int -> int -> int -> 'T -> unit) -> 'T [,,] -> unit`|Applies the given function to each element of the array. The integer indices passed to the function indicate the index of element.|
|[length1](array3d.length1['t]-function.md)|`'T [,,] -> int`|Returns the length of an array in the first dimension|
|[length2](array3d.length2['t]-function.md)|`'T [,,] -> int`|Returns the length of an array in the second dimension.|
|[length3](array3d.length3['t]-function.md)|`'T [,,] -> int`|Returns the length of an array in the third dimension.|
|[map](array3d.map['t,'u]-function.md)|`('T -> 'U) -> 'T [,,] -> 'U [,,]`|Builds a new array whose elements are the results of applying the given function to each of the elements of the array.|
|[mapi](array3d.mapi['t,'u]-function.md)|`(int -> int -> int -> 'T -> 'U) -> 'T [,,] -> 'U [,,]`|Builds a new array whose elements are the results of applying the given function to each of the elements of the array. The integer indices passed to the function indicate the element being transformed.|
|[set](array3d.set['t]-function.md)|`'T [,,] -> int -> int -> int -> 'T -> unit`|Sets the value of an element in an array. You can also use the syntax `array.[index1,index2,index3] <- value`.|
|[zeroCreate](array3d.zerocreate['t]-function.md)|`int -> int -> int -> 'T [,,]`|Creates an array where the entries are initially the default value.|

## See Also
[Microsoft.FSharp.Collections Namespace](../Microsoft.FSharp.Collections-Namespace.md)
