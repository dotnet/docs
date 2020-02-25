---
title: Array.average<^T> Function (F#)
description: Array.average<^T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: bf220f95-eb46-4985-bf94-d9ef15269aef 
---

# Array.average<^T> Function (F#)

Returns the average of the elements in the array.

**Namespace/Module Path**: Microsoft.FSharp.Collections.Array

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.average : ^T [] -> ^T (requires ^T with static member (+) and ^T with static member DivideByInt and ^T with static member Zero)

// Usage:
Array.average array
```

#### Parameters
*array*
Type: **^T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The input array.

## Exceptions
|Exception|Condition|
|---------|---------|
|[ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx)|Thrown when array is empty.|

## Return Value
The average of the elements in the array.

## Remarks
This function cannot be used directly on an array of integers since it requires that the type support an exact division operation, which is indicated by the constraint that the element type must support [DivideByInt](https://msdn.microsoft.com/library/24b70b03-c9fb-4edf-b04e-c9d8355fe1ca) Floating point types support `DivideByInt`. To compute the average of an array of integers, see the example in [Array.averageBy](https://msdn.microsoft.com/library/e9d64609-06a3-48f0-bc07-226ab0f85c54).

This function is named `Average` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code shows how to use Array.average.

[!code-fsharp[Main](snippets/fsarrays/snippet43.fs)]

**Output**

```
Average: 5.500000
Average: 5.500000
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)