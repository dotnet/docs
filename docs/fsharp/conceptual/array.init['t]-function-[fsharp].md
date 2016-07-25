---
title: Array.init<'T> Function (F#)
description: Array.init<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 5eb2f51c-a411-4e40-9b67-e8b3834b64ae 
---

# Array.init<'T> Function (F#)

Creates an array given the dimension and a generator function to compute the elements.

**Namespace/Module Path**: Microsoft.FSharp.Collections.Array

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.init : int -> (int -> 'T) -> 'T []

// Usage:
Array.init count initializer
```

#### Parameters
*count*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The number of elements to initialize.


*initializer*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)**-&gt; 'T**


The function to generate the initial values for each index.


## Return Value

The created array.

## Remarks
This function is named `Initialize` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code demonstrates the use of `Array.init`.

[!code-fsharp[Main](snippets/fsarrays/snippet101.fs)]

```
Array of squares: [|0; 1; 4; 9; 16; 25; 36; 49; 64; 81|]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)