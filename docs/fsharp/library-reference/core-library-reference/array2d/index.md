---
title: Collections.Array2D Module (F#)
description: Collections.Array2D Module (F#)
ms.date: 1/3/2020
---

# Collections.Array2D Module (F#)

Basic operations on 2-dimensional arrays.

## Syntax

```fsharp
module Array2D
```

## Remarks
F# and .NET multi-dimensional arrays are typically zero-based. However, .NET multi-dimensional arrays used in conjunction with external libraries (for examples, libraries associated with Visual Basic) be non-zero based, using a potentially different base for each dimension. The operations in this module will accept such arrays, and the basing on an input array will be propagated to a matching output array on the [`Array2D.map`](array2d.map['t,'u]-function.md) and [Array2D.mapi](array2d.mapi['t,'u]-function.md) operations. Non-zero-based arrays can also be created using [`Array2D.zeroCreateBased`](array2d.zerocreatebased['t]-function.md), [`Array2D.createBased`](array2d.createbased['t]-function.md) and [Array2D.initBased](array2d.initbased['t]-function.md).

## Values

|Value|Signature|Description|
|-----|---------|-----------|
|[base1](array2d.base1['t]-function.md)|`'T [,] -> int`|Fetches the base-index for the first dimension of the array.|
|[base2](array2d.base2['t]-function.md)|`'T [,] -> int`|Fetches the base-index for the second dimension of the array.|
|[blit](array2d.blit['t]-function.md)|`'T [,] -> int -> int -> 'T[,] -> int -> int -> int -> int -> unit`|Reads a range of elements from the first array and writes them into the second.|
|[copy](array2d.copy['t]-function.md)|`'T [,] -> 'T [,]`|Creates a new array whose elements are the same as the input array.|
|[create](array2d.create['t]-function.md)|`int -> int -> 'T -> 'T [,]`|Creates an array whose elements are all initially the given value.|
|[createBased](array2d.createbased['t]-function.md)|`int -> int -> int -> int -> 'T -> 'T [,]`|Creates a based array whose elements are all initially the given value.|
|[get](array2d.get['t]-function.md)|`'T [,] -> int -> int -> 'T`|Fetches an element from a 2D array. You can also use the syntax `array.[index1,index2]`.|
|[init](array2d.init['t]-function.md)|`int -> int -> (int -> int -> 'T) -> 'T [,]`|Creates an array given the dimensions and a generator function to compute the elements.|
|[initBased](array2d.initbased['t]-function.md)|`int -> int -> int -> int -> (int -> int -> 'T) -> 'T [,]`|Creates a based array given the dimensions and a generator function to compute the elements.|
|[iter](array2d.iter['t]-function.md)|`('T -> unit) -> 'T [,] -> unit`|Applies the given function to each element of the array.|
|[iteri](array2d.iteri['t]-function.md)|`int -> int -> 'T -> unit`|Applies the given function to each element of the array. The integer indices passed to the function indicate the index of element.|
|[length1](array2d.length1['t]-function.md)|`'T [,] -> int`|Returns the length of an array in the first dimension.|
|[length2](array2d.length2['t]-function.md)|`'T [,] -> int`|Returns the length of an array in the second dimension.|
|[map](array2d.map['t,'u]-function.md)|`('T -> 'U) -> 'T [,] -> 'U [,]`|Creates a new array whose elements are the results of applying the given function to each of the elements of the array.|
|[mapi](array2d.mapi['t,'u]-function.md)|`(int -> int -> 'T -> 'U) -> 'T [,] -> 'U [,]`|Creates a new array whose elements are the results of applying the given function to each of the elements of the array. The integer indices passed to the function indicate the element being transformed.|
|[rebase](array2d.rebase['t]-function.md)|`'T [,] -> 'T [,]`|Creates a new array whose elements are the same as the input array but where a non-zero-based input array generates a corresponding zero-based output array.|
|[set](array2d.set['t]-function.md)|`'T [,] -> int -> int -> 'T -> unit`|Sets the value of an element in an array. You can also use the syntax `array.[index1,index2] <- value`.|
|[zeroCreate](array2d.zerocreate['t]-function.md)|`int -> int -> 'T [,]`|Creates an array where the entries are initially [Unchecked.defaultof<'T>](https://msdn.microsoft.com/library/9ff97f2a-1bd4-4f4c-afbe-5886a74ab977).|
|[zeroCreateBased](array2d.zerocreatebased['t]-function.md)|`int -> int -> int -> int -> 'T [,]`|Creates a based array where the entries are initially [Unchecked.defaultof<'T>](https://msdn.microsoft.com/library/9ff97f2a-1bd4-4f4c-afbe-5886a74ab977).|

## See Also
[Microsoft.FSharp.Collections Namespace](../Microsoft.FSharp.Collections-Namespace.md)
