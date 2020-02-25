---
title: Seq.minBy<'T,'U> Function (F#)
description: Seq.minBy<'T,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: ca5917dd-1ce5-43aa-b9c4-20367b39027c
---

# Seq.minBy<'T,'U> Function (F#)

Returns the lowest of all elements of the sequence, compared by using [Operators.min](https://msdn.microsoft.com/library/adea4fd7-bfad-4834-989c-7878aca81fed) on the function result.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Seq

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Seq.minBy : ('T -> 'U) -> seq<'T> -> 'T (requires comparison)

// Usage:
Seq.minBy projection source
```

#### Parameters
*projection*
Type: **'T -&gt; 'U**


A function to transform items from the input sequence into comparable keys.


*source*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T&gt;**


The input sequence.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx)|Thrown when the input sequence is empty.|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input sequence is null.|

## Return Value

The result sequence.

## Remarks

This function is named `MinBy` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable




## See Also
[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
