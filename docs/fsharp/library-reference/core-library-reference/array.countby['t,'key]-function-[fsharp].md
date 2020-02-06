---
title: Array.countBy<'T,'Key> Function (F#)
description: Array.countBy<'T,'Key> Function (F#)
keywords: visual f#, f#, functional programming
author: liboz
manager: danielfe
ms.date: 07/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 4c453049-7502-49c8-8cbb-f1f739d43a2a
---

# Array.countBy<'T,'Key> Function (F#)

Applies a key-generating function to each element of an array and returns an array yielding unique keys and their number of occurrences in the original array.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
Array.countBy : ('T -> 'Key) -> 'T [] -> ('Key * int) [] ('Key requires equality)

// Usage:
Array.countBy projection source
```

#### Parameters
*projection*
Type: **'T -&gt; 'Key**

A function transforming each item of input array into a key to be compared against the others.

*source*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The input array.

## Exceptions
|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input array is null|

## Return Value

An array of unique keys and their number of occurrences in the original array.

## Remarks
Note that this function returns an array that traverses the whole initial array. As a result this function should not be used with large arrays. The function makes no assumption on the ordering of the original array.

This function is named `CountBy` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following example demonstrates the use of Array.countBy to determine the number of elements in an array that are odd or even.

[!code-fsharp[Main](snippets/fsarrays/snippet115.fs)]

**Output**
```
(1, 50) (0, 50)
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)