---
title: Array.append<'T> Function (F#)
description: Array.append<'T> Function (F#)
ms.date: 02/24/2020
---

# Array.append<'T>

Creates an array that contains the elements of one array followed by the elements of another array.

**Module:** [Microsoft.FSharp.Collections.Array](collections.array-module.md)

## Syntax

```fsharp
// Signature:
Array.append : 'T [] -> 'T [] -> 'T []

// Usage:
Array.append array1 array2
```

#### Parameters

|Paramter name|Type|Description|
|-------------|----|-----------|
| `array1`|[`'T[]`](../core.['t]-type-1d-[fsharp].md)|The first input array.|
| `array2`|[`'T[]`](../core.['t]-type-1d-[fsharp].md)|The second input array.|

## Return Value

The resulting array.

## Remarks
This function is named `Append` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following example demonstrates the use of `Array.append`.

[!code-fsharp[Main](~/samples/snippets/fsharp/arrays/snippet13.fs)]

```
[|1; 2; 3; 4; 5; 6|]
```

## See Also
[Collections.Array Module](collections.array-module.md)

[Microsoft.FSharp.Collections](../microsoft.fsharp.collections-namespace-[fsharp].md)
