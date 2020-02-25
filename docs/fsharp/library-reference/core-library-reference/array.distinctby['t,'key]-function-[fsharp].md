---
title: Array.distinctBy<'T,'Key> Function (F#)
description: Array.distinctBy<'T,'Key> Function (F#)
keywords: visual f#, f#, functional programming
author: erikschierboom
manager: danielfe
ms.date: 03/13/2017
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: dee6a6eb-e4f9-4b89-bb57-2ce9b7098736
---

# Array.distinctBy<'T,'Key> Function (F#)

Returns an array that contains no duplicate entries according to the generic hash and equality comparisons on the keys returned by the given key-generating function. If an element occurs multiple times in the array then the later occurrences are discarded.

**Namespace/Module Path**: Microsoft.FSharp.Collections.Array

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.distinctBy : ('T -> 'Key) -> 'T [] -> 'T [] (requires equality)

// Usage:
Array.distinctBy projection array
```

#### Parameters
*projection*
Type: **'T -&gt; 'Key**


A function that transforms the array items into comparable keys.


*array*
Type: **'T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)


The input array.

## Exceptions
|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input array is null|

## Return Value
The result array.

## Remarks
This function is named `DistinctBy` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following example demonstrates the use of `Array.distinctBy` to keep only the elements in an array that have a distinct absolute value. The first element with a given result is retained in the new array, so the positive numbers from 1 to 5 are dropped in the array from -5 to +10.

[!code-fsharp[Main](snippets/fsarrays/snippet76.fs)]

```
Original array:
[|-5; -4; -3; -2; -1; 0; 1; 2; 3; 4; 5; 6; 7; 8; 9; 10|]
Array with distinct absolute values:
[|-5; -4; -3; -2; -1; 0; 6; 7; 8; 9; 10|]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable


## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
