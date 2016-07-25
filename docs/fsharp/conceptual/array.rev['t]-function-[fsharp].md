---
title: Array.rev<'T> Function (F#)
description: Array.rev<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: f5e309de-6064-4576-9bad-2b05451df1c1 
---

# Array.rev<'T> Function (F#)

Returns a new array with the elements in reverse order.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.rev : 'T [] -> 'T []

// Usage:
Array.rev array
```

#### Parameters
*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The input array.

## Return Value

The reversed array.

## Remarks
This function is named `Reverse` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following example shows how to reverse the elements in an array by using `Array.rev`.

[!code-fsharp[Main](snippets/fsarrays/snippet18.fs)]

```
"Hello world!"
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)