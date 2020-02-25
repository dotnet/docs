---
title: List.collect<'T,'U> Function (F#)
description: List.collect<'T,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 23d6d13c-08d4-4716-9bd3-c16a84cb6da0 
---

# List.collect<'T,'U> Function (F#)

For each element of the list, applies the given function. Concatenates all the results and returns the combined list.

**Namespace/Module Path:** Microsoft.FSharp.Collections.List

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
List.collect : ('T -> 'U list) -> 'T list -> 'U list

// Usage:
List.collect mapping list
```

#### Parameters
*mapping*
Type: **'T -&gt; 'U**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The function to transform each input element into a sublist to be concatenated.


*list*
Type: **'T**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The input list.

## Return Value

The concatenation of the resulting sublists.

## Remarks

This function is named `Collect` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fslists/snippet42.fs)]

**Output**

```
[10; 20; 30; 20; 40; 60; 30; 60; 90]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)