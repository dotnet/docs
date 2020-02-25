---
title: GeneratedSequenceBase.GenerateNext<'T> Method (F#)
description: GeneratedSequenceBase.GenerateNext<'T> Method (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 4873e0b7-36b3-41d6-9690-f964498f94d6 
---

# GeneratedSequenceBase.GenerateNext<'T> Method (F#)

The F# compiler emits implementations of this type for compiled sequence expressions.

**Namespace/Module Path:** Microsoft.FSharp.Core.CompilerServices

**Assembly:** FSharp.Core (in FSharp.Core.dll)


## Syntax

```fsharp
// Signature:
abstract this.GenerateNext : byref<IEnumerable<'T>> -> int

// Usage:
generatedSequenceBase.GenerateNext (result)
```

#### Parameters
*result*
Type: [byref](https://msdn.microsoft.com/library/ab37321f-5515-4c29-8296-48b57eae15f7)**&lt;****System.Collections.Generic.IEnumerable&#96;1****&lt;'T&gt;&gt;**


A reference to the sequence.

## Return Value

A 0, 1, and 2 respectively indicate `Stop`, `Yield`, and `Goto` conditions for the sequence generator.

## Platforms
Windows 8, Windows 7, Windows Server 2012, Windows Server 2008 R2

## Version Information
**F# Core Library Versions**

Supported in: 2.0, 4.0, Portable

## See Also
[CompilerServices.GeneratedSequenceBase&#60;'T&#62; Class &#40;F&#35;&#41;](CompilerServices.GeneratedSequenceBase%5B%27T%5D-Class-%5BFSharp%5D.md)

[Microsoft.FSharp.Core.CompilerServices Namespace &#40;F&#35;&#41;](Microsoft.FSharp.Core.CompilerServices-Namespace-%5BFSharp%5D.md)