---
title: Array.foldBack<'T,'State> Function (F#)
description: Array.foldBack<'T,'State> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 67f07981-c84a-4ca1-b2aa-04367472e5c9 
---

# Array.foldBack<'T,'State> Function (F#)

Applies a function to each element of the array, threading an accumulator argument through the computation. If the input function is **f** and the elements are **i0...iN** then computes **f i0 (...(f iN s))**.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.foldBack : ('T -> 'State -> 'State) -> 'T [] -> 'State -> 'State

// Usage:
Array.foldBack folder array state
```

#### Parameters
*folder*
Type: **'T -&gt; 'State -&gt; 'State**


The function to update the state given the input elements.


*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The input array.


*state*
Type: **'State**


The initial state.

## Return Value

The final state.

## Remarks
This function is named `FoldBack` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.

## Example

The following code example shows the difference between [Array.fold](https://msdn.microsoft.com/library/5ed9dd3b-3694-4567-94d0-fd9a24474e09) and Array.foldBack.

```fsharp
// This computes 3 - 2 - 1, which evalates to -6.
let subtractArray array1 = Array.fold (fun acc elem -> acc - elem) 0 array1
printfn "%d" (subtractArray [| 1; 2; 3 |])

// This computes 3 - (2 - (0 - 1)), which evaluates to 2.
let subtractArrayBack array1 = Array.foldBack (fun elem acc -> elem - acc) array1 0
printfn "%d" (subtractArrayBack [| 1; 2; 3 |])
```

**Output**

```
-6
2
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable




## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)

