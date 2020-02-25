---
title: Seq.zip3<'T1,'T2,'T3> Function (F#)
description: Seq.zip3<'T1,'T2,'T3> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 8d77fb9f-cc41-4bc3-9112-e1cb6cf787cd 
---

# Seq.zip3<'T1,'T2,'T3> Function (F#)

Combines the three sequences into a list of triples. The sequences need not have equal lengths: when one sequence is exhausted any remaining elements in the other sequences are ignored.

**Namespace/Module Path**: Microsoft.FSharp.Collections.Seq

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Seq.zip3 : seq<'T1> -> seq<'T2> -> seq<'T3> -> seq<'T1 * 'T2 * 'T3>

// Usage:
Seq.zip3 source1 source2 source3
```

#### Parameters
*source1*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T1&gt;**


The first input sequence.


*source2*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T2&gt;**


The second input sequence.


*source3*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T3&gt;**


The third input sequence.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when either of the input sequences is null.|

## Return Value

The result sequence.

## Remarks
This function is named `Zip3` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)