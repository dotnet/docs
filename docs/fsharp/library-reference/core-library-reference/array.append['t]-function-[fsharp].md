---
title: Array.append<'T> Function (F#)
description: Array.append<'T> Function (F#)
ms.date: 02/24/2020
---

# Array.append<'T> Function (F#)

Creates an array that contains the elements of one array followed by the elements of another array.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

## Syntax

```fsharp
// Signature:
Array.append : 'T [] -> 'T [] -> 'T []

// Usage:
Array.append array1 array2
```

#### Parameters
*array1*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The first input array.

*array2*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The second input array.

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
[Collections.Array Module](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)