---
title: List.sum<^T> Function (F#)
description: List.sum<^T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 040d88da-12a6-4273-8b05-8c26395503e1 
---

# List.sum<^T> Function (F#)

Returns the sum of the elements in the list.

**Namespace/Module Path:** Microsoft.FSharp.Collections.List

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
List.sum : ^T list -> ^T (requires ^T with static member (+) and ^T with static member Zero)

// Usage:
List.sum list
```

#### Parameters
*list*
Type: **^T**[list](https://msdn.microsoft.com/library/c627b668-477b-4409-91ed-06d7f1b3e4a7)

The input list.


## Return Value
The sum of all elements of the list.


## Exceptions
May throw an [`OverflowException`](https://msdn.microsoft.com/library/system.overflowexception.aspx) due to arithmetic overflows.


## Remarks
The elements are summed using the [`checked + operator`](https://msdn.microsoft.com/visualfsharpdocs/conceptual/checked.[-p-][%5Et1%2c%5Et2%2c%5Et3]-function-[fsharp]) and `Zero` property associated with the summed type.

This function is named `Sum` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.


## Example

The following code example illustrates the use of List.sum, [List.sumBy](https://msdn.microsoft.com/library/b7623389-0fe1-4762-9c67-51079903ab7d), and [List.average](https://msdn.microsoft.com/library/2b9a627b-106d-4548-8c4c-ab5058b8f8e1):

[!code-fsharp[Main](snippets/fslists/snippet11.fs)]

**Output**

```
1.000000
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.List Module &#40;F&#35;&#41;](Collections.List-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)