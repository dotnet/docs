---
title: Array.unzip3<'T1,'T2,'T3> Function (F#)
description: Array.unzip3<'T1,'T2,'T3> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ef4a642e-f706-494f-9a47-a2af53232d50 
---

# Array.unzip3<'T1,'T2,'T3> Function (F#)

Splits an array of triples into three arrays.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.unzip3 : ('T1 * 'T2 * 'T3) [] -> 'T1 [] * 'T2 [] * 'T3 []

// Usage:
Array.unzip3 array
```

#### Parameters
*array*
Type: **('T1 &#42; 'T2 &#42; 'T3)**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The input array.

## Return Value

The tuple of three arrays.

## Remarks
This function is named `Unzip3` in compiled assemblies. If accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code shows how to use `Array.unzip3`.

[!code-fsharp[Main](snippets/fsarrays/snippet71.fs)]

**Output**

```
[|1; 3|]
[|2; 4|]
[|3; 5|]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)