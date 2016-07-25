---
title: List.scan<'T,'State> Function (F#)
description: List.scan<'T,'State> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: eba787c7-bf1d-438b-95d5-1de00a1f6531 
---

# List.scan<'T,'State> Function (F#)

Applies a function to each element of the collection, threading an accumulator argument through the computation. This function takes the second argument, and applies the function to it and the first element of the list. Then, it passes this result into the function along with the second element, and so on. Finally, it returns the list of intermediate results and the final result.

**Namespace/Module Path:** Microsoft.FSharp.Collections.List

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
List.scan : ('State -> 'T -> 'State) -> 'State -> 'T list -> 'State list

// Usage:
List.scan folder state list
```

#### Parameters
*folder*
Type: **'State -&gt; 'T -&gt; 'State**


The function to update the state given the input elements.


*state*
Type: **'State**


The initial state.


*list*
Type: **'T**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The input list.

## Return Value

The list of states.

## Remarks
This function is named `Scan` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.

## Example

[!code-fsharp[Main](snippets/fslists/snippet54.fs)]

**Output**

```
Initial balance:
$   1122.73
Transaction   Balance
$   -100.00 $   1122.73
$    450.34 $   1022.73
$    -62.34 $   1473.07
$   -127.00 $   1410.73
$    -13.50 $   1283.73
$    -12.92 $   1270.23
Final balance:
$   1257.31
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)