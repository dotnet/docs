---
title: Seq.sum<^T> Function (F#)
description: Seq.sum<^T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: e4097808-1f76-4ec3-9484-02e4166b3f96
---

# Seq.sum<^T> Function (F#)

Returns the sum of the elements in the sequence.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Seq

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Seq.sum : seq<^T> -> ^T (requires ^T with static member (+) and ^T with static member Zero)

// Usage:
Seq.sum source
```

#### Parameters
*source*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;^T&gt;**

The input sequence.


## Return Value
The sum of all elements of the sequence.


## Exceptions
May throw an [OverflowException](https://msdn.microsoft.com/library/system.overflowexception.aspx) due to arithmetic overflows.


## Remarks
The elements are summed using the [checked + operator](https://msdn.microsoft.com/visualfsharpdocs/conceptual/checked.[-p-][%5Et1%2c%5Et2%2c%5Et3]-function-[fsharp]) and `Zero` property associated with the summed type.

This function is named `Sum` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
