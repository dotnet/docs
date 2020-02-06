---
title: Array.sum<^T> Function (F#)
description: Array.sum<^T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 532a4929-def0-4095-8c62-3bc7312038f2 
---

# Array.sum<^T> Function (F#)

Returns the sum of the elements in the array.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Array

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Array.sum : ^T [] -> ^T (requires ^T with static member (+) and ^T with static member Zero)

// Usage:
Array.sum array
```

#### Parameters
*array*
Type: **^T**[[]](https://msdn.microsoft.com/library/def20292-9aae-4596-9275-b94e594f8493)

The input array.


## Return Value
The sum of all elements of the array.


## Exceptions
May throw an [OverflowException](https://msdn.microsoft.com/library/system.overflowexception.aspx) due to arithmetic overflows.


## Remarks
The elements are summed using the **[checked + operator](https://msdn.microsoft.com/visualfsharpdocs/conceptual/checked.[-p-][%5Et1%2c%5Et2%2c%5Et3]-function-[fsharp])** and **Zero** property associated with the summed type.

This function is named `Sum` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.


## Example

[!code-fsharp[Main](snippets/fsarrays/snippet66.fs)]

**Output**

```
55
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Collections.Array Module &#40;F&#35;&#41;](Collections.Array-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)