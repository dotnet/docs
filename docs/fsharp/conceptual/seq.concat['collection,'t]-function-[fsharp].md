---
title: Seq.concat<'Collection,'T> Function (F#)
description: Seq.concat<'Collection,'T> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: d73faed0-aa17-4b89-989c-6b427b28fd69
---

# Seq.concat<'Collection,'T> Function (F#)

Combines the given enumeration-of-enumerations as a single concatenated enumeration.

**Namespace/Module Path**: Microsoft.FSharp.Collections.Seq

**Assembly**: FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Seq.concat : seq<'Collection> -> seq<'T> (requires 'Collection :> seq<'T>)

// Usage:
Seq.concat sources
```

#### Parameters
*sources*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'Collection&gt;**


The input enumeration-of-enumerations.

## Exceptions
|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input sequence is null|

## Return Value

The result sequence.

## Remarks
The returned sequence may be passed between threads safely. However, individual `IEnumerator` values generated from the returned sequence should not be accessed concurrently.

This function is named `Concat` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example
The following code shows how to use Seq.concat.

[!code-fsharp[Main](snippets/fssequences/snippet29.fs)]

**Output**

```
1 2 3 4 5 6 7 8 9 10 1 2 3 4 5 6 7 8 9
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable


## See Also
[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
