---
title: List.distinctBy<'T,'Key> Function (F#)
description: List.distinctBy<'T,'Key> Function (F#)
keywords: visual f#, f#, functional programming
author: erikschierboom
manager: danielfe
ms.date: 03/13/2017
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 14ed9913-9b68-4204-985b-8baff1d4f6c2
---

# List.distinctBy<'T,'Key> Function (F#)

Returns a list that contains no duplicate entries according to the generic hash and equality comparisons on the keys returned by the given key-generating function. If an element occurs multiple times in the list then the later occurrences are discarded.

**Namespace/Module Path**: Microsoft.FSharp.Collections.List

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
List.distinctBy : ('T -> 'Key) -> 'T list -> 'T list (requires equality)

// Usage:
List.distinctBy projection list
```

#### Parameters
*projection*
Type: **'T -&gt; 'Key**


A function that transforms the list items into comparable keys.


*list*
Type: **'T**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The input list.

## Exceptions
|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input list is null|

## Return Value
The result list.

## Remarks
This function is named `DistinctBy` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following example demonstrates the use of `List.distinctBy` to keep only the elements in a list that have a distinct absolute value. The first element with a given result is retained in the new list, so the positive numbers from 1 to 5 are dropped in the list from -5 to +10.

[!code-fsharp[Main](snippets/fslists/snippet71.fs)]

```
Original list:
[-5; -4; -3; -2; -1; 0; 1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
List with distinct absolute values:
[-5; -4; -3; -2; -1; 0; 6; 7; 8; 9; 10]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable


## See Also
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
