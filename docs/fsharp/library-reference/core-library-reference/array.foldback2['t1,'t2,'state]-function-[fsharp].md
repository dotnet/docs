---
title: Array.foldBack2<'T1,'T2,'State> Function (F#)
description: Array.foldBack2<'T1,'T2,'State> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 2c75b6cb-89fa-4184-85cc-18236a885e6f 
---

# Array.foldBack2<'T1,'T2,'State> Function (F#)

Apply a function to pairs of elements drawn from the two collections, right-to-left, threading an accumulator argument through the computation. The two input arrays must have the same lengths, otherwise an [ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx) is raised.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
Array.foldBack2 : ('T1 -> 'T2 -> 'State -> 'State) -> 'T1 [] -> 'T2 [] -> 'State -> 'State

// Usage:
Array.foldBack2 folder array1 array2 state
```

#### Parameters
*folder*
Type: **'T1 -&gt; 'T2 -&gt; 'State -&gt; 'State**

The function to update the state given the input elements.

*array1*
Type: **'T1**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The first input array.

*array2*
Type: **'T2**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The second input array.

*state*
Type: **'State**

The initial state.

## Return Value

The final state.

## Remarks
This function is named `FoldBack2` in the .NET assembly. If accessing the member from a .NET language other than F#, or through reflection, use this name.

## Example

The following code shows how to use Array.foldBack2.

[!code-fsharp[Main](snippets/fsarrays/snippet47.fs)]

**Output**

```
Ending balance: $1205.00
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)