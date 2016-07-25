---
title: Seq.contains<'T> Function (F#)
description: Seq.contains<'T> Function (F#)
keywords: visual f#, f#, functional programming
author: liboz
manager: danielfe
ms.date: 07/06/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: d17b835a-d48f-49a7-a2df-da02ba1c48b4
---

# Seq.contains<'T> Function (F#)

Evaluates to `true` if the given element is in the input sequence.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Seq

**Assembly:** FSharp.Core (in FSharp.Core.dll)

## Syntax

```fsharp
// Signature:
Seq.contains : 'T -> seq<'T> -> bool

// Usage:
Seq.contains element source
```

#### Parameters
*element*
Type: **'T**

The element to find.

*source*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T&gt;**

The input sequence.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input sequence is null.|

## Return Value

Evaluates to `true` if the given element is in the input sequence. Otherwise, it will return `false`.

## Remarks
This function is named `Contains` in compiled assemblies. If you are accessing the function from a language other than F#, or through reflection, use this name.

## Example

The following code shows how to use Seq.contains.

[!code-fsharp[Main](snippets/fssequences/snippet205.fs)]

**Output**

```
true
false
```

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 4.0, Portable

## See Also

[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
