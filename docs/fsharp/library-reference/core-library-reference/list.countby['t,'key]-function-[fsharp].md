---
title: List.countBy<'T,'Key> Function (F#)
description: List.countBy<'T,'Key> Function (F#)
keywords: visual f#, f#, functional programming
author: liboz
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: a0b6e7e0-c30a-4e5a-a9dd-f7f9c4761870
---

# List.countBy<'T,'Key> Function (F#)

Applies a key-generating function to each element of a list and returns a list yielding unique keys and their number of occurrences in the original list.

**Namespace/Module Path:** Microsoft.FSharp.Collections.List

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
List.countBy : ('T -> 'Key) -> 'T list -> ('Key * int) list ('Key requires equality)

// Usage:
List.countBy projection source
```

#### Parameters
*projection*
Type: **'T -&gt; 'Key**

A function transforming each item of input list into a key to be compared against the others.

*source*
Type: **'T**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)

The input list.

## Exceptions
|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input list is null|

## Return Value

A list of unique keys and their number of occurrences in the original list.

## Remarks
Note that this function returns a list that traverses the whole initial list. As a result this function should not be used with large lists. The function makes no assumption on the ordering of the original list.

This function is named `CountBy` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following example demonstrates the use of List.countBy to determine the number of elements in a list that are odd or even.

[!code-fsharp[Main](snippets/fslists/snippet115.fs)]

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
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)