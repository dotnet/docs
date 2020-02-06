---
title: List.append<'T> Function (F#)
description: List.append<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: b2048919-e738-456d-b39a-1d80b27c0296 
---

# List.append<'T> Function (F#)

Returns a new list that contains the elements of the first list followed by elements of the second.

**Namespace/Module Path**: Microsoft.FSharp.Collections.List

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
List.append : 'T list -> 'T list -> 'T list

// Usage:
List.append list1 list2
```

#### Parameters
*list1*
Type: **'T**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The first input list.


*list2*
Type: **'T**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)


The second input list.

## Return Value

The resulting list.

## Remarks
This function is named `Append` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code example illustrates the use of `List.append` to join two lists together. Use [`List.concat`](https://msdn.microsoft.com/library/c5afd433-8764-4ea8-a6a8-937fb4d77c4c) to join more than two lists.

[!code-fsharp[Main](snippets/fslists/snippet26.fs)]

**Output**

```
1 2 3 4 5 6 7 8 9 10
1 2 3 4 5 6 7 8 9
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)