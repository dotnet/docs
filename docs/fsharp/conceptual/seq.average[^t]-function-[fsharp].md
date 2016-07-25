---
title: Seq.average<^T> Function (F#)
description: Seq.average<^T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 5dcbee34-171d-4f49-b34c-4ac3edaa2716
---

# Seq.average<^T> Function (F#)

Returns the average of the elements in the sequence.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Seq

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Seq.average : seq<^T> -> ^T (requires ^T with static member (+) and ^T with static member DivideByInt and ^T with static member Zero)

// Usage:
Seq.average source
```

#### Parameters
*source*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;^T&gt;**


The input sequence.

## Exceptions
|Exception|Condition|
|----|----|
|[ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx)|Thrown when the input sequence has zero elements.|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input sequence is null|

## Return Value

The average.

## Remarks
The elements are averaged using the `+` operator, `DivideByInt` method and `Zero` property associated with the element type.

This function cannot be used directly on a sequence of integers since it requires that the type support an exact division operation, which is indicated by the constraint that the element type must support [DivideByInt](https://msdn.microsoft.com/library/24b70b03-c9fb-4edf-b04e-c9d8355fe1ca).

This function is named `Average` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code example shows how to use Seq.average, and also compares `Seq.average` with [`Seq.averageBy`](https://msdn.microsoft.com/library/47c855c1-2dbd-415a-885e-b909d9d3e4f8).

[!code-fsharp[Main](snippets/fssequences/snippet26.fs)]

**Output**
```
Average: 5.500000
Average: 5.500000
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable




## See Also
[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
