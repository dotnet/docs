---
title: Seq.pick<'T,'U> Function (F#)
description: Seq.pick<'T,'U> Function (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 586d94a7-0efc-4617-b83f-9b3d496de03e
---

# Seq.pick<'T,'U> Function (F#)

Applies the given function to successive elements, returning the first value where the function returns a `Some` value.

**Namespace/Module Path:** Microsoft.FSharp.Collections.Seq

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
Seq.pick : ('T -> 'U option) -> seq<'T> -> 'U

// Usage:
Seq.pick chooser source
```

#### Parameters
*chooser*
Type: **'T -&gt; 'U**[option](https://msdn.microsoft.com/library/b08add48-34bf-4410-80a1-ef6a8daddc58)


A function to transform each item of the input sequence into an option of the output type.


*source*
Type: [seq](https://msdn.microsoft.com/library/2f0c87c6-8a0d-4d33-92a6-10d1d037ce75)**&lt;'T&gt;**


The input sequence.

## Exceptions

|Exception|Condition|
|----|----|
|[ArgumentNullException](https://msdn.microsoft.com/library/system.argumentnullexception.aspx)|Thrown when the input sequence is null.|
|[KeyNotFoundException](https://msdn.microsoft.com/library/system.collections.generic.keynotfoundexception.aspx)|Thrown when every item of the sequence evaluates to None when the given function is applied.|

## Return Value

The result sequence.

## Remarks
This function is named `Pick` in compiled assemblies. If you are accessing the function from a .NET language other than F#, or through reflection, use this name.


## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2


## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[Collections.Seq Module &#40;F&#35;&#41;](Collections.Seq-Module-%5BFSharp%5D.md)

[Microsoft.FSharp.Collections Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Collections-Namespace-%5BFSharp%5D.md)
