---
title: Seq.append<'T> Function (F#)
description: Seq.append<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 7ce3254b-d069-4362-a34d-dbf5330e1cc4
---

# Seq.append<'T> Function (F#)

Wraps the two given enumerations as a single concatenated enumeration.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Seq

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Seq.append : seq<'T> -> seq<'T> -> seq<'T>

// Usage:
Seq.append source1 source2
```

#### Parameters
*source1*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T&gt;**


The first sequence.


*source2*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T&gt;**


The second sequence.

## Exceptions
|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input sequence is null|

## Return Value
The result sequence.

## Remarks
The returned sequence may be passed between threads safely. However, individual `System.Collections.Generic.IEnumerator<T>` values generated from the returned sequence should not be accessed concurrently.

This function is named `Append` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following example hows how to use `Seq.append`.

[!code-fsharp[Main](snippets/fssequences/snippet25.fs)]

**Output**

```
seq [1; 2; 3; 4; ...]
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
