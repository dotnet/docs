---
title: Array.choose<'T,'U> Function (F#)
description: Array.choose<'T,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ce0e14f1-4eba-47eb-a9c7-1ca14202b57b 
---

# Array.choose<'T,'U> Function (F#)

Applies the given function to each element of the array. Returns the array comprised of the results `x` for each element where the function returns `Some(x)`.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.choose : ('T -> 'U option) -> 'T [] -> 'U []

// Usage:
Array.choose chooser array
```

#### Parameters
*chooser*
Type: **'T -&gt; 'U**[option](https://msdn.microsoft.com/library/b08add48-34bf-4410-80a1-ef6a8daddc58)


The function to generate options from the elements.


*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The input array.

## Return Value

The array of results.

## Remarks
This function is named `Choose` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example
The following code demonstrates the use of Array.choose to perform an operation only on the even numbers in an array.

[!code-fsharp[Main](snippets/fsarrays/snippet14.fs)]

```
[|3.0; 15.0; 35.0; 63.0; 99.0|]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)