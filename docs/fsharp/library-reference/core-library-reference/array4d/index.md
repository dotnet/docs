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
|[create](https://msdn.microsoft.com/library/c146b4b0-2e63-4d00-8451-5d72833ccfdc)|`int -> int -> int -> int -> 'T -> 'T [,,,]`|Creates an array whose elements are all initially the given value|
|[get](https://msdn.microsoft.com/library/d268205c-d77b-4816-8360-57be8e770005)|`'T [,,,] -> int -> int -> int -> int -> 'T`|Fetches an element from a 4D array.|
|[init](https://msdn.microsoft.com/library/41e8bf42-5a11-4884-8890-a1b194f5f80e)|`int -> int -> int -> int -> (int -> int -> int -> int -> 'T) -> 'T [,,,]`|Creates an array given the dimensions and a generator function to compute the elements.|
|[length1](https://msdn.microsoft.com/library/a864b7e6-7da5-45bf-9b54-ef0f772488f1)|`'T [,,,] -> int`|Returns the length of an array in the first dimension|
|[length2](https://msdn.microsoft.com/library/2da2dd52-1348-4c70-b64c-299a3d43cda1)|`'T [,,,] -> int`|Returns the length of an array in the second dimension.|
|[length3](https://msdn.microsoft.com/library/199a6b83-85df-4ed6-9ef9-faa0b4e2ae6d)|`'T [,,,] -> int`|Returns the length of an array in the third dimension.|
|[length4](https://msdn.microsoft.com/library/f8e138c3-0a87-4b63-86ab-9d286c6b6cff)|`'T [,,,] -> int`|Returns the length of an array in the fourth dimension.|
|[set](https://msdn.microsoft.com/library/2b72ed80-310c-4b75-9fa4-6cbb13aa7ff4)|`'T [,,,] -> int -> int -> int -> int -> 'T -> unit`|Sets the value of an element in an array.|
|[zeroCreate](https://msdn.microsoft.com/library/1391be77-5364-4397-a710-c1298e6397bc)|`int -> int -> int -> int -> 'T [,,,]`|Creates an array where the entries are initially the default value.|

## See Also
[Microsoft.FSharp.Collections Namespace](Microsoft.FSharp.Collections-Namespace.md)

