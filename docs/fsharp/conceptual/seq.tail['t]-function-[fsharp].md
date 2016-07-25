---
title: Seq.tail<'T> Function (F#)
description: Seq.tail<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: liboz
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 1111ea81-e81d-4540-a7c0-465c892e8a23
---

# Seq.tail<'T> Function (F#)

Returns a new sequence by taking the input sequence without its first element.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Seq

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Seq.tail : seq<'T> -> seq<'T>

// Usage:
Seq.tail source
```

#### Parameters
*source*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T&gt;**

The input sequence.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx)|Thrown when the input sequence is empty.|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input sequence is null.|

## Return Value

A sequence consisting of the input sequence without its first element. It is the dual of [Seq.head](seq.head%5B't%5D-function-%5Bfsharp%5D.md).

## Remarks
This function is named `Tail` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code shows how to use Seq.tail.

[!code-fsharp[Main](snippets/fssequences/snippet204.fs)]

**Output**

```
seq [2; 3; 4; 5; ...]
Error: The input sequence has an insufficient number of elements.
Parameter name: source
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also
[Seq.head &#40;F&#35;&#41;](seq.head%5B't%5D-function-%5Bfsharp%5D.md)

[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
