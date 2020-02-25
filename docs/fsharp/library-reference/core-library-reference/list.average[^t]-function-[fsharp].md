---
title: List.average<^T> Function (F#)
description: List.average<^T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ab4f4341-5d60-4db1-a839-4c186b047e69 
---

# List.average<^T> Function (F#)

Returns the average of the elements in the list.

**Namespace/Module Path:** Microsoft.FSharp.Collections.List

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
List.average : ^T list -> ^T (requires ^T with static member (+) and ^T with static member DivideByInt and ^T with static member Zero)

// Usage:
List.average list
```

#### Parameters
*list*
Type: **^T**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The input list.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx)|Thrown when the list is empty.|

## Return Value

The resulting average.

## Remarks
This function cannot be used directly on a list of integers since it requires that the type support an exact division operation, which is indicated by the constraint that the element type must support [`DivideByInt`](https://msdn.microsoft.com/library/24b70b03-c9fb-4edf-b04e-c9d8355fe1ca) Floating point types support `DivideByInt`. To compute the average of a list of integers, see the example in [`List.averageBy`](https://msdn.microsoft.com/library/936cc9ec-62af-464d-8726-7999c2f48403).

This function is named `Average` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code example illustrates the use of List.average.

[!code-fsharp[Main](snippets/fslists/snippet111.fs)]

**Output**

```
1.000000
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)