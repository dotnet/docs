---
title: List.truncate<'T> Function (F#)
description: List.truncate<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: erikschierboom
manager: danielfe
ms.date: 03/14/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 0484c860-1eee-417c-ace6-c58a2d47ad59
---

# List.truncate<'T> Function (F#)

Returns a list that with at most N elements.

**Namespace/Module Path:** Microsoft.FSharp.Collections.List

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
List.truncate : int -> 'T list -> 'T list

// Usage:
List.truncate count list
```

#### Parameters
*count*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)


The maximum number of items to return.


*list*
Type: **'T**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The input list.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input list is null.|

## Return Value

The result list.

## Remarks
This function is named `Truncate` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following example demonstrates the use of `List.truncate` and contrasts the behavior with `List.take`.

[!code-fsharp[Main](snippets/fslists/snippet72.fs)]

```
[1; 4; 9; 16; 25]
[1; 4; 9; 16; 25; 36; 49; 64; 81; 100]
[1; 4; 9; 16; 25]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable




## See Also
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
