---
title: Seq.chunkBySize<'T> Function (F#)
description: Seq.chunkBySize<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: erikschierboom
manager: danielfe
ms.date: 03/12/2017
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: b7b11b7c-749f-4ff8-9edf-85e0fe795942
---

# Seq.chunkBySize<'T> Function (F#)

Divides the input sequence into chunks of size at most `chunkSize`.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Seq

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
Seq.chunkBySize: chunkSize:int -> source:seq<'T> -> seq<seq<'T>>

// Usage:
Seq.chunkBySize chunkSize source
```

#### Parameters

*chunkSize*
Type: [int](https://msdn.microsoft.com/library/025d5455-3622-4ea5-9573-3ecbd4ee1375)

The maximum size of each chunk.

*source*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T&gt;**

The input sequence.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentException](https://msdn.microsoft.com/library/system.argumentexception.aspx)|Thrown when `chunkSize` is not positive.|

## Return Value

The input sequence divided into chunks.

## Remarks

This function is named `ChunkBySize` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code shows how to use Seq.chunkBySize.
[!code-fsharp[Main](snippets/fssequences/snippet66.fs)]

### Output

```
seq [[|1; 2|]; [|3; 4|]; [|5; 6|]; [|7; 8|]; [|9; 10|]]
```

## Platforms

Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information

**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also

[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)