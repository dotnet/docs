---
title: Array.create<'T> Function (F#)
description: Array.create<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: e45bcf48-b08c-46e4-afd4-1674c86b822b 
---

# Array.create<'T> Function (F#)

Creates an array whose elements are all initially the given value.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.create : int -> 'T -> 'T []

// Usage:
Array.create count value
```

#### Parameters
*count*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The length of the array to create.


*value*
Type: **'T**


The value for the elements.

## Return Value

The created array.

## Remarks
This function is named `Create` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example
The following code illustrates the use of `Array.create` as well as setting and getting array values.

[!code-fsharp[Main](snippets/fsarrays/snippet9.fs)]

```
0 1 2 3 4 5 6 7 8 9
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)