---
title: List.minBy<'T,'U> Function (F#)
description: List.minBy<'T,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 47f6d6bc-52e9-4304-9c59-07f22c24e161 
---

# List.minBy<'T,'U> Function (F#)

Returns the lowest of all elements of the list, compared by using [`Operators.min`](https://msdn.microsoft.com/library/adea4fd7-bfad-4834-989c-7878aca81fed) on the function result.

**Namespace/Module Path**: Microsoft.FSharp.Collections.List

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
List.minBy : ('T -> 'U) -> 'T list -> 'T (requires comparison)

// Usage:
List.minBy projection list
```

#### Parameters
*projection*
Type: **'T -&gt; 'U**


The function to transform list elements into the type to be compared.


*list*
Type: **'T**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The input list.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx)|Thrown when the list is empty.|

## Return Value

The minimum value.
## Remarks
This function is named `MinBy` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fslists/snippet58.fs)]

**Output**

```
0.0
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)